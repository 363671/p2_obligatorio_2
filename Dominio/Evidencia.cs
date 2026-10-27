using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public abstract class Evidencia : IValidable
    {
        // ATRIBUTOS y PROPERTIES
        private static int UltimoId { get; set; } = 0;
        protected int Id { get; set; }
        private DateTime FechaRecoleccion { get; set; }
        private string Descripcion { get; set; }

        // ctor
        public Evidencia()
        {
            Id = ++UltimoId;
        }

        public Evidencia(DateTime fechaRecoleccion, string descripcion)
        {
            Id = ++UltimoId;
            FechaRecoleccion = fechaRecoleccion;
            Descripcion = descripcion;
            ValidarDatos();
        }

        // // // // // // // // // // // // // // // // //
        //                                              //
        //                   METODOS                    //
        //                                              //
        // // // // // // // // // // // // // // // // //

        public void ValidarDatos()
        {
            ValidarFechaRecoleccion();
            ValidarDescripcion();
        }

        private void ValidarFechaRecoleccion()
        {
            // validar que no sea mayor a la fecha de hoy / que no sea de hace mucho tiempo / etc
            // throw new NotImplementedException();
        }

        private void ValidarDescripcion()
        {
            string errores = "";

            if (Descripcion.IsWhiteSpace())
            {
                errores += "El largo de la Descripcion no puede ser nulo.";
            }

            if (Descripcion.Length < 30)
            {
                errores += "El largo de la Descripcion no puede ser menor a 20 caracteres.";
            }

            if (errores != "")
            {
                Console.WriteLine("");
                throw new Exception(" < Ha ocurrido un error / Descripcion / > ");
                throw new Exception($" < {errores} > ");
            }
        }
        
        public virtual int CalcularPesoEvidencia()
        {
            return CalcularPesoPorAntiguedad();
        }

        private int CalcularPesoPorAntiguedad()
        {
            // por defecto el peso es 3
            int peso = 3;

            DateTime fechaLimite = DateTime.Now.AddMonths(-6);

            // si la Evidencia tiene menos de 6 meses el peso es 5
            if (FechaRecoleccion > fechaLimite)
            {
                peso = 5;
            }

            return peso;
        }

        // // // // // // // // // // // // // // // // //
        //                                              //
        //                POLIMORFISMO                  //
        //                                              //
        // // // // // // // // // // // // // // // // //

        public override string ToString()
        {
            string datosEvidencia = "";

            datosEvidencia += $"     | Id: {Id} > Descripcion: {Descripcion} \n\n";

            return datosEvidencia;
        }

        
        //
    }
}
