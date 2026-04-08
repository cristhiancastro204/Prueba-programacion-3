using System;

namespace MiApp.Consola
{
    public static class Calculadora
    {
        public static int Sumar(int a, int b)
        {
            int resultado = a + b;
            return resultado;
        }

        public static int Restar(int a, int b)
        {
            int resultado = a - b;
            return resultado;
        }

        public static int Multiplicar(int a, int b)
        {
            int resultado = a * b;
            return resultado;
        }

        public static double Dividir(double a, double b)
        {
            if (b == 0)
            {
                throw new ArgumentException("No se puede dividir por cero.");
            }
            double resultado = a / b;
            return resultado;
        }

        public static double Potencia(double baseNum, double exponente)
        {
            double resultado = Math.Pow(baseNum, exponente);
            return resultado;
        }

        public static double RaizCuadrada(double numero)
        {
            if (numero < 0)
            {
                throw new ArgumentException("No se puede calcular la raíz cuadrada de un número negativo.");
            }
            double resultado = Math.Sqrt(numero);
            return resultado;
        }

        public static double Seno(double anguloRadianes)
        {
            double resultado = Math.Sin(anguloRadianes);
            return resultado;
        }

        public static double Coseno(double anguloRadianes)
        {
            double resultado = Math.Cos(anguloRadianes);
            return resultado;
        }

        public static double Tangente(double anguloRadianes)
        {
            double resultado = Math.Tan(anguloRadianes);
            return resultado;
        }

        public static double Logaritmo(double numero)
        {
            if (numero <= 0)
            {
                throw new ArgumentException("El logaritmo solo está definido para números mayores a cero.");
            }
            // Logaritmo en base 10
            double resultado = Math.Log10(numero); 
            return resultado;
        }
    }
}
