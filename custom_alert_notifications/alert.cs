using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.AnimatorNS;
using Guna.UI2.WinForms;

namespace custom_alert_notifications
{
	public class alert : Form
	{
		public enum AlertType
		{
			success,
			info,
			warnig,
			error
		}

		private int interval;

		private IContainer components;

		private ImageList imageList1;

		private Timer timeout;

		private Timer show;

		private Timer closealert;

		private Label message;

		private PictureBox icon;

		private Guna2VSeparator guna2VSeparator2;

		private Guna2VSeparator guna2VSeparator1;

		private Guna2Separator guna2Separator6;

		private Guna2Transition guna2Transition1;

		private Guna2AnimateWindow guna2AnimateWindow1;

		private Guna2Separator guna2Separator1;

		public alert(string _message, AlertType type)
		{
			InitializeComponent();
			message.Text = _message;
			switch (type)
			{
			case AlertType.success:
				BackColor = Color.FromArgb(22, 22, 22);
				icon.Image = imageList1.Images[1];
				break;
			case AlertType.info:
				BackColor = Color.Gray;
				icon.Image = imageList1.Images[1];
				break;
			case AlertType.warnig:
				BackColor = Color.Crimson;
				icon.Image = imageList1.Images[1];
				break;
			case AlertType.error:
				BackColor = Color.FromArgb(22, 22, 22);
				icon.Image = imageList1.Images[2];
				break;
			}
		}

		public static void Show(string message, AlertType type)
		{
			new alert(message, type).Show();
		}

		private void alert_Load(object sender, EventArgs e)
		{
			base.Top = -1 * base.Height;
			base.Left = Screen.PrimaryScreen.Bounds.Width - base.Width - 60;
			show.Start();
		}

		private void bunifuImageButton1_Click(object sender, EventArgs e)
		{
			closealert.Start();
		}

		private void timeout_Tick(object sender, EventArgs e)
		{
			closealert.Start();
		}

		private void show_Tick(object sender, EventArgs e)
		{
			if (base.Top < 60)
			{
				base.Top += interval;
				interval += 2;
			}
			else
			{
				show.Stop();
			}
		}

