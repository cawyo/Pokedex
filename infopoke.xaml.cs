using Pokedex.Models;
using System.Globalization;


namespace Pokedex;

public partial class infopoke : ContentPage
{
    public infopoke(Pokemon pokemon)
    {
        InitializeComponent();
        BindingContext = pokemon;
    }

}

