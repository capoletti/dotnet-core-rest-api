using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rest_api.Models;

namespace rest_api.Controllers
{
    [Route("rest-api/[controller]")]
    public class ClientController : Controller
    {
        private readonly ClientContext _context;
        
        // Constructor dependency injection data context
        public ClientController(ClientContext context)
        {
            _context = context;
        } 

        // GET rest-api/client
        // return all itens 
        [HttpGet]
        public IEnumerable<Client> GetAll()
        {            
            return _context.ClientBase.ToList();
        }

        // GET rest-api/client
        // return item by ID
        [HttpGet("{id}", Name = "GetClient")]
        public IActionResult GetById(long id)
        {
            var item = _context.ClientBase.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound(); //404
            }
            return new ObjectResult(item);
        }

        // POST rest-api/client json type
        // create a new item and return the item with the new ID
        [HttpPost]
        public IActionResult Create([FromBody] Client item)
        {
            if (item == null)
            {
                return BadRequest(); //400
            }

            _context.ClientBase.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetClient", new { id = item.Id }, item);
        }

        // POST rest-api/client json type and ID
        // update the item with body's content by id 
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Client item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest(); //400
            }

            var client = _context.ClientBase.FirstOrDefault(t => t.Id == id);
            if (client == null)
            {
                return NotFound(); //404
            }

            client.Address = item.Address;
            client.Name = item.Name;

            _context.ClientBase.Update(client);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE rest-api/client
        // delete item by id
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var client = _context.ClientBase.First(t => t.Id == id);
            if (client == null)
            {
                return NotFound(); //404
            }

            _context.ClientBase.Remove(client);
            _context.SaveChanges();
            return new NoContentResult(); //204
        }
    }
}
