using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Linq;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public abstract class Evidencia : IValidable
    {
        // ATRIBUTOS y PROPERTIES
        private static int UltimoId { get; set; } = 0;
        public int Id { get; set; }
        public DateTime FechaRecoleccion { get; set; }
        public string Descripcion { get; set; }

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
            DateTime fechaActual = DateTime.Now;
            DateTime fechaLimite = new DateTime(1800,01,01);

            if (FechaRecoleccion > fechaActual)
            {
                throw new Exception(" Fecha de Recolección inválida ");
            }

            if (FechaRecoleccion < fechaLimite)
            {
                throw new Exception(" Fecha de Recolección inválida ");
            }

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

            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new Exception(" < Ha ocurrido un error / Descripcion / > ");
            }

            if (Descripcion.Length < 30)
            {
                throw new Exception("El largo de la Descripcion no puede ser menor a 20 caracteres.");
            }

            if (errores != "")
            {
                throw new Exception(" < Ha ocurrido un error / Descripcion / > ");
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

        public static IEnumerable<Type> ObtenerClasesHijas()
        {
            var tipoBase = typeof(Evidencia);
            var ensamblado = Assembly.GetAssembly(tipoBase);

            return ensamblado.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(tipoBase));
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
