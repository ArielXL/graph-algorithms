using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B
{
    class Program
    {
        public static int[] d;
        public static int[] pi;
        public static bool[] visitados;
        public static List<Tuple<int, int>>[] grafo;

        public static int ExtraeMinimo()
        {
            int temp = int.MaxValue;
            int pos = int.MaxValue;

            for (int i = 0; i < d.Length; i++)
            {
                if (!visitados[i] && d[i] < temp)
                {
                    temp = d[i];
                    pos = i;
                }
            }
            return pos;
        }

        public static void Relax(int u, int v, int costo)
        {
            if (d[v] > d[u] + costo)
            {
                d[v] = d[u] + costo;
                pi[v] = u;
            }
        }

        public static void Inicializar(int inicio)
        {
            d = new int[grafo.Length];
            pi = new int[grafo.Length];
            visitados = new bool[grafo.Length];

            for (int i = 0; i < grafo.Length; i++)
            {
                visitados[i] = false;
                d[i] = int.MaxValue;
                pi[i] = int.MaxValue;
            }

            d[inicio] = 0;
        }

        public static void Dijkstra(int inicio)
        {
            Inicializar(inicio);
            
            for (int i = 0; i < grafo.Length; i++)
            {
                int temp = ExtraeMinimo();
                visitados[temp] = true;

                for (int j = 0; j < grafo[temp].Count; j++)
                {
                    Relax(temp, grafo[temp][j].Item1, grafo[temp][j].Item2);
                }
            }
        }

        static void Main(string[] args)
        {
            string[] linea = Console.ReadLine().Split();
            int vertices = int.Parse(linea[0]);
            int aristas = int.Parse(linea[1]);

            linea = Console.ReadLine().Split();
            int cantA = int.Parse(linea[0]);
            int cantB = int.Parse(linea[1]);
            int[] a = new int[cantA];
            int[] b = new int[cantB];

            linea = Console.ReadLine().Split();
            for (int i = 0; i < cantA; i++)
            {
                a[i] = int.Parse(linea[i]);
            }

            linea = Console.ReadLine().Split();
            for (int i = 0; i < cantB; i++)
            {
                b[i] = int.Parse(linea[i]);
            }

            grafo = new List<Tuple<int, int>>[vertices + 1];

            for (int i = 0; i < vertices + 1; i++)
            {
                grafo[i] = new List<Tuple<int, int>>();
            }

            for (int i = 0; i < aristas; i++)
            {
                linea = Console.ReadLine().Split();
                int u = int.Parse(linea[0]);
                int v = int.Parse(linea[1]);
                int costo = int.Parse(linea[2]);

                grafo[u].Add(new Tuple<int, int>(v, costo));
                grafo[v].Add(new Tuple<int, int>(u, costo));
            }

            for (int i = 0; i < cantA; i++)
            {
                grafo[0].Add(new Tuple<int, int>(a[i], 0));
                grafo[a[i]].Add(new Tuple<int, int>(0, 0));
            }

            Dijkstra(0);

            Queue<int> cola = new Queue<int>();
            int resp = int.MaxValue;
            int temp = 0;

            for (int i = 0; i < cantB; i++)
            {
                if (d[b[i]] < resp)
                {
                    resp = d[b[i]];
                    temp = b[i];
                }
            }

            while (temp != 0)
            {
                cola.Enqueue(temp);
                temp = pi[temp];
            }

            Console.WriteLine(resp);
            Console.WriteLine(cola.Count);
            Console.Write(cola.Dequeue());

            while (cola.Count > 0)
            {
                Console.Write(" " + cola.Dequeue());
            }
            Console.WriteLine();
        }
    }
}
