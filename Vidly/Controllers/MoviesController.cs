using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        public ActionResult Index()
        {
            var movies = new List<Movie>
            {
                new Movie { Id = 0, Name = "Shrek" },
                new Movie { Id = 1, Name = "Hulk" },
                new Movie { Id = 2, Name = "Batman" },
                new Movie { Id = 3, Name = "Spiderman" },
            };

            var viewModel = new MoviesListViewModel()
            {
                Movies = movies
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var movies = new List<Movie>
            {
                new Movie { Id = 0, Name = "Shrek" },
                new Movie { Id = 1, Name = "Hulk" },
                new Movie { Id = 2, Name = "Batman" },
                new Movie { Id = 3, Name = "Spiderman" },
            };

            Movie resultMovie = null;

            foreach(var movie in movies)
            {
                if (movie.Id == id)
                {
                    resultMovie = movie;
                    break;
                }
            }

            return View(resultMovie);
        }

        //// GET: Movies/Random
        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Shrek!" };
        //    var customers = new List<Customer>
        //    {
        //        new Customer { Name = "Customer 1" },
        //        new Customer { Name = "Customer 2" }
        //    };

        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Customers = customers,
        //        Movie = movie
        //    };

        //    return View(viewModel);
        //}

    }
}