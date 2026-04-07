using System;
using Xunit;
using MiApp.Consola;

namespace MiApp.Consola.Tests
{
    public class CalculadoraTests
    {
        // ------------- SUMA -------------
        [Fact]
        public void Sumar_DosNumerosPositivos_DevuelveSumaCorrecta()
        {
            int a = 5;
            int b = 10;
            int resultadoEsperado = 15;
            int resultadoActual = Calculadora.Sumar(a, b);
            Assert.Equal(resultadoEsperado, resultadoActual);
        }

        [Fact]
        public void Sumar_UnNumeroNegativoYUnPositivo_DevuelveSumaCorrecta()
        {
            int a = -5;
            int b = 10;
            int resultadoEsperado = 5;
            int resultadoActual = Calculadora.Sumar(a, b);
            Assert.Equal(resultadoEsperado, resultadoActual);
        }

        // ------------- POTENCIA -------------
        [Fact]
        public void Potencia_BaseYExponentePositivos_DevuelveResultadoCorrecto()
        {
            double baseNum = 2.0;
            double exponente = 3.0;
            double resultadoEsperado = 8.0;
            double resultadoActual = Calculadora.Potencia(baseNum, exponente);
            Assert.Equal(resultadoEsperado, resultadoActual, 5);
        }

        [Fact]
        public void Potencia_ExponenteCero_DevuelveUno()
        {
            double baseNum = 5.0;
            double exponente = 0.0;
            double resultadoEsperado = 1.0;
            double resultadoActual = Calculadora.Potencia(baseNum, exponente);
            Assert.Equal(resultadoEsperado, resultadoActual, 5);
        }

        // ------------- RAIZ CUADRADA -------------
        [Fact]
        public void RaizCuadrada_NumeroPositivo_DevuelveResultadoCorrecto()
        {
            double numero = 16.0;
            double resultadoEsperado = 4.0;
            double resultadoActual = Calculadora.RaizCuadrada(numero);
            Assert.Equal(resultadoEsperado, resultadoActual, 5);
        }

        [Fact]
        public void RaizCuadrada_NumeroNegativo_LanzaExcepcion()
        {
            double numero = -4.0;
            Action accion = () => Calculadora.RaizCuadrada(numero);
            Assert.Throws<ArgumentException>(accion);
        }

        // ------------- SENO -------------
        [Fact]
        public void Seno_CeroRadianes_DevuelveCero()
        {
            double angulo = 0.0;
            double resultadoEsperado = 0.0;
            double resultadoActual = Calculadora.Seno(angulo);
            Assert.Equal(resultadoEsperado, resultadoActual, 5);
        }

        [Fact]
        public void Seno_PiMedios_DevuelveUno()
        {
            double angulo = Math.PI / 2;
            double resultadoEsperado = 1.0;
            double resultadoActual = Calculadora.Seno(angulo);
            Assert.Equal(resultadoEsperado, resultadoActual, 5);
        }

        // ------------- LOGARITMO -------------
        [Fact]
        public void Logaritmo_NumeroCien_DevuelveDos()
        {
            double numero = 100.0;
            double resultadoEsperado = 2.0;
            double resultadoActual = Calculadora.Logaritmo(numero);
            Assert.Equal(resultadoEsperado, resultadoActual, 5);
        }

        [Fact]
        public void Logaritmo_NumeroCero_LanzaExcepcion()
        {
            double numero = 0.0;
            Action accion = () => Calculadora.Logaritmo(numero);
            Assert.Throws<ArgumentException>(accion);
        }
    }
}
