using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS.Pegasus;

namespace PEGASUS.Design
{
	public class Login : Form
	{
		private static readonly string name = "demoapp";

		private static readonly string pegaid = "5eKYVEBy1c";

		private static readonly string pegmystic = "51264ce3dc45c55a17a1658cc07cf5521331ddc84710d2cc40a584e8e7b2b834";

		private static readonly string version = "1.0";

		public static api Darkness = new api(name, pegaid, pegmystic, version);

		public string Info = string.Empty;

		public string Key = string.Empty;

		public string User = string.Empty;

		public string Pass = string.Empty;

		public string Keys = string.Empty;

		private IContainer components;

		private Label label1;

		private Label label2;

		public Guna2GradientButton UpgradeBtn;

		public Guna2GradientButton LicBtn;

		public Guna2GradientButton RgstrBtn;

		public Guna2GradientButton LoginBtn;

		private Guna2TextBox key;

		private Guna2TextBox password;

		private Guna2TextBox username;

		private PictureBox pictureBox1;

		private Guna2Panel guna2Panel1;

		private Guna2PictureBox guna2PictureBox1;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ShadowForm guna2ShadowForm1;

		private Guna2Separator guna2Separator1;

		private Guna2CheckBox chkSave;

		private Guna2PictureBox guna2PictureBox2;

		private Guna2HtmlToolTip guna2HtmlToolTip1;

		private LinkLabel linkLabel1;

		public Guna2GradientButton guna2GradientButton1;

		private Label status;

		private Label label3;

		public Login()
		{
			InitializeComponent();
		}

		private void siticoneControlBox1_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void Login_Load(object sender, EventArgs e)
		{
			password.UseSystemPasswordChar = true;
			Darkness.init();
			if (File.Exists(Application.StartupPath + "\\Configuration\\LoginRememberMe.ini"))
			{
				chkSave.Checked = true;
				using (StreamReader streamReader = new StreamReader(Application.StartupPath + "\\Configuration\\LoginRememberMe.ini"))
				{
					if (!string.IsNullOrWhiteSpace(streamReader.ReadToEnd()))
					{
						string text = File.ReadAllText(Application.StartupPath + "\\Configuration\\LoginRememberMe.ini");
						User = text.Split('|')[0];
						Pass = text.Split('|')[1];
						username.Text = User;
						password.Text = Pass;
						streamReader.Dispose();
					}
				}
				LoginBtn.PerformClick();
			}
			else if (File.Exists(Application.StartupPath + "\\Configuration\\Key.ini"))
			{
				chkSave.Checked = true;
				using (StreamReader streamReader2 = new StreamReader(Application.StartupPath + "\\Configuration\\Key.ini"))
				{
					if (!string.IsNullOrWhiteSpace(streamReader2.ReadToEnd()))
					{
						string text2 = File.ReadAllText(Application.StartupPath + "\\Configuration\\Key.ini");
						User = text2.Split('|')[0];
						Keys = text2.Split('|')[1];
						key.Text = Keys;
						streamReader2.Dispose();
					}
				}
				LicBtn.PerformClick();
			}
			if (Darkness.checkblack())
			{
				Environment.Exit(0);
			}
		}

		private void UpgradeBtn_Click(object sender, EventArgs e)
		{
			Darkness.upgrade(username.Text, key.Text);
		}

		private void LoginBtn_Click(object sender, EventArgs e)
		{
			Darkness.login(username.Text, password.Text);
			if (Darkness.response.success)
			{
				if (chkSave.Checked)
				{
					if (!File.Exists(Application.StartupPath + "\\Configuration"))
					{
						Directory.CreateDirectory(Application.StartupPath + "\\Configuration");
						string contents = username.Text + "|" + password.Text;
						File.WriteAllText(Application.StartupPath + "\\Configuration\\LoginRememberMe.ini", contents);
					}
					for (int i = 0; i < Darkness.user_data.subscriptions.Count; i++)
					{
						Program.form1.label11.Text = UnixTimeToDateTime(long.Parse(Darkness.user_data.subscriptions[i].expiry)).ToString() ?? "";
					}
					Program.form1.label5.Text = Darkness.user_data.username;
					status.Text = "Login successful!";
				}
				Hide();
			}
			else
			{
				status.Text = "Status: " + Darkness.response.message;
			}
		}

