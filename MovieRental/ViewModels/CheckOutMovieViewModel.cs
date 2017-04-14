using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRental.ViewModels
{
    public class CheckOutMovieViewModel
    {
        public int ID { get; set; }

        public CheckOutMovieViewModel(int id)
        {
            ID = id;
        }
    }
}