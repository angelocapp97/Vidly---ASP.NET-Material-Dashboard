using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private VidlyContext _context;

        public CustomersController()
        {
            _context = new VidlyContext();
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            //var membershipTypes = _context.MembershipTypes.Include(m => m.MembershipTypeGroup).ToList().Select(m => new GroupedSelectListItem
            //{
            //    GroupKey = m.MembershipTypeGroup.Id.ToString(),
            //    GroupName = m.MembershipTypeGroup.Name,
            //    Value = m.Id.ToString(),
            //    Text = m.Name,
            //});

            //var viewModel = new CustomerFormViewModel()
            //{
            //    MembershipTypesListItems = membershipTypes
            //};

            var membershipTypes = _context.MembershipTypes.Include(m => m.MembershipTypeGroup).OrderBy(m => m.MembershipTypeGroup.Name).ToList();

            var viewModel = new CustomerFormViewModel(membershipTypes);

            return View("CustomerForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            //var membershipTypes = _context.MembershipTypes.Include(m => m.MembershipTypeGroup).ToList().Select(m => new GroupedSelectListItem
            //{
            //    GroupKey = m.MembershipTypeGroup.Id.ToString(),
            //    GroupName = m.MembershipTypeGroup.Name,
            //    Value = m.Id.ToString(),
            //    Text = m.Name,
            //});

            //var viewModel = new CustomerFormViewModel(customer)
            //{
            //    MembershipTypesListItems = membershipTypes
            //};

            var membershipTypes = _context.MembershipTypes.Include(m => m.MembershipTypeGroup).ToList();
            var viewModel = new CustomerFormViewModel(customer, membershipTypes);

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                // var membershipTypes = _context.MembershipTypes.ToList();
                //var membershipTypes = _context.MembershipTypes.Include(m => m.MembershipTypeGroup).ToList().Select(m => new GroupedSelectListItem
                //{
                //    GroupKey = m.MembershipTypeGroup.Id.ToString(),
                //    GroupName = m.MembershipTypeGroup.Name,
                //    Value = m.Id.ToString(),
                //    Text = m.Name,
                //});

                //var viewModel = new CustomerFormViewModel(customer)
                //{
                //    MembershipTypesListItems = membershipTypes
                //};

                var membershipTypes = _context.MembershipTypes.Include(m => m.MembershipTypeGroup).ToList();
                var viewModel = new CustomerFormViewModel(customer, membershipTypes);

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index", "customers");
        }

        public ActionResult Delete(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return RedirectToAction("Index", "customers");

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "customers");
        }
    }
}