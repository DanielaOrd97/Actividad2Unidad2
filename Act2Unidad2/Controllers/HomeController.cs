using Act2Unidad2.Models.Entities;
using Act2Unidad2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Act2Unidad2.Controllers
{
    public class HomeController : Controller
    {
        IndexViewModel vm = new();

        public IActionResult Index()
        {

            PerrosContext context = new();

            var datos = context.Razas.OrderBy(x => x.Nombre).ToList();

            vm.Abecedario = datos.Select(x => x.Nombre.FirstOrDefault()).Distinct().ToList();

            vm.ListaRazas = datos.Select(x => new RazasModel
            {
                IdRaza = (int)x.Id,
                NombreRaza = x.Nombre,
            });

          
            return View(vm);

        }


        [Route("/Home/Index/{letra}")]
        public IActionResult Index(char letra)
        {

            PerrosContext context = new();

            var datos = context.Razas.OrderBy(x => x.Nombre).ToList();

            vm.Abecedario = datos.Select(x => x.Nombre.FirstOrDefault()).Distinct().ToList();


            var datos1 = context.Razas.Where(x => x.Nombre.FirstOrDefault() == letra).ToList();

            vm.ListaRazas = datos1.Select(x => new RazasModel
            {
                NombreRaza = x.Nombre,
                IdRaza = (int)x.Id
            });


            

            return View(vm);
        }

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
                    Color = datos.Caracteristicasfisicas.Color,
                };

               

                Random r = new();
                var lista = context.Razas.ToList().OrderBy(x => r.Next()).Take(4);

                vm.ListaAzar = lista.Select(x => new AzarModel
                {
                    Id = (int)x.Id,
                    Nombre = x.Nombre
                });
                
                return View(vm);


            }




        }


        public IActionResult Paises()
        {
            PerrosContext context = new();

            var datos = context.Paises.Include(x => x.Razas).OrderBy(x => x.Nombre).Select(x => new PaisesViewModel
            {
                NombrePais = x.Nombre ?? "No disponible",
                ListaRazasP = x.Razas.Select(x => new RazasModel1
                {
                    IdRaza = (int)x.Id,
                    NombreRaza = x.Nombre
                })
            });

            return View(datos);
        }

    }
}
