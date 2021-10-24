using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenTopologico
{
    class Program
    {
        #region Una Forma

        // Una forma de obtener un orden topologico es cuando en el DFS 
        // se terminan de analizar los vertices (o sea que se ponen negros)
        // se meten en una pila y el orden topologico es cuando se van 
        // sacando de la pila

        static bool[] visitados;
        static Stack<int> pila;

        static void Recorrido_DFS(List<int>[] grafo)
        {
            visitados = new bool[grafo.Length];
            pila = new Stack<int>();
            
            for (int i = 0; i < grafo.Length; i++)
            {
                if (!visitados[i])
                    Recorrido_DFS_Visit(grafo, i);
            }
        }

        static void Recorrido_DFS_Visit(List<int>[] grafo, int elemento)
        {
            visitados[elemento] = true;

            for (int i = 0; i < grafo[elemento].Count; i++)
            {
                int current = grafo[elemento][i];
                if (!visitados[current])
                    Recorrido_DFS_Visit(grafo, current);
            }

            pila.Push(elemento);
        }

        public static int[] OrdenTopologico(List<int>[] grafo)
        {
            Recorrido_DFS(grafo);
            int[] resp = new int[grafo.Length];

            for (int i = 0; i < resp.Length; i++)
            {
                resp[i] = pila.Pop();
            }

            return resp;
        }

        #endregion 

        #region Otra Forma

        static int[] OrdenTopologico(List<int>[] grafo, int[] indegree)
        {
            int[] resp = new int[indegree.Length];
            int cont = 0;

            for (int i = 0; i < indegree.Length; i++)
            {
                if (indegree[i] == 0)
                {
                    resp[cont] = i;
                    cont++;
                    indegree[i]--;

                    for (int j = 0; j < grafo[i].Count; j++)
                    {
                        indegree[grafo[i][j]]--;
                    }
                    i = -1;
                }
            }

            return resp;
        }

        #endregion

        static bool EsOrdenTopologico(List<int>[] grafo, int[] elementos, int[] indegree)
        {
            for (int i = 0; i < elementos.Length; i++)
            {
                int current = elementos[i];

                if (indegree[current] != 0) 
                    return false;

                indegree[current]--;
                for (int j = 0; j < grafo[current].Count; j++)
                {
                    indegree[grafo[current][j]]--;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            List<int>[] a = new[]
            {
                new List<int>(){2},
                new List<int>(){2,3},
                new List<int>(){4},
                new List<int>(){4},
                new List<int>(){}
            };

            int[] ordenTopologico = OrdenTopologico(a);

            for (int i = 0; i < ordenTopologico.Length; i++)
            {
                Console.Write("{0} ", ordenTopologico[i]);
            }
            Console.WriteLine();

            int[] s = { 0, 0, 2, 1, 2 };

            //OrdenTopologico(a, s);
            Console.WriteLine(EsOrdenTopologico(a, new[] { 0, 1, 2, 3, 4 }, s));
        }
    }
}
