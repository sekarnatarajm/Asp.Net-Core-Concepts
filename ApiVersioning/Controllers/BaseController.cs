using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Controllers
{    
    public class BaseController : ControllerBase
    {
        public static readonly List<Product> _products = new List<Product>()
        {
            new Product { Id = 1, Name = "Laptop", Price = 1200 },
            new Product { Id = 2, Name = "Smartphone", Price = 700 }
        };
    }
    public class ProductResponseV1
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ProductResponseV2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
