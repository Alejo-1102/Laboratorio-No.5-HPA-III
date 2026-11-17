using System;

namespace Lab5_Problema4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Problema 4: Recursividad (Cálculo del Factorial) ===");

            Console.Write("\nIngrese un número entero no negativo (n): ");
            string entrada = Console.ReadLine() ?? "";

            // Validación de entrada para evitar excepciones al convertir
            if (int.TryParse(entrada, out int numero) && numero >= 0)
            {
                //  20! es el límite máximo antes de desbordar un tipo 'long' en C#
                if (numero > 20)
                {
                    Console.WriteLine("Advertencia: Los factoriales mayores a 20! sobrepasan el límite de bits del tipo 'long'.");
                }

                long resultado = CalcularFactorial(numero);
                Console.WriteLine($"\nEl factorial de {numero}! es: {resultado}");
            }
            else
            {
                Console.WriteLine("\nError: Debe ingresar un número entero válido mayor o igual a 0.");
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        /// <summary>
        /// Función recursiva para calcular n!
        /// </summary>
        static long CalcularFactorial(int n)
        {
            // Caso Base: Previene llamadas infinitas y evita el StackOverflowException
            if (n <= 1)
            {
                return 1;
            }

            // Paso Recursivo: La función se llama a sí misma con (n - 1)
            return n * CalcularFactorial(n - 1);
        }
    }
}