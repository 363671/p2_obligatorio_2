using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{

    // visto en clase con el profe
    // verificacion opcional para este Obligatorio
    // -> [VerificarSesion]
    //  -> depende de la Clase WebApp/Filters/VerificarSesionAttribute.cs

    [NoEstaLogueado]
    public class InvestigadorController : Controller
    {
        Sistema s = Sistema.GetInstancia();

        // trae el Investigador que se encuentra Logueado
        public Investigador GetInvestigadorLogueado()
        {
            //el filtro ya se encargó de corrobor que haya alguien logueado
            int idInvestigador = HttpContext.Session.GetInt32("IdLogueado").Value;

            Investigador iLogueado = s.GetInvestigadorPorId(idInvestigador);

            return iLogueado;
        }

        public IActionResult Index()
        {
            Investigador iLogueado = GetInvestigadorLogueado();

            return View(iLogueado);
        }

        public IActionResult Perfil()
        {
            Investigador iLogueado = GetInvestigadorLogueado();

            return View(iLogueado);
        }

        // DETECTIVES
        public IActionResult Casos()
        {
            Investigador iLogueado = GetInvestigadorLogueado();
            ViewBag.UsuarioLogueado = iLogueado;

            return View(iLogueado);
        }

        public IActionResult ListadoSospechosos()
        {
            Investigador iLogueado = GetInvestigadorLogueado();
            ViewBag.UsuarioLogueado = iLogueado;

            List<Sospechoso> listaRet = s.GetSospechosos();
            
            return View(listaRet);
        }

        // FISCALES
        [FiscalEstaLogueado]
        public IActionResult CasoAlta()
        {

            return View();
        }

    }
}
