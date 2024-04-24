using AspNetCoreLearn.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreLearn.Controllers
{
    public class OrderController : Controller
    {
        [Route("Order")]
        public IActionResult Order(Order order)
        {
            if (!ModelState.IsValid) 
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
                return new ContentResult { Content = errors, ContentType = "text/plain", StatusCode=400 };
            }

            Random random = new Random();
            int rn = random.Next();
            int orderId = (rn % 99999)+1;
            object response = new { orderNumber=orderId };

            return new JsonResult(response);
        }
    }
}