		private void close_Tick(object sender, EventArgs e)
		{
			if (base.Opacity > 0.0)
			{
				base.Opacity -= 0.2;
			}
			else
			{
				Close();
			}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(custom_alert_notifications.alert));
			Guna.UI2.AnimatorNS.Animation animation = new Guna.UI2.AnimatorNS.Animation();
			imageList1 = new System.Windows.Forms.ImageList(components);
			timeout = new System.Windows.Forms.Timer(components);
			show = new System.Windows.Forms.Timer(components);
			closealert = new System.Windows.Forms.Timer(components);
			message = new System.Windows.Forms.Label();
			icon = new System.Windows.Forms.PictureBox();
			guna2VSeparator1 = new Guna.UI2.WinForms.Guna2VSeparator();
			guna2VSeparator2 = new Guna.UI2.WinForms.Guna2VSeparator();
			guna2Separator6 = new Guna.UI2.WinForms.Guna2Separator();
			guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(components);
			guna2Transition1 = new Guna.UI2.WinForms.Guna2Transition();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			((System.ComponentModel.ISupportInitialize)icon).BeginInit();
			SuspendLayout();
			imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
			imageList1.TransparentColor = System.Drawing.Color.Transparent;
			imageList1.Images.SetKeyName(0, "84f.png");
			imageList1.Images.SetKeyName(1, "Remote Computer.png");
			timeout.Enabled = true;
			timeout.Interval = 5000;
			timeout.Tick += new System.EventHandler(timeout_Tick);
			show.Interval = 1;
			show.Tick += new System.EventHandler(show_Tick);
			closealert.Tick += new System.EventHandler(close_Tick);
			message.AutoSize = true;
			message.BackColor = System.Drawing.Color.Transparent;
			guna2Transition1.SetDecoration(message, Guna.UI2.AnimatorNS.DecorationType.None);
			message.Font = new System.Drawing.Font("Electrolize", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			message.ForeColor = System.Drawing.Color.White;
			message.Location = new System.Drawing.Point(123, 64);
			message.Name = "message";
			message.Size = new System.Drawing.Size(135, 18);
			message.TabIndex = 259;
			message.Text = "Success message ";
			icon.BackColor = System.Drawing.Color.Transparent;
			guna2Transition1.SetDecoration(icon, Guna.UI2.AnimatorNS.DecorationType.None);
			icon.Image = (System.Drawing.Image)resources.GetObject("icon.Image");
			icon.Location = new System.Drawing.Point(11, 39);
			icon.Name = "icon";
			icon.Size = new System.Drawing.Size(94, 105);
			icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			icon.TabIndex = 258;
			icon.TabStop = false;
			guna2VSeparator1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			guna2VSeparator1.BackColor = System.Drawing.Color.Transparent;
			guna2Transition1.SetDecoration(guna2VSeparator1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2VSeparator1.FillColor = System.Drawing.Color.FromArgb(182, 37, 32);
			guna2VSeparator1.Location = new System.Drawing.Point(-5, 3);
			guna2VSeparator1.Name = "guna2VSeparator1";
			guna2VSeparator1.Size = new System.Drawing.Size(10, 244);
			guna2VSeparator1.TabIndex = 262;
			guna2VSeparator2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			guna2VSeparator2.BackColor = System.Drawing.Color.Transparent;
			guna2Transition1.SetDecoration(guna2VSeparator2, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2VSeparator2.FillColor = System.Drawing.Color.FromArgb(182, 37, 32);
			guna2VSeparator2.Location = new System.Drawing.Point(504, 3);
			guna2VSeparator2.Name = "guna2VSeparator2";
			guna2VSeparator2.Size = new System.Drawing.Size(10, 244);
			guna2VSeparator2.TabIndex = 263;
			guna2Separator6.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator6.BackColor = System.Drawing.Color.Transparent;
			guna2Transition1.SetDecoration(guna2Separator6, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Separator6.FillColor = System.Drawing.Color.FromArgb(182, 37, 32);
			guna2Separator6.Location = new System.Drawing.Point(-5, 240);
			guna2Separator6.Name = "guna2Separator6";
			guna2Separator6.Size = new System.Drawing.Size(518, 10);
			guna2Separator6.TabIndex = 264;
			guna2Separator6.UseTransparentBackground = true;
			guna2Transition1.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Particles;
			guna2Transition1.Cursor = null;
			animation.AnimateOnlyDifferences = true;
			animation.BlindCoeff = (System.Drawing.PointF)resources.GetObject("animation1.BlindCoeff");
			animation.LeafCoeff = 0f;
			animation.MaxTime = 1f;
			animation.MinTime = 0f;
			animation.MosaicCoeff = (System.Drawing.PointF)resources.GetObject("animation1.MosaicCoeff");
			animation.MosaicShift = (System.Drawing.PointF)resources.GetObject("animation1.MosaicShift");
			animation.MosaicSize = 1;
			animation.Padding = new System.Windows.Forms.Padding(100, 50, 100, 150);
			animation.RotateCoeff = 0f;
			animation.RotateLimit = 0f;
			animation.ScaleCoeff = (System.Drawing.PointF)resources.GetObject("animation1.ScaleCoeff");
			animation.SlideCoeff = (System.Drawing.PointF)resources.GetObject("animation1.SlideCoeff");
			animation.TimeCoeff = 2f;
			animation.TransparencyCoeff = 0f;
			guna2Transition1.DefaultAnimation = animation;
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Transition1.SetDecoration(guna2Separator1, Guna.UI2.AnimatorNS.DecorationType.None);
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(182, 37, 32);
			guna2Separator1.Location = new System.Drawing.Point(-4, -5);
			guna2Separator1.Name = "guna2Separator1";
			guna2Separator1.Size = new System.Drawing.Size(518, 10);
			guna2Separator1.TabIndex = 265;
			guna2Separator1.UseTransparentBackground = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
			BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			base.ClientSize = new System.Drawing.Size(510, 246);
			base.Controls.Add(guna2Separator6);
			base.Controls.Add(guna2VSeparator2);
			base.Controls.Add(guna2VSeparator1);
			base.Controls.Add(message);
			base.Controls.Add(icon);
			base.Controls.Add(guna2Separator1);
			guna2Transition1.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
			ForeColor = System.Drawing.Color.White;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "alert";
			base.Opacity = 0.95;
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "alert";
			base.TopMost = true;
			base.Load += new System.EventHandler(alert_Load);
			((System.ComponentModel.ISupportInitialize)icon).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
