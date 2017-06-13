using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Sys
    {
        public double[,] matrix;

        public double[] xxx;

        public Sys()
        {
            matrix = new double[3, 4];
            xxx = new double[3];
        }

        public override string ToString()
        {
            return matrix.ToString() + " Решение " + xxx.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double kof;
            Sys a = new Sys();

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 4; j++)
                    a.matrix[i, j] = double.Parse(Console.ReadLine());

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                    Console.Write(a.matrix[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int k = 0; k < 2; k++)
                for (int i = k + 1; i < 3; i++)
                    if (a.matrix[i, k] != 0)
                    {
                        kof = -a.matrix[k, k] / a.matrix[i, k];
                        for (int j = 0; j < 4; j++)
                            a.matrix[i, j] = a.matrix[k, j] + a.matrix[i, j] * kof;
                    }
                    else Console.WriteLine("Система не решаема");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                    Console.Write("{0:0.000} ", a.matrix[i,j]);
                Console.WriteLine();
            }

            a.xxx[2] = a.matrix[2, 3] / a.matrix[2, 2];
            a.xxx[1] = (a.matrix[1, 3] - a.xxx[2] * a.matrix[1, 2]) / a.matrix[1, 1];
            a.xxx[0] = (a.matrix[0, 3] - a.xxx[2] * a.matrix[0, 2] - a.xxx[1]* a.matrix[0,1]) / a.matrix[0, 0];

            foreach (double x in a.xxx)
                Console.WriteLine(x);

            Console.ReadLine();
        }
    }
}
