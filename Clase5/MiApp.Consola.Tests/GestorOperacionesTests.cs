using System;
using Xunit;
using MiApp.Consola;

namespace MiApp.Consola.Tests
{
    public class GestorOperacionesTests
    {
        [Fact]
        public void ObtenerInformacion_Opcion1_EsValidaYRequiereDosParametros()
        {
            var info = GestorOperaciones.ObtenerInformacion("1");
            
            Assert.True(info.EsValida);
            Assert.Equal(2, info.NombresParametros.Length);
            Assert.Equal("el primer entero", info.NombresParametros[0]);
            Assert.Equal("el segundo entero", info.NombresParametros[1]);
        }

        [Fact]
        public void ObtenerInformacion_OpcionNoviaInvalida_DevuelveInvalido()
        {
            var info = GestorOperaciones.ObtenerInformacion("999");
            
            Assert.False(info.EsValida);
        }

        [Fact]
        public void Ejecutar_Opcion1ConParametros_LlamaSumaYDevuelveResultado()
        {
            // Opcion 1 es Sumar
            double[] parametros = new double[] { 5.0, 10.0 };
            double resultadoActual = GestorOperaciones.Ejecutar("1", parametros);
            
            // 5 + 10 = 15
            Assert.Equal(15.0, resultadoActual);
        }

        [Fact]
        public void Ejecutar_Opcion6ConParametros_LlamaRaizCuadradaYDevuelveResultado()
        {
            // Opcion 6 es Raiz Cuadrada
            double[] parametros = new double[] { 16.0 };
            double resultadoActual = GestorOperaciones.Ejecutar("6", parametros);
            
            // Sqrt(16) = 4
            Assert.Equal(4.0, resultadoActual);
        }

        [Fact]
        public void Ejecutar_OpcionInvalida_LanzaExcepcion()
        {
            double[] parametros = new double[] { 1.0 };
            Action accion = () => GestorOperaciones.Ejecutar("opcionLoca", parametros);
            
            Assert.Throws<ArgumentException>(accion);
        }
    }
}
