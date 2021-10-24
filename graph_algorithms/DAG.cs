using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
    class Program
    {
        static bool[] visitados;
        static Stack<int> pila;
        static int[] d;
        static int[] pi;

        // Este algoritmo se hace para grafos dirigidos y ponderados
        // En el grafo pueden haber arcos de costo negativo 
        // Resuelve el problema, de manera correcta, siempre y cuando en dicho grafo no existan ciclos de costo negativo alcanzables desde el inicio
        // En el grafo item1 es el valor del vertice e item2 es el costo de la arista

        static void AlgoritmoDAG(List<Tuple<int, int>>[] grafo, int inicio)
        {
            int[] ordenTopologico = OrdenTopologico(grafo);

            d = new int[grafo.Length];
            pi = new int[grafo.Length];

            for (int i = 0; i < grafo.Length; i++)
            {
                d[i] = int.MaxValue;
                pi[i] = int.MaxValue;
            }

            d[inicio] = 0;
            pi[inicio] = -1;
            int pos = 0;

            for (int i = 0; i < ordenTopologico.Length; i++)
            {
                if (inicio == ordenTopologico[i])
                {
                    pos = i;
                    break;
                }
            }

            for (int i = pos; i < ordenTopologico.Length; i++)
            {
		        int elemento = ordenTopologico[i];		

                for (int j = 0; j < grafo[elemento].Count; j++)
                {
		            int temp = grafo[elemento][j].Item1;
		            int costo = grafo[elemento][j].Item2;

                    Relax(elemento, temp, costo);
                }
            }
        }

        static void DFS(List<Tuple<int, int>>[] grafo)
        {
            visitados = new bool[grafo.Length];
            pila = new Stack<int>();

            for (int i = 0; i < grafo.Length; i++)
            {
                if (!visitados[i])
                    DFS_Visit(grafo, i);
            }
        }

        static void DFS_Visit(List<Tuple<int, int>>[] grafo, int elemento)
        {
            visitados[elemento] = true;

            for (int i = 0; i < grafo[elemento].Count; i++)
            {
                int temp = grafo[elemento][i].Item1;

                if (!visitados[temp])
                    DFS_Visit(grafo, temp);
            }

            pila.Push(elemento);
        }

        static int[] OrdenTopologico(List<Tuple<int, int>>[] grafo)
        {
            DFS(grafo);
            int[] ordenTopologico = new int[grafo.Length];

            for (int i = 0; i < ordenTopologico.Length; i++)
            {
                ordenTopologico[i] = pila.Pop();
            }

            return ordenTopologico;
        }

        static void Relax(int u, int v, int costo)
        {
            if (d[v] > d[u] + costo)
            {
                d[v] = d[u] + costo;
                pi[v] = u;
            }
        }

        static void ImprimirArray<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
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

            List<Tuple<int, int>>[] grafo = new List<Tuple<int, int>>[vertices];

            for (int i = 0; i < grafo.Length; i++)
            {
                grafo[i] = new List<Tuple<int, int>>();
            }

            for (int i = 0; i < aristas; i++)
            {
                linea = Console.ReadLine().Split();
                int u = int.Parse(linea[0]) - 1;
                int v = int.Parse(linea[1]) - 1;
                int costo = int.Parse(linea[2]);

                grafo[u].Add(new Tuple<int, int>(v, costo));
            }

            AlgoritmoDAG(grafo, 0);

            ImprimirArray(pi);
            ImprimirArray(d);
        }
    }
}
