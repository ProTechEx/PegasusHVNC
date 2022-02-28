using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace HVNC
{
	public class FrmRegister : Form
	{
		private Guna2Button button2;

		private IContainer components;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2Button guna2Button1;

		private Guna2ControlBox guna2ControlBox1;

		private Guna2ControlBox guna2ControlBox2;

		private Guna2DragControl guna2DragControl1;

		private Guna2GroupBox guna2GroupBox1;

		private Guna2ShadowForm guna2ShadowForm1;

		private Label label1;

		private Guna2TextBox license;

		private Guna2TextBox password;

		private PictureBox pictureBox1;

		private Guna2TextBox username;

		public FrmRegister()
		{
			InitializeComponent();
		}

		private void bunifuButton1_Click(object sender, EventArgs e)
		{
			Hide();
			new FrmLogin().Show();
		}

		private void siticoneRoundedButton2_Click(object sender, EventArgs e)
		{
		}

		private void siticoneRoundedButton1_Click(object sender, EventArgs e)
		{
			Hide();
			new FrmLogin().Show();
		}

		private void FrmRegister_FormClosing(object sender, FormClosingEventArgs e)
		{
			Environment.Exit(Environment.ExitCode);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HVNC.FrmRegister));
			guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
			label1 = new System.Windows.Forms.Label();
			guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
			guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
			button2 = new Guna.UI2.WinForms.Guna2Button();
			license = new Guna.UI2.WinForms.Guna2TextBox();
			password = new Guna.UI2.WinForms.Guna2TextBox();
			username = new Guna.UI2.WinForms.Guna2TextBox();
			guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2GroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			guna2ControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
			guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
			guna2ControlBox1.HoverState.Parent = guna2ControlBox1;
			guna2ControlBox1.IconColor = System.Drawing.Color.White;
			guna2ControlBox1.Location = new System.Drawing.Point(-1431, 51);
			guna2ControlBox1.Name = "guna2ControlBox1";
			guna2ControlBox1.ShadowDecoration.Parent = guna2ControlBox1;
			guna2ControlBox1.Size = new System.Drawing.Size(41, 32);
			guna2ControlBox1.TabIndex = 10;
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.Gainsboro;
			label1.Location = new System.Drawing.Point(3, 3);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(104, 29);
			label1.TabIndex = 3;
			label1.Text = "Register";
			guna2GroupBox1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2GroupBox1.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2GroupBox1.BorderThickness = 5;
			guna2GroupBox1.Controls.Add(pictureBox1);
			guna2GroupBox1.Controls.Add(guna2ControlBox2);
			guna2GroupBox1.Controls.Add(guna2Button1);
			guna2GroupBox1.Controls.Add(button2);
			guna2GroupBox1.Controls.Add(license);
			guna2GroupBox1.Controls.Add(label1);
			guna2GroupBox1.Controls.Add(password);
			guna2GroupBox1.Controls.Add(username);
			guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2GroupBox1.FillColor = System.Drawing.Color.Transparent;
			guna2GroupBox1.Font = new System.Drawing.Font("Electrolize", 9f);
			guna2GroupBox1.ForeColor = System.Drawing.Color.Gainsboro;
			guna2GroupBox1.Location = new System.Drawing.Point(9, 12);
			guna2GroupBox1.Name = "guna2GroupBox1";
			guna2GroupBox1.ShadowDecoration.Parent = guna2GroupBox1;
			guna2GroupBox1.Size = new System.Drawing.Size(214, 504);
			guna2GroupBox1.TabIndex = 0;
			pictureBox1.Location = new System.Drawing.Point(8, 41);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(198, 200);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 146;
			pictureBox1.TabStop = false;
			guna2ControlBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox2.BackColor = System.Drawing.Color.Transparent;
			guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
			guna2ControlBox2.HoverState.Parent = guna2ControlBox2;
			guna2ControlBox2.IconColor = System.Drawing.Color.White;
			guna2ControlBox2.Location = new System.Drawing.Point(169, 3);
			guna2ControlBox2.Name = "guna2ControlBox2";
			guna2ControlBox2.ShadowDecoration.Parent = guna2ControlBox2;
			guna2ControlBox2.Size = new System.Drawing.Size(41, 32);
			guna2ControlBox2.TabIndex = 123;
			guna2Button1.Animated = true;
			guna2Button1.BackColor = System.Drawing.Color.Transparent;
			guna2Button1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2Button1.CheckedState.Parent = guna2Button1;
			guna2Button1.CustomImages.Parent = guna2Button1;
			guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			guna2Button1.DisabledState.Parent = guna2Button1;
			guna2Button1.FillColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2Button1.Font = new System.Drawing.Font("Electrolize", 9f);
			guna2Button1.ForeColor = System.Drawing.Color.White;
			guna2Button1.HoverState.BorderColor = System.Drawing.Color.FromArgb(26, 43, 56);
			guna2Button1.HoverState.FillColor = System.Drawing.Color.FromArgb(26, 43, 56);
			guna2Button1.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2Button1.HoverState.Parent = guna2Button1;
			guna2Button1.Location = new System.Drawing.Point(8, 455);
			guna2Button1.Name = "guna2Button1";
			guna2Button1.PressedColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2Button1.ShadowDecoration.Parent = guna2Button1;
			guna2Button1.Size = new System.Drawing.Size(197, 34);
			guna2Button1.TabIndex = 6;
			guna2Button1.Text = "Back to login";
			guna2Button1.Click += new System.EventHandler(siticoneRoundedButton1_Click);
			button2.Animated = true;
			button2.BackColor = System.Drawing.Color.Transparent;
			button2.CheckedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			button2.CheckedState.Parent = button2;
			button2.CustomImages.Parent = button2;
			button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			button2.DisabledState.Parent = button2;
			button2.FillColor = System.Drawing.Color.FromArgb(191, 38, 33);
			button2.Font = new System.Drawing.Font("Electrolize", 9f);
			button2.ForeColor = System.Drawing.Color.White;
			button2.HoverState.BorderColor = System.Drawing.Color.FromArgb(26, 43, 56);
			button2.HoverState.FillColor = System.Drawing.Color.FromArgb(26, 43, 56);
			button2.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 38, 33);
			button2.HoverState.Parent = button2;
			button2.Location = new System.Drawing.Point(8, 405);
			button2.Name = "button2";
			button2.PressedColor = System.Drawing.Color.FromArgb(191, 38, 33);
			button2.ShadowDecoration.Parent = button2;
			button2.Size = new System.Drawing.Size(197, 34);
			button2.TabIndex = 5;
			button2.Text = "Register";
			button2.Click += new System.EventHandler(siticoneRoundedButton2_Click);
			license.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			license.BorderThickness = 5;
			license.Cursor = System.Windows.Forms.Cursors.IBeam;
			license.DefaultText = "";
			license.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			license.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			license.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			license.DisabledState.Parent = license;
			license.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			license.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			license.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			license.FocusedState.Parent = license;
			license.Font = new System.Drawing.Font("Electrolize", 9f);
			license.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			license.HoverState.Parent = license;
			license.Location = new System.Drawing.Point(8, 346);
			license.Name = "license";
			license.PasswordChar = '\0';
			license.PlaceholderForeColor = System.Drawing.Color.Gainsboro;
			license.PlaceholderText = "License";
			license.SelectedText = "";
			license.ShadowDecoration.Parent = license;
			license.Size = new System.Drawing.Size(198, 34);
			license.TabIndex = 4;
			password.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			password.BorderThickness = 5;
			password.Cursor = System.Windows.Forms.Cursors.IBeam;
			password.DefaultText = "";
			password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			password.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			password.DisabledState.Parent = password;
			password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			password.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			password.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			password.FocusedState.Parent = password;
			password.Font = new System.Drawing.Font("Electrolize", 9f);
			password.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			password.HoverState.Parent = password;
			password.Location = new System.Drawing.Point(8, 304);
			password.Name = "password";
			password.PasswordChar = '\0';
			password.PlaceholderForeColor = System.Drawing.Color.Gainsboro;
			password.PlaceholderText = "Password";
			password.SelectedText = "";
			password.ShadowDecoration.Parent = password;
			password.Size = new System.Drawing.Size(198, 34);
			password.TabIndex = 2;
			username.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			username.BorderThickness = 5;
			username.Cursor = System.Windows.Forms.Cursors.IBeam;
			username.DefaultText = "";
			username.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			username.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			username.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			username.DisabledState.Parent = username;
			username.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			username.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			username.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			username.FocusedState.Parent = username;
			username.Font = new System.Drawing.Font("Electrolize", 9f);
			username.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			username.HoverState.Parent = username;
			username.Location = new System.Drawing.Point(8, 264);
			username.Name = "username";
			username.PasswordChar = '\0';
			username.PlaceholderForeColor = System.Drawing.Color.Gainsboro;
			username.PlaceholderText = "Username";
			username.SelectedText = "";
			username.ShadowDecoration.Parent = username;
			username.Size = new System.Drawing.Size(198, 34);
			username.TabIndex = 1;
			guna2DragControl1.TargetControl = guna2GroupBox1;
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2ShadowForm1.TargetForm = this;
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2BorderlessForm1.TransparentWhileDrag = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(232, 529);
			base.Controls.Add(guna2GroupBox1);
			base.Controls.Add(guna2ControlBox1);
			DoubleBuffered = true;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FrmRegister";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Register";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FrmRegister_FormClosing);
			guna2GroupBox1.ResumeLayout(false);
			guna2GroupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}
	}
}
