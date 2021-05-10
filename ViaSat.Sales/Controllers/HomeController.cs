using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViaSat.Sales.Entities;

namespace ViaSat.Sales.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public static List<List<Good>> SalesTaxes()
        {
            return new List<List<Good>>()
            {
                new List<Good>()
                {
                    new Good(2, "book", true, 12.49m),
                    new Good(1, "music CD", false, 14.99m),
                    new Good(1, "chocolate bar", true, 0.85m)
                },

                // Test2

                new List<Good>()
                {
                    new Good(1, "imported box of chocolates", true, 10.00m),
                    new Good(1, "imported bottle of perfume", false, 47.50m)
                },

                // Test3

                new List<Good>()
                {
                    new Good(1, "imported bottle of perfume", false, 27.99m),
                    new Good(1, "bottle of perfume", false, 18.99m),
                    new Good(1, "packet of headache pills", true, 9.75m),
                    new Good(3, "box of imported chocolates", true, 11.25m)
                }
            };
        }

        [HttpGet]
        public IEnumerable<Good> Get()
        {
            var rng = new Random();
            return SalesTaxes().ElementAt(rng.Next(3)).ToArray();
        }
    }
}
