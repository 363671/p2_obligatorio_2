using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Caso : IValidable
    {
        // ATRIBUTOS y PROPERTIES
        private static int UltimoId { get; set; } = 0;
        private int Id { get; set; }
        private string Nombre { get; set; }
        private string Descripcion { get; set; }
        private bool Activo { get; set; }
        private Sospechoso SospechosoPrincipal { get; set; }
        private Investigador InvestigadorD { get; set; }
        private List<Evidencia> _evidenciasDelCaso { get; set; } = new List<Evidencia>();

        // CONSTRUCTORES
        public Caso()
        {
            Id = ++UltimoId;
            ValidarDatos();
        }

        public Caso(string nombre, string descripcion, bool activo)
        {
            Id = ++UltimoId;
            Nombre = nombre;
            Descripcion = descripcion;
            Activo = activo;
            ValidarDatos();
        }

        // Constructor para Evidencias Fisicas
        public Caso(string nombre, string descripcion, bool activo, Sospechoso sospechoso, Investigador investigadorD, DateTime fechaRecoleccion, string descEvidencia, bool tieneHuellasDigitales)
        {
            Id = ++UltimoId;
            Nombre = nombre;
            Descripcion = descripcion;
            Activo = activo;
            SospechosoPrincipal = sospechoso;
            InvestigadorD = investigadorD;
            _evidenciasDelCaso.Add(new Fisica(tieneHuellasDigitales, fechaRecoleccion, descEvidencia));
            ValidarDatos();
        }

        // Constructor para Evidencias Grabaciones
        public Caso(string nombre, string descripcion, bool activo, Sospechoso sospechoso, Investigador investigadorD, DateTime fechaRecoleccion, string descEvidencia, int calidad, bool inFraganti)
        {
            Id = ++UltimoId;
            Nombre = nombre;
            Descripcion = descripcion;
            Activo = activo;
            SospechosoPrincipal = sospechoso;
            InvestigadorD = investigadorD;
            _evidenciasDelCaso.Add(new Grabacion(calidad, inFraganti, fechaRecoleccion, descEvidencia));
            ValidarDatos();
        }

        // Constructor para Evidencias Testimonios
        public Caso(string nombre, string descripcion, bool activo, Sospechoso sospechoso, Investigador investigadorD, DateTime fechaRecoleccion, string descEvidencia, string nombreTestigo, Credibilidad credibilidad)
        {
            Id = ++UltimoId;
            Nombre = nombre;
            Descripcion = descripcion;
            Activo = activo;
            SospechosoPrincipal = sospechoso;
            InvestigadorD = investigadorD;
            _evidenciasDelCaso.Add(new Testimonio(nombreTestigo, credibilidad, fechaRecoleccion, descEvidencia));
            ValidarDatos();
        }

        // // // // // // // // // // // // // // // // //
        //                                              //
        //                   METODOS                    //
        //                                              //
        // // // // // // // // // // // // // // // // //

        public void AgregarEvidencia(Evidencia e)
        {
            ValidarActivo();
            _evidenciasDelCaso.Add(e);
        }

        public void ValidarDatos()
        {
            ValidarActivo();
            ValidarInvestigador();
        }

        private void ValidarActivo()
        {
            if (!Activo)
            {
                throw new Exception(" < Ha ocurrido un error / El Caso se encuentra INACTIVO. > ");
            }
        }

        private void ValidarInvestigador()
        {
            if(InvestigadorD.Rol == Rol.Fiscal)
            {
                throw new Exception(" < Ha ocurrido un error / Investigador es Fiscal, no Detective / > ");
            }
        }

        public string ElaborarRecomendacion()
        {
            string recomendacion = "";
            int puntaje = 0;
            
            // Aqui voy a agregar los calculos del puntaje
            // !


            if(puntaje < 30)
            {
                recomendacion = $"DESESTIMADO: El caso “[{Nombre}]“ carece de fundamentos. \n" +
                                $"El peso de la prueba es [{puntaje}] y debería ser desestimado \n" +
                                $"finalizando la investigación en contra de [{SospechosoPrincipal.Nombre}] \n";
            }

            if (puntaje >= 30 && puntaje < 70)
            {
                recomendacion = $"CONTINUAR INVESTIGANDO: El caso “[{Nombre}]” parece ir \n" +
                                $"por el camino correcto, pero necesita más investigación. \n" +
                                $"El peso de la prueba es [{puntaje}] pero aún no hay información \n" +
                                $"suficiente para imputar a [{SospechosoPrincipal.Nombre}] \n";
            }
            
            if (puntaje >= 70)
            {
                recomendacion = $"IMPUTACIÓN INMINENTE: El caso “[{Nombre}]” está resuelto. \n" +
                                $"El peso de la prueba es [{puntaje}] \n" +
                                $"y debería imputarse a [{SospechosoPrincipal.Nombre}] inmediatamente. \n";

            }

            return recomendacion;
        }


        // Se cuenta cuantas evidencias hay y se evalua su fecha de recol.
        public int SumaDeEvidencias()
        {
            int peso = 0;

            List<Evidencia> l = GetEvidenciasDelCaso();

            foreach (Evidencia e in l)
            {
                peso += e.CalcularPesoEvidencia();
            }

            return peso;
        }
        
        public List<Evidencia> GetEvidenciasDelCaso()
        {
            return _evidenciasDelCaso;
        }
        
        public bool MailEsDeInvestigador(string mail)
        {
            return InvestigadorD.InvestigadorTieneMail(mail);
        }

        // // // // // // // // // // // // // // // // //
        //                                              //
        //                POLIMORFISMO                  //
        //                                              //
        // // // // // // // // // // // // // // // // //

        public override string ToString()
        {
            string datosCaso = "\n------------------------------------------------------------------------";

            datosCaso += $"\n Caso: \n";
            datosCaso += $"  -> Id: {Id} Nombre: {Nombre} \n";
            datosCaso += $"  Descripcion: {Descripcion} \n";
            datosCaso += $"{SospechosoPrincipal.ToString()}";
            datosCaso += $"  Evidencias: \n";

            for (int i = 0; i < _evidenciasDelCaso.Count(); i++)
            {
                datosCaso += "    " + _evidenciasDelCaso[i].ToString();
            }

            return datosCaso;
        }

        public override bool Equals(object? obj)
        {
            return obj is Caso caso && Nombre == caso.Nombre;
        }
    }
}
