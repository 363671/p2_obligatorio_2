using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AccesoController : Controller
    {
        Sistema s = Sistema.GetInstancia();

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string pass)
        {
            Investigador i = s.GetInvestigadorLogin(email, pass);

            if (i != null)
            {
                // seteo las variables de session
                HttpContext.Session.SetInt32("IdLogueado", i.Id);
                HttpContext.Session.SetString("RolLogueado", i.Rol.ToString());

                return RedirectToAction("Index", "Investigador");
            }

            ViewBag.Error = "Credenciales inválidas.";
            
            return View();
        }

        public IActionResult Registrarse()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult Registrarse(Investigador i)
        {
            try
            {
                //se crea el Investigador
                s.AgregarInvestigador(i);

                // seteo las variables de session
                HttpContext.Session.SetInt32("IdLogueado", i.Id);
                HttpContext.Session.SetString("RolLogueado", i.Rol.ToString());
                ViewBag.detective = i;

                //se loguea de forma directa
                return RedirectToAction("Index", "Investigador");
            }
            catch(Exception e)
            {
                ViewBag.ErrorRegistro = e.Message;
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}
