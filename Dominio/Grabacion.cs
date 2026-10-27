using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Grabacion : Evidencia, IValidable
    {
        // CLASE HIJA de EVIDENCIA

        // PROPERTIES
        private int Calidad { get; set; }
        private bool InFraganti { get; set; }

        // CTOR
        public Grabacion()
        {
        
        }

        public Grabacion(int calidad, bool inFraganti, DateTime fechaRecoleccion, string descripcion) : base(fechaRecoleccion, descripcion)
        {
            Calidad = calidad;
            InFraganti = inFraganti;
            ValidarDatos();
        }

        // // // // // // // // // // // // // // // // //
        //                                              //
        //                   METODOS                    //
        //                                              //
        // // // // // // // // // // // // // // // // //

        // Se genera el método general ValidarDatos() como buena practica
        public void ValidarDatos()
        {
            ValidarCalidad();
        }

        private void ValidarCalidad()
        {
            if (Calidad < 1 && Calidad > 5 )
            {
                throw new Exception(" < Ha ocurrido un error / Calidad Grabacion / > ");
            }
        }

        public override int CalcularPesoEvidencia()
        {
            int ptos = 0;

            // CONSULTAR AL PROFE SI ESTE CALCULO DEBE SER ANIDADO > OK consultado
            /*
                Si la evidencia es una grabación que registra al sospechoso en infraganti delito, se le suman 60
                puntos. Además, si la calidad es superior o igual a 3, suma 10 más.
            */

            if (InFraganti)
            {
                ptos += 40;
            }

            if (Calidad >= 3)
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
            string evidencia = " ----------------- Evidencia > Grabacion ----------------- ";

            evidencia += $"\n     | La CALIDAD es {Calidad} de 5 | ";

            if (InFraganti)
            {
                evidencia += $"La GRABACION fue In Fraganti |\n";
                evidencia += base.ToString();

                return evidencia;
            }

            evidencia += $"La GRABACION NO fue In Fraganti |\n";
            evidencia += base.ToString();

            return evidencia;
        }

        //
    }
}
