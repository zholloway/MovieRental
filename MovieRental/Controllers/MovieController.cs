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

        public ActionResult Index()
        {
            return View(movieServices.GetAllMovies());
        }
        
        public ActionResult CreateMovie()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateMovie(FormCollection collection)
        {
            movieServices.CreateMovie(collection);
            return RedirectToAction("CRUDmovies");
        }

        public ActionResult EditMovie(int id)
        {
            return View(movieServices.GetOneMovieByID(id));
        }

        [HttpPost]
        public ActionResult EditMovie(FormCollection collection)
        {
            movieServices.EditMovie(collection);
            return RedirectToAction("CRUDmovies");
        }

        public ActionResult DeleteMovie(int id)
        {
            movieServices.DeleteMovie(id);
            return RedirectToAction("CRUDmovies");
        }

        //for Admin
        public ActionResult CRUDmovies()
        {
            return View(movieServices.GetAllMovies());
        }
    }
}