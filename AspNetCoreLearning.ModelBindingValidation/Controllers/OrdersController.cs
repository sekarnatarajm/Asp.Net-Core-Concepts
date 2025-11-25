using AspNetCoreLearning.ModelBindingValidation.Model;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreLearning.ModelBindingValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpPost("create")]
        public IActionResult SaveProduct(Orders orders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
