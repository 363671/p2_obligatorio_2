using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Fisica : Evidencia
    {
        // CLASE HIJA de EVIDENCIA

        // PROPERTIES
        private bool TieneHuellasDigitales { get; set; }

        // CTOR
        public Fisica(bool tieneHuellas, DateTime fechaRecoleccion, string descripcion) : base (fechaRecoleccion, descripcion)
        {
            TieneHuellasDigitales = tieneHuellas;
        }

        // // // // // // // // // // // // // // // // //
        //                                              //
        //                   METODOS                    //
        //                                              //
        // // // // // // // // // // // // // // // // //

        public override int CalcularPesoEvidencia()
        {
            int ptos = 0;
            
            if (TieneHuellasDigitales)
            {
                ptos = 40;
            }

            // el base calcula la Fecha de Recoleccion y le suma ptos si tiene o no Huellas digitales
            return base.CalcularPesoEvidencia() + ptos;
        }

        // // // // // // // // // // // // // // // // //
        //                                              //
        //                POLIMORFISMO                  //
        //                                              //
        // // // // // // // // // // // // // // // // //

        public override string ToString()
        {
            string evidencia = " ----------------- Evidencia > Fisica ----------------- ";

            if (TieneHuellasDigitales)
            {
                evidencia += $"\n     | La evidencia TIENE huellas del SOSPECHOSO | \n";
                evidencia += base.ToString();
                return evidencia;
            }

            evidencia += $"\n     | La evidencia NO tiene huellas del SOSPECHOSO | \n";
            evidencia += base.ToString();
            
            return evidencia;
        }

    }
}