		private void RgstrBtn_Click(object sender, EventArgs e)
		{
			Darkness.register(username.Text, password.Text, key.Text);
			if (Darkness.response.success)
			{
				status.Text = "register successful!";
				Hide();
			}
			else
			{
				status.Text = "Status: " + Darkness.response.message;
			}
		}

		public DateTime UnixTimeToDateTime(long unixtime)
		{
			return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local).AddSeconds(unixtime).ToLocalTime();
		}

		private void LicBtn_Click(object sender, EventArgs e)
		{
			Darkness.license(key.Text);
			if (Darkness.response.success)
			{
				if (chkSave.Checked)
				{
					if (!File.Exists(Application.StartupPath + "\\Configuration"))
					{
						Directory.CreateDirectory(Application.StartupPath + "\\Configuration");
						string contents = "Key|" + key.Text;
						File.WriteAllText(Application.StartupPath + "\\Configuration\\Key.ini", contents);
					}
					for (int i = 0; i < Darkness.user_data.subscriptions.Count; i++)
					{
						Program.form1.label11.Text = UnixTimeToDateTime(long.Parse(Darkness.user_data.subscriptions[i].expiry)).ToString() ?? "";
					}
					Program.form1.label5.Text = Darkness.user_data.username;
					status.Text = "Login successful!";
				}
				Hide();
			}
			else
			{
				status.Text = "Status: " + Darkness.response.message;
			}
		}

		private void guna2PictureBox1_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
		{
			ReleaseCapture();
			SendMessage(base.Handle, 274, 61458, 0);
		}

		[DllImport("user32.DLL")]
		private static extern void ReleaseCapture();

