using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_.Models;

namespace WebApi_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>()
        {
            new Product{
            Id = 1006368,
            Name = "Austin and Barbeque AABQ Wifi Food Thermometer",
            Description = "Thermometer med WiFi för en optimal innertemperatur",
            Price = 399
            },

            new Product{
            Id = 1006369,
            Name = "Andersson Elektrisd Tandare ECL 1.1",
            Description = "Elektrisk stormsäker tändare helt utan gas och bränsle",
            Price = 89
            },

            new Product{
            Id = 1006370,
            Name = "Webber Non Stick Spray",
            Description = "BBQ-Oljespray som motverkar att råvaror fastnar på gallret",
            Price = 99
            }
        };

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id) 
        {
            var product = products.Find(product => product.Id == id);
            if (product == null) 
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Product product) 
        {
            if (products.Exists(p =>p.Id == product.Id)) 
            {
                return Conflict();
            }
            products.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, products);
        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Product>> Delete(int id)
        {
            var product = products.Where(product => product.Id == id);
            if (product == null) 
            {
                return NotFound();
            }
            products = products.Except(product).ToList();
            return products;
        }

        [HttpPut]
        public ActionResult<IEnumerable<Product>> Put(int id, [FromBody] Product product) 
        {
            if(id != product.Id) 
            {
                return BadRequest();
            }

            var existingProduct = products.Where(p => p.Id == id);
            products = products.Except(existingProduct).ToList();
            products.Add(product);
            return products;
        }
 
    }
}
