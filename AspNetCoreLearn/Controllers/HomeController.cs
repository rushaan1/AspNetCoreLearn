using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreLearn.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return Content("Welome to Home!");
        }
    }
}
