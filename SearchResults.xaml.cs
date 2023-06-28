using Pokedex.Models;
using System.Collections.Generic;



namespace Pokedex
{
    public partial class SearchResults : ContentPage
    {
        public SearchResults(List<Pokemon> searchResults)
        {
            InitializeComponent();

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

            foreach (Pokemon pokemon in searchResults)
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
    }
}