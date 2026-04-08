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

        // ------------- RESTA -------------
        [Fact]
        public void Restar_DosNumeros_DevuelveRestaCorrecta()
        {
            int a = 10;
            int b = 4;
            int resultadoEsperado = 6;
            int resultadoActual = Calculadora.Restar(a, b);
            Assert.Equal(resultadoEsperado, resultadoActual);
        }

        // ------------- MULTIPLICACION -------------
        [Fact]
        public void Multiplicar_DosNumeros_DevuelveProductoCorrecto()
        {
            int a = 5;
            int b = 4;
            int resultadoEsperado = 20;
            int resultadoActual = Calculadora.Multiplicar(a, b);
            Assert.Equal(resultadoEsperado, resultadoActual);
        }

        // ------------- DIVISION -------------
        [Fact]
        public void Dividir_DosNumeros_DevuelveCocienteCorrecto()
        {
            double a = 10.0;
            double b = 2.0;
            double resultadoEsperado = 5.0;
            double resultadoActual = Calculadora.Dividir(a, b);
            Assert.Equal(resultadoEsperado, resultadoActual, 5);
        }

        [Fact]
        public void Dividir_PorCero_LanzaExcepcion()
        {
            double a = 10.0;
            double b = 0.0;
            Action accion = () => Calculadora.Dividir(a, b);
            Assert.Throws<ArgumentException>(accion);
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

        // ------------- COSENO -------------
        [Fact]
        public void Coseno_CeroRadianes_DevuelveUno()
        {
            double angulo = 0.0;
            double resultadoEsperado = 1.0;
            double resultadoActual = Calculadora.Coseno(angulo);
            Assert.Equal(resultadoEsperado, resultadoActual, 5);
        }

        [Fact]
        public void Coseno_Pi_DevuelveMenosUno()
        {
            double angulo = Math.PI;
            double resultadoEsperado = -1.0;
            double resultadoActual = Calculadora.Coseno(angulo);
            Assert.Equal(resultadoEsperado, resultadoActual, 5);
        }

        // ------------- TANGENTE -------------
        [Fact]
        public void Tangente_CeroRadianes_DevuelveCero()
        {
            double angulo = 0.0;
            double resultadoEsperado = 0.0;
            double resultadoActual = Calculadora.Tangente(angulo);
            Assert.Equal(resultadoEsperado, resultadoActual, 5);
        }

        [Fact]
        public void Tangente_PiCuartos_DevuelveUno()
        {
            double angulo = Math.PI / 4;
            double resultadoEsperado = 1.0;
            double resultadoActual = Calculadora.Tangente(angulo);
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
