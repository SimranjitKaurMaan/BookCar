using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookCar.Models;

namespace BookCar.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> Memberships { get; set; }
        public Customer customer { get; set; }

    }
}