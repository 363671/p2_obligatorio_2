using Dominio;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filters;

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
            
            List<Caso> CasosDeInvestigador = s.ListarCasosDeUnInvestigador(iLogueado);
            List<Caso> CasosDelSistema = s.GetCasos();

            ViewBag.CasosDetective = CasosDeInvestigador;
            ViewBag.CasosSistema = CasosDelSistema;

            return View(iLogueado);
        }

        public IActionResult CasoDetalle(int id, string inpDecision, string slcTipoEvidencia)
        {
            Caso cSeleccionado = s.GetCasoPorId(id);

            ViewBag.AgregacionEvidencia = false;
            TempData["EvidenciaInvalida"] = "";

            List<string> tiposEvidencias = ["Fisica", "Testimonio", "Grabacion"];
            ViewBag.TiposEvidencias = tiposEvidencias;

            // se evalua que Boton fue presionado, comparten "name" pero tienen distinto "value"
            switch (inpDecision)
            {
                case "agregarEvidencia":
                    ViewBag.AgregacionEvidencia = true;
                    break;

                case "cancelar":
                    ViewBag.AgregacionEvidencia = false;
                    break;

                case "siguiente":
                    ViewBag.AgregacionEvidencia = true;
                    if (slcTipoEvidencia == "x")
                        TempData["EvidenciaInvalida"] = "Error, tipo de Evidencia invalida.";
                    break;
                default:
                    break;
            }

            return View(cSeleccionado);
        }

        public IActionResult ListadoSospechosos(string nombreABuscar, string edadASuperar)
        {
            Investigador iLogueado = GetInvestigadorLogueado();
            ViewBag.UsuarioLogueado = iLogueado;

            List<Sospechoso> listaRet = new List<Sospechoso>();

            listaRet = s.GetSospechosos();
            
            if (!string.IsNullOrEmpty(nombreABuscar))
            {
                listaRet = s.GetSospechososConNombre(nombreABuscar);
            }

            if (!string.IsNullOrEmpty(edadASuperar))
            {
                listaRet = s.GetSospechososMayoresDeEdad(edadASuperar);
            }
            
            return View(listaRet);
        }

        // FISCALES
        // FiltroParaDetective > para que Detectives no puedan dar de alta
        [FiltroParaDetective]
        public IActionResult CasoAlta()
        {

            return View();
        }

    }
}
