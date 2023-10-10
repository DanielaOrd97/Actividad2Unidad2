using Act2Unidad2.Models.Entities;
using Act2Unidad2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Act2Unidad2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(char letra)
        {
            PerrosContext context = new();
           
                var datos = context.Razas.OrderBy(x => x.Nombre).Select(x => new IndexViewModel
                {
                    IdRaza = (int)x.Id,
                    NombreRaza = x.Nombre
                });

            return View(datos);
        }

        //public IActionResult Filtro(char letra)
        //{
        //    PerrosContext context = new();

        //    var datos = context.Razas.OrderBy(x => x.Nombre).Where(x => x.Nombre[0] == letra).Select(x => new IndexViewModel
        //    {
        //        IdRaza = (int)x.Id,
        //        NombreRaza = x.Nombre
        //    });

        //    return View(datos);
        //}

    }
}
