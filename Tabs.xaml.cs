using Pokedex.Models;

namespace Pokedex;
	
public partial class Tabs : TabbedPage
{
	public Tabs()
	{
		InitializeComponent();

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        GenerateButtons();
    }

    private void GenerateButtons()
    {
        var repository = new PokeRepository("Server=SNCCHLAB03F09\\TEW_SQLEXPRESS;Database=POKEDATA;Integrated Security=True;");
        List<Pokemon> pokes = repository.GetAllPokemon();

        // Clear existing rows and columns
        buttonGrid.RowDefinitions.Clear();
        buttonGrid.ColumnDefinitions.Clear();

        // Define the number of columns
        for (int i = 0; i < 3; i++)
        {
            buttonGrid.ColumnDefinitions.Add(new ColumnDefinition());
        }


        int row = 0;
        int col = 0;

        foreach (Pokemon pokemon in pokes)
        {
            Button button = new Button
            {

                Text = pokemon.Nome,
                MaximumHeightRequest = 150,
                MaximumWidthRequest = 150,
                CornerRadius = 20
            };

            // Set row and column definitions dynamically
            buttonGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(200) });
            Grid.SetRow(button, row);
            Grid.SetColumn(button, col);

            // Set an event handler to navigate to a new page
            button.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new infopoke(pokemon));
            };

            buttonGrid.Children.Add(button);

            col++;
            if (col == 3)
            {
                col = 0;
                row++;
            }
        }
    }
}