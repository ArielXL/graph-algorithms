using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaminoLongitudMinima
{
    class Program
    {
        static int[] d;
        static int[] pi;
        static int[] componentes_conexas;
        static int resp;

        static void CaminoLongitudMinima_BFS(List<int>[] grafo, int u, int w)
        {
            d = new int[grafo.Length];
            pi = new int[grafo.Length];
            componentes_conexas = new int[grafo.Length];
            resp = 0;

            for (int i = 0; i < d.Length; i++)
            {
                d[i] = int.MinValue;
                pi[i] = int.MinValue;
            }

            d[u] = 0;
            pi[u] = -1;
            componentes_conexas[u] = 1;
            BFS(grafo, u);
            resp = componentes_conexas[w] % 200003;
        }

        static void BFS(List<int>[] grafo, int u)
        {
            Queue<int> cola = new Queue<int>();
            cola.Enqueue(u);

            while (cola.Count != 0)
            {
                int temp = cola.Dequeue();

                for (int i = 0; i < grafo[temp].Count; i++)
                {
                    int q = grafo[temp][i];

                    if (pi[q] == int.MinValue)
                    {
                        d[q] = d[temp] + 1;
                        pi[q] = temp;
                        cola.Enqueue(q);
                    }
                    if (d[q] - 1 == d[temp])
                        componentes_conexas[q] = ((componentes_conexas[q] % 200003) + (componentes_conexas[temp] % 200003));
                }
            }
        }

        static void Main(string[] args)
        {
            string[] linea = Console.ReadLine().Split();
            int vertices = int.Parse(linea[0]);
            int aristas = int.Parse(linea[1]);

            linea = Console.ReadLine().Split();
            int u = int.Parse(linea[0]) - 1;
            int w = int.Parse(linea[1]) - 1;

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
            }

            CaminoLongitudMinima_BFS(grafo, u, w);
            Console.WriteLine(resp);
        }
    }
}
