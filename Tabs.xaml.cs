namespace Pokedex;
	
public partial class Tabs : TabbedPage
{
    int clickTotal;
	public Tabs()
	{
		InitializeComponent();
	}

    void OnImageButtonClicked(object sender, EventArgs e)
    {
        clickTotal += 1;
    }
}