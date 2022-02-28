using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic;

namespace PEGASUS.Design
{
	public class DLLInjectionPanel : Form
	{
		private IContainer components;

		private Guna2Panel guna2Panel1;

		private Guna2Separator guna2Separator1;

		private PictureBox pictureBox1;

		private Label label1;

		private Guna2PictureBox guna2PictureBox1;

		private Guna2TabControl guna2TabControl1;

		private TabPage tabPage1;

		private TabPage tabPage2;

		private TabPage tabPage3;

		private TabPage tabPage4;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ShadowForm guna2ShadowForm1;

		private ListView managedListView;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader2;

		private ColumnHeader columnHeader5;

		private ListView unmanagedListView;

		private ColumnHeader columnHeader3;

		private ColumnHeader columnHeader4;

		private ListView shellCodeListView;

		private ColumnHeader columnHeader6;

		private ColumnHeader columnHeader7;

		private ListView listView1;

		private ColumnHeader columnHeader8;

		private ColumnHeader columnHeader9;

		private ContextMenuStrip managedContextMenuStrip;

		private ToolStripMenuItem addToolStripMenuItem;

		private ToolStripMenuItem removeToolStripMenuItem;

		private ToolStripMenuItem injectToolStripMenuItem;

		private ContextMenuStrip nativePEContextMenuStrip;

		private ToolStripMenuItem toolStripMenuItem4;

		private ToolStripMenuItem toolStripMenuItem5;

		private ToolStripMenuItem toolStripMenuItem6;

		private ContextMenuStrip shellCodeContextMenuStrip;

		private ToolStripMenuItem toolStripMenuItem1;

		private ToolStripMenuItem toolStripMenuItem2;

		private ToolStripMenuItem toolStripMenuItem3;

		private ContextMenuStrip unmanagedContextMenuStrip;

		private ToolStripMenuItem addToolStripMenuItem1;

		private ToolStripMenuItem removeToolStripMenuItem1;

		private ToolStripMenuItem injectToolStripMenuItem1;

		public string ClientHWID { get; set; }

		public string IP_Origin { get; set; }

		private void DLLInjectionPanel_Load(object sender, EventArgs e)
		{
		}

		public DLLInjectionPanel(string ClientHWID, string IP_Origin)
		{
			this.ClientHWID = ClientHWID;
			this.IP_Origin = IP_Origin;
			InitializeComponent();
		}

		private void ExecuteDllForm_Load(object sender, EventArgs e)
		{
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void maximizeButton_Click(object sender, EventArgs e)
		{
			if (base.WindowState == FormWindowState.Normal)
			{
				base.WindowState = FormWindowState.Maximized;
			}
			else
			{
				base.WindowState = FormWindowState.Normal;
			}
		}

		private void minimizeButton_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void addToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			ListViewItem listViewItem = new ListViewItem();
			using OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.DefaultExt = ".dll";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				listViewItem.Text = openFileDialog.FileName;
				listViewItem.SubItems.Add(Numeric2Bytes(new FileInfo(openFileDialog.FileName).Length));
				unmanagedListView.Items.Add(listViewItem);
			}
		}

		private static string ThreeNonZeroDigits(double value)
		{
			if (value >= 100.0)
			{
				return Strings.Format(Convert.ToInt32(value));
			}
			if (value >= 10.0)
			{
				return value.ToString("0.0");
			}
			return value.ToString("0.00");
		}

		public static string Numeric2Bytes(double b)
		{
			string result = null;
			string[] array = new string[9];
			int num = 0;
			array[0] = "Bytes";
			array[1] = "KB";
			array[2] = "MB";
			array[3] = "GB";
			array[4] = "TB";
			array[5] = "PB";
			array[6] = "EB";
			array[7] = "ZB";
			array[8] = "YB";
			double num2 = b;
			for (num = array.GetUpperBound(0); num >= 0; num--)
			{
				if (num2 >= Math.Pow(1024.0, num))
				{
					result = ThreeNonZeroDigits(num2 / Math.Pow(1024.0, num)) + " " + array[num];
					break;
				}
			}
			return result;
		}

