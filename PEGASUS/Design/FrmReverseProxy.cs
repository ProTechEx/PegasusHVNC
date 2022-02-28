using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PEGASUS.Diadyktio;
using PEGASUS.IcarusWings;
using PEGASUS.Properties;

namespace PEGASUS.Design
{
	public class FrmReverseProxy : Form
	{
		private static readonly string[] Sizes = new string[6] { "B", "KB", "MB", "GB", "TB", "PB" };

		private readonly Clients[] _clients;

		private ReverseProxyClient[] _openConnections;

		private IContainer components;

		private Label lblLocalServerPort;

		private TabControl tabCtrl;

		private TabPage tabPage1;

		private AeroListView lstConnections;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader2;

		private ColumnHeader columnHeader3;

		private ColumnHeader columnHeader4;

		private ColumnHeader columnHeader5;

		private Label lblProxyInfo;

		private ContextMenuStrip contextMenuStrip;

		private ToolStripMenuItem killConnectionToolStripMenuItem;

		private ColumnHeader columnHeader6;

		private ColumnHeader columnHeader7;

		private Label label1;

		private Label lblLoadBalance;

		private Guna2ShadowForm guna2ShadowForm1;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2GradientButton btnStop;

		private Guna2GradientButton btnStart;

		private Guna2NumericUpDown nudServerPort;

		private Guna2Panel guna2Panel1;

		private Guna2Separator guna2Separator1;

		private PictureBox pictureBox1;

		private Label label3;

		private Guna2PictureBox guna2PictureBox2;

		private Guna2ContextMenuStrip guna2ContextMenuStrip2;

		private ToolStripMenuItem toolStripMenuItem70;

		public PEGASUS_M F { get; set; }

		public FrmReverseProxy(Clients[] clients)
		{
			_clients = clients;
			RegisterMessageHandler();
			InitializeComponent();
		}

		private void RegisterMessageHandler()
		{
		}

		private void UnregisterMessageHandler()
		{
		}

		private void ClientDisconnected(Clients client, bool connected)
		{
			if (!connected)
			{
				Invoke(new MethodInvoker(base.Close));
			}
		}

		private void FrmReverseProxy_Load(object sender, EventArgs e)
		{
			if (_clients.Length > 1)
			{
				Text = "Reverse Proxy [Load-Balancer is active]";
				lblLoadBalance.Text = "The Load Balancer is active, " + _clients.Length + " clients will be used as proxy\r\nKeep refreshing at www.ipchicken.com to see if your ip address will keep changing, if so, it works";
			}
			else if (_clients.Length == 1)
			{
				lblLoadBalance.Text = "The Load Balancer is not active, only 1 client is used, select multiple clients to activate the load balancer";
			}
			nudServerPort.Value = global::PEGASUS.Properties.Settings.Default.ReverseProxyPort;
		}

		private void FrmReverseProxy_FormClosing(object sender, FormClosingEventArgs e)
		{
			global::PEGASUS.Properties.Settings.Default.ReverseProxyPort = GetPortSafe();
			UnregisterMessageHandler();
		}

