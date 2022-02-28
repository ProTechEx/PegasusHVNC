using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

internal class InputDialog : Form
{
	private const int CS_DROPSHADOW = 131072;

	protected string _txtInput;

	protected bool _txtPaintInvalidated;

	private IContainer components;

	private Guna2BorderlessForm guna2BorderlessForm1;

	private Guna2Panel guna2Panel1;

	private Guna2PictureBox guna2PictureBox1;

	private Guna2Separator guna2Separator1;

	private Guna2ShadowForm guna2ShadowForm1;

	private Label label3;

	protected Label lblMessage;

	private PictureBox pictureBox1;

	protected TextBox txtInput;

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams obj = base.CreateParams;
			obj.ClassStyle |= 131072;
			return obj;
		}
	}

	private InputDialog()
	{
		Panel panel = new Panel
		{
			Dock = DockStyle.Fill
		};
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			Dock = DockStyle.Fill
		};
		lblMessage = new Label();
		lblMessage.Font = new Font("Electrolize", 10f);
		lblMessage.ForeColor = Color.White;
		lblMessage.AutoSize = true;
		Panel panel2 = new Panel();
		panel2.BorderStyle = BorderStyle.None;
		panel2.Width = 360;
		panel2.Height = 28;
		panel2.Padding = new Padding(5);
		panel2.BackColor = Color.FromArgb(24, 24, 24);
		panel2.Margin = new Padding(0, 15, 0, 0);
		panel2.Paint += txtPl_Paint;
		txtInput = new TextBox();
		txtInput.Dock = DockStyle.Fill;
		txtInput.BorderStyle = BorderStyle.None;
		txtInput.Font = new Font("Electrolize", 9f);
		txtInput.KeyDown += txtInput_KeyDown;
		txtInput.BackColor = Color.FromArgb(30, 30, 30);
		txtInput.Multiline = true;
		txtInput.ForeColor = Color.White;
		panel2.Controls.Add(txtInput);
		FlowLayoutPanel flowLayoutPanel2 = new FlowLayoutPanel
		{
			Dock = DockStyle.Bottom,
			FlowDirection = FlowDirection.RightToLeft,
			Height = 35
		};
		Button button = new Button();
		button.Text = "Cancel";
		button.ForeColor = Color.White;
		button.Font = new Font("Electrolize", 8f);
		button.Padding = new Padding(3);
		button.FlatStyle = FlatStyle.Flat;
		button.Height = 30;
		button.Click += btnCancel_Click;
		Button button2 = new Button();
		button2.Text = "OK";
		button2.ForeColor = Color.White;
		button2.Font = new Font("Electrolize", 8f);
		button2.Padding = new Padding(3);
		button2.FlatStyle = FlatStyle.Flat;
		button2.Height = 30;
		button2.Click += btnOK_Click;
		flowLayoutPanel2.Controls.Add(button);
		flowLayoutPanel2.Controls.Add(button2);
		flowLayoutPanel.Controls.Add(lblMessage);
		flowLayoutPanel.SetFlowBreak(lblMessage, value: true);
		flowLayoutPanel.Controls.Add(panel2);
		flowLayoutPanel.SetFlowBreak(panel2, value: true);
		flowLayoutPanel.Controls.Add(flowLayoutPanel2);
		panel.Controls.Add(flowLayoutPanel);
		base.Controls.Add(panel);
		base.Controls.Add(flowLayoutPanel2);
		base.FormBorderStyle = FormBorderStyle.None;
		BackColor = Color.FromArgb(24, 24, 24);
		base.StartPosition = FormStartPosition.CenterScreen;
		base.Padding = new Padding(20);
		base.Width = 400;
		base.Height = 200;
	}

	private void txtInput_KeyDown(object sender, KeyEventArgs e)
	{
		TextBox textBox = (TextBox)sender;
		if (e.KeyCode == Keys.Return)
		{
			_txtInput = textBox.Text;
			Dispose();
			return;
		}
		if (textBox.Text.Length > 60)
		{
			textBox.Parent.Height = 80;
			if (!_txtPaintInvalidated)
			{
				textBox.Parent.Invalidate();
				_txtPaintInvalidated = true;
			}
		}
		if (textBox.Text.Length < 60)
		{
			textBox.Parent.Height = 28;
			if (_txtPaintInvalidated)
			{
				textBox.Parent.Invalidate();
				_txtPaintInvalidated = false;
			}
		}
	}

	private void txtPl_Paint(object sender, PaintEventArgs e)
	{
		Panel panel = (Panel)sender;
		base.OnPaint(e);
		Graphics graphics = e.Graphics;
		Rectangle rect = new Rectangle(new Point(0, 0), new Size(panel.Width - 1, panel.Height - 1));
		Pen pen = new Pen(Color.FromArgb(198, 25, 31))
		{
			Width = 3f
		};
		graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, 30, 30)), rect);
		graphics.DrawRectangle(pen, rect);
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Dispose();
	}

	private void btnOK_Click(object sender, EventArgs e)
	{
		_txtInput = txtInput.Text;
		Dispose();
	}

	public static string Show(string message)
	{
		InputDialog inputDialog = new InputDialog();
		inputDialog.lblMessage.Text = message;
		inputDialog.ShowDialog();
		return inputDialog._txtInput;
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		Graphics graphics = e.Graphics;
		Rectangle rect = new Rectangle(new Point(0, 0), new Size(base.Width - 1, base.Height - 1));
		Pen pen = new Pen(Color.FromArgb(198, 25, 31));
		graphics.DrawRectangle(pen, rect);
	}

	private void InitializeComponent()
	{
		components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputDialog));
		guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
		guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
		guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		label3 = new System.Windows.Forms.Label();
		guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
		guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
		guna2Panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		guna2Panel1.Controls.Add(guna2PictureBox1);
		guna2Panel1.Controls.Add(guna2Separator1);
		guna2Panel1.Controls.Add(pictureBox1);
		guna2Panel1.Controls.Add(label3);
		guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		guna2Panel1.Location = new System.Drawing.Point(0, 0);
		guna2Panel1.Name = "guna2Panel1";
		guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
		guna2Panel1.Size = new System.Drawing.Size(284, 67);
		guna2Panel1.TabIndex = 13;
		guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
		guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
		guna2PictureBox1.ImageRotate = 0f;
		guna2PictureBox1.Location = new System.Drawing.Point(243, 12);
		guna2PictureBox1.Name = "guna2PictureBox1";
		guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
		guna2PictureBox1.Size = new System.Drawing.Size(29, 31);
		guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		guna2PictureBox1.TabIndex = 115;
		guna2PictureBox1.TabStop = false;
		guna2PictureBox1.UseTransparentBackground = true;
		guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		guna2Separator1.BackColor = System.Drawing.Color.Transparent;
		guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
		guna2Separator1.Location = new System.Drawing.Point(-477, 61);
		guna2Separator1.Name = "guna2Separator1";
		guna2Separator1.Size = new System.Drawing.Size(1238, 10);
		guna2Separator1.TabIndex = 15;
		guna2Separator1.UseTransparentBackground = true;
		pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
		pictureBox1.Location = new System.Drawing.Point(15, 12);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(40, 42);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 14;
		pictureBox1.TabStop = false;
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.ForeColor = System.Drawing.Color.LightGray;
		label3.Location = new System.Drawing.Point(112, 20);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(52, 19);
		label3.TabIndex = 11;
		label3.Text = "Input";
		guna2BorderlessForm1.ContainerControl = this;
		guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(198, 25, 31);
		guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(198, 25, 31);
		guna2ShadowForm1.TargetForm = this;
		BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
		base.ClientSize = new System.Drawing.Size(284, 261);
		base.Controls.Add(guna2Panel1);
		ForeColor = System.Drawing.Color.LightGray;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "InputDialog";
		guna2Panel1.ResumeLayout(false);
		guna2Panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
	}

	private void guna2PictureBox1_Click(object sender, EventArgs e)
	{
		Close();
	}
}
