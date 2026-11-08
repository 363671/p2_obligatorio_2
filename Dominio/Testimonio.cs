using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public class Testimonio : Evidencia, IValidable
    {
        // CLASE HIJA de EVIDENCIA

        // PROPERTIES
        public string NombreTestigo { get; set; }
        public Credibilidad IndiceCredibilidad { get; set; }

        // CTOR
        
        public Testimonio(string nombreTestigo, Credibilidad indiceCredibilidad, DateTime fechaRecoleccion, string descripcion) : base(fechaRecoleccion, descripcion)
        {
            NombreTestigo = nombreTestigo;
            IndiceCredibilidad = indiceCredibilidad;
            ValidarDatos();
        }

        // // // // // // // // // // // // // // // // //
        //                                              //
        //                   METODOS                    //
        //                                              //
        // // // // // // // // // // // // // // // // //

        public void ValidarDatos()
        {
            ValidarNombreTestigo();
        }

        // Se valida que el nombre no sea Nulo y que no supere los 90 caracteres
        private void ValidarNombreTestigo()
        {
            string errores = "";

            if (NombreTestigo.IsWhiteSpace())
            {
                errores += "El largo del Nombre del Testigo no puede ser nulo.";
                
                
            } else if (NombreTestigo.Length > 90)
            {
                errores += "El largo del Nombre del Testigo no puede superar los 90 caracteres.";
            }
            

            if (errores != "")
            {
                Console.WriteLine("");
                throw new Exception(" < Ha ocurrido un error / Nombre del Testigo / > ");
            }
        }

        public override int CalcularPesoEvidencia()
        {
            int ptos = 0;
            
            if(IndiceCredibilidad == Credibilidad.Medio ||
                IndiceCredibilidad == Credibilidad.Alto)
            {
                ptos += 10;
            }

            return base.CalcularPesoEvidencia() + ptos;
        }

        // // // // // // // // // // // // // // // // //
        //                                              //
        //                POLIMORFISMO                  //
        //                                              //
        // // // // // // // // // // // // // // // // //

        public override string ToString()
        {
            string evidencia = " ----------------- Evidencia > Testimonio ----------------- ";
            evidencia += $"\n     | Testigo: {NombreTestigo} / Ind. Credibilidad: {IndiceCredibilidad} |\n";
            evidencia += base.ToString();

            return evidencia;
        }

    }
}
