public class LoyalListViewSubItem
{
	public string Text { get; set; }

	public LoyalListViewSubItem()
	{
	}

	public LoyalListViewSubItem(string text)
	{
		Text = text;
	}

	public override string ToString()
	{
		return Text;
	}
}
