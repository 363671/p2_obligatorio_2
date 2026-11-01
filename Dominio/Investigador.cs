using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public class Investigador : IValidable
    {
        // ATRIBUTOS y PROPERTIES
        private static int UltimoId { get; set; } = 0;
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public Rol Rol { get; set; }

        // CTOR
        public Investigador()
        {
            Id = ++UltimoId;
        }

        public Investigador(string mail, string contrasena, string nombre, Rol rol)
        {
            Id = ++UltimoId;
            Mail = mail;
            Contrasena = contrasena;
            Nombre = nombre;
            Rol = rol;
            ValidarDatos();
        }

        // METODOS
        public void ValidarDatos()
        {
            ValidarMail();
            ValidarContrasena();
            ValidarNombre();
            ValidarRol();
        }
        
        private void ValidarMail()
        {
            string errores = "";

            char primerCaracter = Mail.First();
            char ultimoCaracter = Mail.Last();
            char arroba = '@';

            if (!TextoTieneCaracter(Mail, arroba))
            {
                errores += "El correo debe tener @. ";
            }

            if (!TextoTieneCaracter(Mail, '.'))
            {
                errores += "El correo no tiene punto. ";

            }

            if (Mail.EndsWith(arroba))
            {
                errores += "El último carácter no puede ser un @. ";
            }

            if (primerCaracter == arroba)
            {
                errores += "El primer carácter no puede ser un @. ";
            }

            if (primerCaracter == '.')
            {
                errores += "El primer carácter no puede ser un punto. ";
            }

            if (ultimoCaracter == '.')
            {
                errores += "El último carácter no puede ser un punto. ";
            }

            if (Mail.Length <= 1)
            {
                errores += "El largo del correo debe ser mayor a 1. ";
            }

            if (errores != "")
            {
                Console.WriteLine("");
                throw new Exception(" < Ha ocurrido un error / Mail inválido / > ");
            }
        }

        public bool InvestigadorTieneMail(string mail)
        {
            return Mail == mail;
        }

        private void ValidarContrasena()
        {
            string errores = "";

            if (!TextoTieneCaracter(Contrasena, '@') &&
                !TextoTieneCaracter(Contrasena, '.') &&
                !TextoTieneCaracter(Contrasena, '#') &&
                !TextoTieneCaracter(Contrasena, ','))
            {
                errores += "La contrasena debe tener un caracter especial (@ . # ,";
            }

            if (Contrasena.Length <= 4)
            {
                errores += "El largo de la contrasena debe ser mayor a 4 caracteres. ";
            }

            if (errores != "")
            {
                Console.WriteLine("");
                throw new Exception(" < Ha ocurrido un error / Contrasena / > ");
            }
        }

        private void ValidarNombre()
        {
            string errores = "";

            if (Nombre.IsWhiteSpace())
            {
                errores += "El largo del nombre no puede ser nulo.";
            } else if (Nombre.Length > 90)
            {
                errores += "El largo del nombre no puede superar los 90 caracteres.";
            }

            if (errores != "")
            {
                throw new Exception($" < Ha ocurrido un error / {errores} / > ");
            }
        }

        private bool TextoTieneCaracter(string texto, char caracter)
        {
            if (texto.Contains(caracter))
            {
                return true;
            }
         
            return false;
        }

        private void ValidarRol()
        {
            if (Rol != Rol.Detective && Rol != Rol.Fiscal)
            {
                Console.WriteLine("");
                throw new Exception(" < Ha ocurrido un error / Rol / > ");
            }
        }
        
        public bool InvEsFiscal()
        {
            return Rol == Rol.Fiscal;
        }
        
        // Aprovechando POLIMORFISMO
        public override string ToString()
        {
            string datosInvestigador = "";

            datosInvestigador += $" Investigador -> Id: {Id} Nombre: {Nombre} Mail: {Mail} Rol: {Rol} \n\n";

            return datosInvestigador;
        }

        public override bool Equals(object? obj)
        {
            return obj is Investigador inv && Mail == inv.Mail;
        }
    }
}
