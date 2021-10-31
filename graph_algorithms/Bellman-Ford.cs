using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bellman_Ford
{
    class Program
    {
        static int[] d;
        static int[] pi;
        static bool[] ciclo;
        static List<int> resp;

        static void Inicializar(List<Tuple<int, int>>[] grafo, int inicio)
        {
            d = new int[grafo.Length];
            pi = new int[grafo.Length];
            resp = new List<int>();
            ciclo = new bool[grafo.Length];

            for (int i = 0; i < grafo.Length; i++)
            {
                d[i] = 100000000;
                pi[i] = -1;
            }

            d[inicio] = 0;
        }

        static bool BellmanFord(List<Tuple<int, int>>[] grafo, int inicio)
        {
            Inicializar(grafo, inicio);

            for (int i = 0; i < grafo.Length - 1; i++)
            {
                for (int j = 0; j < grafo.Length; j++)
                {
                    for (int k = 0; k < grafo[j].Count; k++)
                    {
                        Relax(j, grafo[j][k].Item1, grafo[j][k].Item2);
                    }
                }
            }

            for (int i = 0; i < grafo.Length; i++)
            {
                for (int j = 0; j < grafo[i].Count; j++)
                {
                    if (d[grafo[i][j].Item1] > d[i] + grafo[i][j].Item2)
                    {
                        ResuelveCiclo(i);
                        return false;
                    }
                }
            }

            return true;
        }

        static void Relax(int u, int v, int w)
        {
            if (d[v] > d[u] + w)
            {
                d[v] = d[u] + w;
                pi[v] = u;
            }
        }

        static void ResuelveCiclo(int i)
        {
            while (!ciclo[i])
            {
                ciclo[i] = true;
                i = pi[i];
            }
            DameCiclo(pi[i], i);
        }

        static void DameCiclo(int i, int j)
        {
            if (i == j)
            {
                resp.Add(i);
                return;
            }
            else
            {
                DameCiclo(pi[i], j);
                resp.Add(i);
            }
        }

        static void Main(string[] args)
        {
            string[] linea = Console.ReadLine().Split();
            int vertices = int.Parse(linea[0]);
            int aristas = int.Parse(linea[1]);

            List<Tuple<int, int>>[] grafo = new List<Tuple<int, int>>[vertices];

            for (int i = 0; i < vertices; i++)
            {
                grafo[i] = new List<Tuple<int, int>>();
            }

            for (int i = 0; i < aristas; i++)
            {
                linea = Console.ReadLine().Split();
                int a = int.Parse(linea[0]) - 1;
                int b = int.Parse(linea[1]) - 1;
                int peso = int.Parse(linea[2]);

                grafo[a].Add(new Tuple<int, int>(b, peso));
            }

            if (!BellmanFord(grafo, 0))
            {
                Console.WriteLine("SI");
                Console.WriteLine(resp.Count);

                for (int i = 0; i < resp.Count; i++)
                {
                    Console.Write("{0} ", resp[i] + 1);
                }
                Console.WriteLine();
            }
            else
                Console.WriteLine("NO");
        }
    }
}
