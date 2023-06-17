using Newtonsoft.Json;
using Pokedex.Models;
using Newtonsoft.Json.Converters;

namespace Pokedex;
	
public partial class Tabs : TabbedPage
{
    int clickTotal;
    public string Name;
    public string Url;
    public string Next;
    public string Previous;
	public Tabs()
	{
		InitializeComponent();
        Url = "https://pokeapi.co/api/v2/pokemon/";
        _ = GetPokemon(Url);

    }
    public async Task<bool> GetPokemon(string s)
    {
        HttpClient http = new HttpClient();
        var response = await http.GetAsync(s);
        if (response.IsSuccessStatusCode)
        {
            var respString = await response.Content.ReadAsStringAsync();
            var json_s = JsonConvert.DeserializeObject<PokemonApiModel>(respString);
        }
        else
        {

        }

        return true;
    }

    void OnImageButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new infopoke());
    }
}