using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace HVNC
{
	public class FrmLogin : Form
	{
		private IContainer components;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ControlBox guna2ControlBox2;

		private Guna2DragControl guna2DragControl1;

		private Guna2GroupBox guna2GroupBox1;

		private Guna2ShadowForm guna2ShadowForm1;

		private Label label1;

		private Guna2Button LoginBtn;

		private Guna2TextBox passwordbox;

		private PictureBox pictureBox1;

		private Guna2Button RegisterBtn;

		private Guna2TextBox usernamebox;

		public FrmLogin()
		{
			InitializeComponent();
		}

		private void bunifuButton1_Click(object sender, EventArgs e)
		{
			Hide();
			new FrmRegister().Show();
		}

		private void button2_Click(object sender, EventArgs e)
		{
		}

		private void guna2Button1_Click(object sender, EventArgs e)
		{
			Hide();
			new FrmRegister().Show();
		}

		private void FrmLogin_Load(object sender, EventArgs e)
		{
			passwordbox.UseSystemPasswordChar = true;
		}

		private void passwordbox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				LoginBtn.PerformClick();
			}
		}

		private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HVNC.FrmLogin));
			guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
			guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
			RegisterBtn = new Guna.UI2.WinForms.Guna2Button();
			LoginBtn = new Guna.UI2.WinForms.Guna2Button();
			label1 = new System.Windows.Forms.Label();
			passwordbox = new Guna.UI2.WinForms.Guna2TextBox();
			usernamebox = new Guna.UI2.WinForms.Guna2TextBox();
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2GroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			guna2DragControl1.TargetControl = guna2GroupBox1;
			guna2GroupBox1.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2GroupBox1.BorderThickness = 5;
			guna2GroupBox1.Controls.Add(pictureBox1);
			guna2GroupBox1.Controls.Add(guna2ControlBox2);
			guna2GroupBox1.Controls.Add(RegisterBtn);
			guna2GroupBox1.Controls.Add(LoginBtn);
			guna2GroupBox1.Controls.Add(label1);
			guna2GroupBox1.Controls.Add(passwordbox);
			guna2GroupBox1.Controls.Add(usernamebox);
			guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2GroupBox1.FillColor = System.Drawing.Color.Transparent;
			guna2GroupBox1.Font = new System.Drawing.Font("Electrolize", 9f);
			guna2GroupBox1.ForeColor = System.Drawing.Color.Gainsboro;
			guna2GroupBox1.Location = new System.Drawing.Point(9, 12);
			guna2GroupBox1.Name = "guna2GroupBox1";
			guna2GroupBox1.ShadowDecoration.Parent = guna2GroupBox1;
			guna2GroupBox1.Size = new System.Drawing.Size(210, 346);
			guna2GroupBox1.TabIndex = 0;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(25, 87);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(156, 101);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 145;
			pictureBox1.TabStop = false;
			guna2ControlBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox2.BackColor = System.Drawing.Color.Transparent;
			guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
			guna2ControlBox2.HoverState.Parent = guna2ControlBox2;
			guna2ControlBox2.IconColor = System.Drawing.Color.White;
			guna2ControlBox2.Location = new System.Drawing.Point(165, 3);
			guna2ControlBox2.Name = "guna2ControlBox2";
			guna2ControlBox2.ShadowDecoration.Parent = guna2ControlBox2;
			guna2ControlBox2.Size = new System.Drawing.Size(41, 32);
			guna2ControlBox2.TabIndex = 123;
			RegisterBtn.Animated = true;
			RegisterBtn.BackColor = System.Drawing.Color.Transparent;
			RegisterBtn.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			RegisterBtn.CheckedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			RegisterBtn.CheckedState.Parent = RegisterBtn;
			RegisterBtn.CustomImages.Parent = RegisterBtn;
			RegisterBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			RegisterBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			RegisterBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			RegisterBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			RegisterBtn.DisabledState.Parent = RegisterBtn;
			RegisterBtn.FillColor = System.Drawing.Color.FromArgb(191, 38, 33);
			RegisterBtn.Font = new System.Drawing.Font("Electrolize", 9f);
			RegisterBtn.ForeColor = System.Drawing.Color.White;
			RegisterBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			RegisterBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(191, 38, 33);
			RegisterBtn.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 38, 33);
			RegisterBtn.HoverState.Parent = RegisterBtn;
			RegisterBtn.Location = new System.Drawing.Point(115, 300);
			RegisterBtn.Name = "RegisterBtn";
			RegisterBtn.PressedColor = System.Drawing.Color.FromArgb(191, 38, 33);
			RegisterBtn.ShadowDecoration.Parent = RegisterBtn;
			RegisterBtn.Size = new System.Drawing.Size(83, 34);
			RegisterBtn.TabIndex = 3;
			RegisterBtn.Text = "Register";
			RegisterBtn.Click += new System.EventHandler(guna2Button1_Click);
			LoginBtn.Animated = true;
			LoginBtn.BackColor = System.Drawing.Color.Transparent;
			LoginBtn.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			LoginBtn.CheckedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			LoginBtn.CheckedState.Parent = LoginBtn;
			LoginBtn.CustomImages.Parent = LoginBtn;
			LoginBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			LoginBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			LoginBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
			LoginBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
			LoginBtn.DisabledState.Parent = LoginBtn;
			LoginBtn.FillColor = System.Drawing.Color.FromArgb(191, 38, 33);
			LoginBtn.Font = new System.Drawing.Font("Electrolize", 9f);
			LoginBtn.ForeColor = System.Drawing.Color.White;
			LoginBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			LoginBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(191, 38, 33);
			LoginBtn.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 38, 33);
			LoginBtn.HoverState.Parent = LoginBtn;
			LoginBtn.Location = new System.Drawing.Point(9, 300);
			LoginBtn.Name = "LoginBtn";
			LoginBtn.PressedColor = System.Drawing.Color.FromArgb(191, 38, 33);
			LoginBtn.ShadowDecoration.Parent = LoginBtn;
			LoginBtn.Size = new System.Drawing.Size(83, 34);
			LoginBtn.TabIndex = 2;
			LoginBtn.Text = "Login";
			LoginBtn.Click += new System.EventHandler(button2_Click);
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.Gainsboro;
			label1.Location = new System.Drawing.Point(4, 6);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(158, 24);
			label1.TabIndex = 120;
			label1.Text = "PEGASUS HVNC";
			passwordbox.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			passwordbox.BorderThickness = 5;
			passwordbox.Cursor = System.Windows.Forms.Cursors.IBeam;
			passwordbox.DefaultText = "";
			passwordbox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			passwordbox.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			passwordbox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			passwordbox.DisabledState.Parent = passwordbox;
			passwordbox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			passwordbox.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			passwordbox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			passwordbox.FocusedState.Parent = passwordbox;
			passwordbox.Font = new System.Drawing.Font("Electrolize", 9f);
			passwordbox.ForeColor = System.Drawing.Color.White;
			passwordbox.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			passwordbox.HoverState.Parent = passwordbox;
			passwordbox.Location = new System.Drawing.Point(9, 260);
			passwordbox.Name = "passwordbox";
			passwordbox.PasswordChar = '\0';
			passwordbox.PlaceholderForeColor = System.Drawing.Color.Gainsboro;
			passwordbox.PlaceholderText = "Password";
			passwordbox.SelectedText = "";
			passwordbox.ShadowDecoration.Parent = passwordbox;
			passwordbox.Size = new System.Drawing.Size(189, 34);
			passwordbox.TabIndex = 1;
			passwordbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(passwordbox_KeyPress);
			usernamebox.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			usernamebox.BorderThickness = 5;
			usernamebox.Cursor = System.Windows.Forms.Cursors.IBeam;
			usernamebox.DefaultText = "";
			usernamebox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
			usernamebox.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
			usernamebox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			usernamebox.DisabledState.Parent = usernamebox;
			usernamebox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
			usernamebox.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			usernamebox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			usernamebox.FocusedState.Parent = usernamebox;
			usernamebox.Font = new System.Drawing.Font("Electrolize", 9f);
			usernamebox.ForeColor = System.Drawing.Color.White;
			usernamebox.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			usernamebox.HoverState.Parent = usernamebox;
			usernamebox.Location = new System.Drawing.Point(9, 220);
			usernamebox.Name = "usernamebox";
			usernamebox.PasswordChar = '\0';
			usernamebox.PlaceholderForeColor = System.Drawing.Color.Gainsboro;
			usernamebox.PlaceholderText = "Username";
			usernamebox.SelectedText = "";
			usernamebox.ShadowDecoration.Parent = usernamebox;
			usernamebox.Size = new System.Drawing.Size(189, 34);
			usernamebox.TabIndex = 0;
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2ShadowForm1.TargetForm = this;
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2BorderlessForm1.TransparentWhileDrag = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(228, 370);
			base.Controls.Add(guna2GroupBox1);
			DoubleBuffered = true;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FrmLogin";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Login";
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FrmLogin_FormClosed);
			base.Load += new System.EventHandler(FrmLogin_Load);
			guna2GroupBox1.ResumeLayout(false);
			guna2GroupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}
	}
}
