using MovieRental.Services;
using MovieRental.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRental.Controllers
{    
    public class RentalController : Controller
    {
        const string PathToMovieRentalDatabase = @"Server=localhost\SQLEXPRESS;Database=MovieRental;Trusted_Connection=True;";
        RentalServices rentalServices = new RentalServices(PathToMovieRentalDatabase);

        [HttpGet]
        public ActionResult CheckInMovie(int id)
        {
            rentalServices.CheckInMovie(id);
            return RedirectToAction("Index", "Movie");
        }

        public ActionResult CustomersForCheckout(int id)
        {

            return View(new CheckOutMovieViewModel(id));
        }

        public ActionResult CheckOutMovie(int movieId, int customerID)
        {
            rentalServices.CheckOutMovie(movieId, customerID);
            return RedirectToAction("Index", "Movie");
        }
    }
}