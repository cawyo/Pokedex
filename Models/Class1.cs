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
    }
    public class PokeRepository
    {
        private readonly string connectionString;
        private string conect = "Server=SNCCHLAB03F09\\TEW_SQLEXPRESS;Database=POKEDATA; trusted_connection=true; trustServerCertificate=true;";

        public PokeRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Pokemon> GetAllPokemon()
        {
            using (var connection = new SqlConnection(conect))
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

                var query = "INSERT INTO Pokemon (nome, altura, peso) VALUES (@nome, @altura, @peso)";
                connection.Execute(query, pokemon);
            }
        }
    }
}
