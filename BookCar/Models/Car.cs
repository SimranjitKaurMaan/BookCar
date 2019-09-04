using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BookCar.Models
{
    public class Car
    {
       
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string carType { get; set; }

        [Required]
        public DateTime releaseDate { get; set; }

        [Required]
        public DateTime dateAdded { get; set; }

        [Required]
        public int numberInStock { get; set; }

        public int carTypeID { get; set; }

    }
}