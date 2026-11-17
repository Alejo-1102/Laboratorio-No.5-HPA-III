namespace Lab5_Problema1
{
    using System;

    namespace Lab5_Problema3
    {


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
                    int n1 = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el segundo número entero: ");
                    int n2 = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Resultado: {calculadora.Calcular(n1, n2)}");

                    // 2. Entrada para decimales (double, double)
                    Console.WriteLine("\n--- Operación 2: Multiplicación de Decimales (double, double) ---");
                    Console.Write("Ingrese el primer número decimal: ");
                    double d1 = double.Parse(Console.ReadLine());
                    Console.Write("Ingrese el segundo número decimal: ");
                    double d2 = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Resultado: {calculadora.Calcular(d1, d2)}");

                    // 3. Entrada para texto y decimal (string, double)
                    Console.WriteLine("\n--- Operación 3: Cálculo de Porcentaje (string, double) ---");
                    Console.Write("Ingrese el monto como texto (ej. 150.50): ");
                    string montoTexto = Console.ReadLine();
                    Console.Write("Ingrese el porcentaje decimal (ej. 0.07 para 7%): ");
                    double porcentaje = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Resultado: {calculadora.Calcular(montoTexto, porcentaje)}");

                    Console.WriteLine("\nPresione cualquier tecla para salir...");
                    Console.ReadKey();
                }
            }

            class CalculadoraOperaciones
            {
                // Firma 1: (int, int) -> Suma
                public int Calcular(int a, int b)
                {
                    return a + b;
                }

                // Firma 2: (double, double) -> Multiplicación
                public double Calcular(double a, double b)
                {
                    return a * b;
                }

            }
        }
    }
}
