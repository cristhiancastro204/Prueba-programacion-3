using System;

namespace MiApp.Consola
{
    public class InformacionOpcion
    {
        public bool EsValida { get; set; }
        public string[] NombresParametros { get; set; } = Array.Empty<string>();
    }

    public static class GestorOperaciones
    {
        public static InformacionOpcion ObtenerInformacion(string opcion)
        {
            switch (opcion)
            {
                case "1": return new InformacionOpcion { EsValida = true, NombresParametros = new[] { "el primer entero", "el segundo entero" } };
                case "2": return new InformacionOpcion { EsValida = true, NombresParametros = new[] { "el primer entero", "el segundo entero" } };
                case "3": return new InformacionOpcion { EsValida = true, NombresParametros = new[] { "el primer entero", "el segundo entero" } };
                case "4": return new InformacionOpcion { EsValida = true, NombresParametros = new[] { "el dividendo", "el divisor" } };
                case "5": return new InformacionOpcion { EsValida = true, NombresParametros = new[] { "la base", "el exponente" } };
                case "6": return new InformacionOpcion { EsValida = true, NombresParametros = new[] { "el número para calcular su raíz cuadrada" } };
                case "7": return new InformacionOpcion { EsValida = true, NombresParametros = new[] { "el ángulo en radianes" } };
                case "8": return new InformacionOpcion { EsValida = true, NombresParametros = new[] { "el ángulo en radianes" } };
                case "9": return new InformacionOpcion { EsValida = true, NombresParametros = new[] { "el ángulo en radianes" } };
                case "10": return new InformacionOpcion { EsValida = true, NombresParametros = new[] { "el número para calcular logaritmo (Base 10)" } };
                default: return new InformacionOpcion { EsValida = false };
            }
        }

        public static double Ejecutar(string opcion, double[] parametros)
        {
            switch (opcion)
            {
                case "1": return Calculadora.Sumar((int)parametros[0], (int)parametros[1]);
                case "2": return Calculadora.Restar((int)parametros[0], (int)parametros[1]);
                case "3": return Calculadora.Multiplicar((int)parametros[0], (int)parametros[1]);
                case "4": return Calculadora.Dividir(parametros[0], parametros[1]);
                case "5": return Calculadora.Potencia(parametros[0], parametros[1]);
                case "6": return Calculadora.RaizCuadrada(parametros[0]);
                case "7": return Calculadora.Seno(parametros[0]);
                case "8": return Calculadora.Coseno(parametros[0]);
                case "9": return Calculadora.Tangente(parametros[0]);
                case "10": return Calculadora.Logaritmo(parametros[0]);
                default: throw new ArgumentException("Opción no válida");
            }
        }
    }
}
