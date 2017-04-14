using MovieRental.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRental.Controllers
{
    public class MovieController : Controller
    {
        const string PathToMovieRentalDatabase = @"Server=localhost\SQLEXPRESS;Database=MovieRental;Trusted_Connection=True;";
        MovieServices movieServices = new MovieServices(PathToMovieRentalDatabase);

        // GET: Movie
        public ActionResult Index()
        {
            return View(movieServices.GetAllMovies());
        }
    }
}