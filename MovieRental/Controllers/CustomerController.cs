using MovieRental.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRental.Controllers
{
    public class CustomerController : Controller
    {
        const string PathToMovieRentalDatabase = @"Server=localhost\SQLEXPRESS;Database=MovieRental;Trusted_Connection=True;";
        CustomerServices customerServices = new CustomerServices(PathToMovieRentalDatabase);

        // GET: Customer
        public ActionResult Index()
        {
            return View(customerServices.GetAllCustomers());
        }
    }
}