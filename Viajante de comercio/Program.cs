using System;
using System.Collections.Generic;
using System.Linq;
using Viajante_de_comercio;

class Program
{
    static void Main()
    {

        Viajante viajero = new Viajante();
        viajero.EmpezarPrograma();






        
        // Ejemplo de uso
       const int numeroDeVertices = 4;
        GrafoPonderado grafo = new GrafoPonderado(numeroDeVertices);
        //int verticeInicial = 0;
        /*
        List<Arista>[] lista = grafo.getListaAdyacencia();
        for (int i=0; i<numeroDeVertices; i++)
        {
            Console.WriteLine("Arista " + i);
            foreach (Arista arista in lista[i])
            {
                Console.WriteLine(" - Destino: " + arista.Destino);
                Console.WriteLine(" - Peso: " + arista.Peso);
            }
            Console.WriteLine();
        }
        */


        /*
        // A
        Arista aristaAB = new Arista(1, 7);
        Arista aristaAC = new Arista(2, 3);
        Arista aristaAD = new Arista(3, 1);
        // B
        Arista aristaBD = new Arista(3, 1);
        Arista aristaBA = new Arista(0, 7);
        // C
        Arista aristaCD = new Arista(3, 4);
        Arista aristaCA = new Arista(0, 3);
        //D
        Arista aristaDA = new Arista(0, 1);
        Arista aristaDB = new Arista(1, 1);
        Arista aristaDC = new Arista(2, 4);

        List<Arista>[] lista = new List<Arista>[numeroDeVertices] {
            new List<Arista> {aristaAB, aristaAC, aristaAD},
            new List<Arista> {aristaBA, aristaBD},
            new List<Arista> {aristaCA, aristaCD},
            new List<Arista> {aristaDA, aristaDB, aristaDC}};

        grafo.setListaAdyacencia(lista);
        List<int> solucion = ProblemaViajante(grafo, verticeInicial);

        Console.WriteLine("Solución del Problema del Viajante:");
        foreach (var vertice in solucion)
        {
            Console.Write($"{vertice} ");
        }
        */
    }

    static List<int> ProblemaViajante(GrafoPonderado grafo, int vertice)
    {
        List<int> solucion = new List<int>();
        int numeroDeVertices = grafo.NumeroDeVertices;
        bool[] visitado = new bool[numeroDeVertices];

        for (int v = 0; v < numeroDeVertices; v++)
        {
            visitado[v] = false;
        }

        solucion.Add(vertice);
        visitado[vertice] = true;
        int verticeActual = vertice;

        while (ExisteVerticeNoVisitado(visitado))
        {
            int siguienteVertice = ExtraerVerticeConDistanciaMinimaDesde(grafo, verticeActual, visitado);

            if (siguienteVertice >= 0)
            {
                solucion.Add(siguienteVertice);
                // Añadir arista dirigida desde verticeActual a siguienteVertice
                int peso = grafo.AgregarAristaDirigida(verticeActual, siguienteVertice);
                Console.WriteLine($"Añadiendo arista dirigida de {verticeActual} a {siguienteVertice} con peso {peso}");
                visitado[siguienteVertice] = true;
                verticeActual = siguienteVertice;
            }
            else
            {
                // No quedan vértices no visitados
                break;
            }
        }

        // Vuelta a casa
        grafo.AgregarAristaDirigida(verticeActual, vertice);
        Console.WriteLine($"Añadiendo arista dirigida de vuelta a casa desde {verticeActual} a {vertice}");

        return solucion;
    }

    static bool ExisteVerticeNoVisitado(bool[] visitado)
    {
        return visitado.Any(v => !v);
    }

    static int ExtraerVerticeConDistanciaMinimaDesde(GrafoPonderado grafo, int verticeActual, bool[] visitado)
    {
        int minPeso = int.MaxValue;
        int siguienteVertice = -1;

        foreach (var arista in grafo.ObtenerAristasDesde(verticeActual))
        {
            if (!visitado[arista.Destino] && arista.Peso < minPeso)
            {
                minPeso = arista.Peso;
                siguienteVertice = arista.Destino;
            }
        }

        return siguienteVertice;
    }

    class GrafoPonderado
    {
        private List<Arista>[] listaDeAdyacencia;

        public int NumeroDeVertices { get; }

        public GrafoPonderado(int numeroDeVertices)
        {
            NumeroDeVertices = numeroDeVertices;
            listaDeAdyacencia = new List<Arista>[numeroDeVertices];

            for (int i = 0; i < numeroDeVertices; i++)
            {
                listaDeAdyacencia[i] = new List<Arista>();
            }

            // Agrega aristas con pesos (en este ejemplo, pesos aleatorios para simular un grafo disperso).
            Random random = new Random();
            for (int i = 0; i < numeroDeVertices; i++)
            {
                for (int j = i + 1; j < numeroDeVertices; j++)
                {
                    if (random.Next(2) == 0) // Agrega arista con probabilidad del 50%
                    {
                        int peso = random.Next(1, 10); // Pesos aleatorios entre 1 y 10.
                        listaDeAdyacencia[i].Add(new Arista(j, peso));
                        listaDeAdyacencia[j].Add(new Arista(i, peso));
                    }
                }
            }
        }

        public void setListaAdyacencia(List<Arista>[] lista)
        {
            listaDeAdyacencia = lista;
        }
        public List<Arista>[] getListaAdyacencia()
        {
            return listaDeAdyacencia;
        }

        public int AgregarAristaDirigida(int origen, int destino)
        {
            // Implementa la lógica para agregar una arista dirigida.
            int peso = listaDeAdyacencia[origen].Find(a => a.Destino == destino)?.Peso ?? 0;
            Console.WriteLine($"Añadiendo arista dirigida de {origen} a {destino} con peso {peso}");
            return peso;
        }

        public IEnumerable<Arista> ObtenerAristasDesde(int vertice)
        {
            return listaDeAdyacencia[vertice];
        }
    }

    class Arista
    {
        public int Destino { get; }
        public int Peso { get; }

        public Arista(int destino, int peso)
        {
            Destino = destino;
            Peso = peso;
        }
    }
}