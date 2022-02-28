using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS.Properties;

namespace PEGASUS.Design
{
	public class FrmNgrokPanel : Form
	{
		public bool IsOK;

		private IContainer components;

		private Guna2Panel guna2Panel1;

		private Label label3;

		private Guna2PictureBox guna2PictureBox2;

		private Guna2Separator guna2Separator1;

		private PictureBox pictureBox1;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ShadowForm guna2ShadowForm1;

		private Label label2;

		private Label label9;

		private Label label4;

		private Guna2GradientButton btnStop;

		private Guna2GradientButton btnStart;

		public Guna2TextBox txtToken;

		public Guna2TextBox txtProto;

		public Guna2TextBox ProxyPort;

		public FrmNgrokPanel()
		{
			InitializeComponent();
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

		private void guna2PictureBox2_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
		}

		private void FrmNgrokPanel_Load(object sender, EventArgs e)
		{
			txtToken.Text = global::PEGASUS.Properties.Settings.Default.NgrokToken;
			txtProto.Text = global::PEGASUS.Properties.Settings.Default.NgrokProto;
			ProxyPort.Text = global::PEGASUS.Properties.Settings.Default.NgrokPort;
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			global::PEGASUS.Properties.Settings.Default.NgrokToken = txtToken.Text;
			global::PEGASUS.Properties.Settings.Default.NgrokProto = txtProto.Text;
			global::PEGASUS.Properties.Settings.Default.NgrokPort = ProxyPort.Text;
			global::PEGASUS.Properties.Settings.Default.Save();
			Hide();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNgrokPanel));
			guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			label3 = new System.Windows.Forms.Label();
			guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			label2 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			btnStop = new Guna.UI2.WinForms.Guna2GradientButton();
			btnStart = new Guna.UI2.WinForms.Guna2GradientButton();
			txtProto = new Guna.UI2.WinForms.Guna2TextBox();
			txtToken = new Guna.UI2.WinForms.Guna2TextBox();
			ProxyPort = new Guna.UI2.WinForms.Guna2TextBox();
			guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			guna2Panel1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2Panel1.Controls.Add(label3);
			guna2Panel1.Controls.Add(guna2PictureBox2);
			guna2Panel1.Controls.Add(guna2Separator1);
			guna2Panel1.Controls.Add(pictureBox1);
			guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			guna2Panel1.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			guna2Panel1.ForeColor = System.Drawing.Color.LightGray;
			guna2Panel1.Location = new System.Drawing.Point(0, 0);
			guna2Panel1.Name = "guna2Panel1";
			guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
			guna2Panel1.Size = new System.Drawing.Size(588, 72);
			guna2Panel1.TabIndex = 147;
			guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label3.ForeColor = System.Drawing.Color.LightGray;
			label3.Location = new System.Drawing.Point(227, 23);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(131, 19);
			label3.TabIndex = 15;
			label3.Text = "NGROK PANEL";
			guna2PictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox2.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox2.Image");
			guna2PictureBox2.ImageRotate = 0f;
			guna2PictureBox2.Location = new System.Drawing.Point(547, 13);
			guna2PictureBox2.Name = "guna2PictureBox2";
			guna2PictureBox2.ShadowDecoration.Parent = guna2PictureBox2;
			guna2PictureBox2.Size = new System.Drawing.Size(29, 29);
			guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox2.TabIndex = 14;
			guna2PictureBox2.TabStop = false;
			guna2PictureBox2.UseTransparentBackground = true;
			guna2PictureBox2.Click += new System.EventHandler(guna2PictureBox2_Click);
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator1.Location = new System.Drawing.Point(-250, 66);
			guna2Separator1.Name = "guna2Separator1";
			guna2Separator1.Size = new System.Drawing.Size(1088, 11);
			guna2Separator1.TabIndex = 13;
			guna2Separator1.UseTransparentBackground = true;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(12, 13);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(40, 45);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 12;
			pictureBox1.TabStop = false;
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.TargetForm = this;
			label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			label2.AutoSize = true;
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.ForeColor = System.Drawing.Color.LightGray;
			label2.Location = new System.Drawing.Point(55, 119);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(52, 14);
			label2.TabIndex = 148;
			label2.Text = "Protocol:";
			label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			label9.AutoSize = true;
			label9.BackColor = System.Drawing.Color.Transparent;
			label9.ForeColor = System.Drawing.Color.LightGray;
			label9.Location = new System.Drawing.Point(55, 205);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(39, 14);
			label9.TabIndex = 150;
			label9.Text = "Token:";
			label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			label4.AutoSize = true;
			label4.BackColor = System.Drawing.Color.Transparent;
			label4.ForeColor = System.Drawing.Color.LightGray;
			label4.Location = new System.Drawing.Point(55, 162);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(31, 14);
			label4.TabIndex = 149;
			label4.Text = "Port:";
			btnStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnStop.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			btnStop.BorderThickness = 1;
			btnStop.CheckedState.Parent = btnStop;
			btnStop.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnStop.CustomImages.Parent = btnStop;
			btnStop.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			btnStop.DisabledState.CustomBorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
			btnStop.DisabledState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnStop.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnStop.DisabledState.ForeColor = System.Drawing.Color.DimGray;
			btnStop.DisabledState.Parent = btnStop;
			btnStop.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnStop.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
			btnStop.ForeColor = System.Drawing.Color.White;
			btnStop.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnStop.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnStop.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnStop.HoverState.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnStop.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnStop.HoverState.Parent = btnStop;
			btnStop.Location = new System.Drawing.Point(31, 263);
			btnStop.Name = "btnStop";
			btnStop.ShadowDecoration.Parent = btnStop;
			btnStop.Size = new System.Drawing.Size(182, 30);
			btnStop.TabIndex = 153;
			btnStop.Text = "Stop Listening";
			btnStop.Click += new System.EventHandler(btnStop_Click);
			btnStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnStart.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			btnStart.BorderThickness = 1;
			btnStart.CheckedState.Parent = btnStart;
			btnStart.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnStart.CustomImages.Parent = btnStart;
			btnStart.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			btnStart.DisabledState.CustomBorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
			btnStart.DisabledState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnStart.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnStart.DisabledState.ForeColor = System.Drawing.Color.DimGray;
			btnStart.DisabledState.Parent = btnStart;
			btnStart.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnStart.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
			btnStart.ForeColor = System.Drawing.Color.White;
			btnStart.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnStart.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnStart.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnStart.HoverState.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnStart.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnStart.HoverState.Parent = btnStart;
			btnStart.Location = new System.Drawing.Point(372, 263);
			btnStart.Name = "btnStart";
			btnStart.ShadowDecoration.Parent = btnStart;
			btnStart.Size = new System.Drawing.Size(182, 30);
			btnStart.TabIndex = 152;
			btnStart.Text = "Start";
			btnStart.Click += new System.EventHandler(btnStart_Click);
			txtProto.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			txtProto.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtProto.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtProto.DefaultText = "tcp/http";
			txtProto.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			txtProto.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			txtProto.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtProto.DisabledState.Parent = txtProto;
			txtProto.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtProto.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			txtProto.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtProto.FocusedState.Parent = txtProto;
			txtProto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtProto.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtProto.HoverState.Parent = txtProto;
			txtProto.Location = new System.Drawing.Point(134, 112);
			txtProto.Name = "txtProto";
			txtProto.PasswordChar = '\0';
			txtProto.PlaceholderText = "";
			txtProto.SelectedText = "";
			txtProto.SelectionStart = 8;
			txtProto.ShadowDecoration.Parent = txtProto;
			txtProto.Size = new System.Drawing.Size(397, 21);
			txtProto.TabIndex = 154;
			txtToken.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			txtToken.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtToken.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtToken.DefaultText = "2fVs59pGP7gKCHBT9xWtU_2cHWsqseBqouMyAKPiw1a";
			txtToken.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			txtToken.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			txtToken.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtToken.DisabledState.Parent = txtToken;
			txtToken.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txtToken.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			txtToken.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtToken.FocusedState.Parent = txtToken;
			txtToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f);
			txtToken.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			txtToken.HoverState.Parent = txtToken;
			txtToken.Location = new System.Drawing.Point(134, 198);
			txtToken.Name = "txtToken";
			txtToken.PasswordChar = '\0';
			txtToken.PlaceholderText = "";
			txtToken.SelectedText = "";
			txtToken.SelectionStart = 43;
			txtToken.ShadowDecoration.Parent = txtToken;
			txtToken.Size = new System.Drawing.Size(397, 21);
			txtToken.TabIndex = 155;
			ProxyPort.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			ProxyPort.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			ProxyPort.Cursor = System.Windows.Forms.Cursors.IBeam;
			ProxyPort.DefaultText = "3389";
			ProxyPort.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			ProxyPort.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			ProxyPort.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			ProxyPort.DisabledState.Parent = ProxyPort;
			ProxyPort.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			ProxyPort.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			ProxyPort.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			ProxyPort.FocusedState.Parent = ProxyPort;
			ProxyPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ProxyPort.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			ProxyPort.HoverState.Parent = ProxyPort;
			ProxyPort.Location = new System.Drawing.Point(134, 155);
			ProxyPort.Name = "ProxyPort";
			ProxyPort.PasswordChar = '\0';
			ProxyPort.PlaceholderText = "";
			ProxyPort.SelectedText = "";
			ProxyPort.SelectionStart = 4;
			ProxyPort.ShadowDecoration.Parent = ProxyPort;
			ProxyPort.Size = new System.Drawing.Size(397, 21);
			ProxyPort.TabIndex = 156;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(588, 323);
			base.Controls.Add(ProxyPort);
			base.Controls.Add(txtToken);
			base.Controls.Add(txtProto);
			base.Controls.Add(btnStop);
			base.Controls.Add(btnStart);
			base.Controls.Add(label2);
			base.Controls.Add(label9);
			base.Controls.Add(label4);
			base.Controls.Add(guna2Panel1);
			Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ForeColor = System.Drawing.Color.LightGray;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FrmNgrokPanel";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Ngrok Panel";
			base.Load += new System.EventHandler(FrmNgrokPanel_Load);
			guna2Panel1.ResumeLayout(false);
			guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
