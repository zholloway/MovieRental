using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRental.Services
{
    public class GenreServices
    {
        public SqlConnection Connection { get; set; }

        public GenreServices(string connection)
        {
            this.Connection = new SqlConnection(connection);
        }

        public List<Genre> GetAllGenres()
        {
            var genreList = new List<Genre>();

            var query = "SELECT * FROM Genres";
            var cmd = new SqlCommand(query, Connection);

            Connection.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                genreList.Add(new Genre(reader));
            }
            Connection.Close();

            return genreList;
        }

        public void CreateGenre(FormCollection collection)
        {
            var query = "INSERT INTO Genres (Name) "
                            + "Values (@Name)";

            var cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@Name", collection["Name"]);

            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public void DeleteGenre(int id)
        {
            var query = "DELETE FROM Genres WHERE ID=@ID";

            var cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@ID", id);

            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public void EditGenre(int id, FormCollection collection)
        {
            var query = "UPDATE Genres " +
                            "SET [Name] = @Name " +                           
                            "WHERE ID = @ID";

            var cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@Name", collection["Name"]);
            cmd.Parameters.AddWithValue("@ID", id);

            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
    }
}