using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using BookCar.Models;

namespace BookCar.Dtos
{
    public class CustomerDto
    {

        public int Id { get; set; }

        
        public string Name { get; set; }

       
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; } //foreign key
    }
}