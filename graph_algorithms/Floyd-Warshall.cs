using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floyd_Warshall
{
    class Program
    {
        public static int[,] d;
        public static int[,] pi;

        public static void Inicializar(int[,] costo)
        {
            d = new int[costo.GetLength(0), costo.GetLength(1)];
            pi = new int[costo.GetLength(0), costo.GetLength(1)];

            for (int i = 0; i < costo.GetLength(0); i++)
            {
                for (int j = 0; j < costo.GetLength(1); j++)
                {
                    if (costo[i, j] >= 0)
                        d[i, j] = costo[i, j];
                    else
                        d[i, j] = 100000;
                }
            }

            for (int i = 0; i < d.GetLength(0); i++)
            {
                d[i, i] = 0;
            }
        }

        public static void Floyd_Warshall(int[,] costo)
        {
            Inicializar(costo);

            for (int k = 0; k < costo.GetLength(0); k++)
            {
                for (int i = 0; i < costo.GetLength(0); i++)
                {
                    for (int j = 0; j < costo.GetLength(1); j++)
                    {
                        if (d[i, j] > d[i, k] + d[k, j])
                            d[i, j] = d[i, k] + d[k, j];
                    }
                }
            }
        }

        public static void Imprimir<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int[,] costo =
            {
                {  0, 8,  5 },
                {  3, 0, -1 },
                { -1, 2,  0 }
            };

            Floyd_Warshall(costo);

            Imprimir(d);
        }
    }
}
