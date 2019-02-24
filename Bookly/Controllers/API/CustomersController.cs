using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Bookly.DTOs;
using Bookly.Models;

namespace Bookly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private BooklyContext _context;

        public CustomersController()
        {
            _context = new BooklyContext();
        }

        public IHttpActionResult GetCustomers()
        {
            var customers = _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
            return Ok(customers);
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
                //   throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Ok(Mapper.Map<Customer,CustomerDTO>(customer));
        }
        [HttpPost]
        public IHttpActionResult AddCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDto);
            var addCustomer = _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
           // return customerDto;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
                //   throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var updateCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (updateCustomer == null)
            {
                return NotFound();
                //throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(customerDto, updateCustomer);
         
            
            _context.SaveChanges();
            return Ok("Updated");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
                //throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Ok("Deleted");
        }
    }
}
