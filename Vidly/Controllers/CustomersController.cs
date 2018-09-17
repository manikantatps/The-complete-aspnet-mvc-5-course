using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> customers = new List<Customer>
            {
                new Customer{Id=1, Name="Customer 1" },
                new Customer{Id=2, Name="Customer 2" },
                new Customer{Id=3, Name="Customer 3" }
            };

        // GET: Customers
        public ActionResult Index()
        {
            var viewModel = new RandomMovieViewModel
            {
                Customers = customers
            };

            return View(viewModel);
        }

        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = customers.SingleOrDefault(x => x.Id == id);

            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
    }
}