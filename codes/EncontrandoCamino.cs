using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncontrandoCamino
{
    class Program
    {
        static List<int> resp;
        static int[] pi;
        static bool[] visitados;
        static int[] componentes_conexas;
        static int tiempo;
        static int[] d;
        static int[] f;
        static bool ya;

        static void EncontrandoCamino_DFS(List<int>[] grafo, int u, int w)
        {
            resp = new List<int>();
            visitados = new bool[grafo.Length];
            pi = new int[grafo.Length];
            d = new int[grafo.Length];
            f = new int[grafo.Length];
            tiempo = 0;
            ya = false;

            for (int i = 1; i < pi.Length; i++)
            {
                pi[i] = int.MinValue;
                if (i == u)
                    pi[i] = 0;
            }

            DFS_Visit(grafo, u, w);

            if (ya)
            {
                Console.WriteLine(resp.Count);
                for (int i = 0; i < resp.Count; i++)
                {
                    Console.Write("{0} ", resp[i]);
                }
                Console.WriteLine();
            }
            else
                Console.WriteLine(-1);
        }

        static void DFS_Visit(List<int>[] grafo, int u, int w)
        {
            visitados[u] = true;
            tiempo++;
            d[u] = tiempo;

            for (int i = 0; i < grafo[u].Count; i++)
            {
                int q = grafo[u][i];
                if (!visitados[q])
                {
                    pi[q] = u;
                    if (q == w)
                    {
                        ya = true;
                        BuscarCamino(grafo, q);
                        resp.Reverse();
                        break;
                    }

                    DFS_Visit(grafo, q, w);
                    if (ya)
                        break;
                }
            }

            tiempo++;
            f[u] = tiempo;
        }

        static void BuscarCamino(List<int>[] grafo, int q)
        {
            if (pi[q] == 0)
            {
                resp.Add(q);
                return;
            }
            else
            {
                resp.Add(q);
                BuscarCamino(grafo, pi[q]);
            }
        }

        static void Main(string[] args)
        {
            string[] linea = Console.ReadLine().Split();
            int vertices = int.Parse(linea[0]);
            int aristas = int.Parse(linea[1]);

            linea = Console.ReadLine().Split();
            int u = int.Parse(linea[0]);
            int w = int.Parse(linea[1]);

            List<int>[] grafo = new List<int>[vertices + 1];

            for (int i = 1; i < grafo.Length; i++)
            {
                grafo[i] = new List<int>();
            }

            for (int i = 0; i < aristas; i++)
            {
                linea = Console.ReadLine().Split();
                int a = int.Parse(linea[0]);
                int b = int.Parse(linea[1]);

                grafo[a].Add(b);
            }

            EncontrandoCamino_DFS(grafo, u, w);
        }
    }
}
