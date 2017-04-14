using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MovieRental.ViewModels
{
    public class CheckCustomerRental
    {
        public int Movie_ID { get; set; }
        public string Movie_Name { get; set; }
        public DateTime DateCheckedOut { get; set; }
        public DateTime DueDate { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Email { get; set; }
        public string Customer_PhoneNumber { get; set; }

        public CheckCustomerRental() { }
        public CheckCustomerRental(SqlDataReader reader)
        {
            Movie_ID = (int)reader["Movie ID"];
            Movie_Name = reader["Title"].ToString();
            DateCheckedOut = (DateTime)reader["Checkout Date"];
            DueDate = (DateTime)reader["Due Date"];
            Customer_Name = reader["Customer Name"].ToString();
            Customer_Email = reader["Email"].ToString();
            Customer_PhoneNumber = reader["Phone Number"].ToString();
        }
    }
}