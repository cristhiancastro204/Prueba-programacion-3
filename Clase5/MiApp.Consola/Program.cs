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
        var info = GestorOperaciones.ObtenerInformacion(opcion);
        if (!info.EsValida)
        {
            Console.WriteLine("Opción no válida.");
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            continue;
        }

        double[] parametros = new double[info.NombresParametros.Length];
        for (int i = 0; i < info.NombresParametros.Length; i++)
        {
            Console.Write($"Ingrese {info.NombresParametros[i]}: ");
            parametros[i] = double.Parse(Console.ReadLine() ?? "0");
        }

        double resultado = GestorOperaciones.Ejecutar(opcion, parametros);
        Console.WriteLine($"Resultado: {resultado}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al procesar la operación: {ex.Message}");
    }

    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}
