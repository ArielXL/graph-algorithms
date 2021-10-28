using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Program
    {
        static long[] d;
        static int[] pi;

        static void inicializar(List<Tuple<long, int>>[] grafo, int origen)
        {
            d = new long[grafo.Length];
            pi = new int[grafo.Length];

            //inicializar los arreglos
            for (int i = 0; i < grafo.Length; i++)
            {
                d[i] = int.MaxValue;
                pi[i] = int.MaxValue;
            }

            d[origen] = 0;
            pi[origen] = -1;
        }

        static bool Relax(int u, int v, long w)
        {
            if (d[v] > d[u] + w)
            {
                d[v] = d[u] + w;
                pi[v] = u;
                return true;
            }
            else
                return false;
        }

        // item1 es el costo
        static void Dijkstra(List<Tuple<long, int>>[] grafo, int origen)
        {
            inicializar(grafo, origen);

            SortedSet<Tuple<long, int>> avl = new SortedSet<Tuple<long, int>>();
            avl.Add(new Tuple<long, int>(0, origen));

            while (avl.Count != 0)
            {
                Tuple<long, int> elemento = avl.Min;
                avl.Remove(avl.Min);

                for (int i = 0; i < grafo[elemento.Item2].Count; i++)
                {
                    Tuple<long, int> temp = grafo[elemento.Item2][i];

                    if (Relax(elemento.Item2, temp.Item2, temp.Item1))
                    {
                        Tuple<long, int> aux = new Tuple<long, int>(d[temp.Item2], temp.Item2);
                        if (avl.Contains(aux))
                            avl.Remove(aux);

                        avl.Add(new Tuple<long, int>(d[temp.Item2], temp.Item2));
                    }
                }
            }
        }

        static void Imprime<T>(T[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            string[] linea = Console.ReadLine().Split();
            int vertices = int.Parse(linea[0]);
            int aristas = int.Parse(linea[1]);

            List<Tuple<long, int>>[] grafo = new List<Tuple<long, int>>[vertices + 1];

            for (int i = 0; i < grafo.Length; i++)
            {
                grafo[i] = new List<Tuple<long, int>>();
            }

            for (int i = 0; i < aristas; i++)
            {
                linea = Console.ReadLine().Split();
                int u = int.Parse(linea[0]);
                int v = int.Parse(linea[1]);
                long costo = long.Parse(linea[2]);

                grafo[u].Add(new Tuple<long, int>(costo, v));
            }

            int origen = int.Parse(Console.ReadLine());

            //caso de la conferencia
            //input
            //5 10
            //1 2 10
            //2 4 1
            //1 3 5
            //3 5 2
            //5 1 7
            //3 4 9
            //2 3 2
            //3 2 3
            //4 5 4
            //5 4 6
            //1
            //output
            //d = { 0, 8, 5, 9, 7 }
            //pi = { -1, 3, 1, 2, 3 }

            Dijkstra(grafo, origen);
            Imprime(d);
            Imprime(pi);
        }
    }
}
