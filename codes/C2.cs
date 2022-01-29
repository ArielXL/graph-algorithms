using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C
{
    class Program
    {
        private static long[] d;
        private static int[] pi;
        private static int[] indegree;
        private static bool[] no_cero;

        static List<int> OrdenTopologico(List<Tuple<int, long>>[] grafo)
        {
            List<int> orden_topologico = new List<int>();

            for (int i = 0; i < indegree.Length; i++)
            {
                if (indegree[i] == 0)
                {
                    orden_topologico.Add(i);
                    indegree[i]--;

                    for (int j = 0; j < grafo[i].Count; j++)
                    {
                        int temp = grafo[i][j].Item1;
                        indegree[temp]--;
                    }

                    i = -1;
                }
            }

            return orden_topologico;
        }

        static void AlgoritmoDAG(List<Tuple<int, long>>[] grafo)
        {
            List<int> orden_topologico = OrdenTopologico(grafo);
            inicializar(grafo);

            for (int i = 0; i < orden_topologico.Count; i++)
            {
                for (int j = 0; j < grafo[orden_topologico[i]].Count; j++)
                {
                    Relax(orden_topologico[i], grafo[orden_topologico[i]][j].Item1, grafo[orden_topologico[i]][j].Item2);
                }
            }
        }

        static void inicializar(List<Tuple<int, long>>[] grafo)
        {
            d = new long[grafo.Length];
            pi = new int[grafo.Length];

            for (int i = 0; i < grafo.Length; i++)
            {
                d[i] = int.MaxValue;
                pi[i] = int.MaxValue;
            }

            for (int i = 0; i < no_cero.Length; i++)
            {
                if (!no_cero[i])
                    d[i] = 0;
            }
        }

        static void Relax(int u, int v, long costo)
        {
            if (d[v] > d[u] + costo)
            {
                d[v] = d[u] + costo;
                pi[v] = u;
            }
        }

        static void Main(string[] args)
        {
            string[] linea = Console.ReadLine().Split();
            int n = int.Parse(linea[0]);
            int m = int.Parse(linea[1]);

            List<Tuple<int, long>>[] grafo = new List<Tuple<int, long>>[n];

            for (int i = 0; i < grafo.Length; i++)
            {
                grafo[i] = new List<Tuple<int, long>>();
            }

            indegree = new int[n];
            no_cero = new bool[n];

            for (int i = 0; i < m; i++)
            {
                linea = Console.ReadLine().Split();
                int u = int.Parse(linea[0]) - 1;
                int v = int.Parse(linea[1]) - 1;
                long costo = long.Parse(linea[2]);

                grafo[u].Add(new Tuple<int, long>(v, (-1 * costo)));
                indegree[v]++;
                no_cero[v] = true;
            }

            AlgoritmoDAG(grafo);
            long menor = int.MaxValue;

            for (int i = 0; i < d.Length; i++)
            {
                if (d[i] < menor)
                    menor = d[i];
            }

            Console.WriteLine(-1 * menor);
        }
    }
}
