using MovieRental.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRental.Controllers
{
    public class GenreController : Controller
    {
        const string PathToMovieRentalDatabase = @"Server=localhost\SQLEXPRESS;Database=MovieRental;Trusted_Connection=True;";
        GenreServices genreServices = new GenreServices(PathToMovieRentalDatabase);

        public ActionResult Index()
        {
            return View(genreServices.GetAllGenres());
        }
    }
}