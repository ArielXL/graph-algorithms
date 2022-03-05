using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncontrandoAristasPuentes
{
    class Program
    {
        public static bool[] visited;
        public static int[] pi;
        public static int time;
        public static int[] d;
        public static int[] low;
        public static List<Tuple<int, int>> aristasPuente;

        static void DFS(List<int>[] grafo)
        {
            for (int i = 0; i < grafo.Length; i++)
            {
                if (!visited[i])
                    DFS_Visit_PA(grafo, i);
            }
        }

        static void DFS_Visit_PA(List<int>[] grafo, int elem)
        {
            visited[elem] = true;
            time++;
            d[elem] = time;
            low[elem] = d[elem];
            for (int i = 0; i < grafo[elem].Count; i++)
            {
                if (!visited[grafo[elem][i]])
                {
                    pi[grafo[elem][i]] = elem;

                    DFS_Visit_PA(grafo, grafo[elem][i]);

                    low[elem] = Math.Min(low[elem], low[grafo[elem][i]]);
                }
                else if (pi[elem] != grafo[elem][i])
                    low[elem] = Math.Min(low[elem], d[grafo[elem][i]]);
            }
            if (pi[elem] != int.MinValue && low[elem] == d[elem])
                aristasPuente.Add(new Tuple<int, int>(pi[elem], elem));
        }

        static void EncontrandoAristasPuentes_DFS(List<int>[] grafo)
        {
            aristasPuente = new List<Tuple<int, int>>();
            visited = new bool[grafo.Length];
            pi = new int[grafo.Length];
            time = 0;
            d = new int[grafo.Length];
            low = new int[grafo.Length];
            pi[0] = int.MinValue;

            DFS(grafo);
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
                grafo[int.Parse(linea[0]) - 1].Add(int.Parse(linea[1]) - 1);
                grafo[int.Parse(linea[1]) - 1].Add(int.Parse(linea[0]) - 1);
            }

            EncontrandoAristasPuentes_DFS(grafo);

            if (aristasPuente.Count > 0)
            {
                Console.WriteLine(aristasPuente.Count);
                for (int i = 0; i < aristasPuente.Count; i++)
                {
                    Console.WriteLine("{0} {1}", aristasPuente[i].Item1 + 1, aristasPuente[i].Item2 + 1);
                }
            }
            else
                Console.WriteLine(-1);

        }
    }
}