		private void ConnectionChanged(object sender, ReverseProxyClient[] proxyClients)
		{
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			try
			{
				if (GetPortSafe() == 0)
				{
					MessageBox.Show("Please enter a valid port > 0.", "Please enter a valid port", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					ToggleConfigurationButtons(started: true);
				}
			}
			catch (SocketException ex)
			{
				if (ex.ErrorCode == 10048)
				{
					MessageBox.Show("The port is already in use.", "Listen Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					MessageBox.Show($"An unexpected socket error occurred: {ex.Message}\n\nError Code: {ex.ErrorCode}", "Unexpected Listen Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			catch (Exception ex2)
			{
				MessageBox.Show("An unexpected error occurred: " + ex2.Message, "Unexpected Listen Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private ushort GetPortSafe()
		{
			if (ushort.TryParse(nudServerPort.Value.ToString(CultureInfo.InvariantCulture), out var result))
			{
				return result;
			}
			return 0;
		}

		private void ToggleConfigurationButtons(bool started)
		{
			btnStart.Enabled = !started;
			nudServerPort.Enabled = !started;
			btnStop.Enabled = started;
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			ToggleConfigurationButtons(started: false);
		}

		private void nudServerPort_ValueChanged(object sender, EventArgs e)
		{
			lblProxyInfo.Text = $"Connect to this SOCKS5 Proxy: 127.0.0.1:{nudServerPort.Value} (no user/pass)";
		}

		private void LvConnections_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
		{
		}

		public static string GetHumanReadableFileSize(long size)
		{
			double num = size;
			int num2 = 0;
			while (num >= 1024.0 && num2 + 1 < Sizes.Length)
			{
				num2++;
				num /= 1024.0;
			}
			return $"{num:0.##} {Sizes[num2]}";
		}

		private void killConnectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReverseProxy));
			lblLocalServerPort = new System.Windows.Forms.Label();
			tabCtrl = new System.Windows.Forms.TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			lstConnections = new IcarusWings.AeroListView();
			columnHeader6 = new System.Windows.Forms.ColumnHeader();
			columnHeader7 = new System.Windows.Forms.ColumnHeader();
			columnHeader1 = new System.Windows.Forms.ColumnHeader();
			columnHeader2 = new System.Windows.Forms.ColumnHeader();
			columnHeader3 = new System.Windows.Forms.ColumnHeader();
			columnHeader4 = new System.Windows.Forms.ColumnHeader();
			columnHeader5 = new System.Windows.Forms.ColumnHeader();
			contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
			killConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			lblProxyInfo = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			lblLoadBalance = new System.Windows.Forms.Label();
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			btnStart = new Guna.UI2.WinForms.Guna2GradientButton();
			btnStop = new Guna.UI2.WinForms.Guna2GradientButton();
			nudServerPort = new Guna.UI2.WinForms.Guna2NumericUpDown();
			guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			label3 = new System.Windows.Forms.Label();
			guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			guna2ContextMenuStrip2 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
			toolStripMenuItem70 = new System.Windows.Forms.ToolStripMenuItem();
			tabCtrl.SuspendLayout();
			tabPage1.SuspendLayout();
			contextMenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudServerPort).BeginInit();
			guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			guna2ContextMenuStrip2.SuspendLayout();
			SuspendLayout();
			lblLocalServerPort.AutoSize = true;
			lblLocalServerPort.Location = new System.Drawing.Point(300, 443);
			lblLocalServerPort.Name = "lblLocalServerPort";
			lblLocalServerPort.Size = new System.Drawing.Size(98, 14);
			lblLocalServerPort.TabIndex = 1;
			lblLocalServerPort.Text = "Local Server Port:";
			tabCtrl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			tabCtrl.Controls.Add(tabPage1);
			tabCtrl.Location = new System.Drawing.Point(12, 73);
			tabCtrl.Name = "tabCtrl";
			tabCtrl.SelectedIndex = 0;
			tabCtrl.Size = new System.Drawing.Size(753, 292);
			tabCtrl.TabIndex = 3;
			tabPage1.Controls.Add(lstConnections);
			tabPage1.Location = new System.Drawing.Point(4, 23);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new System.Windows.Forms.Padding(3);
			tabPage1.Size = new System.Drawing.Size(745, 265);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Open Connections";
			tabPage1.UseVisualStyleBackColor = true;
			lstConnections.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			lstConnections.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lstConnections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[7] { columnHeader6, columnHeader7, columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
			lstConnections.ContextMenuStrip = contextMenuStrip;
			lstConnections.Dock = System.Windows.Forms.DockStyle.Fill;
			lstConnections.ForeColor = System.Drawing.Color.LightGray;
			lstConnections.FullRowSelect = true;
			lstConnections.HideSelection = false;
			lstConnections.Location = new System.Drawing.Point(3, 3);
			lstConnections.Name = "lstConnections";
			lstConnections.Size = new System.Drawing.Size(739, 259);
			lstConnections.TabIndex = 0;
			lstConnections.UseCompatibleStateImageBehavior = false;
			lstConnections.View = System.Windows.Forms.View.Details;
			lstConnections.VirtualMode = true;
			lstConnections.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(LvConnections_RetrieveVirtualItem);
			columnHeader6.Text = "Client IP";
			columnHeader6.Width = 106;
			columnHeader7.Text = "Client Country";
			columnHeader7.Width = 106;
			columnHeader1.Text = "Target Server";
			columnHeader1.Width = 135;
			columnHeader2.Text = "Target Port";
			columnHeader2.Width = 68;
			columnHeader3.Text = "Total Received";
			columnHeader3.Width = 105;
			columnHeader4.Text = "Total Sent";
			columnHeader4.Width = 95;
			columnHeader5.Text = "Proxy Type";
			columnHeader5.Width = 90;
			contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { killConnectionToolStripMenuItem });
			contextMenuStrip.Name = "contextMenuStrip1";
			contextMenuStrip.Size = new System.Drawing.Size(156, 26);
			killConnectionToolStripMenuItem.Name = "killConnectionToolStripMenuItem";
			killConnectionToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			killConnectionToolStripMenuItem.Text = "Kill Connection";
			killConnectionToolStripMenuItem.Click += new System.EventHandler(killConnectionToolStripMenuItem_Click);
			lblProxyInfo.AutoSize = true;
			lblProxyInfo.Location = new System.Drawing.Point(207, 368);
			lblProxyInfo.Name = "lblProxyInfo";
			lblProxyInfo.Size = new System.Drawing.Size(314, 14);
			lblProxyInfo.TabIndex = 5;
			lblProxyInfo.Text = "Connect to this SOCKS5 Proxy: 127.0.0.1:3128 (no user/pass)";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(207, 384);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(401, 14);
			label1.TabIndex = 6;
			label1.Text = "All the DNS Queries will be executed at the remote client to reduce DNS Leaks";
			lblLoadBalance.AutoSize = true;
			lblLoadBalance.Location = new System.Drawing.Point(207, 401);
			lblLoadBalance.Name = "lblLoadBalance";
			lblLoadBalance.Size = new System.Drawing.Size(102, 14);
			lblLoadBalance.TabIndex = 7;
			lblLoadBalance.Text = "[Load Balance Info]";
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.TargetForm = this;
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
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
			btnStart.Location = new System.Drawing.Point(33, 460);
			btnStart.Name = "btnStart";
			btnStart.ShadowDecoration.Parent = btnStart;
			btnStart.Size = new System.Drawing.Size(182, 30);
			btnStart.TabIndex = 125;
			btnStart.Text = "Start Listening";
			btnStart.Click += new System.EventHandler(btnStart_Click);
			btnStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
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
			btnStop.Location = new System.Drawing.Point(573, 460);
			btnStop.Name = "btnStop";
			btnStop.ShadowDecoration.Parent = btnStop;
			btnStop.Size = new System.Drawing.Size(182, 30);
			btnStop.TabIndex = 126;
			btnStop.Text = "Stop Listening";
			btnStop.Click += new System.EventHandler(btnStop_Click);
			nudServerPort.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			nudServerPort.BackColor = System.Drawing.Color.Transparent;
			nudServerPort.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
			nudServerPort.Cursor = System.Windows.Forms.Cursors.IBeam;
			nudServerPort.DisabledState.Parent = nudServerPort;
			nudServerPort.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			nudServerPort.FocusedState.Parent = nudServerPort;
			nudServerPort.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			nudServerPort.ForeColor = System.Drawing.Color.LightGray;
			nudServerPort.Location = new System.Drawing.Point(303, 460);
			nudServerPort.Maximum = new decimal(new int[4] { 65534, 0, 0, 0 });
			nudServerPort.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			nudServerPort.Name = "nudServerPort";
			nudServerPort.ShadowDecoration.Parent = nudServerPort;
			nudServerPort.Size = new System.Drawing.Size(182, 30);
			nudServerPort.TabIndex = 143;
			nudServerPort.UpDownButtonFillColor = System.Drawing.Color.FromArgb(191, 37, 33);
			nudServerPort.UpDownButtonForeColor = System.Drawing.Color.White;
			nudServerPort.Value = new decimal(new int[4] { 3128, 0, 0, 0 });
			guna2Panel1.Controls.Add(label3);
			guna2Panel1.Controls.Add(guna2PictureBox2);
			guna2Panel1.Controls.Add(guna2Separator1);
			guna2Panel1.Controls.Add(pictureBox1);
			guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			guna2Panel1.Location = new System.Drawing.Point(0, 0);
			guna2Panel1.Name = "guna2Panel1";
			guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
			guna2Panel1.Size = new System.Drawing.Size(777, 67);
			guna2Panel1.TabIndex = 146;
			guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label3.ForeColor = System.Drawing.Color.LightGray;
			label3.Location = new System.Drawing.Point(311, 20);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(150, 19);
			label3.TabIndex = 15;
			label3.Text = "REVERSE PROXY";
			guna2PictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox2.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox2.Image");
			guna2PictureBox2.ImageRotate = 0f;
			guna2PictureBox2.Location = new System.Drawing.Point(736, 12);
			guna2PictureBox2.Name = "guna2PictureBox2";
			guna2PictureBox2.ShadowDecoration.Parent = guna2PictureBox2;
			guna2PictureBox2.Size = new System.Drawing.Size(29, 27);
			guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox2.TabIndex = 14;
			guna2PictureBox2.TabStop = false;
			guna2PictureBox2.UseTransparentBackground = true;
			guna2PictureBox2.Click += new System.EventHandler(guna2PictureBox2_Click);
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator1.Location = new System.Drawing.Point(-250, 61);
			guna2Separator1.Name = "guna2Separator1";
			guna2Separator1.Size = new System.Drawing.Size(1277, 10);
			guna2Separator1.TabIndex = 13;
			guna2Separator1.UseTransparentBackground = true;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(12, 12);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(40, 42);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 12;
			pictureBox1.TabStop = false;
			guna2ContextMenuStrip2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2ContextMenuStrip2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			guna2ContextMenuStrip2.ImageScalingSize = new System.Drawing.Size(29, 29);
			guna2ContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { toolStripMenuItem70 });
			guna2ContextMenuStrip2.Margin = new System.Windows.Forms.Padding(3);
			guna2ContextMenuStrip2.Name = "guna2ContextMenuStrip1";
			guna2ContextMenuStrip2.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ContextMenuStrip2.RenderStyle.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2ContextMenuStrip2.RenderStyle.ColorTable = null;
			guna2ContextMenuStrip2.RenderStyle.RoundedEdges = true;
			guna2ContextMenuStrip2.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
			guna2ContextMenuStrip2.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ContextMenuStrip2.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
			guna2ContextMenuStrip2.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
			guna2ContextMenuStrip2.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			guna2ContextMenuStrip2.Size = new System.Drawing.Size(188, 40);
			toolStripMenuItem70.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem70.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem70.Image");
			toolStripMenuItem70.Name = "toolStripMenuItem70";
			toolStripMenuItem70.Size = new System.Drawing.Size(187, 36);
			toolStripMenuItem70.Text = "      Kill Connection";
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(777, 511);
			base.Controls.Add(guna2Panel1);
			base.Controls.Add(nudServerPort);
			base.Controls.Add(btnStop);
			base.Controls.Add(btnStart);
			base.Controls.Add(lblLoadBalance);
			base.Controls.Add(label1);
			base.Controls.Add(lblProxyInfo);
			base.Controls.Add(tabCtrl);
			base.Controls.Add(lblLocalServerPort);
			Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ForeColor = System.Drawing.Color.LightGray;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FrmReverseProxy";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Reverse Proxy []";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FrmReverseProxy_FormClosing);
			base.Load += new System.EventHandler(FrmReverseProxy_Load);
			tabCtrl.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			contextMenuStrip.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)nudServerPort).EndInit();
			guna2Panel1.ResumeLayout(false);
			guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			guna2ContextMenuStrip2.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
