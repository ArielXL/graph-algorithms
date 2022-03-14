using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoBipartito
{
    class Program
    {
        static bool[] marcados;
        static int[] pi;
        static char[] conjuntos;

        static bool BFS(List<int>[] grafo)
        {
            marcados = new bool[grafo.Length];
            pi = new int[grafo.Length];
            conjuntos = new char[grafo.Length];

            for (int i = 0; i < pi.Length; i++)
            {
                pi[i] = int.MinValue;
            }

            Queue<int> cola = new Queue<int>();
            cola.Enqueue(0);
            marcados[0] = true;
            conjuntos[0] = 'a';

            while (cola.Count != 0)
            {
                int currrent = cola.Dequeue();
                for (int i = 0; i < grafo[currrent].Count; i++)
                {
                    int temp = grafo[currrent][i];
                    if (!marcados[temp])
                    {
                        marcados[temp] = true;
                        pi[temp] = currrent;
                        if (conjuntos[currrent] == 'a')
                        {
                            if (!TieneArista(grafo, temp, 'b'))
                                conjuntos[temp] = 'b';
                            else
                                return false;
                        }
                        if (conjuntos[currrent] == 'b')
                        {
                            if (!TieneArista(grafo, temp, 'a'))
                                conjuntos[temp] = 'a';
                            else
                                return false;
                        }
                        cola.Enqueue(temp);
                    }
                }
            }
            return true;
        }

        static bool TieneArista(List<int>[] grafo, int vertice, char c)
        {
            for (int i = 0; i < grafo[vertice].Count; i++)
            {
                if (conjuntos[grafo[vertice][i]] == c)
                    return true;
            }
            return false;
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
                int a = int.Parse(linea[0]) - 1;
                int b = int.Parse(linea[1]) - 1;

                grafo[a].Add(b);
                grafo[b].Add(a);
            }

            if (BFS(grafo))
            {
                Console.WriteLine("True");
                for (int i = 0; i < conjuntos.Length; i++)
                {
                    if(conjuntos[i] == 'a')
                        Console.Write("{0} ", 0);
                    else
                        Console.Write("{0} ", 1);
                }
                Console.WriteLine();
            }
            else
                Console.WriteLine("False");
        }
    }
}
