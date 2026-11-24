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
                Casos = s.GetCasosDeUnInvestigador(iLogueado);
            }

            // Ordeno la lista
            //  según el criterio de ordenamiento establecido en el CompareTo
            Casos.Sort();

            ViewBag.Casos = Casos;

            return View(iLogueado);
        }

        // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //
        // // // // // // // // //            CasoDetalle           // // // // // // // // // //
        // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //

        // Opción para DETECTIVES y FISCALES
        // HttpGet
        public IActionResult CasoDetalle(int id, string btnRecomendacion)
        {
            Caso cSeleccionado = s.GetCasoPorId(id);

            Investigador iLogueado = GetInvestigadorLogueado();

            // en este apartado se controla que un Detective no pueda acceder a un Caso que no se encuentre asignado
            if(iLogueado.Rol.ToString() != "Fiscal" && cSeleccionado.InvestigadorD.Id != iLogueado.Id)
            {
                return RedirectToAction("Index");
            }

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

            TempData["Excepcion"] += "";

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

            if (slcTipoEvidencia == "x")
            {
                TempData["Excepcion"] = "Debes seleccionar un Tipo de Evidencia.";
            }

            // FechaRecoleccion Descripcion / TieneHuellasDigitales / Calidad InFraganti / NombreTestigo IndiceCredibilidad
            if (slcTipoEvidencia == "Fisica")
            {
                bool tiene = false;

                if(TieneHuellasDigitales == "siTiene")
                {
                    tiene = true;
                }

                try
                {
                    cSeleccionado.AgregarEvidencia(new Fisica(tiene, FechaRecoleccion, Descripcion));
                }
                catch (Exception e)
                {
                    TempData["Excepcion"] = " " + e.Message;
                }
            }

            if (slcTipoEvidencia == "Grabacion")
            {
                bool captado = false;

                if (InFraganti == "on")
                {
                    captado = true;
                }

                try
                {
                    // TODO, se deberia generar la Evidencia desde Sistema? consultar
                    cSeleccionado.AgregarEvidencia(new Grabacion(Calidad, captado, FechaRecoleccion, Descripcion));
                }
                catch (Exception e)
                {
                    TempData["Excepcion"] += " " + e.Message;
                }
            }

            if (slcTipoEvidencia == "Testimonio")
            {
                try
                {
                    cSeleccionado.AgregarEvidencia(new Testimonio(NombreTestigo, IndiceCredibilidad, FechaRecoleccion, Descripcion));
                }
                catch (Exception e)
                {
                    TempData["Excepcion"] += " " + e.Message;
                }
            }

            return View(cSeleccionado);
        }

        // // // // // // // // // //                               // // // // // // // // // //
        // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //


        // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //
        // // // // // // // // // //            CasoAlta           // // // // // // // // // //
        // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //

        // Opción exclusiva para FISCALES
        [FiltroParaDetective]
        public IActionResult CasoAlta()
        {
            IEnumerable<Sospechoso> listaSospechosos = s.GetSospechosos();
            IEnumerable<Investigador> listaDetectives = s.GetDetectives();

            ViewBag.Sospechosos = listaSospechosos;
            ViewBag.Detectives = listaDetectives;

            List<string> tiposEvidencias = s.GetClasesHijasDeEvidencia();
            ViewBag.TiposEvidencias = tiposEvidencias;

            return View();
        }

        [HttpPost]
        public IActionResult CasoAlta(
            // Datos del Caso
            // // string NombreCaso,
            // // string DescripcionCaso,
            Caso cNuevo,
            // Sospechoso
            int slcSospechoso,
            // Detective
            int slcDetective,
            // Evidencia
            string slcTipoEvidencia,
            DateTime FechaRecoleccion,
            string Descripcion,
            string TieneHuellasDigitales,
            int Calidad,
            string InFraganti,
            string NombreTestigo,
            Credibilidad IndiceCredibilidad)
        {
            Sospechoso sSeleccionado = s.GetSospechosoPorId(slcSospechoso);
            Investigador dSeleccionado = s.GetInvestigadorPorId(slcDetective);

            IEnumerable<Sospechoso> listaSospechosos = s.GetSospechosos();
            IEnumerable<Investigador> listaDetectives = s.GetDetectives();

            cNuevo.SospechosoPrincipal = sSeleccionado;
            cNuevo.InvestigadorD = dSeleccionado;

            ViewBag.Sospechosos = listaSospechosos;
            ViewBag.Detectives = listaDetectives;

            List<string> tiposEvidencias = s.GetClasesHijasDeEvidencia();
            ViewBag.TiposEvidencias = tiposEvidencias;

            // FechaRecoleccion Descripcion / TieneHuellasDigitales / Calidad InFraganti / NombreTestigo IndiceCredibilidad
            if (slcTipoEvidencia == "Fisica")
            {
                bool tiene = false;

                if (TieneHuellasDigitales == "siTiene")
                {
                    tiene = true;
                }

                try
                {
                    cNuevo.AgregarEvidencia(new Fisica(tiene, FechaRecoleccion, Descripcion));
                }
                catch (Exception e)
                {
                    TempData["Excepcion"] += " " + e.Message;
                }
            }

            if (slcTipoEvidencia == "Grabacion")
            {
                bool captado = false;

                if (InFraganti == "on")
                {
                    captado = true;
                }

                try
                {
                    cNuevo.AgregarEvidencia(new Grabacion(Calidad, captado, FechaRecoleccion, Descripcion));
                }
                catch (Exception e)
                {
                    TempData["Excepcion"] += " " + e.Message;
                }

            }

            if (slcTipoEvidencia == "Testimonio")
            {
                try
                {
                    cNuevo.AgregarEvidencia(new Testimonio(NombreTestigo, IndiceCredibilidad, FechaRecoleccion, Descripcion));
                }
                catch (Exception e)
                {
                    TempData["Excepcion"] += " " + e.Message;
                }
            }

            if (TempData["Excepcion"] == null)
            {
                try
                {
                    // se agrega el Caso a la lista _casos
                    s.AgregarCaso(cNuevo);
                }
                catch (Exception e)
                {
                    TempData["Excepcion"] += " " + e.Message;
                }

                TempData["CasoIngresado"] = "¡Caso ingresado exitosamente!";
                
                
                return RedirectToAction("CasoDetalle", new { id = cNuevo.Id });
            }

            return View();
        }

        // // // // // // // // // //                               // // // // // // // // // //
        // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //

        /// <summary>
        /// Se listan los Sospechosos del Sistema.
        /// Si no hay un Nombre o una Edad introducida, se traen todas las instancias.
        /// </summary>
        /// <param name="nombreABuscar"></param>
        /// <param name="edadASuperar"></param>
        /// <returns></returns>
        public IActionResult ListadoSospechosos(int id, string nombreABuscar, string edadASuperar, string antecedentes)
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

            if(antecedentes == "0")
            {
                listaRet = s.GetSospechososSinAntecedentes();
            }

            if (antecedentes == "1")
            {
                listaRet = s.GetSospechososConAntecedentes();
            }

            return View(listaRet);
        }

        // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //
        // // // // // // // // // //        SospechosoAlta         // // // // // // // // // //
        // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //


        public IActionResult SospechosoAlta()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SospechosoAlta(Sospechoso sAIngresar)
        {
            TempData["Fecha"] = DateTime.Today.ToString("yyyy-MM-dd");
            TempData["FechaMin"] = DateTime.Today.AddYears(-130);

            try
            {
                sAIngresar.ValidarDatos();
                s.AgregarSospechoso(sAIngresar);
            }
            catch (Exception e)
            {
                TempData["Excepcion"] += " " + e.Message;
                return View();
            }

            TempData["SospechosoIngresado"] = "¡Sospechoso ingresado con éxito!";
            
            return RedirectToAction("ListadoSospechosos", "Investigador");
        }
        
        // // // // // // // // // //                               // // // // // // // // // //
        // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //

    }
}
