using System;
using System.Collections.Generic;
using System.ComponentModel;

public class LoyalListViewItem
{
	protected Guid uniqueId;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public List<LoyalListViewSubItem> SubItems { get; set; } = new List<LoyalListViewSubItem>();


	public string Text { get; set; }

	public LoyalListViewItem()
	{
		uniqueId = Guid.NewGuid();
	}

	public LoyalListViewItem(string text)
	{
		uniqueId = Guid.NewGuid();
		Text = text;
	}

	public LoyalListViewItem(string text, List<LoyalListViewSubItem> subitems)
	{
		uniqueId = Guid.NewGuid();
		Text = text;
		SubItems = subitems;
	}

	public override bool Equals(object obj)
	{
		if (obj.GetType() == typeof(LoyalListViewItem))
		{
			return ((LoyalListViewItem)obj).uniqueId == uniqueId;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override string ToString()
	{
		return Text;
	}
}
