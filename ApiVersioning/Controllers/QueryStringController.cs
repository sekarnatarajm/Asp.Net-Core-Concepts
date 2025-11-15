using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ApiVersion("1.0" , Deprecated = true)]
    [ApiVersion("2.0")]
    public class QueryStringController : BaseController
    {
        [HttpGet("api/search/order")]
        [MapToApiVersion("1.0")]
        public IActionResult GetOrderDataV1(int id)
        {
            var productsV1 = _products.Select(p => new ProductResponseV1 { Id = p.Id, Name = p.Name });
            return Ok(productsV1);
        }
        [HttpGet("api/search/order")]
        [MapToApiVersion("2.0")]
        public IActionResult GetOrderDataV2(int id)
        {
            var productsV1 = _products.Select(p => new ProductResponseV2 { Id = p.Id, Name = p.Name, Price = p.Price });
            return Ok(productsV1);
        }
    }
}
