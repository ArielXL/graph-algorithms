using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C
{
    class Program
    {
        public class DisjointSet
        {
            private int[] indices;
            private int[] cantidad;

            public DisjointSet(int n)
            {
                indices = new int[n];
                cantidad = new int[n];

                for (int i = 0; i < n; i++)
                {
                    indices[i] = i;
                    cantidad[i] = 0;
                }
            }

            public int SetOf(int x)
            {
                if (indices[x] == x) 
                    return x;
                else
                    return indices[x] = SetOf(indices[x]);
            }

            public void Merge(int x, int y)
            {
                int a = x;
                int b = y;
                x = SetOf(x);
                y = SetOf(y);

                if (x == y) 
                    return;

                if (cantidad[x] > cantidad[y])
                {
                    cantidad[x] += cantidad[y];
                    indices[y] = x;
                }
                else
                {
                    cantidad[x] += cantidad[y];
                    indices[y] = x;
                }

                Console.WriteLine((a + 1) + " " + (b + 1));
            }
        }

        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split();
            int vertices = int.Parse(line[0]);
            int aristas = int.Parse(line[1]);

            List<Tuple<int, int, int>> grafo = new List<Tuple<int, int, int>>();
            DisjointSet disjoin_set = new DisjointSet(vertices);

            for (int i = 0; i < aristas; i++)
            {
                line = Console.ReadLine().Split();
                grafo.Add(new Tuple<int, int, int>(int.Parse(line[2]), int.Parse(line[0]) - 1, int.Parse(line[1]) - 1));
            }

            grafo.Sort();
            for (int i = 0; i < grafo.Count; i++)
            {
                disjoin_set.Merge(grafo[i].Item2, grafo[i].Item3);
            }
        }
    }
}