		[DllImport("user32.DLL")]
		private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(reupload("b~~zy0%%aosk\u007f~b$ieg%zkdof%ZOMKUY_Y%ZOMKY_YL_FF"));
		}

		private static string reupload(string str)
		{
			char c = '\n';
			StringBuilder stringBuilder = new StringBuilder();
			char[] array = str.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				char value = (char)(array[i] ^ c);
				stringBuilder.Append(value);
			}
			return stringBuilder.ToString();
		}

		private void Login_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void Login_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			username = new Guna.UI2.WinForms.Guna2TextBox();
			password = new Guna.UI2.WinForms.Guna2TextBox();
			key = new Guna.UI2.WinForms.Guna2TextBox();
			LoginBtn = new Guna.UI2.WinForms.Guna2GradientButton();
			RgstrBtn = new Guna.UI2.WinForms.Guna2GradientButton();
			LicBtn = new Guna.UI2.WinForms.Guna2GradientButton();
			UpgradeBtn = new Guna.UI2.WinForms.Guna2GradientButton();
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			chkSave = new Guna.UI2.WinForms.Guna2CheckBox();
			guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2HtmlToolTip1 = new Guna.UI2.WinForms.Guna2HtmlToolTip();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
			label3 = new System.Windows.Forms.Label();
			status = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox2).BeginInit();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Segoe UI Light", 10f);
			label1.ForeColor = System.Drawing.Color.White;
			label1.Location = new System.Drawing.Point(-1, 146);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(0, 19);
			label1.TabIndex = 22;
			label2.AutoSize = true;
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.Font = new System.Drawing.Font("Electrolize", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.ForeColor = System.Drawing.Color.LightGray;
			label2.Location = new System.Drawing.Point(279, 28);
			label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(148, 18);
			label2.TabIndex = 27;
			label2.Text = "PEGASUS | LOGIN";
			guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(674, 17);
			guna2PictureBox1.Name = "guna2PictureBox1";
			guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
			guna2PictureBox1.Size = new System.Drawing.Size(29, 29);
			guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox1.TabIndex = 116;
			guna2PictureBox1.TabStop = false;
			guna2PictureBox1.UseTransparentBackground = true;
			guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
			pictureBox1.BackColor = System.Drawing.Color.Transparent;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(12, 12);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(40, 50);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 115;
			pictureBox1.TabStop = false;
			guna2Panel1.Controls.Add(guna2Separator1);
			guna2Panel1.Controls.Add(guna2PictureBox1);
			guna2Panel1.Controls.Add(label2);
			guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			guna2Panel1.Location = new System.Drawing.Point(0, 0);
			guna2Panel1.Name = "guna2Panel1";
			guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
			guna2Panel1.Size = new System.Drawing.Size(715, 78);
			guna2Panel1.TabIndex = 117;
			guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator1.Location = new System.Drawing.Point(-210, 72);
			guna2Separator1.Name = "guna2Separator1";
			guna2Separator1.Size = new System.Drawing.Size(1137, 10);
			guna2Separator1.TabIndex = 117;
			guna2Separator1.UseTransparentBackground = true;
			username.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			username.Cursor = System.Windows.Forms.Cursors.IBeam;
			username.DefaultText = "";
			username.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			username.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			username.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			username.DisabledState.Parent = username;
			username.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			username.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			username.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			username.FocusedState.Parent = username;
			username.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			username.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			username.HoverState.Parent = username;
			username.Location = new System.Drawing.Point(116, 154);
			username.Name = "username";
			username.PasswordChar = '\0';
			username.PlaceholderText = "Username";
			username.SelectedText = "";
			username.ShadowDecoration.Parent = username;
			username.Size = new System.Drawing.Size(502, 21);
			username.TabIndex = 147;
			password.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			password.Cursor = System.Windows.Forms.Cursors.IBeam;
			password.DefaultText = "dark";
			password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			password.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			password.DisabledState.Parent = password;
			password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			password.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			password.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			password.FocusedState.Parent = password;
			password.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			password.ForeColor = System.Drawing.Color.LightGray;
			password.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			password.HoverState.Parent = password;
			password.Location = new System.Drawing.Point(116, 181);
			password.Name = "password";
			password.PasswordChar = '*';
			password.PlaceholderForeColor = System.Drawing.Color.LightGray;
			password.PlaceholderText = "Password";
			password.SelectedText = "";
			password.SelectionStart = 4;
			password.ShadowDecoration.Parent = password;
			password.Size = new System.Drawing.Size(502, 21);
			password.TabIndex = 148;
			key.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			key.Cursor = System.Windows.Forms.Cursors.IBeam;
			key.DefaultText = "";
			key.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			key.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			key.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			key.DisabledState.Parent = key;
			key.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			key.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			key.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			key.FocusedState.Parent = key;
			key.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			key.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			key.HoverState.Parent = key;
			key.Location = new System.Drawing.Point(116, 208);
			key.Name = "key";
			key.PasswordChar = '\0';
			key.PlaceholderText = "License";
			key.SelectedText = "";
			key.ShadowDecoration.Parent = key;
			key.Size = new System.Drawing.Size(502, 21);
			key.TabIndex = 161;
			LoginBtn.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			LoginBtn.BorderThickness = 1;
			LoginBtn.CheckedState.Parent = LoginBtn;
			LoginBtn.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			LoginBtn.CustomImages.Parent = LoginBtn;
			LoginBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			LoginBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			LoginBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			LoginBtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			LoginBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			LoginBtn.DisabledState.Parent = LoginBtn;
			LoginBtn.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			LoginBtn.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			LoginBtn.Font = new System.Drawing.Font("Electrolize", 9f);
			LoginBtn.ForeColor = System.Drawing.Color.White;
			LoginBtn.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			LoginBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			LoginBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			LoginBtn.HoverState.ForeColor = System.Drawing.Color.LightGray;
			LoginBtn.HoverState.Parent = LoginBtn;
			LoginBtn.Location = new System.Drawing.Point(348, 235);
			LoginBtn.Name = "LoginBtn";
			LoginBtn.ShadowDecoration.Parent = LoginBtn;
			LoginBtn.Size = new System.Drawing.Size(132, 30);
			LoginBtn.TabIndex = 162;
			LoginBtn.Text = "Login";
			guna2HtmlToolTip1.SetToolTip(LoginBtn, "Login with username and password!");
			LoginBtn.Click += new System.EventHandler(LoginBtn_Click);
			RgstrBtn.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			RgstrBtn.BorderThickness = 1;
			RgstrBtn.CheckedState.Parent = RgstrBtn;
			RgstrBtn.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			RgstrBtn.CustomImages.Parent = RgstrBtn;
			RgstrBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			RgstrBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			RgstrBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			RgstrBtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			RgstrBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			RgstrBtn.DisabledState.Parent = RgstrBtn;
			RgstrBtn.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			RgstrBtn.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			RgstrBtn.Font = new System.Drawing.Font("Electrolize", 9f);
			RgstrBtn.ForeColor = System.Drawing.Color.White;
			RgstrBtn.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			RgstrBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			RgstrBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			RgstrBtn.HoverState.ForeColor = System.Drawing.Color.LightGray;
			RgstrBtn.HoverState.Parent = RgstrBtn;
			RgstrBtn.Location = new System.Drawing.Point(210, 235);
			RgstrBtn.Name = "RgstrBtn";
			RgstrBtn.ShadowDecoration.Parent = RgstrBtn;
			RgstrBtn.Size = new System.Drawing.Size(132, 30);
			RgstrBtn.TabIndex = 163;
			RgstrBtn.Text = "Register";
			guna2HtmlToolTip1.SetToolTip(RgstrBtn, "Register your new key!");
			RgstrBtn.Click += new System.EventHandler(RgstrBtn_Click);
			LicBtn.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			LicBtn.BorderThickness = 1;
			LicBtn.CheckedState.Parent = LicBtn;
			LicBtn.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			LicBtn.CustomImages.Parent = LicBtn;
			LicBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			LicBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			LicBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			LicBtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			LicBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			LicBtn.DisabledState.Parent = LicBtn;
			LicBtn.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			LicBtn.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			LicBtn.Font = new System.Drawing.Font("Electrolize", 9f);
			LicBtn.ForeColor = System.Drawing.Color.White;
			LicBtn.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			LicBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			LicBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			LicBtn.HoverState.ForeColor = System.Drawing.Color.LightGray;
			LicBtn.HoverState.Parent = LicBtn;
			LicBtn.Location = new System.Drawing.Point(486, 235);
			LicBtn.Name = "LicBtn";
			LicBtn.ShadowDecoration.Parent = LicBtn;
			LicBtn.Size = new System.Drawing.Size(132, 30);
			LicBtn.TabIndex = 164;
			LicBtn.Text = "Login with License";
			guna2HtmlToolTip1.SetToolTip(LicBtn, "Login with current valid  key!");
			LicBtn.Click += new System.EventHandler(LicBtn_Click);
			UpgradeBtn.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			UpgradeBtn.BorderThickness = 1;
			UpgradeBtn.CheckedState.Parent = UpgradeBtn;
			UpgradeBtn.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			UpgradeBtn.CustomImages.Parent = UpgradeBtn;
			UpgradeBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			UpgradeBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			UpgradeBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			UpgradeBtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			UpgradeBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			UpgradeBtn.DisabledState.Parent = UpgradeBtn;
			UpgradeBtn.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			UpgradeBtn.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			UpgradeBtn.Font = new System.Drawing.Font("Electrolize", 9f);
			UpgradeBtn.ForeColor = System.Drawing.Color.White;
			UpgradeBtn.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			UpgradeBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			UpgradeBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			UpgradeBtn.HoverState.ForeColor = System.Drawing.Color.LightGray;
			UpgradeBtn.HoverState.Parent = UpgradeBtn;
			UpgradeBtn.Location = new System.Drawing.Point(433, 321);
			UpgradeBtn.Name = "UpgradeBtn";
			UpgradeBtn.ShadowDecoration.Parent = UpgradeBtn;
			UpgradeBtn.Size = new System.Drawing.Size(132, 30);
			UpgradeBtn.TabIndex = 165;
			UpgradeBtn.Text = "Upgrade Key";
			guna2HtmlToolTip1.SetToolTip(UpgradeBtn, "Use this option only if your key has expired and you have buy a new one!");
			UpgradeBtn.Visible = false;
			UpgradeBtn.Click += new System.EventHandler(UpgradeBtn_Click);
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.TargetForm = this;
			chkSave.AutoSize = true;
			chkSave.CheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			chkSave.CheckedState.BorderRadius = 0;
			chkSave.CheckedState.BorderThickness = 1;
			chkSave.CheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			chkSave.CheckMarkColor = System.Drawing.Color.FromArgb(191, 37, 33);
			chkSave.Font = new System.Drawing.Font("Electrolize", 8.249999f);
			chkSave.Location = new System.Drawing.Point(116, 247);
			chkSave.Name = "chkSave";
			chkSave.Size = new System.Drawing.Size(79, 18);
			chkSave.TabIndex = 166;
			chkSave.Text = "Save Login";
			chkSave.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			chkSave.UncheckedState.BorderRadius = 0;
			chkSave.UncheckedState.BorderThickness = 1;
			chkSave.UncheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox2.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox2.Image");
			guna2PictureBox2.ImageRotate = 0f;
			guna2PictureBox2.Location = new System.Drawing.Point(21, 154);
			guna2PictureBox2.Name = "guna2PictureBox2";
			guna2PictureBox2.ShadowDecoration.Parent = guna2PictureBox2;
			guna2PictureBox2.Size = new System.Drawing.Size(89, 82);
			guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox2.TabIndex = 167;
			guna2PictureBox2.TabStop = false;
			guna2PictureBox2.UseTransparentBackground = true;
			guna2HtmlToolTip1.AllowLinksHandling = true;
			guna2HtmlToolTip1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2HtmlToolTip1.BorderColor = System.Drawing.Color.FromArgb(198, 25, 31);
			guna2HtmlToolTip1.MaximumSize = new System.Drawing.Size(0, 0);
			guna2HtmlToolTip1.TitleFont = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			guna2HtmlToolTip1.TitleForeColor = System.Drawing.Color.FromArgb(198, 25, 31);
			guna2HtmlToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			guna2HtmlToolTip1.ToolTipTitle = "PEGASUS";
			linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			linkLabel1.AutoSize = true;
			linkLabel1.LinkColor = System.Drawing.Color.FromArgb(191, 38, 33);
			linkLabel1.Location = new System.Drawing.Point(18, 312);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(68, 14);
			linkLabel1.TabIndex = 168;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "Reset HWID";
			linkLabel1.Visible = false;
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			guna2GradientButton1.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			guna2GradientButton1.BorderThickness = 1;
			guna2GradientButton1.CheckedState.Parent = guna2GradientButton1;
			guna2GradientButton1.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			guna2GradientButton1.CustomImages.Parent = guna2GradientButton1;
			guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			guna2GradientButton1.DisabledState.Parent = guna2GradientButton1;
			guna2GradientButton1.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2GradientButton1.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2GradientButton1.Font = new System.Drawing.Font("Electrolize", 9f);
			guna2GradientButton1.ForeColor = System.Drawing.Color.White;
			guna2GradientButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			guna2GradientButton1.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			guna2GradientButton1.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2GradientButton1.HoverState.ForeColor = System.Drawing.Color.LightGray;
			guna2GradientButton1.HoverState.Parent = guna2GradientButton1;
			guna2GradientButton1.Location = new System.Drawing.Point(571, 321);
			guna2GradientButton1.Name = "guna2GradientButton1";
			guna2GradientButton1.ShadowDecoration.Parent = guna2GradientButton1;
			guna2GradientButton1.Size = new System.Drawing.Size(132, 30);
			guna2GradientButton1.TabIndex = 169;
			guna2GradientButton1.Text = "Update";
			guna2GradientButton1.Visible = false;
			label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(18, 337);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(42, 14);
			label3.TabIndex = 170;
			label3.Text = "Status:";
			status.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			status.AutoSize = true;
			status.ForeColor = System.Drawing.Color.FromArgb(191, 38, 33);
			status.Location = new System.Drawing.Point(59, 337);
			status.Name = "status";
			status.Size = new System.Drawing.Size(39, 14);
			status.TabIndex = 171;
			status.Text = "status";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
			BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			base.ClientSize = new System.Drawing.Size(715, 363);
			base.Controls.Add(status);
			base.Controls.Add(label3);
			base.Controls.Add(guna2GradientButton1);
			base.Controls.Add(linkLabel1);
			base.Controls.Add(guna2PictureBox2);
			base.Controls.Add(chkSave);
			base.Controls.Add(UpgradeBtn);
			base.Controls.Add(LicBtn);
			base.Controls.Add(RgstrBtn);
			base.Controls.Add(LoginBtn);
			base.Controls.Add(key);
			base.Controls.Add(password);
			base.Controls.Add(username);
			base.Controls.Add(pictureBox1);
			base.Controls.Add(label1);
			base.Controls.Add(guna2Panel1);
			Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ForeColor = System.Drawing.Color.LightGray;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Login";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "PEGASUS | LOGIN";
			base.Load += new System.EventHandler(Login_Load);
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			guna2Panel1.ResumeLayout(false);
			guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox2).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		private static string info(string str)
		{
			char c = '\n';
			StringBuilder stringBuilder = new StringBuilder();
			char[] array = str.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				char value = (char)(array[i] ^ c);
				stringBuilder.Append(value);
			}
			return stringBuilder.ToString();
		}
	}
}
