using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace MovieRental.Services
{
    public class RentalServices
    {
        public SqlConnection Connection { get; set; }
        public RentalServices(string connection)
        {
            Connection = new SqlConnection(connection);
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

        public void CheckOutMovie(int movieId, int customerID)
        {
            //update movie status
            var query = "UPDATE Movies " +
                            "SET [IsCheckedOut] = 'True' " +
                            "WHERE ID = @ID";

            var cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@ID", movieId);

            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();

            //create new RentalLog 
            query = "INSERT INTO RentalLog (CustomerID, MovieID, DateCheckedOut, DueDate) "
                            + "Values (@CustomerID, @MovieID, @DateCheckedOut, @DueDate)";

            cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@CustomerID", customerID);
            cmd.Parameters.AddWithValue("@MovieID", movieId);
            cmd.Parameters.AddWithValue("@DateCheckedOut", DateTime.Now);
            cmd.Parameters.AddWithValue("@DueDate", DateTime.Now.AddDays(7));

            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
    }
}