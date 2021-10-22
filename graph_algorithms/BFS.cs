using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    class Program
    {
        static void BFS(List<int>[] grafo, int vertice)
        {
            Queue<int> cola = new Queue<int>();
            cola.Enqueue(vertice);
            int[] distancia = new int[grafo.Length];
            int[] pi = new int[grafo.Length];

            for (int i = 0; i < grafo.Length; i++)
            {
                if (i != vertice)
                {
                    distancia[i] = int.MinValue;
                    pi[i] = int.MinValue;
                }
                else
                {
                    distancia[i] = 0;
                    pi[i] = int.MinValue;
                }
            }

            while (cola.Count != 0)
            {
                var temp = cola.Dequeue();
                for (int i = 0; i < grafo[temp].Count; i++)
                {
                    if (distancia[grafo[temp][i]] == int.MinValue)
                    {
                        distancia[grafo[temp][i]] = distancia[temp] + 1;
                        pi[grafo[temp][i]] = temp;
                        cola.Enqueue(grafo[temp][i]);
                    }
                }
            }

            Console.WriteLine("Los vertices son:");
            for (int i = 0; i < grafo.Length; i++)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();

            Console.WriteLine("El arreglo distancia es:");
            for (int i = 0; i < distancia.Length; i++)
            {
                Console.Write("{0} ", distancia[i]);
            }
            Console.WriteLine();

            Console.WriteLine("El arreglo pi es:");
            for (int i = 0; i < pi.Length; i++)
            {
                Console.Write("{0} ", pi[i]);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            List<int>[] grafo = new List<int>[]
            {
                new List<int>() { 1, 2 }, new List<int>() { 0, 2, 3 }, new List<int>() { 0, 1, 3, 4 }, new List<int>() { 1, 2, 4, 5 },
                new List<int>(){ 2, 3, 5 }, new List<int>(){ 3, 4 }
            };

            BFS(grafo, 3);
        }
    }
}
