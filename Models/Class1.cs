using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Pokedex.Models
{
    public class Pokemon
    {
        public string Nome { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public string Tipo1 { get; set; }
        public string Tipo2 { get; set; }
        public string Imgurl { get; set;}

        public string AlturaFormat => $"{Altura} M";
        public string PesoFormat => $"{Peso} Kg";
    }
    public class PokeRepository
    {
        private readonly string connectionString;


        public PokeRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Pokemon> GetAllPokemon()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var query = "SELECT * FROM Pokemon";
                var pokemon = connection.Query<Pokemon>(query).AsList();

                return pokemon;

            }
        }

        public void AddPoke(Pokemon pokemon)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var query = "INSERT INTO Pokemon (nome, altura, peso, tipo1, tipo2, imgurl) VALUES (@nome, @altura, @peso, @tipo1, @tipo2, @imgurl)";
                connection.Execute(query, pokemon);
            }
        }

    }

}
