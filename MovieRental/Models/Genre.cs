using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace MovieRental.Models
{
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Genre() { }
        public Genre(SqlDataReader reader)
        {
            this.ID = (int)reader["ID"];
            this.Name = reader["Name"].ToString();
        }
    }
}