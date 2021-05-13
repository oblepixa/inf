using System;
namespace task_5_golden_section
{
    class Program
    {
        static void Main(string[] args)
        {
            double A = Math.E, B = -1, a = -3, b = 3, eps = 0.000001;
            double fi = (1 + Math.Sqrt(5)) / 2;
            double c;
            double x;
            Console.WriteLine("Поиск точки экстремума будет осуществляться на отрезке[-3; 3]");
            while (b - a > eps)
            {
                c = a + (b - a) / fi;
                x = (a + b - c);
                if (c > x)
                {
                    if ((Math.Pow(A, c)) - B * c > (Math.Pow(A, x)) - B * x)
                    {
                        b = c;
                    }
                    else
                    {
                        a = x;
                    }
                }
                else
                {
                    if (c < (Math.Pow(A, c)) - B * c)
                    {
                        a = c;
                    }
                    else
                    {
                        b = x;
                    }

                }
                Console.WriteLine("Начало отрезка: " + a);
                Console.WriteLine("Конец отрезка: " + b);
                Console.WriteLine("Точка экстремума: " + x);
            }

               
            

        }
    }
}

