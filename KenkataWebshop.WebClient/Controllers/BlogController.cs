using Microsoft.AspNetCore.Mvc;

namespace KenkataWebshop.WebClient.Controllers
{
    public class BlogController : Controller
    {

        [Route("Blog")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
