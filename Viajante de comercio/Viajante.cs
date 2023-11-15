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
                int i;                                                   //
                for (i = 0; i < V; i++){                                 // 1, n+1, n
                    pesoRuta += grafo[k, vertices[i]];                   // 1 + 1
                    ruta[i] = vertices[i];                               // 1
                    k = vertices[i];                                     // 1
                }

                pesoRuta += grafo[k, inicio];                            // 1 + 1

                if (pesoRuta < pesoMinimo){                              // 1
                    pesoMinimo = pesoRuta;                               // 1 
                    for (i = 0; i < V; i++){                             // 1, n+1, 1
                        Console.Write((char)(65 + ruta[i]) + " ");       // 1 + 1
                    }
                    Console.WriteLine((char)(65 + inicio));              // 1
                }
            } while (SiguientePermutacion(vertices));                    // 
        }

        // Función para obtener la siguiente permutación
        private bool SiguientePermutacion(int[] array)
        {
            int i = array.Length - 1;                                    // 1 + 1
            while (i > 0 && array[i - 1] >= array[i])                    // n + n
                i--;                                                     //

            if (i <= 0)                                                  // 1 
                return false;

            int j = array.Length - 1;                                    // 1 + 1
            while (array[j] <= array[i - 1])                             //
                j--;                                                     //

            int temp = array[i - 1];                                     //
            array[i - 1] = array[j];                                     //
            array[j] = temp;                                             //

            j = array.Length - 1;                                        //
            while (i < j){                                               //
                temp = array[i];                                         //
                array[i] = array[j];                                     //
                array[j] = temp;                                         //
                i++;                                                     //
                j--;                                                     //
            }

            return true;
        }

        // Función principal
        public void EmpezarPrograma(int[,] grafo, int verticeInicio)
        {
            V = grafo.GetLength(0); // Filas del grafo, valdría con columnas

            Console.WriteLine("Rutas posibles:");
            TSP(grafo, verticeInicio);
        }
    }
}
