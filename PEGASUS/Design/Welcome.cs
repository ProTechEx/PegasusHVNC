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

namespace PEGASUS.Design
{
	public class Welcome : Form
	{
		private IContainer components;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2Panel guna2Panel1;

		private Guna2Separator guna2Separator1;

		private PictureBox pictureBox1;

		private Label label1;

		private Guna2PictureBox guna2PictureBox7;

		private ToolTip toolTip1;

		private Label label2;

		private Guna2GradientButton btnIcon;

		public Welcome()
		{
			InitializeComponent();
		}

		private void guna2PictureBox1_Click(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/w2hVN45E");
		}

		private void guna2PictureBox2_Click(object sender, EventArgs e)
		{
			MsgBox.Show("SkynetCorporation@protonmail.com");
		}

		private void guna2PictureBox3_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.youtube.com/channel/UCd6mDeM9gLKOMlbUGynEUbQ");
		}

		private void guna2PictureBox4_Click(object sender, EventArgs e)
		{
		}

		private void guna2PictureBox5_Click(object sender, EventArgs e)
		{
			Process.Start("https://skynet-corporation.com/");
		}

		private void guna2PictureBox4_Click_1(object sender, EventArgs e)
		{
			Process.Start("https://t.me/joinchat/Izuv0GvwIOU3ZTNk");
		}

		private void guna2PictureBox7_Click(object sender, EventArgs e)
		{
			Close();
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

		public static void DeleteDirectory(string target_dir)
		{
			string[] files = Directory.GetFiles(target_dir);
			string[] directories = Directory.GetDirectories(target_dir);
			string[] array = files;
			foreach (string path in array)
			{
				File.SetAttributes(path, FileAttributes.Normal);
				File.Delete(path);
			}
			array = directories;
			for (int i = 0; i < array.Length; i++)
			{
				DeleteDirectory(array[i]);
			}
			Directory.Delete(target_dir, recursive: false);
		}

		private void btnIcon_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void Welcome_Load(object sender, EventArgs e)
		{
		}

		private void btnIcon_Click_1(object sender, EventArgs e)
		{
			Close();
		}

		private void guna2PictureBox1_Click_1(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			label1 = new System.Windows.Forms.Label();
			guna2PictureBox7 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			btnIcon = new Guna.UI2.WinForms.Guna2GradientButton();
			label2 = new System.Windows.Forms.Label();
			guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox7).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
			guna2BorderlessForm1.TransparentWhileDrag = true;
			guna2Panel1.Controls.Add(label1);
			guna2Panel1.Controls.Add(guna2PictureBox7);
			guna2Panel1.Controls.Add(guna2Separator1);
			guna2Panel1.Controls.Add(pictureBox1);
			guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			guna2Panel1.Location = new System.Drawing.Point(0, 0);
			guna2Panel1.Name = "guna2Panel1";
			guna2Panel1.Size = new System.Drawing.Size(800, 72);
			guna2Panel1.TabIndex = 15;
			guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.LightGray;
			label1.Location = new System.Drawing.Point(358, 25);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(77, 19);
			label1.TabIndex = 15;
			label1.Text = "UPDATE";
			guna2PictureBox7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox7.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox7.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox7.Image");
			guna2PictureBox7.ImageRotate = 0f;
			guna2PictureBox7.Location = new System.Drawing.Point(759, 13);
			guna2PictureBox7.Name = "guna2PictureBox7";
			guna2PictureBox7.Size = new System.Drawing.Size(29, 29);
			guna2PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox7.TabIndex = 14;
			guna2PictureBox7.TabStop = false;
			guna2PictureBox7.UseTransparentBackground = true;
			guna2PictureBox7.Click += new System.EventHandler(guna2PictureBox7_Click);
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator1.Location = new System.Drawing.Point(-250, 66);
			guna2Separator1.Name = "guna2Separator1";
			guna2Separator1.Size = new System.Drawing.Size(1300, 11);
			guna2Separator1.TabIndex = 13;
			guna2Separator1.UseTransparentBackground = true;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(12, 13);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(40, 45);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 12;
			pictureBox1.TabStop = false;
			toolTip1.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
			toolTip1.ForeColor = System.Drawing.Color.LightGray;
			toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			toolTip1.ToolTipTitle = "Skynet!";
			btnIcon.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
			btnIcon.BorderThickness = 1;
			btnIcon.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			btnIcon.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			btnIcon.DisabledState.CustomBorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
			btnIcon.DisabledState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnIcon.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnIcon.DisabledState.ForeColor = System.Drawing.Color.DimGray;
			btnIcon.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnIcon.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnIcon.Font = new System.Drawing.Font("Electrolize", 9f);
			btnIcon.ForeColor = System.Drawing.Color.White;
			btnIcon.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			btnIcon.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnIcon.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			btnIcon.HoverState.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
			btnIcon.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
			btnIcon.Location = new System.Drawing.Point(297, 415);
			btnIcon.Name = "btnIcon";
			btnIcon.Size = new System.Drawing.Size(182, 32);
			btnIcon.TabIndex = 131;
			btnIcon.Text = "ok";
			btnIcon.Click += new System.EventHandler(btnIcon_Click_1);
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Electrolize", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(173, 214);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(440, 90);
			label2.TabIndex = 132;
			label2.Text = resources.GetString("label2.Text");
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
			BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
			base.ClientSize = new System.Drawing.Size(800, 485);
			base.Controls.Add(label2);
			base.Controls.Add(btnIcon);
			base.Controls.Add(guna2Panel1);
			Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ForeColor = System.Drawing.Color.LightGray;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Welcome";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Welcome";
			base.TopMost = true;
			base.Load += new System.EventHandler(Welcome_Load);
			guna2Panel1.ResumeLayout(false);
			guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox7).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
