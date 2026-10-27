using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public class Sistema
    {
        // ATRIBUTOS y PROPERTIES
        private List<Investigador> _investigadores { get; } = new List<Investigador>();
        private List<Sospechoso> _sospechosos { get; } = new List<Sospechoso>();
        private List<Caso> _casos { get; } = new List<Caso>();
        private static Sistema _instancia;

        // CTOR
        private Sistema()
        {
            PrecargarDatos();    
        }

        // PRECARGAS DE DATOS
        private void PrecargarDatos()
        {
            PrecargarInvestigadores();
            PrecargarSospechosos();
            PrecargarCasos();
        }

        // Singleton
        // > Método que retorna una única instancia
        public static Sistema GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new Sistema();
            }

            return _instancia;
        }
        
        // > Precargas concretas
        private void PrecargarInvestigadores()
        {
            Investigador i1 = new Investigador("sherlock@gmail.com", "Pass1234.", "Sherlock Holmes", Rol.Detective);
            Investigador i2 = new Investigador("watson@gmail.com", "Pass1234.", "John Watson", Rol.Detective);
            Investigador i3 = new Investigador("poirot@gmail.com", "Pass1234.", "Hercule Poirot", Rol.Detective);
            Investigador i4 = new Investigador("marlowe@gmail.com", "Pass1234.", "Philip Marlowe", Rol.Detective);
            Investigador i5 = new Investigador("spade@gmail.com", "Pass1234.", "Sam Spade", Rol.Detective);
            Investigador i6 = new Investigador("columbo@gmail.com", "Pass1234.", "Frank Columbo", Rol.Detective);
            Investigador i7 = new Investigador("holmes2@gmail.com", "Pass1234.", "Enola Holmes", Rol.Detective);
            Investigador i8 = new Investigador("marple@gmail.com", "Pass1234.", "Jane Marple", Rol.Detective);
            Investigador i9 = new Investigador("marpleq@gmail.com", "Pass1234.", "Inspector Morse", Rol.Detective);
            Investigador i10 = new Investigador("veras@gmail.com", "Pass1234.", "Elena Vera", Rol.Detective);

            Investigador i11 = new Investigador("fiscal1@gmail.com", "Pass1234.", "Carlos Rodríguez", Rol.Fiscal);
            Investigador i12 = new Investigador("fiscal2@gmail.com", "Pass1234.", "María González", Rol.Fiscal);
            Investigador i13 = new Investigador("fiscal3@gmail.com", "Pass1234.", "Javier Fernández", Rol.Fiscal);
            Investigador i14 = new Investigador("fiscal4@gmail.com", "Pass1234.", "Lucía Martínez", Rol.Fiscal);
            Investigador i15 = new Investigador("fiscal5@gmail.com", "Pass1234.", "Andrés Pereira", Rol.Fiscal);
            Investigador i16 = new Investigador("fiscal6@gmail.com", "Pass1234.", "Sofía Silva", Rol.Fiscal);
            Investigador i17 = new Investigador("fiscal7@gmail.com", "Pass1234.", "Diego Ramírez", Rol.Fiscal);
            Investigador i18 = new Investigador("fiscal8@gmail.com", "Pass1234.", "Valentina Torres", Rol.Fiscal);
            Investigador i19 = new Investigador("fiscal9@gmail.com", "Pass1234.", "Martín Cabrera", Rol.Fiscal);
            Investigador i20 = new Investigador("fiscal10@gmail.com", "Pass1234.", "Camila Suárez", Rol.Fiscal);

            AgregarInvestigador(i1);
            AgregarInvestigador(i2);
            AgregarInvestigador(i3);
            AgregarInvestigador(i4);
            AgregarInvestigador(i5);
            AgregarInvestigador(i6);
            AgregarInvestigador(i7);
            AgregarInvestigador(i8);
            AgregarInvestigador(i9);
            AgregarInvestigador(i10);
            AgregarInvestigador(i11);
            AgregarInvestigador(i12);
            AgregarInvestigador(i13);
            AgregarInvestigador(i14);
            AgregarInvestigador(i15);
            AgregarInvestigador(i16);
            AgregarInvestigador(i17);
            AgregarInvestigador(i18);
            AgregarInvestigador(i19);
            AgregarInvestigador(i20);
        }

        private void PrecargarSospechosos()
        {
            Sospechoso s1 = new Sospechoso("Juan Pérez", "11111111-1", new DateTime(1985, 3, 15), true);
            Sospechoso s2 = new Sospechoso("María González", "22222222-2", new DateTime(1992, 7, 22), false);
            Sospechoso s3 = new Sospechoso("Carlos Rodríguez", "33333333-3", new DateTime(1978, 11, 8), true);
            Sospechoso s4 = new Sospechoso("Laura Fernández", "44444444-4", new DateTime(1990, 1, 30), false);
            Sospechoso s5 = new Sospechoso("Martín Silva", "55555555-5", new DateTime(1982, 5, 17), true);
            Sospechoso s6 = new Sospechoso("Sofía Martínez", "66666666-6", new DateTime(1995, 9, 3), false);
            Sospechoso s7 = new Sospechoso("Diego Cabrera", "77777777-7", new DateTime(1975, 12, 19), true);
            Sospechoso s8 = new Sospechoso("Valentina López", "88888888-8", new DateTime(1988, 4, 26), false);
            Sospechoso s9 = new Sospechoso("Andrés Pereira", "99999999-9", new DateTime(1980, 8, 11), true);
            Sospechoso s10 = new Sospechoso("Camila Suárez", "10101010-0", new DateTime(1997, 2, 14), false);
            Sospechoso s11 = new Sospechoso("Federico Acosta", "12121212-1", new DateTime(1986, 6, 29), true);
            Sospechoso s12 = new Sospechoso("Natalia Méndez", "13131313-2", new DateTime(1993, 10, 7), false);
            Sospechoso s13 = new Sospechoso("Sebastián Torres", "14141414-3", new DateTime(1972, 3, 21), true);
            Sospechoso s14 = new Sospechoso("Paula Ramírez", "15151515-4", new DateTime(1989, 12, 5), false);
            Sospechoso s15 = new Sospechoso("Gonzalo Castro", "16161616-5", new DateTime(1991, 7, 18), true);

            Sospechoso s16 = new Sospechoso("Martín Cabrera", "17171717-1", new DateTime(1989, 3, 12, 0, 0, 0), false);
            Sospechoso s17 = new Sospechoso("Gabriela Ortiz", "18181818-1", new DateTime(1993, 6, 25, 0, 0, 0), true);
            Sospechoso s18 = new Sospechoso("Andrés Pereira", "19191919-1", new DateTime(1979, 10, 8, 0, 0, 0), false);
            Sospechoso s19 = new Sospechoso("Natalia Suárez", "20202020-2", new DateTime(1996, 1, 19, 0, 0, 0), true);
            Sospechoso s20 = new Sospechoso("Sebastián Ramos", "21212121-2", new DateTime(1984, 5, 27, 0, 0, 0), false);

            Sospechoso s21 = new Sospechoso("Carolina Méndez", "23232323-2", new DateTime(1999, 9, 4, 0, 0, 0), true);
            Sospechoso s22 = new Sospechoso("Nicolás Acosta", "24242424-2", new DateTime(1981, 12, 17, 0, 0, 0), false);
            Sospechoso s23 = new Sospechoso("Florencia Rojas", "25252525-2", new DateTime(1995, 4, 11, 0, 0, 0), true);
            Sospechoso s24 = new Sospechoso("Matías Sosa", "26262626-2", new DateTime(1990, 8, 23, 0, 0, 0), false);
            Sospechoso s25 = new Sospechoso("Romina Vázquez", "27272727-2", new DateTime(1987, 2, 6, 0, 0, 0), true);

            Sospechoso s26 = new Sospechoso("Gonzalo Medina", "28282828-2", new DateTime(1983, 7, 15, 0, 0, 0), false);
            Sospechoso s27 = new Sospechoso("Verónica Iglesias", "29292929-2", new DateTime(1992, 11, 2, 0, 0, 0), true);
            Sospechoso s28 = new Sospechoso("Alejandro Figueroa", "30303030-3", new DateTime(1977, 6, 29, 0, 0, 0), false);
            Sospechoso s29 = new Sospechoso("Mariana Domínguez", "31313131-3", new DateTime(1998, 10, 13, 0, 0, 0), true);
            Sospechoso s30 = new Sospechoso("Esteban Olivera", "32323232-3", new DateTime(1985, 1, 31, 0, 0, 0), false);

            AgregarSospechoso(s1);
            AgregarSospechoso(s2);
            AgregarSospechoso(s3);
            AgregarSospechoso(s4);
            AgregarSospechoso(s5);
            AgregarSospechoso(s6);
            AgregarSospechoso(s7);
            AgregarSospechoso(s8);
            AgregarSospechoso(s9);
            AgregarSospechoso(s10);
            AgregarSospechoso(s11);
            AgregarSospechoso(s12);
            AgregarSospechoso(s13);
            AgregarSospechoso(s14);
            AgregarSospechoso(s15);
            AgregarSospechoso(s16);
            AgregarSospechoso(s17);
            AgregarSospechoso(s18);
            AgregarSospechoso(s19);
            AgregarSospechoso(s20);
            AgregarSospechoso(s21);
            AgregarSospechoso(s22);
            AgregarSospechoso(s23);
            AgregarSospechoso(s24);
            AgregarSospechoso(s25);
            AgregarSospechoso(s26);
            AgregarSospechoso(s27);
            AgregarSospechoso(s28);
            AgregarSospechoso(s29);
            AgregarSospechoso(s30);
        }

        // // // // // // // // // // // // // // // // //
        //                                              //
        //                    CASOS                     //
        //                                              //
        // // // // // // // // // // // // // // // // //

        private void PrecargarCasos()
        {
            // ==========================================================
            // CASO 1 - Se crea inicialmente con un TESTIMONIO
            // ==========================================================

            Caso c1 = new Caso(
                "Robo en Joyería Central",
                "Investigación por robo ocurrido durante la madrugada en una joyería.",
                true,
                _sospechosos[0],
                _investigadores[0],
                new DateTime(2024, 3, 12),
                "Testigo afirma haber visto a una persona salir rápidamente del local.",
                "Carlos Méndez",
                Credibilidad.Alto
            );

            c1.AgregarEvidencia(
                new Fisica(
                    true,
                    new DateTime(2024, 3, 12),
                    "Destornillador encontrado junto a la puerta trasera."
                )
            );

            c1.AgregarEvidencia(
                new Grabacion(
                    8,
                    true,
                    new DateTime(2024, 3, 12),
                    "Cámara de seguridad registra al sospechoso ingresando al comercio."
                )
            );

            c1.AgregarEvidencia(
                new Testimonio(
                    "Mariana López",
                    Credibilidad.Medio,
                    new DateTime(2024, 3, 13),
                    "Vecina escuchó ruidos de vidrios rotos durante la madrugada."
                )
            );

            // ==========================================================
            // CASO 2 - Se crea inicialmente con una GRABACIÓN
            // ==========================================================

            Caso c2 = new Caso(
                "Asalto a Estación de Servicio",
                "Investigación por asalto a una estación de servicio durante la noche.",
                true,
                _sospechosos[1],
                _investigadores[1],
                new DateTime(2023, 7, 21),
                "Grabación de la cámara ubicada sobre la caja registradora.",
                9,
                true
            );

            c2.AgregarEvidencia(
                new Fisica(
                    true,
                    new DateTime(2023, 7, 21),
                    "Guante encontrado detrás del mostrador."
                )
            );

            c2.AgregarEvidencia(
                new Testimonio(
                    "Federico Silva",
                    Credibilidad.Alto,
                    new DateTime(2023, 7, 21),
                    "Empleado describe la vestimenta y características del atacante."
                )
            );

            c2.AgregarEvidencia(
                new Grabacion(
                    6,
                    false,
                    new DateTime(2023, 7, 22),
                    "Cámara exterior registra un vehículo abandonando el lugar."
                )
            );

            // ==========================================================
            // CASO 3 - Se crea inicialmente con evidencia FÍSICA
            // ==========================================================

            Caso c3 = new Caso(
                "Hurto en Museo Histórico",
                "Desaparición de una pieza histórica perteneciente a una exposición.",
                true,
                _sospechosos[2],
                _investigadores[2],
                new DateTime(2022, 11, 5),
                "Herramienta metálica encontrada cerca de la vitrina forzada.",
                true
            );

            c3.AgregarEvidencia(
                new Grabacion(
                    7,
                    false,
                    new DateTime(2022, 11, 5),
                    "Grabación muestra movimientos en un corredor próximo a la exposición."
                )
            );

            c3.AgregarEvidencia(
                new Testimonio(
                    "Laura Fernández",
                    Credibilidad.Medio,
                    new DateTime(2022, 11, 6),
                    "Guardia recuerda haber visto a una persona permanecer cerca de la vitrina."
                )
            );

            c3.AgregarEvidencia(
                new Fisica(
                    false,
                    new DateTime(2022, 11, 5),
                    "Trozo de tela encontrado enganchado en la vitrina."
                )
            );

            // ==========================================================
            // CASO 4 - TESTIMONIO
            // ==========================================================
            Caso c4 = new Caso(
                "Robo de Vehículo",
                "Investigación por la desaparición de un vehículo estacionado en la vía pública.",
                true,
                _sospechosos[3],
                _investigadores[3],
                new DateTime(2021, 5, 18),
                "Testigo vio a una persona manipulando la cerradura del vehículo.",
                "Martín Rodríguez",
                Credibilidad.Alto
            );

            c4.AgregarEvidencia(
                new Grabacion(
                    5,
                    false,
                    new DateTime(2021, 5, 18),
                    "Cámara de un comercio registra parcialmente el momento del robo."
                )
            );

            c4.AgregarEvidencia(
                new Fisica(
                    true,
                    new DateTime(2021, 5, 18),
                    "Herramienta utilizada para forzar la cerradura."
                )
            );

            c4.AgregarEvidencia(
                new Testimonio(
                    "Andrea Suárez",
                    Credibilidad.Bajo,
                    new DateTime(2021, 5, 19),
                    "Afirma haber visto el vehículo circulando por otra zona de la ciudad."
                )
            );

            // ==========================================================
            // CASO 5 - GRABACIÓN
            // ==========================================================
            Caso c5 = new Caso(
                "Rapiña en Supermercado",
                "Investigación por una rapiña ocurrida minutos antes del cierre.",
                true,
                _sospechosos[4],
                _investigadores[4],
                new DateTime(2025, 1, 8),
                "Grabación principal del sistema de vigilancia del supermercado.",
                10,
                true
            );

            c5.AgregarEvidencia(
                new Fisica(
                    true,
                    new DateTime(2025, 1, 8),
                    "Mochila abandonada utilizada durante la rapiña."
                )
            );

            c5.AgregarEvidencia(
                new Testimonio(
                    "Sofía Pereira",
                    Credibilidad.Alto,
                    new DateTime(2025, 1, 8),
                    "Cajera reconoce características físicas del sospechoso."
                )
            );

            c5.AgregarEvidencia(
                new Grabacion(
                    8,
                    false,
                    new DateTime(2025, 1, 8),
                    "Grabación del estacionamiento muestra la ruta de escape."
                )
            );

            // ==========================================================
            // CASO 6 - FÍSICA
            // ==========================================================
            Caso c6 = new Caso(
                "Ingreso Ilegal a Depósito",
                "Investigación por acceso no autorizado a un depósito industrial.",
                true,
                _sospechosos[5],
                _investigadores[5],
                new DateTime(2020, 9, 14),
                "Barreta metálica encontrada junto a una puerta forzada.",
                true
            );

            c6.AgregarEvidencia(
                new Grabacion(
                    4,
                    false,
                    new DateTime(2020, 9, 14),
                    "Cámara distante registra una silueta ingresando al depósito."
                )
            );

            c6.AgregarEvidencia(
                new Testimonio(
                    "Ricardo Núñez",
                    Credibilidad.Medio,
                    new DateTime(2020, 9, 15),
                    "Guardia nocturno escuchó ruidos provenientes del depósito."
                )
            );

            c6.AgregarEvidencia(
                new Fisica(
                    false,
                    new DateTime(2020, 9, 14),
                    "Linterna encontrada dentro de una zona restringida."
                )
            );

            // ==========================================================
            // CASO 7 - TESTIMONIO
            // ==========================================================
            Caso c7 = new Caso(
                "Fraude en Comercio Electrónico",
                "Investigación relacionada con compras realizadas utilizando datos ajenos.",
                true,
                _sospechosos[6],
                _investigadores[6],
                new DateTime(2024, 8, 2),
                "Empleado afirma haber entregado varios pedidos a la misma persona.",
                "Nicolás Cabrera",
                Credibilidad.Medio
            );

            c7.AgregarEvidencia(
                new Grabacion(
                    9,
                    false,
                    new DateTime(2024, 8, 2),
                    "Cámara del punto de entrega registra al individuo retirando productos."
                )
            );

            c7.AgregarEvidencia(
                new Fisica(
                    true,
                    new DateTime(2024, 8, 3),
                    "Comprobante de compra encontrado durante una inspección."
                )
            );

            c7.AgregarEvidencia(
                new Testimonio(
                    "Valentina Castro",
                    Credibilidad.Alto,
                    new DateTime(2024, 8, 3),
                    "Reconoce al sospechoso como la persona que retiró varios paquetes."
                )
            );

            // ==========================================================
            // CASO 8 - GRABACIÓN
            // ==========================================================
            Caso c8 = new Caso(
                "Vandalismo en Centro Educativo",
                "Investigación por daños ocasionados durante la madrugada.",
                true,
                _sospechosos[7],
                _investigadores[7],
                new DateTime(2022, 2, 26),
                "Cámara del acceso principal registra a varias personas entrando al predio.",
                7,
                true
            );

            c8.AgregarEvidencia(
                new Fisica(
                    true,
                    new DateTime(2022, 2, 26),
                    "Lata de pintura encontrada junto a una pared vandalizada."
                )
            );

            c8.AgregarEvidencia(
                new Testimonio(
                    "Daniel Gómez",
                    Credibilidad.Bajo,
                    new DateTime(2022, 2, 27),
                    "Vecino afirma haber escuchado voces durante la madrugada."
                )
            );

            c8.AgregarEvidencia(
                new Grabacion(
                    6,
                    false,
                    new DateTime(2022, 2, 26),
                    "Otra cámara registra a un grupo alejándose del centro educativo."
                )
            );

            // ==========================================================
            // CASO 9 - FÍSICA
            // ==========================================================
            Caso c9 = new Caso(
                "Robo en Farmacia",
                "Investigación por sustracción de dinero y medicamentos.",
                true,
                _sospechosos[8],
                _investigadores[8],
                new DateTime(2023, 12, 11),
                "Guante encontrado sobre el mostrador del establecimiento.",
                true
            );

            c9.AgregarEvidencia(
                new Grabacion(
                    8,
                    true,
                    new DateTime(2023, 12, 11),
                    "Cámara interna registra claramente al sospechoso."
                )
            );

            c9.AgregarEvidencia(
                new Testimonio(
                    "Paula Acosta",
                    Credibilidad.Alto,
                    new DateTime(2023, 12, 11),
                    "Empleada estuvo presente durante el robo y describe al responsable."
                )
            );

            c9.AgregarEvidencia(
                new Fisica(
                    false,
                    new DateTime(2023, 12, 11),
                    "Bolsa abandonada cerca de la entrada de la farmacia."
                )
            );

            // ==========================================================
            // CASO 10 - GRABACIÓN
            // ==========================================================
            Caso c10 = new Caso(
                "Robo en Local de Informática",
                "Investigación por robo de computadoras y otros dispositivos electrónicos.",
                true,
                _sospechosos[9],
                _investigadores[9],
                new DateTime(2025, 6, 17),
                "Cámara interna registra el momento en que se retiran varios equipos.",
                9,
                true
            );

            c10.AgregarEvidencia(
                new Fisica(
                    true,
                    new DateTime(2025, 6, 17),
                    "Destornillador encontrado debajo de uno de los escritorios."
                )
            );

            c10.AgregarEvidencia(
                new Testimonio(
                    "Gabriel Martínez",
                    Credibilidad.Medio,
                    new DateTime(2025, 6, 18),
                    "Comerciante de la zona vio a una persona cargando equipos en un vehículo."
                )
            );

            c10.AgregarEvidencia(
                new Grabacion(
                    7,
                    false,
                    new DateTime(2025, 6, 17),
                    "Cámara exterior permite identificar parcialmente la matrícula del vehículo."
                )
            );

            // ==========================================================
            // Añadir Casos a la lista _casos
            // ==========================================================
            AgregarCaso(c1);
            AgregarCaso(c2);
            AgregarCaso(c3);
            AgregarCaso(c4);
            AgregarCaso(c5);
            AgregarCaso(c6);
            AgregarCaso(c7);
            AgregarCaso(c8);
            AgregarCaso(c9);
            AgregarCaso(c10);
        }

        //////////////////// AGREGAR A LAS LISTAS DE DATOS ////////////////////
        // > Agregar Investigador
        private void AgregarInvestigador(Investigador i)
        {
            if (!_investigadores.Contains(i))
            {
                _investigadores.Add(i);
                return;
            }

            throw new Exception(" < Ha ocurrido un error / El mail ingresado ya está asociado a un Investigador / > ");
        }
       
        // > Agregar Sospechoso
        private void AgregarSospechoso(Sospechoso s)
        {
            if (!_sospechosos.Contains(s))
            {
                _sospechosos.Add(s);
                return;
            }

            throw new Exception(" < Ha ocurrido un error / La CI ingresada ya está asociada a un Sospechoso / > ");
        }

        // > Agregar Caso
        private void AgregarCaso(Caso c)
        {
            if (!_casos.Contains(c))
            {
                _casos.Add(c);
                return;
            }

            throw new Exception(" < Ha ocurrido un error / Ya hay un Caso con el nombre ingresado / > ");
        }

        //////////////////// RETORNAR LAS LISTAS DE DATOS ////////////////////

        public List<Caso> GetCasos()
        {
            return _casos;
        }

        public List<Investigador> GetInvestigadores()
        {
            return _investigadores;
        }

        public List<Sospechoso> GetSospechosos()
        {
            return _sospechosos;
        }

        //////////////////// CREACION DE SOSPECHOSO (para el caso 3) ////////////////////
        public void AltaSospechoso(string nombre, string ci, DateTime fechaNac, string antecedentes)
        {
            // como antecedentes es un string se convierte a booleano
            bool antec = AntecedentesStringABool(antecedentes);

            Sospechoso s = new Sospechoso(nombre, ci, fechaNac, antec);
            
            s.ValidarDatos();
            AgregarSospechoso(s);
        }

        private bool AntecedentesStringABool(string antecedentes)
        {
            // se valida que el string este bien
            ValidarStringAntecedentes(antecedentes);

            antecedentes = antecedentes.ToUpper();

            bool antec = false;

            if (antecedentes == "S")
            {
                antec = true;
            }

            return antec;
        }

        /////////////// RETORNAR INVESTIGADOR POR MAIL ///////////////
        public Investigador GetInvestigadorPorMail(string mail)
        {
            Investigador i = null;

            List<Investigador> lista = GetInvestigadores();

            foreach (Investigador inv in lista)
            {
                if (inv.InvestigadorTieneMail(mail))
                {
                    i = inv;
                }
            }

            return i;
        }
        
        /////////////// MOSTRAR DATOS ///////////////
        public string MostrarCasosYEvidencias()
        {
            string textoConCasos = "";
            foreach (Caso c in _casos)
            {
                textoConCasos += c.ToString();
            }

            return(textoConCasos);
        }

        public string MostrarCasosDeUnInvestigador(string mail)
        {
            string textoConCasos = "";

            foreach (Caso c in _casos)
            {
                // se delega la responsabilidad a su Clase
                if(c.MailEsDeInvestigador(mail))
                {
                    textoConCasos += c.ToString();
                }
            }

            if(textoConCasos == "")
            {
                return "\n El Investigador no tiene casos asociados. \n";
            }

            return textoConCasos;
        }

        public string MostrarSospechososConAntecedentes()
        {
            string textoConSospechosos = "";

            foreach (Sospechoso s in _sospechosos)
            {
                // se delega la responsabilidad a su Clase
                if (s.SospechosoTieneAntecedentes())
                {
                    textoConSospechosos += s.ToString();
                    textoConSospechosos += "\n";
                }
            }

            return textoConSospechosos;
        }

        private void ValidarStringAntecedentes(string antec)
        {
            antec = antec.ToUpper();

            if (antec != "S" && antec != "N")
            {
                throw new Exception(" < Ha ocurrido un error / Opcion invalida de Antecedentes > ");
            }
        }

        public void InvestigadorEsFiscal(string mail)
        {
            Investigador i = GetInvestigadorPorMail(mail);

            if (i != null && i.InvEsFiscal())
            {
                throw new Exception(" El mail ingresado corresponde al de un Fiscal, el cual no puede tener Casos asignados. ");
            }
        }

        //sistema
    }
}
