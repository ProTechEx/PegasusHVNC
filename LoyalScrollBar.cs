using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

[DefaultEvent("Scroll")]
internal class LoyalScrollBar : Control
{
	public delegate void ScrollEventHandler(object sender);

	private readonly int buttonSize = 16;

	private readonly int thumbSize = 24;

	private Rectangle TSA;

	private Rectangle BSA;

	private Rectangle Shaft;

	private Rectangle Thumb;

	private bool _showThumb;

	private bool _thumbDown;

	private int I1;

	private int _minimum;

	private int _maximum = 100;

	private int _value;

	private int _smallChange = 1;

	private int _largeChange = 10;

	private Color _backColor = Color.FromArgb(31, 31, 31);

	private Color _arrowColor = Color.FromArgb(51, 51, 51);

	private Color _scrollColor = Color.FromArgb(41, 41, 41);

	private Color _borderColor = Color.FromArgb(18, 18, 18);

	public int Minimum
	{
		get
		{
			return _minimum;
		}
		set
		{
			if (value < 0)
			{
				throw new Exception("Property value is not valid.");
			}
			_minimum = value;
			if (value > _value)
			{
				_value = value;
			}
			if (value > _maximum)
			{
				_maximum = value;
			}
			InvalidateLayout();
		}
	}

	public int Maximum
	{
		get
		{
			return _maximum;
		}
		set
		{
			if (value < 1)
			{
				value = 1;
			}
			_maximum = value;
			if (value < _value)
			{
				_value = value;
			}
			if (value < _minimum)
			{
				_minimum = value;
			}
			InvalidateLayout();
		}
	}

	public int Value
	{
		get
		{
			if (!_showThumb)
			{
				return _minimum;
			}
			return _value;
		}
		set
		{
			if (value != _value)
			{
				if (value > _maximum || value < _minimum)
				{
					throw new Exception("Property value is not valid.");
				}
				_value = value;
				InvalidatePosition();
				if (this.Scroll != null)
				{
					this.Scroll(this);
				}
			}
		}
	}

	public double Percent
	{
		get
		{
			if (!_showThumb)
			{
				return 0.0;
			}
			return GetProgress();
		}
	}

	public int SmallChange
	{
		get
		{
			return _smallChange;
		}
		set
		{
			if (value < 1)
			{
				throw new Exception("Property value is not valid.");
			}
			_smallChange = value;
		}
	}

	public int LargeChange
	{
		get
		{
			return _largeChange;
		}
		set
		{
			if (value < 1)
			{
				throw new Exception("Property value is not valid.");
			}
			_largeChange = value;
		}
	}

	[Category("Colors")]
	public override Color BackColor
	{
		get
		{
			return _backColor;
		}
		set
		{
			_backColor = value;
			Invalidate();
		}
	}

	[Category("Colors")]
	public Color ArrowColor
	{
		get
		{
			return _arrowColor;
		}
		set
		{
			_arrowColor = value;
			Invalidate();
		}
	}

	[Category("Colors")]
	public Color ScrollColor
	{
		get
		{
			return _scrollColor;
		}
		set
		{
			_scrollColor = value;
			Invalidate();
		}
	}

	[Category("Colors")]
	public Color BorderColor
	{
		get
		{
			return _borderColor;
		}
		set
		{
			_borderColor = value;
			Invalidate();
		}
	}

	public event ScrollEventHandler Scroll;

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		Graphics graphics = e.Graphics;
		graphics.Clear(_backColor);
		GraphicsPath path = DrawArrow(4, 6, flip: false);
		GraphicsPath path2 = DrawArrow(4, base.Height - 10, flip: true);
		graphics.FillPath(new SolidBrush(_arrowColor), path);
		graphics.FillPath(new SolidBrush(_arrowColor), path2);
		if (_showThumb)
		{
			graphics.FillRectangle(new SolidBrush(_scrollColor), Thumb);
			graphics.DrawRectangle(new Pen(_borderColor), Thumb);
			int num = Thumb.Y + Thumb.Height / 2 - 3;
			for (int i = 0; i < 3; i++)
			{
				int num2 = num + i * 3;
				graphics.DrawLine(new Pen(_borderColor), Thumb.X + 5, num2, Thumb.Right - 5, num2);
			}
		}
		graphics.DrawRectangle(new Pen(_borderColor), 0, 0, base.Width - 1, base.Height - 1);
		graphics.FillRectangle(new SolidBrush(base.Parent.BackColor), base.Width - 1, base.Height - 1, 1, 1);
		graphics.FillRectangle(new SolidBrush(base.Parent.BackColor), base.Width - 1, 0, 1, 1);
	}

	private void InvalidateLayout()
	{
		TSA = new Rectangle(0, 0, base.Width, buttonSize);
		BSA = new Rectangle(0, base.Height - buttonSize, base.Width, buttonSize);
		Shaft = new Rectangle(0, TSA.Bottom + 1, base.Width, base.Height - buttonSize * 2 - 1);
		_showThumb = _maximum - _minimum > Shaft.Height;
		if (_showThumb)
		{
			Thumb = new Rectangle(1, 0, base.Width - 3, thumbSize);
		}
		if (this.Scroll != null)
		{
			this.Scroll(this);
		}
		InvalidatePosition();
	}

	private void InvalidatePosition()
	{
		Thumb.Y = Convert.ToInt32(GetProgress() * (double)(Shaft.Height - thumbSize)) + TSA.Height;
		Invalidate();
	}

	private double GetProgress()
	{
		return (double)(_value - _minimum) / (double)(_maximum - _minimum);
	}

	private GraphicsPath DrawArrow(int x, int y, bool flip)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = 9;
		int num2 = 5;
		if (flip)
		{
			graphicsPath.AddLine(x + 1, y, x + num + 1, y);
			graphicsPath.AddLine(x + num, y, x + num2, y + num2 - 1);
		}
		else
		{
			graphicsPath.AddLine(x, y + num2, x + num, y + num2);
			graphicsPath.AddLine(x + num, y + num2, x + num2, y);
		}
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	protected override void OnSizeChanged(EventArgs e)
	{
		InvalidateLayout();
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left && _showThumb)
		{
			if (TSA.Contains(e.Location))
			{
				I1 = _value - _smallChange;
			}
			else if (BSA.Contains(e.Location))
			{
				I1 = _value + _smallChange;
			}
			else
			{
				if (Thumb.Contains(e.Location))
				{
					_thumbDown = true;
					base.OnMouseDown(e);
					return;
				}
				if (e.Y < Thumb.Y)
				{
					I1 = _value - _largeChange;
				}
				else
				{
					I1 = _value + _largeChange;
				}
			}
			_value = Math.Min(Math.Max(I1, _minimum), _maximum);
			InvalidatePosition();
		}
		base.OnMouseDown(e);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		if (_thumbDown && _showThumb)
		{
			int num = e.Y - TSA.Height - thumbSize / 2;
			int num2 = Shaft.Height - thumbSize;
			I1 = Convert.ToInt32((double)num / (double)num2 * (double)(_maximum - _minimum)) + _minimum;
			_value = Math.Min(Math.Max(I1, _minimum), _maximum);
			InvalidatePosition();
		}
		base.OnMouseMove(e);
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		_thumbDown = false;
		base.OnMouseUp(e);
	}

	public LoyalScrollBar()
	{
		SetStyle(ControlStyles.Selectable, value: false);
		SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
		base.Width = 19;
	}
}
