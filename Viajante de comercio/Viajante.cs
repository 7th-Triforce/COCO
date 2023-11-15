using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viajante_de_comercio
{
    internal class Viajante
    {
        public int V; // Número de vértices en el grafo

        // Función para encontrar la ruta más corta                                
        private void TSP(int[,] grafo, int inicio)                       //
        {                                                                //
            int[] vertices = new int[V];                                 // 1
            for (int i = 0; i < V; i++){                                 // 1, n+1, n
                vertices[i] = i;                                         // n
            }

            int[] ruta = new int[V + 1];                                 // 1
            int pesoMinimo = int.MaxValue;                               // 1

            do                                                           //
            {                                                            //
                int pesoRuta = 0;                                        // 1
                int k = inicio;                                          // 1
                for (int i = 0; i < V; i++){                             // 1, n+1, n
                    pesoRuta += grafo[k, vertices[i]];                   // (1 + 1) * n
                    ruta[i] = vertices[i];                               // n
                    k = vertices[i];                                     // n
                }

                pesoRuta += grafo[k, inicio];                            // 1 + 1

                if (pesoRuta < pesoMinimo){                              // 1 | Encontró una ruta válida
                    pesoMinimo = pesoRuta;                               // n 
                    for (int i = 0; i < V; i++){                         // 1, n+1, n
                        Console.Write((char)(65 + ruta[i]) + " ");       // (1 + 1) * n
                    }
                    Console.WriteLine((char)(65 + inicio));              // 1
                }
            } while (SiguientePermutacion(vertices));                    // n! es el máximo de permutaciones posibles -> n! * (11n + 10) 
        }

        // Función para obtener la siguiente permutación
        private bool SiguientePermutacion(int[] array)
        {
            int i = array.Length - 1;                                    // 1 + 1
            while (i > 0 && array[i - 1] >= array[i])                    // n + 2n
                i--;                                                     // n

            if (i <= 0)                                                  // 1 
                return false;

            int j = array.Length - 1;                                    // 1 + 1
            while (array[j] <= array[i - 1])                             // n + n
                j--;                                                     // n

            int temp = array[i - 1];                                     // 1 + 1
            array[i - 1] = array[j];                                     // 1 + 1
            array[j] = temp;                                             // 1

            j = array.Length - 1;                                        // 1 + 1
            while (i < j){                                               // n/2
                temp = array[i];                                         // n/2
                array[i] = array[j];                                     // n/2
                array[j] = temp;                                         // n/2
                i++;                                                     // n/2
                j--;                                                     // n/2
            }

            return true;
        }

        // Función principal
        public void EmpezarPrograma(int[,] grafo, int verticeInicio) // O(n * n!) 
        {
            V = grafo.GetLength(0); // Filas del grafo, valdría con columnas

            Console.WriteLine("Rutas posibles:");
            TSP(grafo, verticeInicio);
        }
    }
}
