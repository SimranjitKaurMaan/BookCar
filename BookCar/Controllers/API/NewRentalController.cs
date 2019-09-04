using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookCar.Dtos;
using BookCar.Models;

namespace BookCar.Controllers.API
{

    public class NewRentalController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }

       // /api/NewRental/CreateRental
       [HttpPost]
        public IHttpActionResult CreateRental(NewRentalDto newRentalDto)
        {
            var customerId = newRentalDto.customer.Id;

            var customer = _context.customers.Single(c => c.Id == customerId);

            var carsInDb = _context.cars.Where(m => newRentalDto.carIds.Contains(m.Id));

            foreach (var car in carsInDb)
            {
                
                var newRental = new Rental
                {
                    customer = customer,
                    car = car,
                    DateRented = DateTime.Now

                };

                _context.rentals.Add(newRental);  

            }
            _context.SaveChanges();

            return Ok();
        }

        //api/NewRental/getRentals
        public void getRentals()
        {
            var rentalsInDb = _context.rentals;
            foreach(var rental in rentalsInDb)
            {
                Console.Write("customer :"+rental.customer.Name);
                Console.Write("car :" + rental.car.Name);
                Console.Write("Date Rented: " + rental.DateRented);
                Console.WriteLine();
            }

        }
    }
}
