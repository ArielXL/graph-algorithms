using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruskal
{
    public class DisjointSet
    {
        int[] indices;
        int[] cantHijos;

        public DisjointSet(int n)
        {
            indices = new int[n];
            cantHijos = new int[n];
            for (int i = 0; i < n; i++)
            {
                indices[i] = i;
                cantHijos[i] = 1;
            }
        }

        public int SetOff(int x)
        {
            if (indices[x] == x)
                return x;
            else
                return indices[x] = SetOff(indices[x]);
        }

        public bool Merge(int x, int y)
        {
            x = SetOff(x);
            y = SetOff(y);

            if (x == y)
                return false;
            else if (cantHijos[x] > cantHijos[y])
            {
                cantHijos[x] += cantHijos[y];
                cantHijos[y] = 0;
                indices[y] = x;
            }
            else
            {
                cantHijos[y] += cantHijos[x];
                cantHijos[x] = 0;
                indices[x] = y;
            }

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] linea = Console.ReadLine().Split();
            int vertices = int.Parse(linea[0]);
            int aristas = int.Parse(linea[1]);

            DisjointSet conjuntos_disjuntos = new DisjointSet(vertices + 1);
            List<Tuple<int, int, int>> grafo = new List<Tuple<int, int, int>>();

            for (int i = 0; i < aristas; i++)
            {
                linea = Console.ReadLine().Split();

                int u = int.Parse(linea[0]);
                int v = int.Parse(linea[1]);
                int peso = int.Parse(linea[2]);

                grafo.Add(new Tuple<int, int, int>(peso, u, v));
            }

            grafo.Sort();
            int resp = 0;
            
            for (int i = 0; i < grafo.Count; i++)
            {
                if (conjuntos_disjuntos.Merge(grafo[i].Item2, grafo[i].Item3))
                {
                    resp += grafo[i].Item1;
                    Console.WriteLine("{0} {1}", grafo[i].Item2, grafo[i].Item3);
                }
            }

            Console.WriteLine(resp);
        }
    }
}
