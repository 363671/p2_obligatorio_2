using Dominio;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filters;

namespace WebApp.Controllers
{
    // si esta Logueado, no debe acceder al Login, al Registro
    public class AccesoController : Controller
    {
        Sistema s = Sistema.GetInstancia();

        [RedirigirSiLogueado]
        public IActionResult Login()
        {
            return View();
        }

        [RedirigirSiLogueado]
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

        [RedirigirSiLogueado]
        public IActionResult Registrarse()
        {
            return View();
        }

        [RedirigirSiLogueado]
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

        // de no estar Logueado, no tiene sentido que se permita hacer este Clear()
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}
