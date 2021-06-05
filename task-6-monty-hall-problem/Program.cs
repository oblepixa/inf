using System;
using System.Linq;

namespace task_6_monty_hall_problem
{
    class Program
    {
        static bool[] door = new bool[3];
        static Random rnd = new Random();
        static void Main(string[] args)
        {
           
            
            
            //int value = rnd.Next(0, 3);      
            //door[value] = true;
            Alisa();
            Bob();
        }
        static void Alisa()
        {
            double vivod;
            int res;
            int score = 0;
            int choice1;
            int choice2;
            choice1 = 0;
            choice2 = choice1;
           for(int n = 0; n < 1001; n++)
           {
                door[0] = false;
                door[1] = false; 
                door[2] = false;
                int value = rnd.Next(0, 3);
                door[value] = true;
                res = game1(choice1);
                score = score + game2(choice2);
           }
            vivod = (double) score / 10;
           Console.WriteLine("Процент побед Алисы: " + vivod + "%");
        }
        static void Bob()
        {
            double vivod;
            int score = 0;
            int bobmo = -1;
            int choice1;
            int choice2;
            choice1 = 0;           
            for (int n = 0; n < 1000; n++)
            {
                door[0] = false;
                door[1] = false;
                door[2] = false;
                int value = rnd.Next(0, 3);
                door[value] = true;
                bobmo = game1(choice1);
                if (bobmo == 1)
                {
                    choice2 = 2;
                }
                else
                {
                    choice2 = 1;
                }
                score = score + game2(choice2);

            }
            vivod = (double) score / 10;
            Console.WriteLine("Процент побед Боба: " + vivod + "%") ;
        }
        private static int game1(int choice1)
        {
            int i;
            int mo = -1;
            if (door[choice1])
            {
                var _rand = new System.Random();
                mo = RandomFromRangeWithExceptions(0, 3, choice1);
            }
            else
            {
                for (i = 0; i < 3; i++)
                {
                    if ((i != choice1) && (!door[i]))
                    {
                        mo = i;
                    }
                }
            }
                return mo;
        }
        private static int game2(int choice2)
        {
            if (door[choice2])
            {
                return 1; 
            }
            else
            {
                return 0;
            }
        }

        private static int RandomFromRangeWithExceptions(int rangeMin, int rangeMax, params int[] exclude)
        {
            var range = Enumerable.Range(rangeMin, rangeMax).Where(i => !exclude.Contains(i));

            int index = rnd.Next(rangeMin, rangeMax - exclude.Count());
            return range.ElementAt(index);
        }


    }
}
