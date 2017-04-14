using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace MovieRental.Services
{
    public class MovieServices
    {
        public SqlConnection Connection { get; set; }

        public MovieServices(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }

        public List<Movie> GetAllMovies()
        {
            var movieList = new List<Movie>();

            var query = "SELECT * FROM Movies";
            var cmd = new SqlCommand(query, Connection);

            this.Connection.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                movieList.Add(new Movie(reader));
            }  
            this.Connection.Close();

            return movieList;
        }

        public void CreateMovie(FormCollection collection)
        {
            var query = "INSERT INTO Movies (Name, YearReleased, Director, GenreID) "
                            + "Values (@Name, @YearReleased, @Director, @GenreID)";

            var cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@Name", collection["Name"]);
            cmd.Parameters.AddWithValue("@YearReleased", collection["YearReleased"]);
            cmd.Parameters.AddWithValue("@Director", collection["Director"]);
            cmd.Parameters.AddWithValue("@GenreID", collection["GenreID"]);

            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public void DeleteMovie(int id)
        {
            var query = "DELETE FROM Movies WHERE ID=@ID";

            var cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@ID", id);

            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public void EditMovie(int id, FormCollection collection)
        {
            var query = "UPDATE Customers " +
                            "SET [Name] = @Name," +
                            "[YearReleased] = @YearReleased," +
                            "[Director] = @Director," +
                            "[GenreID] = @GenreID," +
                            "[IsCheckedOut] = @IsCheckedOut " +
                            "WHERE ID = @ID";

            var cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@Name", collection["Name"]);
            cmd.Parameters.AddWithValue("@YearReleased", collection["YearReleased"]);
            cmd.Parameters.AddWithValue("@Director", collection["Director"]);
            cmd.Parameters.AddWithValue("@GenreID", collection["GenreID"]);
            cmd.Parameters.AddWithValue("@IsCheckedOut", collection["IsCheckedOut"]);
            cmd.Parameters.AddWithValue("@ID", id);

            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public void CheckInMovie(int id)
        {
            //update movie status
            var query = "UPDATE Movies " +
                            "SET [IsCheckedOut] = 'False' " +
                            "WHERE ID = @ID";

            var cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@ID", id);

            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();

            //now to delete RentalLog for this movie
            query = "DELETE FROM RentalLog WHERE MovieID = @MovieID";
            cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@MovieID", id);

            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public void CheckOutMovie(int id)
        {

        }
    }
}