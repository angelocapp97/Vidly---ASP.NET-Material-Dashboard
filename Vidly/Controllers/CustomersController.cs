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
        // GET: Customers
        public ActionResult Index()
        {
            var customers = new List<Customer>()
            {
                new Customer { Id = 0, Name = "Angelo" },
                new Customer { Id = 1, Name = "Francesco" },
                new Customer { Id = 2, Name = "Giuseppe" },
                new Customer { Id = 3, Name = "Giovanni" },
            };

            var viewModel = new CustomersListViewModel()
            {
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var customers = new List<Customer>()
            {
                new Customer { Id = 0, Name = "Angelo" },
                new Customer { Id = 1, Name = "Francesco" },
                new Customer { Id = 2, Name = "Giuseppe" },
                new Customer { Id = 3, Name = "Giovanni" },
            };

            Customer customerResult = null;
            foreach(var customer in customers)
            {
                if(customer.Id == id)
                {
                    customerResult = customer;
                    break;
                }
            }

            return View(customerResult);
        }
    }
}