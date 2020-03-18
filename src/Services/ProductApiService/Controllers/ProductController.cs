using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProductApiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private static readonly string[] Names = new[]
        {
            "ab", "ba", "ss", "cc", "1m1c", "CC123", "C12", "Hot", "Poıı", "Sice"
        };

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Product
            {
                CreatedDate = DateTime.Now.AddDays(index),
                Id = rng.Next(1, 100),
                Name = Names[rng.Next(Names.Length)]
            })
            .ToArray();
        }

         [HttpGet("{id}")]  
        public Product GetById(int id)
        {
            var rng = new Random();
            return  new Product
            {
                CreatedDate = DateTime.Now.AddDays(-id),
                Id = rng.Next(1, 100),
                Name = Names[rng.Next(Names.Length)]
            };
        }
    }
}
