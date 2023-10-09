using Act2Unidad2.Models.Entities;
using Act2Unidad2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Act2Unidad2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            PerrosContext context = new();

            var datos = context.Razas.OrderBy(x => x.Nombre).Select(x => new RazasViewModel
            {
                IdRaza = (int)x.Id,
                NombreRaza = x.Nombre
            });

            return View(datos);
        }


    }
}
