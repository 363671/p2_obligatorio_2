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
            Sospechoso s1 = new Sospechoso("Juan Perez", "11111111-1", new DateTime(1985, 3, 15), true);
            Sospechoso s2 = new Sospechoso("Maria Gonzalez", "22222222-2", new DateTime(1992, 7, 22), false);
            Sospechoso s3 = new Sospechoso("Carlos Rodriguez", "33333333-3", new DateTime(1978, 11, 8), true);
            Sospechoso s4 = new Sospechoso("Laura Fernandez", "44444444-4", new DateTime(1990, 1, 30), false);
            Sospechoso s5 = new Sospechoso("Martin Silva", "55555555-5", new DateTime(1982, 5, 17), true);
            Sospechoso s6 = new Sospechoso("Sofia Martinez", "66666666-6", new DateTime(1995, 9, 3), false);
            Sospechoso s7 = new Sospechoso("Diego Cabrera", "77777777-7", new DateTime(1975, 12, 19), true);
            Sospechoso s8 = new Sospechoso("Valentina Lopez", "88888888-8", new DateTime(1988, 4, 26), false);
            Sospechoso s9 = new Sospechoso("Andres Pereira", "99999999-9", new DateTime(1980, 8, 11), true);
            Sospechoso s10 = new Sospechoso("Camila Suarez", "10101010-0", new DateTime(1997, 2, 14), false);
            Sospechoso s11 = new Sospechoso("Federico Acosta", "12121212-1", new DateTime(1986, 6, 29), true);
            Sospechoso s12 = new Sospechoso("Natalia Mendez", "13131313-2", new DateTime(1993, 10, 7), false);
            Sospechoso s13 = new Sospechoso("Sebastian Torres", "14141414-3", new DateTime(1972, 3, 21), true);
            Sospechoso s14 = new Sospechoso("Paula Ramirez", "15151515-4", new DateTime(1989, 12, 5), false);
            Sospechoso s15 = new Sospechoso("Gonzalo Castro", "16161616-5", new DateTime(1991, 7, 18), true);

            Sospechoso s16 = new Sospechoso("Martin Cabrera", "17171717-1", new DateTime(1989, 3, 12, 0, 0, 0), false);
            Sospechoso s17 = new Sospechoso("Gabriela Ortiz", "18181818-1", new DateTime(1993, 6, 25, 0, 0, 0), true);
            Sospechoso s18 = new Sospechoso("Andres Pereira", "19191919-1", new DateTime(1979, 10, 8, 0, 0, 0), false);
            Sospechoso s19 = new Sospechoso("Natalia Suarez", "20202020-2", new DateTime(1996, 1, 19, 0, 0, 0), true);
            Sospechoso s20 = new Sospechoso("Sebastian Ramos", "21212121-2", new DateTime(1984, 5, 27, 0, 0, 0), false);
            Sospechoso s21 = new Sospechoso("Carolina Mendez", "23232323-2", new DateTime(1999, 9, 4, 0, 0, 0), true);
            Sospechoso s22 = new Sospechoso("Nicolas Acosta", "24242424-2", new DateTime(1981, 12, 17, 0, 0, 0), false);
            Sospechoso s23 = new Sospechoso("Florencia Rojas", "25252525-2", new DateTime(1995, 4, 11, 0, 0, 0), true);
            Sospechoso s24 = new Sospechoso("Matias Sosa", "26262626-2", new DateTime(1990, 8, 23, 0, 0, 0), false);
            Sospechoso s25 = new Sospechoso("Romina Vazquez", "27272727-2", new DateTime(1987, 2, 6, 0, 0, 0), true);
            Sospechoso s26 = new Sospechoso("Gonzalo Medina", "28282828-2", new DateTime(1983, 7, 15, 0, 0, 0), false);
            Sospechoso s27 = new Sospechoso("Veronica Iglesias", "29292929-2", new DateTime(1992, 11, 2, 0, 0, 0), true);
            Sospechoso s28 = new Sospechoso("Alejandro Figueroa", "30303030-3", new DateTime(1977, 6, 29, 0, 0, 0), false);
            Sospechoso s29 = new Sospechoso("Mariana Dominguez", "31313131-3", new DateTime(1998, 10, 13, 0, 0, 0), true);
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
                Credibilidad.Bajo
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
                    4,
                    false,
                    new DateTime(2024, 3, 12),
                    "Cámara de seguridad registra al sospechoso ingresando al comercio."
                )
            );

            c1.AgregarEvidencia(
                new Testimonio(
                    "Mariana López",
                    Credibilidad.Bajo,
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
                1,
                false
            );

            c2.AgregarEvidencia(
                new Fisica(
                    false,
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
                    5,
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
                _investigadores[0],
                new DateTime(2022, 11, 5),
                "Herramienta metálica encontrada cerca de la vitrina forzada.",
                true
            );

            c3.AgregarEvidencia(
                new Grabacion(
                    1,
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
                _investigadores[1],
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
                _investigadores[0],
                new DateTime(2025, 1, 8),
                "Grabación principal del sistema de vigilancia del supermercado.",
                3,
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
                    Credibilidad.Medio,
                    new DateTime(2025, 1, 8),
                    "Cajera reconoce características físicas del sospechoso."
                )
            );

            c5.AgregarEvidencia(
                new Grabacion(
                    3,
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
                _investigadores[1],
                new DateTime(2020, 9, 14),
                "Barreta metálica encontrada junto a una puerta forzada.",
                true
            );

            c6.AgregarEvidencia(
                new Grabacion(
                    2,
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
                _investigadores[0],
                new DateTime(2024, 8, 2),
                "Empleado afirma haber entregado varios pedidos a la misma persona.",
                "Nicolás Cabrera",
                Credibilidad.Medio
            );

            c7.AgregarEvidencia(
                new Grabacion(
                    1,
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
                _investigadores[1],
                new DateTime(2022, 2, 26),
                "Cámara del acceso principal registra a varias personas entrando al predio.",
                1,
                false
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
                    1,
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
                _investigadores[0],
                new DateTime(2023, 12, 11),
                "Guante encontrado sobre el mostrador del establecimiento.",
                true
            );

            c9.AgregarEvidencia(
                new Grabacion(
                    2,
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
                _investigadores[1],
                new DateTime(2025, 6, 17),
                "Cámara interna registra el momento en que se retiran varios equipos.",
                2,
                false
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
                    Credibilidad.Bajo,
                    new DateTime(2025, 6, 18),
                    "Comerciante de la zona vio a una persona cargando equipos en un vehículo."
                )
            );

            c10.AgregarEvidencia(
                new Grabacion(
                    3,
                    false,
                    new DateTime(2025, 6, 17),
                    "Cámara exterior permite identificar parcialmente la matrícula del vehículo."
                )
            );

            // ==========================================================
            // CASO 11 - TESTIMONIO (Se mantiene ACTIVO)
            // ==========================================================
            Caso c11 = new Caso(
                "Sabotaje en Fábrica Textil",
                "Investigación por daños intencionales en la maquinaria principal de hilado.",
                true,
                _sospechosos[0],
                _investigadores[1],
                new DateTime(2026, 2, 14),
                "Operario afirma haber visto a alguien ajeno a la sección merodeando.",
                "Jorge Ramírez",
                Credibilidad.Bajo
            );

            c11.AgregarEvidencia(new Fisica(false, new DateTime(2026, 2, 14), "Cable de alimentación cortado con pinza."));
            c11.AgregarEvidencia(new Grabacion(3, false, new DateTime(2026, 2, 14), "Cámara de pasillo muestra silueta borrosa a la distancia."));
            c11.AgregarEvidencia(new Testimonio("Elena Ortiz", Credibilidad.Bajo, new DateTime(2026, 2, 15), "Limpiadora cree haber escuchado una discusión previa al hecho."));
            c11.AgregarEvidencia(new Fisica(false, new DateTime(2026, 2, 14), "Candado del tablero eléctrico forzado."));

            // ==========================================================
            // CASO 12 - GRABACIÓN (Se INACTIVA por recomendación)
            // ==========================================================
            Caso c12 = new Caso(
                "Hurto de Cables en Vía Pública",
                "Sustracción de cableado subterráneo de fibra óptica en zona norte.",
                true,
                _sospechosos[1],
                _investigadores[0],
                new DateTime(2025, 9, 30),
                "Cámara municipal registra movimientos vehiculares inusuales de madrugada.",
                2,
                false
            );

            c12.AgregarEvidencia(new Fisica(false, new DateTime(2025, 9, 30), "Pinza de presión oxidada abandonada en la zanja."));
            c12.AgregarEvidencia(new Testimonio("Luis Alvez", Credibilidad.Bajo, new DateTime(2025, 10, 1), "Vecino dice haber visto una camioneta blanca sin matrícula."));
            c12.AgregarEvidencia(new Grabacion(4, false, new DateTime(2025, 9, 30), "Cámara comercial capta ráfaga de luces del presunto vehículo escape."));
            c12.AgregarEvidencia(new Fisica(false, new DateTime(2025, 9, 30), "Guantes de lona sucios cerca de la cámara de registro."));
            c12.Inactivar(); // Pasa a estado Inactivo

            // ==========================================================
            // CASO 13 - FÍSICA (Se mantiene ACTIVO)
            // ==========================================================
            Caso c13 = new Caso(
                "Intrusión en Estacionamiento Privado",
                "Denuncia por intento de apertura forzada de varios vehículos particulares.",
                true,
                _sospechosos[2],
                _investigadores[1],
                new DateTime(2026, 4, 11),
                "Ganzúa casera encontrada trabada en la cerradura de un coche.",
                true
            );

            c13.AgregarEvidencia(new Grabacion(2, false, new DateTime(2026, 4, 11), "Cámara del subsuelo registra sombras moviéndose entre los pilares."));
            c13.AgregarEvidencia(new Testimonio("Clara Mendoza", Credibilidad.Bajo, new DateTime(2026, 4, 12), "Inquilina afirma haber oído silbidos extraños en el garaje."));
            c13.AgregarEvidencia(new Fisica(false, new DateTime(2026, 4, 11), "Gorra deportiva negra tirada en una plaza vacía."));
            c13.AgregarEvidencia(new Testimonio("Pedro Rocha", Credibilidad.Medio, new DateTime(2026, 4, 11), "Guardia del turno tarde vio a un joven sospechoso merodeando el portón."));

            // ==========================================================
            // CASO 14 - TESTIMONIO (Se INACTIVA por recomendación)
            // ==========================================================
            Caso c14 = new Caso(
                "Falta de Stock en Barraca",
                "Investigación interna por faltante acumulado de herramientas eléctricas.",
                true,
                _sospechosos[3],
                _investigadores[0],
                new DateTime(2025, 11, 12),
                "Empleado administrativo sugiere que los remitos de carga fueron alterados.",
                "Mario Benítez",
                Credibilidad.Bajo
            );

            c14.AgregarEvidencia(new Grabacion(4, false, new DateTime(2025, 11, 12), "Cámara del sector de carga muestra operarios trabajando de espaldas."));
            c14.AgregarEvidencia(new Fisica(true, new DateTime(2025, 11, 13), "Planilla de inventario con tachaduras en el renglón de taladros."));
            c14.AgregarEvidencia(new Testimonio("Lucía Ríos", Credibilidad.Bajo, new DateTime(2025, 11, 14), "Cajera escuchó rumores sobre ventas informales fuera del horario comercial."));
            c14.AgregarEvidencia(new Grabacion(3, false, new DateTime(2025, 11, 12), "Domótica de entrada registra apertura fuera de hora sin video claro."));
            c14.Inactivar(); // Pasa a estado Inactivo

            // ==========================================================
            // CASO 15 - GRABACIÓN (Se mantiene ACTIVO)
            // ==========================================================
            Caso c15 = new Caso(
                "Vandalismo en Fachada de Banco",
                "Pintadas y rotura de cartelería digital en la sucursal de la avenida principal.",
                true,
                _sospechosos[4],
                _investigadores[1],
                new DateTime(2026, 1, 20),
                "Cámara del cajero automático capta de reojo el inicio del disturbio.",
                3,
                false
            );

            c15.AgregarEvidencia(new Fisica(false, new DateTime(2026, 1, 20), "Ladrillo partido utilizado para golpear el vidrio del tótem."));
            c15.AgregarEvidencia(new Testimonio("Hugo Peralta", Credibilidad.Bajo, new DateTime(2026, 1, 21), "Transeúnte dice que el grupo vestía camperas de un club local."));
            c15.AgregarEvidencia(new Grabacion(4, false, new DateTime(2026, 1, 20), "Cámara de tránsito muestra un grupo de personas corriendo tres cuadras más adelante."));
            c15.AgregarEvidencia(new Fisica(false, new DateTime(2026, 1, 20), "Restos de un envase de pintura en aerosol color negro."));

            // ==========================================================
            // CASO 16 - FÍSICA (Se INACTIVA por recomendación)
            // ==========================================================
            Caso c16 = new Caso(
                "Robo en Obra en Construcción",
                "Pérdida de materiales de construcción y grifería fina guardada en depósito temporal.",
                true,
                _sospechosos[5],
                _investigadores[0],
                new DateTime(2025, 8, 5),
                "Corte neto en el tejido perimetral del predio de la obra.",
                true
            );

            c16.AgregarEvidencia(new Grabacion(3, false, new DateTime(2025, 8, 5), "Cámara de la esquina graba un camión detenido cerca de la brecha."));
            c16.AgregarEvidencia(new Testimonio("Andrés Fleitas", Credibilidad.Bajo, new DateTime(2025, 8, 6), "Sereno de la obra lindera afirma haberse quedado dormido por ruidos extraños."));
            c16.AgregarEvidencia(new Fisica(false, new DateTime(2025, 8, 5), "Huella de calzado embarrado talle grande cerca del contenedor."));
            c16.AgregarEvidencia(new Testimonio("Sonia Viera", Credibilidad.Bajo, new DateTime(2025, 8, 7), "Vecina reporta ruidos de carga a altas horas de la noche."));
            c16.Inactivar(); // Pasa a estado Inactivo

            // ==========================================================
            // CASO 17 - TESTIMONIO (Se mantiene ACTIVO)
            // ==========================================================
            Caso c17 = new Caso(
                "Estafa en Taller Mecánico",
                "Cliente denuncia colocación de repuestos usados facturados como nuevos.",
                true,
                _sospechosos[6],
                _investigadores[1],
                new DateTime(2026, 5, 2),
                "Ex-empleado del taller afirma que es una práctica común del dueño.",
                "Roberto Díaz",
                Credibilidad.Bajo
            );

            c17.AgregarEvidencia(new Fisica(false, new DateTime(2026, 5, 3), "Filtro de aceite desgastado extraído del auto del denunciante."));
            c17.AgregarEvidencia(new Grabacion(5, false, new DateTime(2026, 5, 2), "Cámara del taller registra el auto en la fosa pero los mecánicos tapan la visual."));
            c17.AgregarEvidencia(new Testimonio("Gisela Cardozo", Credibilidad.Bajo, new DateTime(2026, 5, 4), "Clienta sospecha que le ocurrió lo mismo por un ruido persistente en su motor."));
            c17.AgregarEvidencia(new Fisica(false, new DateTime(2026, 5, 2), "Caja de repuesto nuevo tirada vacía en el contenedor de basura."));

            // ==========================================================
            // CASO 18 - GRABACIÓN (Se INACTIVA por recomendación)
            // ==========================================================
            Caso c18 = new Caso(
                "Hurto de Mercadería en Minimercado",
                "Sustracción hormiga detectada en góndolas de perfumería y cosmética.",
                true,
                _sospechosos[7],
                _investigadores[0],
                new DateTime(2025, 6, 14),
                "Domótica de pasillo registra un movimiento sospechoso de manos hacia una mochila.",
                2,
                false
            );

            c18.AgregarEvidencia(new Fisica(false, new DateTime(2025, 6, 14), "Blíster de desodorante vacío escondido detrás de las cajas de cereal."));
            c18.AgregarEvidencia(new Testimonio("Estela Maris", Credibilidad.Bajo, new DateTime(2025, 6, 15), "Repositora cree recordar a una pareja sospechosa esa tarde."));
            c18.AgregarEvidencia(new Grabacion(5, false, new DateTime(2025, 6, 14), "Cámara de salida capta a los sospechosos cruzando las cajas sin comprar nada."));
            c18.AgregarEvidencia(new Testimonio("Juan Pintos", Credibilidad.Bajo, new DateTime(2025, 6, 14), "Cliente vio a alguien apurado saliendo hacia el estacionamiento."));
            c18.Inactivar(); // Pasa a estado Inactivo

            // ==========================================================
            // CASO 19 - FÍSICA (Se mantiene ACTIVO)
            // ==========================================================
            Caso c19 = new Caso(
                "Intento de Estafa Telefónica",
                "Investigación por llamadas extorsivas simulando secuestro familiar a una anciana.",
                true,
                _sospechosos[8],
                _investigadores[1],
                new DateTime(2026, 3, 19),
                "Papel con anotación del número de cuenta destino arrojado en el jardín.",
                true
                );

            c19.AgregarEvidencia(new Grabacion(3, false, new DateTime(2026, 3, 19), "Audio del contestador automático con la voz distorsionada del atacante."));
            c19.AgregarEvidencia(new Testimonio("Olga Suárez", Credibilidad.Bajo, new DateTime(2026, 3, 19), "Víctima nerviosa confunde detalles sobre la voz del llamante."));
            c19.AgregarEvidencia(new Testimonio("Raúl Castro", Credibilidad.Bajo, new DateTime(2026, 3, 20), "Vecino dice haber visto una moto sospechosa al momento de la llamada."));
            c19.AgregarEvidencia(new Fisica(false, new DateTime(2026, 3, 19), "Chip Prepago de telefonía descartado en la vereda contigua."));

            // ==========================================================
            // CASO 20 - GRABACIÓN (Se mantiene ACTIVO)
            // ==========================================================
            Caso c20 = new Caso(
                "Sustracción en Vestuarios de Club",
                "Reporte de hurto de una billetera y un reloj de alta gama del casillero.",
                true,
                _sospechosos[9],
                _investigadores[0],
                new DateTime(2026, 6, 8),
                "Cámara de acceso al pasillo del vestuario registra entradas y salidas generales.",
                1,
                false
                );
            
            c20.AgregarEvidencia(new Fisica(false, new DateTime(2026, 6, 8), "Traba del casillero número 14 visiblemente falseada."));
            c20.AgregarEvidencia(new Testimonio("Marcos Paz", Credibilidad.Bajo, new DateTime(2026, 6, 9), "Socio menciona haber visto ingresar a un joven que no suele ir a esa hora."));
            c20.AgregarEvidencia(new Grabacion(4, false, new DateTime(2026, 6, 8), "Cámara del hall principal muestra el egreso apresurado de una persona."));
            c20.AgregarEvidencia(new Testimonio("Tomás Delgado", Credibilidad.Bajo, new DateTime(2026, 6, 8), "Profesor de gimnasia escuchó un portazo fuerte pero no revisó el área."));


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
            AgregarCaso(c11);
            AgregarCaso(c12);
            AgregarCaso(c13);
            AgregarCaso(c14);
            AgregarCaso(c15);
            AgregarCaso(c16);
            AgregarCaso(c17);
            AgregarCaso(c18);
            AgregarCaso(c19);
            AgregarCaso(c20);
        }

        //////////////////// AGREGAR A LAS LISTAS DE DATOS ////////////////////
        // > Agregar Investigador
        public void AgregarInvestigador(Investigador i)
        {
            i.ValidarDatos();

            if (!_investigadores.Contains(i))
            {
                _investigadores.Add(i);
                return;
            }

            throw new Exception(" < Ha ocurrido un error / El mail ingresado ya está asociado a un Investigador / > ");
        }

        // > Agregar Sospechoso
        public void AgregarSospechoso(Sospechoso s)
        {
            if (!_sospechosos.Contains(s))
            {
                _sospechosos.Add(s);
                return;
            }

            throw new Exception(" < Ha ocurrido un error / La CI ingresada ya está asociada a un Sospechoso / > ");
        }

        // > Agregar Caso
        public void AgregarCaso(Caso c)
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

        public List<Caso> GetCasosDeUnInvestigador(Investigador i)
        {
            List<Caso> listaRet = new List<Caso>();

            foreach (Caso c in _casos)
            {
                if (c.InvestigadorD.Equals(i))
                {
                    listaRet.Add(c);
                }
            }

            return listaRet;
        }

        public List<Sospechoso> GetSospechososConAntecedentes()
        {
            List<Sospechoso> listaRet = new List<Sospechoso>();

            foreach (Sospechoso s in _sospechosos)
            {
                // se delega la responsabilidad a su Clase
                if (s.SospechosoTieneAntecedentes())
                {
                    listaRet.Add(s);
                }
            }

            return listaRet;
        }


        public List<Sospechoso> GetSospechososSinAntecedentes()
        {
            List<Sospechoso> listaRet = new List<Sospechoso>();

            foreach (Sospechoso s in _sospechosos)
            {
                // se delega la responsabilidad a su Clase
                if (!s.SospechosoTieneAntecedentes())
                {
                    listaRet.Add(s);
                }
            }

            return listaRet;
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

            if (i != null && i.InvestigadorEsFiscal())
            {
                throw new Exception(" El mail ingresado corresponde al de un Fiscal, el cual no puede tener Casos asignados. ");
            }
        }

        public Investigador GetInvestigadorLogin(string email, string pass)
        {
            foreach(Investigador i in _investigadores)
            {
                if(i.Mail == email && i.Contrasena == pass)
                {
                    // retorna el Investigador y su espacio en memoria
                    return i;
                }
            }

            return null;
        }

        public Investigador GetInvestigadorPorId(int idInvestigador)
        {
            foreach (Investigador i in _investigadores)
            {
                if(i.Id == idInvestigador)
                {
                    // retorna el Investigador y su espacio en memoria
                    return i;
                }
            }

            return null;
        }

        public Sospechoso GetSospechosoPorId(int idSospechoso)
        {
            foreach (Sospechoso s in _sospechosos)
            {
                if (s.Id == idSospechoso)
                {
                    // retorna el Sospechoso y su espacio en memoria
                    return s;
                }
            }

            return null;
        }

        public Caso GetCasoPorId(int id)
        {
            foreach (Caso c in GetCasos())
            {
                if (c.Id.Equals(id)){
                    return c;
                }
            }

            return null;
        }

        public List<Sospechoso> GetSospechososConNombre(string nombreABuscar)
        {
            List<Sospechoso> listaRet = new List<Sospechoso>();

            nombreABuscar = nombreABuscar.Trim().ToLower();

            foreach (Sospechoso s in GetSospechosos())
            {
                string item = s.Nombre.ToLower();

                if (item.Contains(nombreABuscar))
                {
                    listaRet.Add(s);
                }
            }

            return listaRet;
        }

        public List<Sospechoso> GetSospechososMayoresDeEdad(string edadASuperar)
        {
            List<Sospechoso> listaRet = new List<Sospechoso>();

            int mayorQue = int.Parse(edadASuperar);

            foreach (Sospechoso s in GetSospechosos())
            {
                int item = s.CalcularEdad();

                if (item > mayorQue)
                {
                    listaRet.Add(s);
                }
            }

            return listaRet;
        }

        public IEnumerable<Investigador> GetDetectives()
        {
            List<Investigador> listaRet = new List<Investigador>();

            foreach (Investigador i in _investigadores)
            {
                if(i.Rol == Rol.Detective)
                {
                    listaRet.Add(i);
                }
            }

            return listaRet;
        }

        public List<string> GetClasesHijasDeEvidencia()
        {
            List<string> listaRet = new List<string>();

            var clasesHijas = Evidencia.ObtenerClasesHijas();

            foreach (var cH in clasesHijas)
            {
                listaRet.Add(cH.Name);
            }

            return listaRet;
        }
        
        //sistema
    }
}
