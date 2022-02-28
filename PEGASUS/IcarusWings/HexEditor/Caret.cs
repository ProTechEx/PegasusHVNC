using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace PEGASUS.IcarusWings.HexEditor
{
	public class Caret
	{
		private int _startIndex;

		private bool _isCaretHidden;

		private Point _location;

		private readonly HexEditor _editor;

		public int SelectionStart
		{
			get
			{
				if (CurrentIndex < _startIndex)
				{
					return CurrentIndex;
				}
				return _startIndex;
			}
		}

		public int SelectionLength
		{
			get
			{
				if (CurrentIndex < _startIndex)
				{
					return _startIndex - CurrentIndex;
				}
				return CurrentIndex - _startIndex;
			}
		}

		public bool Focused { get; private set; }

		public int CurrentIndex { get; private set; }

		public Point Location => _location;

		public event EventHandler SelectionStartChanged;

		public event EventHandler SelectionLengthChanged;

		public Caret(HexEditor editor)
		{
			_editor = editor;
			Focused = false;
			_startIndex = 0;
			CurrentIndex = 0;
			_isCaretHidden = true;
			_location = new Point(0, 0);
		}

		private bool Create(IntPtr hWHandler)
		{
			if (!Focused)
			{
				Focused = true;
				return CreateCaret(hWHandler, IntPtr.Zero, 0, (int)_editor.CharSize.Height - 2);
			}
			return false;
		}

		private bool Show(IntPtr hWnd)
		{
			if (Focused)
			{
				_isCaretHidden = false;
				return ShowCaret(hWnd);
			}
			return false;
		}

		public bool Hide(IntPtr hWnd)
		{
			if (Focused && !_isCaretHidden)
			{
				_isCaretHidden = true;
				return HideCaret(hWnd);
			}
			return false;
		}

		public bool Destroy()
		{
			if (Focused)
			{
				Focused = false;
				DeSelect();
				DestroyCaret();
			}
			return false;
		}

		public void SetStartIndex(int index)
		{
			_startIndex = index;
			CurrentIndex = _startIndex;
			if (this.SelectionStartChanged != null)
			{
				this.SelectionStartChanged(this, EventArgs.Empty);
			}
			if (this.SelectionLengthChanged != null)
			{
				this.SelectionLengthChanged(this, EventArgs.Empty);
			}
		}

		public void SetEndIndex(int index)
		{
			CurrentIndex = index;
			if (this.SelectionStartChanged != null)
			{
				this.SelectionStartChanged(this, EventArgs.Empty);
			}
			if (this.SelectionLengthChanged != null)
			{
				this.SelectionLengthChanged(this, EventArgs.Empty);
			}
		}

		public void SetCaretLocation(Point start)
		{
			Create(_editor.Handle);
			_location = start;
			SetCaretPos(_location.X, _location.Y);
			Show(_editor.Handle);
		}

		public bool IsSelected(int byteIndex)
		{
			if (SelectionStart <= byteIndex)
			{
				return byteIndex < SelectionStart + SelectionLength;
			}
			return false;
		}

		private void DeSelect()
		{
			if (CurrentIndex < _startIndex)
			{
				_startIndex = CurrentIndex;
			}
			else
			{
				CurrentIndex = _startIndex;
			}
			if (this.SelectionStartChanged != null)
			{
				this.SelectionStartChanged(this, EventArgs.Empty);
			}
			if (this.SelectionLengthChanged != null)
			{
				this.SelectionLengthChanged(this, EventArgs.Empty);
			}
		}

		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool CreateCaret(IntPtr hWnd, IntPtr hBitmap, int nWidth, int nHeight);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool DestroyCaret();

		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool SetCaretPos(int x, int y);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool ShowCaret(IntPtr hWnd);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool HideCaret(IntPtr hWnd);
	}
}
