using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace MovieRental.Services
{
    public class CustomerServices
    {
        public SqlConnection Connection { get; set; }

        public CustomerServices(string connection)
        {
            var sqlConnection = new SqlConnection(connection);
            Connection = sqlConnection;
        }

        public List<Customer> GetAllCustomers()
        {
            var customerList = new List<Customer>();

            var query = "SELECT * FROM Customers";
            var cmd = new SqlCommand(query, Connection);

            this.Connection.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                customerList.Add(new Customer(reader));
            }
            this.Connection.Close();

            return customerList;
        }

        public Customer GetOneCustomerByID(int id)
        {
            var singleCustomer = new Customer();

            var query = "SELECT * FROM Customers WHERE ID=@ID";

            var cmd = new SqlCommand(query,Connection);
            cmd.Parameters.AddWithValue("@ID", id);

            Connection.Open();
            var reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                singleCustomer = new Customer(reader);
            }
            Connection.Close();

            return singleCustomer;
        }

        public void CreateCustomer(FormCollection collection)
        {
            var query = "INSERT INTO Customers (Name, Email, PhoneNumber) "
                            + "Values (@Name, @Email, @PhoneNumber)";

            var cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@Name", collection["Name"]);
            cmd.Parameters.AddWithValue("@Email", collection["Email"]);
            cmd.Parameters.AddWithValue("@PhoneNumber", collection["PhoneNumber"]);

            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public void DeleteCustomer(int id)
        {
            var query = "DELETE FROM Customers WHERE ID=@ID";

            var cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@ID", id);

            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public void EditCustomer(FormCollection collection)
        {
            var query = "UPDATE Customers " +
                            "SET [Name] = @Name," +
                            "[Email] = @Email," +
                            "[PhoneNumber] = @PhoneNumber " +
                            "WHERE ID = @ID";

            var cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@Name", collection["Name"]);
            cmd.Parameters.AddWithValue("@Email", collection["Email"]);
            cmd.Parameters.AddWithValue("@PhoneNumber", collection["PhoneNumber"]);
            cmd.Parameters.AddWithValue("@ID", collection["ID"]);

            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public ViewModels.CheckCustomerRental GetCheckedOutMoviesAndCustomers()
        {
            var checkCustomerRentalModel = new ViewModels.CheckCustomerRental();

            var query = "SELECT Movies.ID AS 'Movie ID', Movies.Name AS Title, RentalLog.DateCheckedOut AS 'Checkout Date', " +
                            "RentalLog.DueDate AS 'Due Date', Customers.Name AS 'Customer Name', " +
                            "Customers.Email,Customers.PhoneNumber AS 'Phone Number' " +
                        "FROM Movies " +
                        "JOIN RentalLog ON Movies.ID = RentalLog.MovieID " +
                        "JOIN Customers ON RentalLog.CustomerID = Customers.ID " +
                        "WHERE IsCheckedOut = 'True' " +
                        "ORDER BY Customers.Name ASC";

            var cmd = new SqlCommand(query, Connection);

            Connection.Open();
            var reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                checkCustomerRentalModel = new ViewModels.CheckCustomerRental(reader);
            }

            return checkCustomerRentalModel;
        }
    }
}