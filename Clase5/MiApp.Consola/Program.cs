using System;
using MiApp.Consola;

// Top-level statements en consola
int numeroA = 10;
int numeroB = 25;
int suma = Calculadora.Sumar(numeroA, numeroB);
Console.WriteLine($"Suma: {numeroA} + {numeroB} = {suma}\n");

// --- Funciones Científicas ---

double basePotencia = 2.0;
double exponente = 3.0;
double potencia = Calculadora.Potencia(basePotencia, exponente);
Console.WriteLine($"Potencia: {basePotencia} elevado a {exponente} = {potencia}");

double numeroRaiz = 16.0;
double raiz = Calculadora.RaizCuadrada(numeroRaiz);
Console.WriteLine($"Raíz cuadrada de {numeroRaiz} = {raiz}");

double anguloPimedios = Math.PI / 2;
double seno = Calculadora.Seno(anguloPimedios);
Console.WriteLine($"Seno de Pi/2 radianes = {seno}");

double numeroLog = 100.0;
double logaritmo = Calculadora.Logaritmo(numeroLog);
Console.WriteLine($"Logaritmo en base 10 de {numeroLog} = {logaritmo}");
