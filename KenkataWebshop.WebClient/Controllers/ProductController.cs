using Microsoft.AspNetCore.Mvc;

namespace KenkataWebshop.WebClient.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
