using Act2Unidad2.Models.Entities;
using Act2Unidad2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Act2Unidad2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //PerrosContext context = new();

            //    var datos = context.Razas.OrderBy(x => x.Nombre).Select(x => new IndexViewModel
            //    {
            //        IdRaza = (int)x.Id,
            //        NombreRaza = x.Nombre
            //    });

            PerrosContext context = new();

            var datos = context.Razas.OrderBy(x => x.Nombre);

            IndexViewModel vm = new();

            vm.ListaRazas = datos.Select(x => new RazasModel
            {
                IdRaza = (int)x.Id,
                NombreRaza = x.Nombre
            });

            return View(vm);
        }

        //metodo para generar abecedario

        [Route("/Home/Detalles/{NombreRaza}")]
        public IActionResult Detalles(string NombreRaza)
        {
            PerrosContext context = new();

            var datos = context.Razas.Include(x => x.Caracteristicasfisicas)
                .Include(x => x.Estadisticasraza).Include(x => x.IdPaisNavigation).FirstOrDefault(x => x.Nombre == NombreRaza);

            RazaViewModel vm = new()
            {
                IdRaza = (int)datos.Id,
                NombreRaza = datos.Nombre,
                Descripcion = datos.Descripcion,
            };

            return View(vm);
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
