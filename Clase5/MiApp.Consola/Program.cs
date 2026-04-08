using System;
using MiApp.Consola;

bool continuar = true;

while (continuar)
{
    Console.Clear();
    Console.WriteLine("=== CALCULADORA CIENTÍFICA ===");
    Console.WriteLine("1. Sumar (Enteros)");
    Console.WriteLine("2. Restar (Enteros)");
    Console.WriteLine("3. Multiplicar (Enteros)");
    Console.WriteLine("4. Dividir");
    Console.WriteLine("5. Potencia");
    Console.WriteLine("6. Raíz Cuadrada");
    Console.WriteLine("7. Seno");
    Console.WriteLine("8. Coseno");
    Console.WriteLine("9. Tangente");
    Console.WriteLine("10. Logaritmo (Base 10)");
    Console.WriteLine("11. Salir");
    Console.Write("Seleccione una opción: ");
    
    string opcion = Console.ReadLine();

    if (opcion == "11")
    {
        continuar = false;
        continue;
    }

    try
    {
        if (opcion == "1")
        {
            Console.Write("Ingrese el primer entero: ");
            int a = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Ingrese el segundo entero: ");
            int b = int.Parse(Console.ReadLine() ?? "0");
            int resultado = Calculadora.Sumar(a, b);
            Console.WriteLine($"Resultado: {resultado}");
        }
        else if (opcion == "2")
        {
            Console.Write("Ingrese el primer entero: ");
            int a = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Ingrese el segundo entero: ");
            int b = int.Parse(Console.ReadLine() ?? "0");
            int resultado = Calculadora.Restar(a, b);
            Console.WriteLine($"Resultado: {resultado}");
        }
        else if (opcion == "3")
        {
            Console.Write("Ingrese el primer entero: ");
            int a = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Ingrese el segundo entero: ");
            int b = int.Parse(Console.ReadLine() ?? "0");
            int resultado = Calculadora.Multiplicar(a, b);
            Console.WriteLine($"Resultado: {resultado}");
        }
        else if (opcion == "4")
        {
            Console.Write("Ingrese el dividendo: ");
            double a = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Ingrese el divisor: ");
            double b = double.Parse(Console.ReadLine() ?? "0");
            double resultado = Calculadora.Dividir(a, b);
            Console.WriteLine($"Resultado: {resultado}");
        }
        else if (opcion == "5")
        {
            Console.Write("Ingrese la base: ");
            double baseNum = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Ingrese el exponente: ");
            double exponente = double.Parse(Console.ReadLine() ?? "0");
            double resultado = Calculadora.Potencia(baseNum, exponente);
            Console.WriteLine($"Resultado: {resultado}");
        }
        else if (opcion == "6")
        {
            Console.Write("Ingrese el número para calcular su raíz cuadrada: ");
            double num = double.Parse(Console.ReadLine() ?? "0");
            double resultado = Calculadora.RaizCuadrada(num);
            Console.WriteLine($"Resultado: {resultado}");
        }
        else if (opcion == "7")
        {
            Console.Write("Ingrese el ángulo en radianes: ");
            double num = double.Parse(Console.ReadLine() ?? "0");
            double resultado = Calculadora.Seno(num);
            Console.WriteLine($"Resultado: {resultado}");
        }
        else if (opcion == "8")
        {
            Console.Write("Ingrese el ángulo en radianes: ");
            double num = double.Parse(Console.ReadLine() ?? "0");
            double resultado = Calculadora.Coseno(num);
            Console.WriteLine($"Resultado: {resultado}");
        }
        else if (opcion == "9")
        {
            Console.Write("Ingrese el ángulo en radianes: ");
            double num = double.Parse(Console.ReadLine() ?? "0");
            double resultado = Calculadora.Tangente(num);
            Console.WriteLine($"Resultado: {resultado}");
        }
        else if (opcion == "10")
        {
            Console.Write("Ingrese el número para calcular logaritmo (Base 10): ");
            double num = double.Parse(Console.ReadLine() ?? "1");
            double resultado = Calculadora.Logaritmo(num);
            Console.WriteLine($"Resultado: {resultado}");
        }
        else
        {
            Console.WriteLine("Opción no válida.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al procesar la operación: {ex.Message}");
    }

    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}
