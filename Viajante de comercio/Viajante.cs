using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viajante_de_comercio
{
    internal class Viajante
    {
        public int V = 5; // Número de vértices en el grafo

        // Función para encontrar la ruta más corta
        private void TSP(int[,] grafo, int inicio)
        {
            int[] vertices = new int[V];
            for (int i = 0; i < V; i++)
            {
                vertices[i] = i;
            }

            int[] ruta = new int[V + 1];
            int pesoMinimo = int.MaxValue;

            do
            {
                int pesoRuta = 0;
                int k = inicio;
                int i;
                for (i = 0; i < V; i++)
                {
                    pesoRuta += grafo[k, vertices[i]];
                    ruta[i] = vertices[i];
                    k = vertices[i];
                }

                pesoRuta += grafo[k, inicio];

                if (pesoRuta < pesoMinimo)
                {
                    pesoMinimo = pesoRuta;
                    for (i = 0; i < V; i++)
                    {
                        Console.Write((char)(65 + ruta[i]) + " ");
                    }
                    Console.WriteLine((char)(65 + inicio));
                }

            } while (NextPermutation(vertices));
        }

        // Función para obtener la siguiente permutación
        private bool NextPermutation(int[] array)
        {
            int i = array.Length - 1;
            while (i > 0 && array[i - 1] >= array[i])
            {
                i--;
            }

            if (i <= 0)
            {
                return false;
            }

            int j = array.Length - 1;
            while (array[j] <= array[i - 1])
            {
                j--;
            }

            int temp = array[i - 1];
            array[i - 1] = array[j];
            array[j] = temp;

            j = array.Length - 1;
            while (i < j)
            {
                temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                i++;
                j--;
            }

            return true;
        }

        // Función principal
        public void EmpezarPrograma()
        {
            int[,] grafo = {
                { 0, 5, 3, 7, 2 },
                { 5, 0, 6, 8, 9 },
                { 3, 6, 0, 4, 1 },
                { 7, 8, 4, 0, 3 },
                { 2, 9, 1, 3, 0 }
            };

            int inicio = 0; // Punto de partida

            Console.WriteLine("Rutas posibles:");
            TSP(grafo, inicio);
        }
    }
}
