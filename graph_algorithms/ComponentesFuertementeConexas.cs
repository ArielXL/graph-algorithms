using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentesFuertementeConexas
{
    class Program
    {
        static bool[] visitados;
        static Stack<int> pila;
        static int[] pi;
        static int[] fuertementeConexas;

        static void DFS(List<int>[] grafo)
        {
            visitados = new bool[grafo.Length];
            pila = new Stack<int>();

            for (int i = 0; i < grafo.Length; i++)
            {
                if (!visitados[i])
                    DFSVisit(grafo, i);
            }
        }

        static void DFSVisit(List<int>[] grafo, int elemento)
        {
            visitados[elemento] = true;

            for (int i = 0; i < grafo[elemento].Count; i++)
            {
                int temp = grafo[elemento][i];
                if (!visitados[temp])
                    DFSVisit(grafo, temp);
            }

            pila.Push(elemento);
        }

        static int DFS_Transpuesto(List<int>[] grafo)
        {
            visitados = new bool[grafo.Length];
            int cantidadComponentesFuertementeConexas = 1;
            pi = new int[grafo.Length];
            fuertementeConexas = new int[grafo.Length];

            while (pila.Count > 0)
            {
                int temp = pila.Pop();

                if (!visitados[temp])
                {
                    pi[temp] = int.MinValue;
                    DFS_Visit_Transpuesto(grafo, temp, cantidadComponentesFuertementeConexas);
                    cantidadComponentesFuertementeConexas++;
                }
            }

            return cantidadComponentesFuertementeConexas - 1;
        }

        static void DFS_Visit_Transpuesto(List<int>[] grafo, int elemento, int cantidadComponentesFuertementeConexas)
        {
            visitados[elemento] = true;

            for (int i = 0; i < grafo[elemento].Count; i++)
            {
                int temp = grafo[elemento][i];

                if (!visitados[temp])
                {
                    pi[temp] = elemento;
                    DFS_Visit_Transpuesto(grafo, temp, cantidadComponentesFuertementeConexas);
                }
            }

            fuertementeConexas[elemento] = cantidadComponentesFuertementeConexas;
        }

        static List<int>[] Transpuesta(List<int>[] grafo)
        {
            List<int>[] grafoTranspuesta = new List<int>[grafo.Length];

            for (int i = 0; i < grafoTranspuesta.Length; i++)
            {
                grafoTranspuesta[i] = new List<int>();
            }

            for (int i = 0; i < grafo.Length; i++)
            {
                for (int j = 0; j < grafo[i].Count; j++)
                {
                    int temp = grafo[i][j];
                    grafoTranspuesta[temp].Add(i);
                }
            }

            return grafoTranspuesta;
        }

        static int ComponentesFuertementeConexas(List<int>[] grafo)
        {
            DFS(grafo);
            List<int>[] grafoTranspuesta = Transpuesta(grafo);

            return DFS_Transpuesto(grafoTranspuesta);
        }

        static List<int>[] GrafoReducido(List<int>[] grafo, int cantidadComponentesFuertementeConexas)
        {
            List<int>[] grafoReducido = new List<int>[cantidadComponentesFuertementeConexas];

            for (int i = 0; i < cantidadComponentesFuertementeConexas; i++)
            {
                grafoReducido[i] = new List<int>();
            }

            for (int i = 0; i < grafo.Length; i++)
            {
                for (int j = 0; j < grafo[i].Count; j++)
                {
                    int temp = grafo[i][j];

                    if (fuertementeConexas[i] != fuertementeConexas[temp])
                    {
                        if (grafoReducido[fuertementeConexas[i] - 1].Count == 0)
                            grafoReducido[fuertementeConexas[i] - 1].Add(fuertementeConexas[temp] - 1);
                        else
                        {
                            if (!grafoReducido[fuertementeConexas[i] - 1].Contains(fuertementeConexas[temp] - 1))
                                grafoReducido[fuertementeConexas[i] - 1].Add(fuertementeConexas[temp] - 1);
                        }
                    }
                }
            }

            return grafoReducido;
        }

        static void ImprimeGrafo(List<int>[] grafo)
        {
            for (int i = 0; i < grafo.Length; i++)
            {
                for (int j = 0; j < grafo[i].Count; j++)
                {
                    int temp = grafo[i][j];
                    Console.WriteLine("{0} {1}", i + 1, temp + 1);
                }
            }
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
            }

            // ImprimeGrafo(grafo);

            int cantidadComponentesFuertementeConexas = ComponentesFuertementeConexas(grafo);
            Console.WriteLine(cantidadComponentesFuertementeConexas);

            List<int>[] grafoReducido = GrafoReducido(grafo, cantidadComponentesFuertementeConexas);
            ImprimeGrafo(grafoReducido);
        }
    }
}
