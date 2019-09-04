using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookCar.Models;

namespace BookCar.Dtos
{
    public class NewRentalDto
    {
        public Customer customer { get; set; }
        public List<int> carIds { get; set; }


    }
}