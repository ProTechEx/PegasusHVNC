using System.Collections;
using System.Windows.Forms;

public class ListViewColumnSorter : IComparer
{
	private readonly CaseInsensitiveComparer _objectCompare;

	public int SortColumn { get; set; }

	public SortOrder Order { get; set; }

	public ListViewColumnSorter()
	{
		SortColumn = 0;
		Order = SortOrder.None;
		_objectCompare = new CaseInsensitiveComparer();
	}

	public int Compare(object x, object y)
	{
		ListViewItem listViewItem = (ListViewItem)x;
		ListViewItem listViewItem2 = (ListViewItem)y;
		if (listViewItem.SubItems[0].Text == ".." || listViewItem2.SubItems[0].Text == "..")
		{
			return 0;
		}
		int num = _objectCompare.Compare(listViewItem.SubItems[SortColumn].Text, listViewItem2.SubItems[SortColumn].Text);
		if (Order == SortOrder.Ascending)
		{
			return num;
		}
		if (Order != SortOrder.Descending)
		{
			return 0;
		}
		return -num;
	}
}
