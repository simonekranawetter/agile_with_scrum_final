using Microsoft.AspNetCore.Mvc;

namespace KenkataWebshop.WebClient.Controllers
{
    public class ProductController : Controller
    {
        [Route("/Products")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
