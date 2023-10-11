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
            NombreRaza = NombreRaza.Replace("-", " ");

            PerrosContext context = new();

            var datos = context.Razas.Include(x => x.Caracteristicasfisicas)
                .Include(x => x.Estadisticasraza).Include(x => x.IdPaisNavigation).FirstOrDefault(x => x.Nombre == NombreRaza);


            if (datos == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                RazaViewModel vm = new()
                {
                    IdRaza = (int)datos.Id,
                    NombreRaza = datos.Nombre,
                    Descripcion = datos.Descripcion,
                    OtrosNombres = datos.OtrosNombres ?? "No existen",
                    PaisDeOrigen = datos.IdPaisNavigation.Nombre ?? "No disponible",
                    PesoMax = datos.PesoMax,
                    PesoMin = datos.PesoMin,
                    AlturaMin = datos.AlturaMin,
                    AlturaMax = datos.AlturaMax,
                    EsperanzaDeVida = (int)datos.EsperanzaVida,
                    NivelEnergia = (int)datos.Estadisticasraza.NivelEnergia,
                    Entrenamiento = (int)datos.Estadisticasraza.FacilidadEntrenamiento,
                    EjercicioObligatorio = (int)datos.Estadisticasraza.EjercicioObligatorio,
                    AmistadDesconocidos = (int)datos.Estadisticasraza.AmistadDesconocidos,
                    AmistadPerros = (int)datos.Estadisticasraza.AmistadPerros,
                    Cepillado = (int)datos.Estadisticasraza.NecesidadCepillado,
                    Patas = datos.Caracteristicasfisicas.Patas,
                    Cola = datos.Caracteristicasfisicas.Cola,
                    Hocico = datos.Caracteristicasfisicas.Hocico,
                    Pelo = datos.Caracteristicasfisicas.Pelo,
                    Color = datos.Caracteristicasfisicas.Color
                };

                return View(vm);
            }

        }

    }
}
