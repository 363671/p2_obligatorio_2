using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class InvestigadorController : Controller
    {
        Sistema s = Sistema.GetInstancia();

        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("IdLogueado") != null)
            {

            }
                //HttpContext.Session.SetInt32("IdLogueado")

            return View();
        }
    }
}
