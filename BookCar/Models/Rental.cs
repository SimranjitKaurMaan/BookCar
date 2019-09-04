using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace BookCar.Models
{
    //Association Class between the car n customer
    public class Rental
    {
        public int Id { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }

        [Required]
        public Car car { get; set; }//navigation property

        [Required]
        public Customer customer { get; set; }//navigation property

    }
}