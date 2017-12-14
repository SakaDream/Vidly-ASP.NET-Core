using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public CustomersController(IMapper mapper)
        {
            _mapper = mapper;
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IActionResult GetCustomers(string query = null)
        {
            var customersIncludeQuery = _context.Customers.Include(c => c.MembershipType);
            var customersQuery = customersIncludeQuery.Where(c => true);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));    

            return Ok(customersQuery.ToList().Select(_mapper.Map<Customer, CustomerDto>));
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();
            return Ok(_mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return CreatedAtRoute("GetCustomer", new {id = customer.Id}, _mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerInDb = _context.Customers.Single(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.Single(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return NoContent();
        }
    }
}