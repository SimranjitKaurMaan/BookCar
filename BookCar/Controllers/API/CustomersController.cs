﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookCar.Models;
using BookCar.Dtos;
using AutoMapper;

namespace BookCar.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);

        }
        //GET /api/customers/1
        public Customer GetCustomer(int id)
        {
            var customer = _context.customers.SingleOrDefault(c=>c.Id==id);
            if(customer==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return customer;

        }

        //POST /api/customers
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerdto)
        {
            if(!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerdto);
            _context.customers.Add(customer);
            _context.SaveChanges();
            customerdto.Id = customer.Id;
            return Mapper.Map<Customer,CustomerDto>(customer);

        }

        //PUT /api/customers/1
        [HttpPut]

        public void UpdateCustomer(int id,CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDb = _context.customers.SingleOrDefault(c => c.Id == id);

            if(customerInDb==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);

            }
            Mapper.Map<CustomerDto, Customer>(customerdto, customerInDb);

            
            _context.SaveChanges();

        }

        //  DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);

            }

            _context.customers.Remove(customerInDb);
            _context.SaveChanges();


        }








   }
}
