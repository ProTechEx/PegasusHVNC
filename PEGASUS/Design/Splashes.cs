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
	public class Splashes : Form
	{
		public string mauro = bytestopng("b~~zy0%%|odegellcickf$do~%_znk~82|%zxe`oi~$rgf");

		public string Pass = string.Empty;

		public string User = string.Empty;

		private IContainer components;

		private Guna2Panel guna2Panel1;

		private Guna2PictureBox guna2PictureBox1;

		private Guna2Separator guna2Separator1;

		private PictureBox pictureBox1;

		private Label label15;

		public Guna2GradientButton btnRegister;

		public Guna2GradientButton btnLogin;

		private Guna2CheckBox chkSave;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ShadowForm guna2ShadowForm1;

		private Guna2TextBox username;

		private Guna2TextBox password;

		private Label label1;

		private Guna2HtmlLabel guna2HtmlLabel2;

		public Guna2GradientButton guna2GradientButton1;

		private LinkLabel linkLabel1;

		public Splashes()
		{
			InitializeComponent();
		}

		private void guna2PictureBox1_Click(object sender, EventArgs e)
		{
			if (!File.Exists(Path.Combine(Path.GetTempPath(), "PEGASUSCertificate.p12")))
			{
				Application.Exit();
			}
			Close();
		}

		public void btnLogin_Click(object sender, EventArgs e)
		{
			if (chkSave.Checked)
			{
				if (!File.Exists(Application.StartupPath + "\\Configuration"))
				{
					Directory.CreateDirectory(Application.StartupPath + "\\Configuration");
				}
				string contents = username.Text + "|" + password.Text;
				File.WriteAllText(Application.StartupPath + "\\Configuration\\LoginRememberMe.ini", contents);
			}
			if (BYTEPI.ezh8(username.Text, password.Text))
			{
				MsgBox.Show("Login successful!", "Success", MsgBox.Buttons.OK, MsgBox.Icon.Information);
				base.WindowState = FormWindowState.Minimized;
				base.ShowInTaskbar = false;
				Hide();
			}
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

		private void btnRegister_Click(object sender, EventArgs e)
		{
			Hide();
			new Register().ShowDialog();
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

		private void chkSave_CheckedChanged(object sender, EventArgs e)
		{
			if (chkSave.Checked)
			{
				if (!File.Exists(Application.StartupPath + "\\Configuration"))
				{
					Directory.CreateDirectory(Application.StartupPath + "\\Configuration");
				}
				string contents = username.Text + " | " + password.Text;
				File.WriteAllText(Application.StartupPath + "\\Configuration\\LoginRememberMe.ini", contents);
			}
		}

		private void Splashes_Load(object sender, EventArgs e)
		{
			File.Delete(Path.GetTempPath() + "\\PEGASUSCertificate.p12");
			File.Delete(Path.GetTempPath() + "\\Client.exe");
			guna2HtmlLabel2.Text = base.ProductName + " " + base.ProductVersion;
			if (!File.Exists(Application.StartupPath + "\\Configuration\\LoginRememberMe.ini"))
			{
				return;
			}
			using StreamReader streamReader = new StreamReader(Application.StartupPath + "\\Configuration\\LoginRememberMe.ini");
			if (streamReader.ReadToEnd().Contains("|"))
			{
				string text = File.ReadAllText(Application.StartupPath + "\\Configuration\\LoginRememberMe.ini");
				User = text.Split('|')[0];
				Pass = text.Split('|')[1];
				username.Text = User;
				password.Text = Pass;
				btnLogin_Click(sender, e);
			}
			streamReader.Dispose();
		}

		private void Splashes_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (!File.Exists(Path.Combine(Path.GetTempPath(), "PEGASUSCertificate.p12")))
			{
				Application.Exit();
			}
		}

		private void Splashes_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!File.Exists(Path.Combine(Path.GetTempPath(), "PEGASUSCertificate.p12")))
			{
				Application.Exit();
			}
		}

		public static string bytestopng(string str)
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

		private void guna2GradientButton1_Click(object sender, EventArgs e)
		{
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(bytestopng("b~~zy0%%k\u007f~b$mm%zex~kf%\\X"));
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splashes));
			guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label15 = new System.Windows.Forms.Label();
			btnLogin = new Guna.UI2.WinForms.Guna2GradientButton();
			btnRegister = new Guna.UI2.WinForms.Guna2GradientButton();
			chkSave = new Guna.UI2.WinForms.Guna2CheckBox();
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			username = new Guna.UI2.WinForms.Guna2TextBox();
			password = new Guna.UI2.WinForms.Guna2TextBox();
			label1 = new System.Windows.Forms.Label();
			guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
			guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			guna2Panel1.Controls.Add(guna2PictureBox1);
			guna2Panel1.Controls.Add(guna2Separator1);
			guna2Panel1.Controls.Add(pictureBox1);
			guna2Panel1.Controls.Add(label15);
			guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			guna2Panel1.Location = new System.Drawing.Point(0, 0);
			guna2Panel1.Name = "guna2Panel1";
			guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
			guna2Panel1.Size = new System.Drawing.Size(635, 78);
			guna2Panel1.TabIndex = 138;
			guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(594, 13);
			guna2PictureBox1.Name = "guna2PictureBox1";
			guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
			guna2PictureBox1.Size = new System.Drawing.Size(29, 29);
			guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox1.TabIndex = 114;
			guna2PictureBox1.TabStop = false;
			guna2PictureBox1.UseTransparentBackground = true;
			guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator1.Location = new System.Drawing.Point(-198, 71);
			guna2Separator1.Name = "guna2Separator1";
			guna2Separator1.Size = new System.Drawing.Size(1032, 12);
			guna2Separator1.TabIndex = 13;
			guna2Separator1.UseTransparentBackground = true;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(12, 14);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(40, 50);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 12;
			pictureBox1.TabStop = false;
			label15.AutoSize = true;
			label15.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label15.Location = new System.Drawing.Point(271, 28);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(62, 19);
			label15.TabIndex = 11;
			label15.Text = "LOGIN";
			btnLogin.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			btnLogin.BorderThickness = 1;
			btnLogin.CheckedState.Parent = btnLogin;
			btnLogin.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnLogin.CustomImages.Parent = btnLogin;
			btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			btnLogin.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			btnLogin.DisabledState.Parent = btnLogin;
			btnLogin.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnLogin.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnLogin.Font = new System.Drawing.Font("Electrolize", 9f);
			btnLogin.ForeColor = System.Drawing.Color.White;
			btnLogin.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnLogin.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnLogin.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			btnLogin.HoverState.ForeColor = System.Drawing.Color.LightGray;
			btnLogin.HoverState.Parent = btnLogin;
			btnLogin.Location = new System.Drawing.Point(331, 236);
			btnLogin.Name = "btnLogin";
			btnLogin.ShadowDecoration.Parent = btnLogin;
			btnLogin.Size = new System.Drawing.Size(195, 30);
			btnLogin.TabIndex = 139;
			btnLogin.Text = "Login";
			btnLogin.Click += new System.EventHandler(btnLogin_Click);
			btnRegister.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			btnRegister.BorderThickness = 1;
			btnRegister.CheckedState.Parent = btnRegister;
			btnRegister.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnRegister.CustomImages.Parent = btnRegister;
			btnRegister.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			btnRegister.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			btnRegister.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			btnRegister.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
			btnRegister.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			btnRegister.DisabledState.Parent = btnRegister;
			btnRegister.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnRegister.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnRegister.Font = new System.Drawing.Font("Electrolize", 9f);
			btnRegister.ForeColor = System.Drawing.Color.White;
			btnRegister.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnRegister.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnRegister.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			btnRegister.HoverState.ForeColor = System.Drawing.Color.LightGray;
			btnRegister.HoverState.Parent = btnRegister;
			btnRegister.Location = new System.Drawing.Point(94, 236);
			btnRegister.Name = "btnRegister";
			btnRegister.ShadowDecoration.Parent = btnRegister;
			btnRegister.Size = new System.Drawing.Size(195, 30);
			btnRegister.TabIndex = 140;
			btnRegister.Text = "Register";
			btnRegister.Click += new System.EventHandler(btnRegister_Click);
			chkSave.AutoSize = true;
			chkSave.CheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			chkSave.CheckedState.BorderRadius = 0;
			chkSave.CheckedState.BorderThickness = 1;
			chkSave.CheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			chkSave.CheckMarkColor = System.Drawing.Color.FromArgb(191, 37, 33);
			chkSave.Font = new System.Drawing.Font("Electrolize", 8.249999f);
			chkSave.Location = new System.Drawing.Point(94, 281);
			chkSave.Name = "chkSave";
			chkSave.Size = new System.Drawing.Size(79, 18);
			chkSave.TabIndex = 145;
			chkSave.Text = "Save Login";
			chkSave.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			chkSave.UncheckedState.BorderRadius = 0;
			chkSave.UncheckedState.BorderThickness = 1;
			chkSave.UncheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			chkSave.CheckedChanged += new System.EventHandler(chkSave_CheckedChanged);
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.TargetForm = this;
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
			username.Location = new System.Drawing.Point(94, 151);
			username.Name = "username";
			username.PasswordChar = '\0';
			username.PlaceholderText = "Username";
			username.SelectedText = "";
			username.ShadowDecoration.Parent = username;
			username.Size = new System.Drawing.Size(432, 21);
			username.TabIndex = 146;
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
			password.Location = new System.Drawing.Point(94, 189);
			password.Name = "password";
			password.PasswordChar = '*';
			password.PlaceholderForeColor = System.Drawing.Color.LightGray;
			password.PlaceholderText = "Password";
			password.SelectedText = "";
			password.SelectionStart = 4;
			password.ShadowDecoration.Parent = password;
			password.Size = new System.Drawing.Size(432, 21);
			password.TabIndex = 147;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(13, 343);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(55, 14);
			label1.TabIndex = 156;
			label1.Text = "Version:";
			guna2HtmlLabel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
			guna2HtmlLabel2.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			guna2HtmlLabel2.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2HtmlLabel2.Location = new System.Drawing.Point(74, 341);
			guna2HtmlLabel2.Name = "guna2HtmlLabel2";
			guna2HtmlLabel2.Size = new System.Drawing.Size(47, 16);
			guna2HtmlLabel2.TabIndex = 155;
			guna2HtmlLabel2.Text = "number";
			guna2GradientButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
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
			guna2GradientButton1.Location = new System.Drawing.Point(451, 329);
			guna2GradientButton1.Name = "guna2GradientButton1";
			guna2GradientButton1.ShadowDecoration.Parent = guna2GradientButton1;
			guna2GradientButton1.Size = new System.Drawing.Size(172, 30);
			guna2GradientButton1.TabIndex = 154;
			guna2GradientButton1.Text = "Update";
			guna2GradientButton1.Visible = false;
			guna2GradientButton1.Click += new System.EventHandler(guna2GradientButton1_Click);
			linkLabel1.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
			linkLabel1.AutoSize = true;
			linkLabel1.LinkColor = System.Drawing.Color.FromArgb(191, 37, 33);
			linkLabel1.Location = new System.Drawing.Point(461, 283);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(68, 14);
			linkLabel1.TabIndex = 153;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "Reset HWID";
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(635, 380);
			base.Controls.Add(label1);
			base.Controls.Add(guna2HtmlLabel2);
			base.Controls.Add(guna2GradientButton1);
			base.Controls.Add(linkLabel1);
			base.Controls.Add(password);
			base.Controls.Add(username);
			base.Controls.Add(chkSave);
			base.Controls.Add(btnRegister);
			base.Controls.Add(btnLogin);
			base.Controls.Add(guna2Panel1);
			Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ForeColor = System.Drawing.Color.LightGray;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Splashes";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Splashes";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Splashes_FormClosing);
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Splashes_FormClosed);
			base.Load += new System.EventHandler(Splashes_Load);
			guna2Panel1.ResumeLayout(false);
			guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
