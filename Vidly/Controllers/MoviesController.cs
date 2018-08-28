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
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            //return View(movie);
            //Content Will just return the text
            //return Content("Hello World!!!!");
            //HttpNotFound will return 404 not found page
            //return HttpNotFound();
            //EmptyResult return nothing
            //return new EmptyResult();
            //RedirectToAction navigates the controller action as specified Parameters are action, controller and parameters(parameters will be shown in URL)
            //return RedirectToAction("Contact", "Home", new { page = 1, sortBy = "name" });

            //View Data
            //View data is a old approach and "Movie" is changed it will thoughts a null error. Instead of this passing model is the best way.
            //ViewData["Movie"] = movie;
            //return View();

            //ViewModel Example

            var customers = new List<Customer>
            {
                new Customer{Name="Customer 1" },
                new Customer{Name="Customer 2" },
                new Customer{Name="Customer 3" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        // GET: Movies/Edit/{id}
        public ActionResult Edit(int id)
        {
            return Content("Id=" + id);
        }

        //This is for optional parameters
        // GET: Movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "name";
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        //Example for custom route and the custom route is added in "RouteConfig.cs"
        // GET: Movies/Released
        //Below Route is without constraints
        //[Route("movies/released/{year}/{month}")]
        //Below Route is with constraints below regular expression will accepts only 2 digit number for month
        //[Route("movies/released/{year}/{month:regex(\\d{2})}")]
        //Below Route is with multiple constraints below regular expression will accepts only 2 digit number for month and range will be 1 to 12
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}