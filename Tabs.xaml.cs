using Pokedex.Models;
using System.Collections.Generic;
using System.Linq;


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
        var repository = new PokeRepository("Server=MP-CONSULTORIA;Database=POKEDATA;trustServerCertificate=true;trusted_connection=true;");
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
            ImageButton imageButton = new ImageButton
            {
                Source = pokemon.Imgurl,
                BackgroundColor = Color.FromArgb("#f2d5d5"), // Pinkish red color
                Padding = new Thickness(0),
                CornerRadius = 20,
                Aspect = Aspect.AspectFill,
                MaximumHeightRequest = 150,
                MaximumWidthRequest = 150
            };

            // Set row and column definitions dynamically
            buttonGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(200) });
            Grid.SetRow(imageButton, row);
            Grid.SetColumn(imageButton, col);

            // Set an event handler to navigate to a new page
            imageButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new infopoke(pokemon));
            };

            buttonGrid.Children.Add(imageButton);

            col++;
            if (col == 3)
            {
                col = 0;
                row++;
            }
        }
    }


        private async void OnSearchButtonClicked(object sender, EventArgs e)
        {
            string searchTerm = SearchPokemon.Text.ToLower();

            var repository = new PokeRepository("Server=MP-CONSULTORIA;Database=POKEDATA;trustServerCertificate=true;trusted_connection=true;");
            List<Pokemon> searchResults = repository.GetAllPokemon().Where(p => p.Nome.ToLower().Contains(searchTerm)).ToList();

            // Navigate to the search results page and pass the search results
            await Navigation.PushAsync(new SearchResults(searchResults));
        }
}