using Microsoft.AspNetCore.Mvc;

namespace KenkataWebshop.WebClient.Controllers
{
    public class CategoryController : Controller
    {

        [Route("Category")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
