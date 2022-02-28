using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class LoyalListView : Control
{
	private int[] _columnOffsets;

	private readonly LoyalScrollBar _VS;

	private bool _down;

	private int _itemHeight = 24;

	private List<LoyalListViewItem> _items = new List<LoyalListViewItem>();

	private readonly List<LoyalListViewItem> _selectedItems = new List<LoyalListViewItem>();

	private List<LoyalListViewColumnHeader> _columns = new List<LoyalListViewColumnHeader>();

	private bool _multiSelect = true;

	private Color _headerColor = Color.FromArgb(102, 51, 153);

	private Color _backColor = Color.FromArgb(40, 40, 40);

	private Color _borderColor = Color.FromArgb(18, 18, 18);

	private Color _itemColor = Color.FromArgb(50, 50, 50);

	private Color _selectedItemColor = Color.FromArgb(65, 65, 65);

	private Color _scrollBarBackColor = Color.FromArgb(31, 31, 31);

	private Color _foreColor = Color.White;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Category("Content")]
	public LoyalListViewItem[] Items
	{
		get
		{
			return _items.ToArray();
		}
		set
		{
			_items = new List<LoyalListViewItem>(value);
			InvalidateScroll();
		}
	}

	[Category("Content")]
	public LoyalListViewItem[] SelectedItems => _selectedItems.ToArray();

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Category("Content")]
	public LoyalListViewColumnHeader[] Columns
	{
		get
		{
			return _columns.ToArray();
		}
		set
		{
			_columns = new List<LoyalListViewColumnHeader>(value);
			InvalidateColumns();
		}
	}

	public bool Multiselect
	{
		get
		{
			return _multiSelect;
		}
		set
		{
			_multiSelect = value;
			if (_selectedItems.Count > 1)
			{
				_selectedItems.RemoveRange(1, _selectedItems.Count);
			}
			Invalidate();
		}
	}

	public override Font Font
	{
		get
		{
			return base.Font;
		}
		set
		{
			_itemHeight = Convert.ToInt32(Graphics.FromHwnd(base.Handle).MeasureString("@", Font).Height) + 6;
			if (_VS != null)
			{
				_VS.SmallChange = _itemHeight;
				_VS.LargeChange = _itemHeight;
			}
			base.Font = value;
			InvalidateLayout();
		}
	}

	[Category("Colors")]
	public Color HeaderColor
	{
		get
		{
			return _headerColor;
		}
		set
		{
			_headerColor = value;
			_VS.ScrollColor = _headerColor;
			_VS.ArrowColor = _headerColor;
			Invalidate();
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
	public Color BorderColor
	{
		get
		{
			return _borderColor;
		}
		set
		{
			_borderColor = value;
			_VS.BorderColor = _borderColor;
			Invalidate();
		}
	}

	[Category("Colors")]
	public Color ItemColor
	{
		get
		{
			return _itemColor;
		}
		set
		{
			_itemColor = value;
			Invalidate();
		}
	}

	[Category("Colors")]
	public Color SelectedItemColor
	{
		get
		{
			return _selectedItemColor;
		}
		set
		{
			_selectedItemColor = value;
			Invalidate();
		}
	}

	[Category("Colors")]
	public Color ScrollBarBackColor
	{
		get
		{
			return _scrollBarBackColor;
		}
		set
		{
			_scrollBarBackColor = value;
			_VS.BackColor = _scrollBarBackColor;
			Invalidate();
		}
	}

	[Category("Colors")]
	public override Color ForeColor
	{
		get
		{
			return _foreColor;
		}
		set
		{
			_foreColor = value;
			Invalidate();
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		Graphics graphics = e.Graphics;
		graphics.Clear(_backColor);
		int num = Convert.ToInt32(_VS.Percent * (double)(_VS.Maximum - (base.Height - _itemHeight * 2)));
		int num2 = ((num != 0) ? (num / _itemHeight) : 0);
		int num3 = Math.Min(num2 + base.Height / _itemHeight, _items.Count);
		for (int i = num2; i < num3; i++)
		{
			LoyalListViewItem loyalListViewItem = _items[i];
			Rectangle rectangle = new Rectangle(0, 24 + i * 24 - num, base.Width, 24);
			int num4 = Convert.ToInt32(graphics.MeasureString(loyalListViewItem.Text, Font).Height);
			int num5 = rectangle.Y + Convert.ToInt32(12 - num4 / 2);
			if (_selectedItems.Contains(loyalListViewItem))
			{
				graphics.FillRectangle(new SolidBrush(_selectedItemColor), rectangle);
			}
			else
			{
				graphics.FillRectangle(new SolidBrush(_itemColor), rectangle);
			}
			graphics.DrawRectangle(new Pen(_borderColor), rectangle);
			if (_columns.Count > 0)
			{
				rectangle.Width = _columns[0].Width;
				graphics.SetClip(rectangle);
			}
			graphics.DrawString(loyalListViewItem.Text, Font, new SolidBrush(_foreColor), 4f, num5 + 1);
			if (loyalListViewItem.SubItems.Count > 0)
			{
				for (int j = 0; j < Math.Min(loyalListViewItem.SubItems.Count, _columns.Count); j++)
				{
					int num7 = (rectangle.X = _columnOffsets[j + 1]);
					rectangle.Width = _columns[j].Width;
					graphics.SetClip(rectangle);
					graphics.DrawString(loyalListViewItem.SubItems[j].Text, Font, new SolidBrush(_foreColor), num7 + 1, num5 + 1);
				}
			}
			graphics.ResetClip();
		}
		graphics.FillRectangle(rect: new Rectangle(0, 0, base.Width, 24), brush: new SolidBrush(_headerColor));
		int y = Math.Min(_VS.Maximum + _itemHeight - num + 2, base.Height);
		for (int k = 0; k < _columns.Count; k++)
		{
			LoyalListViewColumnHeader loyalListViewColumnHeader = _columns[k];
			int num8 = Convert.ToInt32(graphics.MeasureString(loyalListViewColumnHeader.Text, Font).Height);
			int num9 = Convert.ToInt32(12 - num8 / 2);
			int num10 = _columnOffsets[k];
			graphics.DrawString(loyalListViewColumnHeader.Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold), new SolidBrush(_foreColor), num10 + 1, num9 + 1);
			graphics.DrawLine(new Pen(_borderColor), num10 - 3, 0, num10 - 3, y);
		}
		graphics.DrawRectangle(new Pen(_borderColor), 0, 0, base.Width - 1, base.Height - 1);
		graphics.DrawLine(new Pen(Color.FromArgb(30, Color.White)), 0, 1, base.Width, 1);
		graphics.DrawLine(new Pen(Color.FromArgb(70, Color.Black)), 0, 23, base.Width, 23);
		graphics.DrawLine(new Pen(_borderColor), 0, 24, base.Width, 24);
		graphics.FillRectangle(new SolidBrush(_backColor), base.Width - 19, 0, base.Width, base.Height);
		graphics.FillRectangle(new SolidBrush(base.Parent.BackColor), 0, 0, 1, 1);
		graphics.FillRectangle(new SolidBrush(base.Parent.BackColor), 0, base.Height - 1, 1, 1);
	}

	private void InvalidateScroll()
	{
		_VS.Maximum = _items.Count * 24;
		Invalidate();
	}

	private void InvalidateColumns()
	{
		int num = 3;
		_columnOffsets = new int[_columns.Count];
		for (int i = 0; i < _columns.Count; i++)
		{
			_columnOffsets[i] = num;
			num += Columns[i].Width;
		}
		Invalidate();
	}

	private void InvalidateLayout()
	{
		_VS.Location = new Point(base.Width - _VS.Width, 0);
		_VS.Size = new Size(19, base.Height);
		InvalidateScroll();
	}

	private void HandleScroll(object sender)
	{
		Invalidate();
	}

	public LoyalListView()
	{
		SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
		_VS = new LoyalScrollBar();
		_VS.LargeChange = _itemHeight;
		_VS.SmallChange = _itemHeight;
		_VS.Scroll += HandleScroll;
		_VS.MouseDown += _VS_MouseDown;
		_VS.MouseMove += _VS_MouseMove;
		_VS.MouseUp += _VS_MouseUp;
		_VS.ScrollColor = _headerColor;
		_VS.BorderColor = _borderColor;
		_VS.ArrowColor = _headerColor;
		_VS.BackColor = _scrollBarBackColor;
		base.Size = new Size(150, 75);
		Font = new Font("Segoe UI", 8.25f);
		base.Controls.Add(_VS);
		InvalidateLayout();
	}

	private void _VS_MouseUp(object sender, MouseEventArgs e)
	{
		_down = false;
	}

	private void _VS_MouseMove(object sender, MouseEventArgs e)
	{
		if (_down)
		{
			Invalidate();
		}
	}

	private void _VS_MouseDown(object sender, MouseEventArgs e)
	{
		_down = true;
		Focus();
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
		int num = -(e.Delta * SystemInformation.MouseWheelScrollLines / 120 * 12);
		int value = Math.Max(Math.Min(_VS.Value + num, _VS.Maximum), _VS.Minimum);
		_VS.Value = value;
		base.OnMouseWheel(e);
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		Focus();
		if (e.Button == MouseButtons.Left)
		{
			int num = Convert.ToInt32(_VS.Percent * (double)(_VS.Maximum - (base.Height - 48)));
			int num2 = (e.Y + num - 24) / 24;
			if (num2 > _items.Count - 1)
			{
				num2 = -1;
			}
			if (num2 > -1)
			{
				if (Control.ModifierKeys == Keys.Control && _multiSelect)
				{
					if (_selectedItems.Contains(_items[num2]))
					{
						_selectedItems.Remove(_items[num2]);
					}
					else
					{
						_selectedItems.Add(_items[num2]);
					}
				}
				else
				{
					_selectedItems.Clear();
					_selectedItems.Add(_items[num2]);
				}
			}
			Invalidate();
		}
		base.OnMouseDown(e);
	}

	protected override void OnSizeChanged(EventArgs e)
	{
		InvalidateLayout();
		base.OnSizeChanged(e);
	}

	public void AddItem(string text, string[] subitems)
	{
		List<LoyalListViewSubItem> list = new List<LoyalListViewSubItem>();
		for (int i = 0; i < subitems.Length; i++)
		{
			LoyalListViewSubItem item = new LoyalListViewSubItem(subitems[i]);
			list.Add(item);
		}
		LoyalListViewItem item2 = new LoyalListViewItem(text, list);
		_items.Add(item2);
		InvalidateScroll();
	}

	public void RemoveItemAt(int index)
	{
		_items.RemoveAt(index);
		InvalidateScroll();
	}

	public void RemoveItem(LoyalListViewItem lvi)
	{
		_items.Remove(lvi);
		InvalidateScroll();
	}

	public void RemoveItems(LoyalListViewItem[] lvis)
	{
		foreach (LoyalListViewItem item in lvis)
		{
			_items.Remove(item);
		}
		InvalidateScroll();
	}
}
