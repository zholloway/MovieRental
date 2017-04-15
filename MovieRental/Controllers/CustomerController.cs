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

        public ActionResult AddNewCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewCustomer(FormCollection collection)
        {
            customerServices.CreateCustomer(collection);
            return RedirectToAction("Index");
        }

        public ActionResult EditCustomer(int id)
        {
            return View(customerServices.GetOneCustomerByID(id));
        }

        [HttpPost]
        public ActionResult EditCustomer(FormCollection collection)
        {
            customerServices.EditCustomer(collection);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCustomer(int id)
        {
            customerServices.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
}