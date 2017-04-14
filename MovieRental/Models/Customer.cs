using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MovieRental.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Customer() {}
        public Customer(SqlDataReader reader)
        {
            this.ID = (int)reader["ID"];
            this.Name = reader["Name"].ToString();
            this.Email = reader["Email"].ToString();
            this.PhoneNumber = reader["PhoneNumber"].ToString();
        }
    }
}