using System;

namespace Lab5_Problema3
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculadoraOperaciones calculadora = new CalculadoraOperaciones();

            Console.WriteLine("=== Problema 3: Sobrecarga de Métodos e Interacción ===");

            // 1. Entrada para enteros (int, int)
            Console.WriteLine("\n--- Operación 1: Suma de Enteros (int, int) ---");
            Console.Write("Ingrese el primer número entero: ");
            int n1 = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Ingrese el segundo número entero: ");
            int n2 = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine($"Resultado: {calculadora.Calcular(n1, n2)}");

            // 2. Entrada para decimales (double, double)
            Console.WriteLine("\n--- Operación 2: Multiplicación de Decimales (double, double) ---");
            Console.Write("Ingrese el primer número decimal: ");
            double d1 = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Ingrese el segundo número decimal: ");
            double d2 = double.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine($"Resultado: {calculadora.Calcular(d1, d2)}");


            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }

    class CalculadoraOperaciones
    {
        // Firma 1: (int, int) -> Suma de enteros
        public int Calcular(int a, int b)
        {
            return a + b;
        }

        // Firma 2: (double, double) -> Multiplicación de decimales
        public double Calcular(double a, double b)
        {
            return a * b;
        }

    }
}