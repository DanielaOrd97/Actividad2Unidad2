using Microsoft.AspNetCore.Mvc;

namespace Act2Unidad2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
