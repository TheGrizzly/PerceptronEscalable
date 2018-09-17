using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron_Escalable
{
    class Program
    {
        static double[][] setTable()
        {
            double[][] Array = new double[][]
            {
                /*new double[] {0,0,0,0},
                new double[] {0,0,1,0},
                new double[] {0,1,0,0},
                new double[] {1,0,0,1},
                new double[] {0,1,1,1},
                new double[] {1,0,1,1},
                new double[] {1,1,0,1},
                new double[] {1,1,1,1}*/
    /*1*/       new double[] { 1,1,1,0,1,1,1,1,0,1,0,0,1},
    /*2*/       new double[] { 1,1,1,0,1,1,0,1,0,0,1,0,1},
    /*3*/       new double[] { 1,0,0,0,1,1,0,0,0,1,0,0,0},
    /*4*/       new double[] { 1,1,0,0,1,1,1,0,1,1,1,1,1},
    /*5*/       new double[] { 1,0,0,0,0,1,0,0,1,0,1,1,0},
    /*6*/       new double[] { 1,0,0,0,1,1,0,0,0,1,0,0,0},
    /*7*/       new double[] { 1,0,0,0,0,1,1,0,0,1,0,0,0},
    /*8*/       new double[] { 1,1,0,0,1,1,1,0,0,1,1,0,1},
                new double[] { 0,0,0,0,0,0,0,0,1,1,0,0,0},
                new double[] { 1,1,0,0,1,1,1,1,0,1,1,0,1},
                new double[] { 0,0,0,1,1,1,0,0,0,0,0,0,1},
                new double[] { 1,0,0,0,1,1,1,0,0,0,0,1,1},
                new double[] { 0,0,0,1,1,1,1,0,0,0,0,0,1},
                new double[] { 1,1,1,1,0,1,1,1,0,0,0,0,1},
                new double[] { 1,1,1,0,0,1,1,0,0,1,1,0,1},
                new double[] { 0,0,0,0,0,1,1,0,0,1,0,0,0},
                new double[] { 1,0,0,0,0,1,0,0,1,1,0,0,0},
                new double[] { 1,1,0,0,1,1,1,0,0,1,0,0,1},
                new double[] { 1,0,0,0,1,1,1,0,0,1,0,0,1},
                new double[] { 0,0,0,0,0,0,0,0,0,1,0,0,0},
                new double[] { 1,1,0,0,1,1,1,0,0,1,1,0,1},
                new double[] { 1,1,1,0,1,1,1,0,0,0,0,1,1},
                new double[] { 0,0,0,0,0,0,0,0,1,1,0,0,0},
                new double[] { 1,0,0,0,1,1,1,0,1,1,0,0,0},
                new double[] { 1,1,0,0,1,1,0,0,0,1,1,0,1},
                new double[] { 1,0,0,0,0,0,0,0,0,1,0,0,0},
                new double[] { 0,0,0,0,0,1,0,0,0,1,0,0,0},
                new double[] { 1,1,1,0,1,1,0,1,1,0,1,1,1},
                new double[] { 0,0,0,0,1,1,0,0,1,1,0,1,0},
                new double[] { 0,1,1,0,0,1,1,0,1,0,1,1,1},
                new double[] { 1,1,0,0,1,1,0,0,1,0,1,1,1},
                new double[] { 0,0,1,0,0,0,1,0,1,0,1,1,0}

            };

            return Array;
        }


        static void Main(string[] args)
        {
            long counter = 0;
            double b = 1;
            bool solved = false;
            Random rnd = new Random();
            double[][] table;
            List<double> weights = new List<double>();
            int rows, columns;
            double learningFactor = 0.5;
            table = setTable();
            rows = table.Count();
            columns = table[0].Count();
            for(int i=0; i<columns-1; i++)
            {
                weights.Add(rnd.Next(-100, 100));
            }
            while (!solved)
            {
                for(int i = 0; i<rows; i++)
                {
                    double temp = 0;
                    for(int j = 0; j < columns-1; j++)
                    {
                        temp += table[i][j] * weights[j];
                    }
                    temp += b;
                    if(table[i][columns-1] == 1)
                    {
                        if (temp <= 0)
                        {
                            for (int j = 0; j < weights.Count(); j++)
                            {
                                weights[j] = weights[j] + (1 * table[i][j] * learningFactor);
                            }
                            b = b + (1 * learningFactor);
                            counter++;
                            break;
                        }
                    }else
                    {
                        if (temp > 0)
                        {
                            for (int j = 0; j < weights.Count(); j++)
                            {
                                weights[j] = weights[j] + (-1 * table[i][j] * learningFactor);
                            }
                            b = b + (-1 * learningFactor);
                            counter++;
                            break;
                        }
                    }
                    if(i== rows - 1)
                    {
                        solved = true;
                    }
                }
            }
            Console.WriteLine("Estos son los pesos usados:");
            for(int i = 0; i< weights.Count(); i++)
            {
                Console.WriteLine("El peso " + i + " es: " + weights[i]);
            }
            Console.WriteLine("El bias es: " + b);
            Console.WriteLine("El numero de iteraciones fue: " + counter);
            Console.ReadLine();
        }
    }
}
