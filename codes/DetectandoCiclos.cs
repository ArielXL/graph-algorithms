using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DetectandoCiclos
{
    class Program
    {
        //colores
        //0 - sin visitar
        //1 - analizando
        //2 - ya visitado

        public static int[] color;
        public static int[] pi;
        public static List<int> ciclo;
        static bool ya;

        static void DetectandoCiclos_DFS(List<int>[] grafo)
        {
            ya = false;
            color = new int[grafo.Length];
            pi = new int[grafo.Length];
            ciclo = new List<int>();

            for (int i = 0; i < grafo.Length; i++)
            {
                if (color[i] == 0)
                {
                    pi[i] = -1;
                    DFS_Visit(grafo, i);
                    if (ya)
                    {
                        ciclo.Add(i + 1);
                        break;
                    }
                }
            }
        }

        static void DFS_Visit(List<int>[] grafo, int vertice)
        {
            color[vertice] = 1;

            for (int i = 0; i < grafo[vertice].Count; i++)
            {
                if (color[grafo[vertice][i]] == 1)
                {
                    ya = true;
                    return;
                }
                else if (color[grafo[vertice][i]] == 0)
                {
                    pi[grafo[vertice][i]] = vertice;
                    DFS_Visit(grafo, grafo[vertice][i]);
                    ciclo.Add(grafo[vertice][i] + 1);
                    if (ya) 
                        return;
                }

            }
            color[vertice] = 2;
        }

        static void Main(string[] args)
        {
            string[] linea = Console.ReadLine().Split();
            int vertices = int.Parse(linea[0]);
            int aristas = int.Parse(linea[1]);

            List<int>[] grafo = new List<int>[vertices];
            
            for (int i = 0; i < vertices; i++)
            {
                grafo[i] = new List<int>();
            }

            for (int i = 0; i < aristas; i++)
            {
                linea = Console.ReadLine().Split();
                int a = int.Parse(linea[0]) - 1;
                int b = int.Parse(linea[1]) - 1;

                grafo[a].Add(b);
            }

            DetectandoCiclos_DFS(grafo);

            if (!ya)
                Console.WriteLine(-1);
            else
            {
                Console.WriteLine(ciclo.Count);
                ciclo.Reverse();
                for (int i = 0; i < ciclo.Count; i++)
                {
                    Console.Write("{0} ", ciclo[i]);
                }
                Console.WriteLine();
            }
        }
    }
}