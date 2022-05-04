using Microsoft.AspNetCore.Mvc;

namespace KenkataWebshop.WebClient.Controllers
{
    public class PageController : Controller
    {

        [Route("Page")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
