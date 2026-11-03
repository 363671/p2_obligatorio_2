using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Filters;
using WebApp.Models;

namespace WebApp.Controllers
{
    [RedirigirSiLogueado]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
