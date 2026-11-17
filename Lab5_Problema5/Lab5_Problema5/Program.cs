using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab5_Problema5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Problema 5: Conteo y Análisis de Frecuencias ===");

            Console.WriteLine("\nIngrese una lista de números enteros separados por espacios o comas:");
            Console.WriteLine("Ejemplo: 10 20 10 30 20 10");
            Console.Write("> ");

            string entrada = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(entrada))
            {
                try
                {
                    // Convierte la entrada de texto en un arreglo int[]
                    int[] datos = entrada
                        .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    Console.WriteLine("\n--- Tabla de Frecuencias ---");
                    ContarFrecuencias(datos);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nError: Se detectaron caracteres no numéricos. Ingrese solo enteros.");
                }
            }
            else
            {
                Console.WriteLine("\nError: No ingresó ningún valor.");
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        /// <summary>
        /// Recorre el arreglo en O(n) y contabiliza la frecuencia de cada entero.
        /// </summary>
        static void ContarFrecuencias(int[] arreglo)
        {
            Dictionary<int, int> frecuencias = new Dictionary<int, int>();

            foreach (int elemento in arreglo)
            {
                if (frecuencias.ContainsKey(elemento))
                {
                    frecuencias[elemento]++;
                }
                else
                {
                    frecuencias[elemento] = 1;
                }
            }

            // Impresión formateada del resultado
            Console.WriteLine("Elemento\tFrecuencia");
            Console.WriteLine("--------------------------");
            foreach (KeyValuePair<int, int> par in frecuencias)
            {
                Console.WriteLine($"{par.Key}\t\t{par.Value}");
            }
        }
    }
}