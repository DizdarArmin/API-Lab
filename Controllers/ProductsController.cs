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
        List<Product> products = new List<Product>()
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
        public Product Get(int id) 
        {
            var product = products.Find(product => product.Id == id);
            return product;
        }
    }
}
