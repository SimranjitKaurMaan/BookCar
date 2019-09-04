using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookCar.Models;

namespace BookCar.Controllers
{
    public class CarsController : Controller
    {
        ApplicationDbContext _context;

        public CarsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Cars
        public ActionResult Index()
        {
            //var cars = getCars();

            var cars = _context.cars;

            if (cars.Count() == 0)
                return Content("We dont have cars yet!");

            return View(cars);
        }




        //GET: Cars/Details/1
        public ActionResult Details(int id)
        {
            var car = _context.cars.Single(c=>c.Id==id);



            return View(car);

        }

        private IEnumerable<Car> getCars()
        {
            return new List<Car>
            {
                   new Car{Id=1,Name="Mahindra"},
                   new Car{Id=2,Name="Baleno"},
                   new Car{Id=3,Name="Honda"}
            };

        }


    }
}