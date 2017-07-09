using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rest_api.Models;

namespace rest_api.Controllers
{
    [Route("rest-api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly CustomerContext _context;
        
        // Constructor dependency injection data context
        public CustomerController(CustomerContext context)
        {
            _context = context;
        } 

        // GET rest-api/customer
        // return all itens 
        [HttpGet]
        public IEnumerable<Customer> GetAll()
        {            
            return _context.CustomerBase.ToList();
        }

        // GET rest-api/customer
        // return item by ID
        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult GetById(long id)
        {
            var item = _context.CustomerBase.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound(); //404
            }
            return new ObjectResult(item);
        }

        // POST rest-api/customer json type
        // create a new item and return the item with the new ID
        [HttpPost]
        public IActionResult Create([FromBody] Customer item)
        {
            if (item == null)
            {
                return BadRequest(); //400
            }

            _context.CustomerBase.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetCustomer", new { id = item.Id }, item);
        }

        // POST rest-api/customer json type and ID
        // update the item with body's content by id 
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Customer item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest(); //400
            }

            var customer = _context.CustomerBase.FirstOrDefault(t => t.Id == id);
            if (customer == null)
            {
                return NotFound(); //404
            }

            customer.Address = item.Address;
            customer.Name = item.Name;

            _context.CustomerBase.Update(customer);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE rest-api/customer
        // delete item by id
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var customer = _context.CustomerBase.First(t => t.Id == id);
            if (customer == null)
            {
                return NotFound(); //404
            }

            _context.CustomerBase.Remove(customer);
            _context.SaveChanges();
            return new NoContentResult(); //204
        }
    }
}
