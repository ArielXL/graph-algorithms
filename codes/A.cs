using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A
{
    class Program
    {
        public static List<int>[] grafo;
        public static int[] d;
        public static int[] pi;

        public static void Inicializar(int inicio)
        {
            for (int i = 0; i < d.Length; i++)
            {
                if (i != inicio)
                {
                    d[i] = int.MinValue;
                    pi[i] = int.MinValue;
                    continue;
                }
                d[i] = 0;
                pi[i] = int.MinValue;
            }
        }

        public static void BFS(List<int>[] grafo, int inicio)
        {
            Queue<int> cola = new Queue<int>();
            cola.Enqueue(inicio);
            Inicializar(inicio);

            while (cola.Count != 0)
            {
                var temp = cola.Dequeue();
                for (int i = 0; i < grafo[temp].Count; i++)
                {
                    if (d[grafo[temp][i]] == int.MinValue)
                    {
                        d[grafo[temp][i]] = d[temp] + 1;
                        pi[grafo[temp][i]] = temp;
                        cola.Enqueue(grafo[temp][i]);
                    }
                }
            }
        }

        public static void ImprimeCamino(int inicio, int fin)
        {
            if (inicio == fin)
            {
                Console.Write("{0} ", inicio + 1);
                return;
            }
            ImprimeCamino(inicio, pi[fin]);
            Console.Write("{0} ", fin + 1);
        }

        static void Main(string[] args)
        {
            string[] linea = Console.ReadLine().Split();
            int vertices = int.Parse(linea[0]);
            int aristas = int.Parse(linea[1]);
            int s = int.Parse(linea[2]) - 1;
            int t = int.Parse(linea[3]) - 1;

            grafo = new List<int>[vertices];
            pi = new int[vertices];
            d = new int[vertices];

            for (int i = 0; i < vertices; i++)
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

            BFS(grafo, s);

            if (d[t] != int.MinValue)
            {
                Console.WriteLine("Si");
                Console.WriteLine(d[t] + 1);
                ImprimeCamino(s, t);
                Console.WriteLine();
            }
            else
                Console.WriteLine("No");
        }
    }
}
