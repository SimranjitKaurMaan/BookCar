using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookCar.Models;
using System.Data.Entity;
using BookCar.ViewModels;

namespace BookCar.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();//disposeable object
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Customers/Index
        public ActionResult Index()
        {

            var customers = _context.customers.Include(c => c.MembershipType);
            //return Content("Hellp Customers");
            //var customers = GetCustomers();

            return View(customers);
        }

        //GET : Customers/Details/Id
        public ActionResult Details(int? Id)
        {
            var customers = _context.customers.Include(c => c.MembershipType);
               
           // var customers = GetCustomers();
            foreach (var customer in customers)
            {
                if (customer.Id == Id)
                {
                    return View(customer);
                }
            }
            return Content("Customer not found");

        }


        public ActionResult Edit(int id)
        {
            var customer = _context.customers.SingleOrDefault(c=>c.Id==id);
            if(customer==null)
            {
                return HttpNotFound();

            }

            var memberships = _context.memberships;
            var viewmodel = new NewCustomerViewModel
            {
                customer = customer,
                Memberships = memberships

            };

            return View("New",viewmodel);
        }

        public ActionResult New()
        {
            var memberships = _context.memberships;
            var viewmodel = new NewCustomerViewModel
            {
                Memberships = memberships
               
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if(customer.Id==0)
            {
                _context.customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershipType = customer.MembershipType;
                customerInDb.BirthDate = customer.BirthDate;
            }
           
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

        private IEnumerable<Customer> GetCustomers()
        {
            var Customers = new List<Customer>
            {
               new Customer{Name =  "John Smith",Id = 1000},
                new Customer{Name =  "Mary Williams",Id=1001}

            };

            return Customers;
        }

    }
}