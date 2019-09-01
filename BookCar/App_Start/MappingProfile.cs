using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BookCar.Models;
using BookCar.Dtos;

namespace BookCar.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();

        }
    }
}