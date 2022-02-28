public class LoyalListViewColumnHeader
{
	public string Text { get; set; }

	public int Width { get; set; } = 60;


	public LoyalListViewColumnHeader()
	{
	}

	public LoyalListViewColumnHeader(string text)
	{
		Text = text;
	}

	public LoyalListViewColumnHeader(string text, int width)
	{
		Text = text;
		Width = width;
	}

	public override string ToString()
	{
		return Text;
	}
}
