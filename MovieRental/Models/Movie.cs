using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace MovieRental.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int YearReleased { get; set; }
        public string Director { get; set; }
        public int GenreID { get; set; }
        public bool IsCheckedOut { get; set; }

        public Movie() { }
        public Movie(SqlDataReader reader)
        {
            this.ID = (int)reader["ID"];
            this.Name = reader["Name"].ToString();
            this.YearReleased = (int)reader["YearReleased"];
            this.Director = reader["Director"].ToString();
            this.GenreID = (int)reader["GenreID"];
            this.IsCheckedOut = (bool)reader["IsCheckedOut"];
        }
    }
}