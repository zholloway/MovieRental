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

        public ActionResult CreateGenre()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateGenre(FormCollection collection)
        {
            genreServices.CreateGenre(collection);
            return RedirectToAction("Index");
        }

        public ActionResult EditGenre(int id)
        {
            return View(genreServices.GetOneGenreByID(id));
        }

        [HttpPost]
        public ActionResult EditGenre(FormCollection collection)
        {
            genreServices.EditGenre(collection);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteGenre(int id)
        {
            genreServices.DeleteGenre(id);
            return RedirectToAction("Index");
        }
    }
}