		private void removeToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (unmanagedListView.SelectedItems.Count == 1)
			{
				unmanagedListView.SelectedItems[0].Remove();
			}
		}

		private void injectToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			_ = unmanagedListView.SelectedItems.Count;
			_ = 1;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DLLInjectionPanel));
			guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			label1 = new System.Windows.Forms.Label();
			guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			managedListView = new System.Windows.Forms.ListView();
			columnHeader1 = new System.Windows.Forms.ColumnHeader();
			columnHeader2 = new System.Windows.Forms.ColumnHeader();
			columnHeader5 = new System.Windows.Forms.ColumnHeader();
			tabPage2 = new System.Windows.Forms.TabPage();
			unmanagedListView = new System.Windows.Forms.ListView();
			columnHeader3 = new System.Windows.Forms.ColumnHeader();
			columnHeader4 = new System.Windows.Forms.ColumnHeader();
			tabPage3 = new System.Windows.Forms.TabPage();
			shellCodeListView = new System.Windows.Forms.ListView();
			columnHeader6 = new System.Windows.Forms.ColumnHeader();
			columnHeader7 = new System.Windows.Forms.ColumnHeader();
			tabPage4 = new System.Windows.Forms.TabPage();
			listView1 = new System.Windows.Forms.ListView();
			columnHeader8 = new System.Windows.Forms.ColumnHeader();
			columnHeader9 = new System.Windows.Forms.ColumnHeader();
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			managedContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
			addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			injectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			nativePEContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
			toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
			shellCodeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
			toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			unmanagedContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
			addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			injectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			guna2TabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
			tabPage3.SuspendLayout();
			tabPage4.SuspendLayout();
			managedContextMenuStrip.SuspendLayout();
			nativePEContextMenuStrip.SuspendLayout();
			shellCodeContextMenuStrip.SuspendLayout();
			unmanagedContextMenuStrip.SuspendLayout();
			SuspendLayout();
			guna2Panel1.Controls.Add(label1);
			guna2Panel1.Controls.Add(guna2Separator1);
			guna2Panel1.Controls.Add(guna2PictureBox1);
			guna2Panel1.Controls.Add(pictureBox1);
			guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			guna2Panel1.Location = new System.Drawing.Point(0, 0);
			guna2Panel1.Name = "guna2Panel1";
			guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
			guna2Panel1.Size = new System.Drawing.Size(800, 67);
			guna2Panel1.TabIndex = 15;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.LightGray;
			label1.Location = new System.Drawing.Point(363, 20);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(67, 19);
			label1.TabIndex = 17;
			label1.Text = "ABOUT";
			guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			guna2Separator1.BackColor = System.Drawing.Color.Transparent;
			guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
			guna2Separator1.Location = new System.Drawing.Point(-250, 61);
			guna2Separator1.Name = "guna2Separator1";
			guna2Separator1.Size = new System.Drawing.Size(1300, 10);
			guna2Separator1.TabIndex = 13;
			guna2Separator1.UseTransparentBackground = true;
			guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(759, 12);
			guna2PictureBox1.Name = "guna2PictureBox1";
			guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
			guna2PictureBox1.Size = new System.Drawing.Size(29, 27);
			guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox1.TabIndex = 16;
			guna2PictureBox1.TabStop = false;
			guna2PictureBox1.UseTransparentBackground = true;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(12, 12);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(40, 42);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 12;
			pictureBox1.TabStop = false;
			guna2TabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			guna2TabControl1.Controls.Add(tabPage1);
			guna2TabControl1.Controls.Add(tabPage2);
			guna2TabControl1.Controls.Add(tabPage3);
			guna2TabControl1.Controls.Add(tabPage4);
			guna2TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			guna2TabControl1.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			guna2TabControl1.ItemSize = new System.Drawing.Size(180, 40);
			guna2TabControl1.Location = new System.Drawing.Point(0, 67);
			guna2TabControl1.Name = "guna2TabControl1";
			guna2TabControl1.SelectedIndex = 0;
			guna2TabControl1.Size = new System.Drawing.Size(800, 383);
			guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
			guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2TabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			guna2TabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
			guna2TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2TabControl1.TabButtonIdleState.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			guna2TabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(156, 160, 167);
			guna2TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
			guna2TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2TabControl1.TabButtonSelectedState.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			guna2TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.LightGray;
			guna2TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(191, 38, 33);
			guna2TabControl1.TabButtonSize = new System.Drawing.Size(180, 40);
			guna2TabControl1.TabIndex = 16;
			guna2TabControl1.TabMenuBackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2TabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalBottom;
			tabPage1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			tabPage1.Controls.Add(managedListView);
			tabPage1.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tabPage1.Location = new System.Drawing.Point(4, 4);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new System.Windows.Forms.Padding(3);
			tabPage1.Size = new System.Drawing.Size(792, 335);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Managed DLLs";
			managedListView.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			managedListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			managedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[3] { columnHeader1, columnHeader2, columnHeader5 });
			managedListView.Dock = System.Windows.Forms.DockStyle.Fill;
			managedListView.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			managedListView.HideSelection = false;
			managedListView.Location = new System.Drawing.Point(3, 3);
			managedListView.Name = "managedListView";
			managedListView.Size = new System.Drawing.Size(786, 329);
			managedListView.TabIndex = 1;
			managedListView.UseCompatibleStateImageBehavior = false;
			managedListView.View = System.Windows.Forms.View.Details;
			columnHeader1.Text = "Path";
			columnHeader1.Width = 350;
			columnHeader2.Text = "Entrypoint";
			columnHeader2.Width = 204;
			columnHeader5.Text = "Size";
			tabPage2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			tabPage2.Controls.Add(unmanagedListView);
			tabPage2.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tabPage2.Location = new System.Drawing.Point(4, 4);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new System.Windows.Forms.Padding(3);
			tabPage2.Size = new System.Drawing.Size(792, 335);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "Native DLLs";
			unmanagedListView.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			unmanagedListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			unmanagedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { columnHeader3, columnHeader4 });
			unmanagedListView.Dock = System.Windows.Forms.DockStyle.Fill;
			unmanagedListView.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			unmanagedListView.HideSelection = false;
			unmanagedListView.Location = new System.Drawing.Point(3, 3);
			unmanagedListView.Name = "unmanagedListView";
			unmanagedListView.Size = new System.Drawing.Size(786, 329);
			unmanagedListView.TabIndex = 2;
			unmanagedListView.UseCompatibleStateImageBehavior = false;
			unmanagedListView.View = System.Windows.Forms.View.Details;
			columnHeader3.Text = "Path";
			columnHeader3.Width = 528;
			columnHeader4.Text = "Size";
			columnHeader4.Width = 204;
			tabPage3.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			tabPage3.Controls.Add(shellCodeListView);
			tabPage3.Location = new System.Drawing.Point(4, 4);
			tabPage3.Name = "tabPage3";
			tabPage3.Padding = new System.Windows.Forms.Padding(3);
			tabPage3.Size = new System.Drawing.Size(792, 335);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "ShellCode Files";
			shellCodeListView.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			shellCodeListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			shellCodeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { columnHeader6, columnHeader7 });
			shellCodeListView.Dock = System.Windows.Forms.DockStyle.Fill;
			shellCodeListView.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			shellCodeListView.HideSelection = false;
			shellCodeListView.Location = new System.Drawing.Point(3, 3);
			shellCodeListView.Name = "shellCodeListView";
			shellCodeListView.Size = new System.Drawing.Size(786, 329);
			shellCodeListView.TabIndex = 3;
			shellCodeListView.UseCompatibleStateImageBehavior = false;
			shellCodeListView.View = System.Windows.Forms.View.Details;
			columnHeader6.Text = "Path";
			columnHeader6.Width = 528;
			columnHeader7.Text = "Size";
			columnHeader7.Width = 204;
			tabPage4.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			tabPage4.Controls.Add(listView1);
			tabPage4.Location = new System.Drawing.Point(4, 4);
			tabPage4.Name = "tabPage4";
			tabPage4.Padding = new System.Windows.Forms.Padding(3);
			tabPage4.Size = new System.Drawing.Size(792, 335);
			tabPage4.TabIndex = 3;
			tabPage4.Text = "Native PE";
			listView1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { columnHeader8, columnHeader9 });
			listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			listView1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			listView1.HideSelection = false;
			listView1.Location = new System.Drawing.Point(3, 3);
			listView1.Name = "listView1";
			listView1.Size = new System.Drawing.Size(786, 329);
			listView1.TabIndex = 3;
			listView1.UseCompatibleStateImageBehavior = false;
			listView1.View = System.Windows.Forms.View.Details;
			columnHeader8.Text = "Path";
			columnHeader8.Width = 528;
			columnHeader9.Text = "Size";
			columnHeader9.Width = 204;
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
			guna2ShadowForm1.TargetForm = this;
			managedContextMenuStrip.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			managedContextMenuStrip.Font = new System.Drawing.Font("Electrolize", 8.249999f);
			managedContextMenuStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
			managedContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { addToolStripMenuItem, removeToolStripMenuItem, injectToolStripMenuItem });
			managedContextMenuStrip.Name = "managedContextMenuStrip";
			managedContextMenuStrip.ShowImageMargin = false;
			managedContextMenuStrip.Size = new System.Drawing.Size(89, 70);
			addToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			addToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			addToolStripMenuItem.Name = "addToolStripMenuItem";
			addToolStripMenuItem.Size = new System.Drawing.Size(88, 22);
			addToolStripMenuItem.Text = "Add";
			removeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			removeToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			removeToolStripMenuItem.Size = new System.Drawing.Size(88, 22);
			removeToolStripMenuItem.Text = "Remove";
			injectToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			injectToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
			injectToolStripMenuItem.Name = "injectToolStripMenuItem";
			injectToolStripMenuItem.Size = new System.Drawing.Size(88, 22);
			injectToolStripMenuItem.Text = "Inject";
			nativePEContextMenuStrip.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			nativePEContextMenuStrip.Font = new System.Drawing.Font("Electrolize", 8.249999f);
			nativePEContextMenuStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
			nativePEContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { toolStripMenuItem4, toolStripMenuItem5, toolStripMenuItem6 });
			nativePEContextMenuStrip.Name = "contextMenuStrip1";
			nativePEContextMenuStrip.ShowImageMargin = false;
			nativePEContextMenuStrip.Size = new System.Drawing.Size(89, 70);
			toolStripMenuItem4.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem4.Font = new System.Drawing.Font("Electrolize", 8.249999f);
			toolStripMenuItem4.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem4.Name = "toolStripMenuItem4";
			toolStripMenuItem4.Size = new System.Drawing.Size(88, 22);
			toolStripMenuItem4.Text = "Add";
			toolStripMenuItem5.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem5.Font = new System.Drawing.Font("Electrolize", 8.249999f);
			toolStripMenuItem5.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem5.Name = "toolStripMenuItem5";
			toolStripMenuItem5.Size = new System.Drawing.Size(88, 22);
			toolStripMenuItem5.Text = "Remove";
			toolStripMenuItem6.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem6.Font = new System.Drawing.Font("Electrolize", 8.249999f);
			toolStripMenuItem6.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem6.Name = "toolStripMenuItem6";
			toolStripMenuItem6.Size = new System.Drawing.Size(88, 22);
			toolStripMenuItem6.Text = "Inject";
			shellCodeContextMenuStrip.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			shellCodeContextMenuStrip.Font = new System.Drawing.Font("Electrolize", 8.249999f);
			shellCodeContextMenuStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
			shellCodeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { toolStripMenuItem1, toolStripMenuItem2, toolStripMenuItem3 });
			shellCodeContextMenuStrip.Name = "contextMenuStrip1";
			shellCodeContextMenuStrip.ShowImageMargin = false;
			shellCodeContextMenuStrip.Size = new System.Drawing.Size(89, 70);
			toolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem1.Font = new System.Drawing.Font("Electrolize", 8.249999f);
			toolStripMenuItem1.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			toolStripMenuItem1.Size = new System.Drawing.Size(88, 22);
			toolStripMenuItem1.Text = "Add";
			toolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem2.Font = new System.Drawing.Font("Electrolize", 8.249999f);
			toolStripMenuItem2.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem2.Name = "toolStripMenuItem2";
			toolStripMenuItem2.Size = new System.Drawing.Size(88, 22);
			toolStripMenuItem2.Text = "Remove";
			toolStripMenuItem3.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem3.Font = new System.Drawing.Font("Electrolize", 8.249999f);
			toolStripMenuItem3.ForeColor = System.Drawing.Color.LightGray;
			toolStripMenuItem3.Name = "toolStripMenuItem3";
			toolStripMenuItem3.Size = new System.Drawing.Size(88, 22);
			toolStripMenuItem3.Text = "Inject";
			unmanagedContextMenuStrip.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			unmanagedContextMenuStrip.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			unmanagedContextMenuStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
			unmanagedContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { addToolStripMenuItem1, removeToolStripMenuItem1, injectToolStripMenuItem1 });
			unmanagedContextMenuStrip.Name = "contextMenuStrip1";
			unmanagedContextMenuStrip.ShowImageMargin = false;
			unmanagedContextMenuStrip.Size = new System.Drawing.Size(156, 92);
			addToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			addToolStripMenuItem1.Font = new System.Drawing.Font("Electrolize", 8.249999f);
			addToolStripMenuItem1.ForeColor = System.Drawing.Color.LightGray;
			addToolStripMenuItem1.Name = "addToolStripMenuItem1";
			addToolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
			addToolStripMenuItem1.Text = "Add";
			addToolStripMenuItem1.Click += new System.EventHandler(addToolStripMenuItem1_Click);
			removeToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			removeToolStripMenuItem1.Font = new System.Drawing.Font("Electrolize", 8.249999f);
			removeToolStripMenuItem1.ForeColor = System.Drawing.Color.LightGray;
			removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
			removeToolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
			removeToolStripMenuItem1.Text = "Remove";
			removeToolStripMenuItem1.Click += new System.EventHandler(removeToolStripMenuItem1_Click);
			injectToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			injectToolStripMenuItem1.Font = new System.Drawing.Font("Electrolize", 8.249999f);
			injectToolStripMenuItem1.ForeColor = System.Drawing.Color.LightGray;
			injectToolStripMenuItem1.Name = "injectToolStripMenuItem1";
			injectToolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
			injectToolStripMenuItem1.Text = "Inject";
			injectToolStripMenuItem1.Click += new System.EventHandler(injectToolStripMenuItem1_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(800, 450);
			base.Controls.Add(guna2TabControl1);
			base.Controls.Add(guna2Panel1);
			ForeColor = System.Drawing.Color.LightGray;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "DLLInjectionPanel";
			Text = "DLLInjectionPanel";
			base.Load += new System.EventHandler(DLLInjectionPanel_Load);
			guna2Panel1.ResumeLayout(false);
			guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			guna2TabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage2.ResumeLayout(false);
			tabPage3.ResumeLayout(false);
			tabPage4.ResumeLayout(false);
			managedContextMenuStrip.ResumeLayout(false);
			nativePEContextMenuStrip.ResumeLayout(false);
			shellCodeContextMenuStrip.ResumeLayout(false);
			unmanagedContextMenuStrip.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
