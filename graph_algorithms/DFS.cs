using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFS
{
    class Program
    {
        public static bool[] visitados;
        public static int[] pi;
        public static int[] componentes_conexas;
        public static int tiempo;
        public static int[] d;
        public static int[] f;

        static void DFS(List<int>[] grafo)
        {
            visitados = new bool[grafo.Length];
            pi = new int[grafo.Length];
            componentes_conexas = new int[grafo.Length];
            d = new int[grafo.Length];
            f = new int[grafo.Length];
            tiempo = 0;
            int cont = 1;

            for (int i = 0; i < grafo.Length; i++)
            {
                if (!visitados[i])
                {
                    pi[i] = int.MinValue;
                    DFS_Visit(grafo, i, cont);
                    cont++;
                }
            }
        }

        static void DFS_Visit(List<int>[] grafo, int elem, int cont)
        {
            visitados[elem] = true;
            tiempo++;
            d[elem] = tiempo;
            for (int i = 0; i < grafo[elem].Count; i++)
            {
                if (!visitados[grafo[elem][i]])
                {
                    pi[grafo[elem][i]] = elem;
                    DFS_Visit(grafo, grafo[elem][i], cont);
                }
            }
            componentes_conexas[elem] = cont;
            tiempo++;
            f[elem] = tiempo;
        }

        static void ImprimeArray()
        {
            for (int i = 0; i < visitados.Length; i++)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
        }

        static void ImprimeArray<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            List<int>[] grafo = new List<int>[]
            {
                new List<int>(){1,2},
                new List<int>(){0,2},
                new List<int>(){0,1,3},
                new List<int>(){2},
                new List<int>(){5},
                new List<int>(){4}   
            };
            
            DFS(grafo);

            ImprimeArray();
            ImprimeArray<bool>(visitados);
            ImprimeArray<int>(pi);
            ImprimeArray<int>(componentes_conexas);
            ImprimeArray<int>(d);
            ImprimeArray<int>(f);
        }
    }
}