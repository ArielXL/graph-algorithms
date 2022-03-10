using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncontrandoPuntosArticulacion
{
    class Program
    {
        static int cantPuntos;
        static int cantHijosRaiz;
        static bool[] puntosArticulacion;
        static int tiempo;
        static bool[] visitados;
        static int[] pi;
        static int[] d;
        static int[] low;

        static void DFS(List<int>[] grafo)
        {
            for (int i = 0; i < grafo.Length; i++)
            {
                if (!visitados[i])
                {
                    cantHijosRaiz = 0;
                    DFS_Visit(grafo, i);
                }
            }
        }

        static void DFS_Visit(List<int>[] grafo, int elemento)
        {
            visitados[elemento] = true;
            tiempo++;
            d[elemento] = tiempo;
            low[elemento] = d[elemento];

            for (int i = 0; i < grafo[elemento].Count; i++)
            {
                int temp = grafo[elemento][i];
                if (!visitados[temp])
                {
                    pi[temp] = elemento;

                    if (elemento == 0)
                        cantHijosRaiz++;

                    DFS_Visit(grafo, temp);
                    low[elemento] = Math.Min(low[elemento], low[temp]);

                    if (pi[elemento] != int.MinValue && low[temp] >= d[elemento])
                    {
                        if (!puntosArticulacion[elemento])
                            cantPuntos++;
                        puntosArticulacion[elemento] = true;
                    }
                }
                else if (pi[temp] != elemento)
                    low[elemento] = Math.Min(low[elemento], d[temp]);
            }
        }

        static void DamePuntosArticulacion(List<int>[] grafo)
        {
            cantPuntos = 0;
            cantHijosRaiz = 0;
            puntosArticulacion = new bool[grafo.Length];
            tiempo = 0;
            visitados = new bool[grafo.Length];
            pi = new int[grafo.Length];
            d = new int[grafo.Length];
            low = new int[grafo.Length];

            pi[0] = int.MinValue;
            DFS(grafo);

            if (cantHijosRaiz >= 2)
            {
                cantPuntos++;
                puntosArticulacion[0] = true;
            }
        }

        static void Main(string[] args)
        {
            string[] linea = Console.ReadLine().Split();
            int vertices = int.Parse(linea[0]);
            int aristas = int.Parse(linea[1]);

            List<int>[] grafo = new List<int>[vertices];

            for (int i = 0; i < grafo.Length; i++)
            {
                grafo[i] = new List<int>();
            }

            for (int i = 0; i < aristas; i++)
            {
                linea = Console.ReadLine().Split();
                int a = int.Parse(linea[0]) - 1;
                int b = int.Parse(linea[1]) - 1;

                grafo[a].Add(b);
                grafo[b].Add(a);
            }

            DamePuntosArticulacion(grafo);

            if (cantPuntos == 0)
                Console.WriteLine(-1);
            else
            {
                Console.WriteLine(cantPuntos);
                for (int i = 0; i < puntosArticulacion.Length; i++)
                {
                    if(puntosArticulacion[i])
                        Console.Write("{0} ", i + 1);
                }
                Console.WriteLine();
            }
        }
    }
}
