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

        public IActionResult Casos()
        {
            Investigador iLogueado = GetInvestigadorLogueado();

            List<Caso> Casos = new List<Caso>();

            if(iLogueado.Rol.ToString() == "Fiscal")
            {
                Casos = s.GetCasos();
            }

            if (iLogueado.Rol.ToString() == "Detective")
            {
                Casos = s.ListarCasosDeUnInvestigador(iLogueado);
            }

            // Ordeno la lista
            //  según el criterio de ordenamiento establecido en el CompareTo
            Casos.Sort();

            ViewBag.Casos = Casos;

            return View(iLogueado);
        }

        // Opción para DETECTIVES y FISCALES
        // HttpGet
        public IActionResult CasoDetalle(int id, string btnRecomendacion)
        {
            Caso cSeleccionado = s.GetCasoPorId(id);

            ViewBag.Recomendacion = "";

            List<string> tiposEvidencias = s.GetClasesHijasDeEvidencia();
            ViewBag.TiposEvidencias = tiposEvidencias;

            if(btnRecomendacion == "elaborarRecomendacion")
            {
                ViewBag.Recomendacion = cSeleccionado.ElaborarRecomendacion();
            }

            return View(cSeleccionado);
        }

        // la vista CasoDetalle tiene Vistas Parciales integradas
        // -> AgregarFormulario.cshtml
        [HttpPost]
        public IActionResult CasoDetalle(
            int id,
            string btnRecomendacion, 
            string slcTipoEvidencia,
            DateTime FechaRecoleccion,
            string Descripcion,
            string TieneHuellasDigitales,
            int Calidad,
            string InFraganti,
            string NombreTestigo,
            Credibilidad IndiceCredibilidad)
        {
            Caso cSeleccionado = s.GetCasoPorId(id);

            List<string> tiposEvidencias = s.GetClasesHijasDeEvidencia();
            ViewBag.TiposEvidencias = tiposEvidencias;

            ViewBag.Recomendacion = "";
            TempData["EvidenciaInvalida"] = "";
            TempData["TipoEvidencia"] = "";
            TempData["FechaActual"] = DateTime.Today.ToString("yyyy-MM-dd");

            // en el Detalle del Caso, interesa que se pueda modificar el estado del CASO
            // como modifica el Sistema, corresponde que sea POST
            switch (btnRecomendacion)
            {
                case "btnReactivar":
                    ViewBag.Recomendacion = "";
                    cSeleccionado.ReActivarElCaso();
                    break;
                case "tomarRecomendacion": 
                    cSeleccionado.Inactivar();
                    break;
            }

            // FechaRecoleccion Descripcion / TieneHuellasDigitales / Calidad InFraganti / NombreTestigo IndiceCredibilidad
            if (slcTipoEvidencia == "Fisica")
            {
                bool tiene = false;

                if(TieneHuellasDigitales == "siTiene")
                {
                    tiene = true;
                }

                // TODO, se deberia generar la Evidencia desde Sistema? consultar
                cSeleccionado.AgregarEvidencia(new Fisica(tiene, FechaRecoleccion, Descripcion));

                TempData["EvidenciaIngresada"] = "Evidencia Física ingresada.";
            }

            if (slcTipoEvidencia == "Grabacion")
            {
                bool captado = false;

                if (InFraganti == "on")
                {
                    captado = true;
                }

                // TODO, se deberia generar la Evidencia desde Sistema? consultar
                cSeleccionado.AgregarEvidencia(new Grabacion(Calidad, captado, FechaRecoleccion, Descripcion));
                
                TempData["EvidenciaIngresada"] = "Evidencia Grabación ingresada.";
            }

            if (slcTipoEvidencia == "Testimonio")
            {
                cSeleccionado.AgregarEvidencia(new Testimonio(NombreTestigo, IndiceCredibilidad, FechaRecoleccion, Descripcion));
             
                TempData["EvidenciaIngresada"] = "Evidencia Testimonio ingresada.";
            }

            return View(cSeleccionado);
        }

        /// <summary>
        /// Se listan los Sospechosos del Sistema.
        /// Si no hay un Nombre o una Edad introducida, se traen todas las instancias.
        /// </summary>
        /// <param name="nombreABuscar"></param>
        /// <param name="edadASuperar"></param>
        /// <returns></returns>
        public IActionResult ListadoSospechosos(string nombreABuscar, string edadASuperar)
        {
            Investigador iLogueado = GetInvestigadorLogueado();
            ViewBag.UsuarioLogueado = iLogueado;

            List<Sospechoso> listaRet = s.GetSospechosos();
            
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

        // Opción exclusiva para FISCALES
        [FiltroParaDetective]
        public IActionResult CasoAlta()
        {
            IEnumerable<Sospechoso> listaSospechosos = s.GetSospechosos();
            IEnumerable<Investigador> listaDetectives = s.GetDetectives();

            ViewBag.Sospechosos = listaSospechosos;
            ViewBag.Detectives = listaDetectives;

            ViewBag.AgregacionEvidencia = false;
            List<string> tiposEvidencias = s.GetClasesHijasDeEvidencia();
            ViewBag.TiposEvidencias = tiposEvidencias;

            return View();
        }

    }
}
