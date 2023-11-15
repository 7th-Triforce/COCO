using System;
using System.Collections.Generic;
using System.Linq;
using Viajante_de_comercio;

class Program
{
    static void Main()
    {
        int[,] grafo = {
                { 0, 5, 3, 7, 2 },
                { 5, 0, 6, 8, 9 },
                { 3, 6, 0, 4, 1 },
                { 7, 8, 4, 0, 3 },
                { 2, 9, 1, 3, 0 }
        };

        int inicio = 0; // Punto de partida -> A

        Viajante viajero = new Viajante();
        viajero.EmpezarPrograma(grafo, inicio);
    }
}