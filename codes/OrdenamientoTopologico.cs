using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrednamientoTopologico
{
    class Program
    {
        static int[] ordenTopologico;

        static bool OrdenTopologico(List<int>[] grafo, int[] indegree)
        {
            ordenTopologico = new int[grafo.Length];
            int cont = 0;

            for (int i = 0; i < indegree.Length; i++)
            {
                if (indegree[i] == 0)
                {
                    ordenTopologico[cont] = i;
                    cont++;
                    indegree[i]--;
                    for (int j = 0; j < grafo[i].Count; j++)
                    {
                        indegree[grafo[i][j]]--;
                    }
                    i = -1;
                }
            }

            if (cont == grafo.Length)
                return true;
            else
                return false;
        }

        static void Main(string[] args)
        {
            string[] linea = Console.ReadLine().Split();
            int vertices = int.Parse(linea[0]);
            int aristas = int.Parse(linea[1]);

            List<int>[] grafo = new List<int>[vertices];
            int[] indegree = new int[vertices];

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
                indegree[b] += 1;
            }

            if (OrdenTopologico(grafo, indegree))
            {
                Console.WriteLine("True");
                for (int i = 0; i < ordenTopologico.Length; i++)
                {
                    Console.Write("{0} ", ordenTopologico[i] + 1);
                }
                Console.WriteLine();
            }
            else
                Console.WriteLine("False");
        }
    }
}
