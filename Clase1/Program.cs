using System;

Console.WriteLine("Calculadora Básica en C#");
Console.WriteLine("------------------------");

Console.Write("Ingresa el primer número: ");
if (!double.TryParse(Console.ReadLine(), out double num1))
{
    Console.WriteLine("Número inválido.");
    return;
}

Console.Write("Ingresa la operación (+, -, *, /): ");
string operacion = Console.ReadLine();

Console.Write("Ingresa el segundo número: ");
if (!double.TryParse(Console.ReadLine(), out double num2))
{
    Console.WriteLine("Número inválido.");
    return;
}

double resultado = 0;

switch (operacion)
{
    case "+":
        resultado = num1 + num2;
        break;
    case "-":
        resultado = num1 - num2;
        break;
    case "*":
        resultado = num1 * num2;
        break;
    case "/":
        if (num2 == 0)
        {
            Console.WriteLine("Error: No se puede dividir por cero.");
            return;
        }
        resultado = num1 / num2;
        break;
    default:
        Console.WriteLine("Operación no válida.");
        return;
}

Console.WriteLine($"\nEl resultado es: {num1} {operacion} {num2} = {resultado}");
