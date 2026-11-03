using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{

    // visto en clase con el profe
    // verificacion opcional para este Obligatorio
    // -> [VerificarSesion]
    //  -> depende de la Clase WebApp/Filters/VerificarSesionAttribute.cs

    [VerificarSesion]
    public class InvestigadorController : Controller
    {
        Sistema s = Sistema.GetInstancia();

        public IActionResult Index()
        {
            //el filtro ya se encargó de corrobor que haya alguien logueado
            int idInvestigador = HttpContext.Session.GetInt32("IdLogueado").Value;

            Investigador iLogueado = s.GetInvestigadorPorId(idInvestigador);

            return View(iLogueado);
        }

        public IActionResult Perfil()
        {

            return View();
        }

        // Detective
        public IActionResult VerCasosAsignados()
        {

            return View();
        }

        public IActionResult VerSospechosos()
        {

            return View();
        }

        // Fiscal
        public IActionResult CrearCaso()
        {

            return View();
        }

    }
}
