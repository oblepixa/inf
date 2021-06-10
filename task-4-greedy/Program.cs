using System;

namespace Mis
{
	class Program
	{
		public static void Main(string[] args)
		{

			int k, n;

			Console.WriteLine("Введите колличество песен k");
			k = Convert.ToInt32(Console.ReadLine());
			int[] nums = new int[k];
			Console.WriteLine("Введите длительность каждой песни в секундах");
			for (int i = 0; i < k; i++)
			{
				nums[i] = Convert.ToInt32(Console.ReadLine());
			}
			Console.WriteLine("Введите размер дисков в минутах n");
			n = Convert.ToInt32(Console.ReadLine());
			n = n * 60;
			int[] ostat = { n };

			int q = 1;
			int j = 0;
			bool f;
			for (int i = 0; i < k; i++)							// пробегаемся по всем песням
			{
				f = false;
				if (nums[i] <= n)								// песня меньше размера дисков
				{
					for (j = 0; j < q; j++)						// пробегаемся по всем остатками
					{

						if ((nums[i] <= ostat[j]))				// песня влезает на диск j
						{
							ostat[j] -= nums[i];
							Console.WriteLine(i + 1 + " песня записана на диск " + (j + 1));
							f = true; j = q + 1;
						}
					}
					if (f == false)
					{											// нужен новый диск
                        Insert(ref ostat, n, q);
						ostat[q] -= nums[i];
						Console.WriteLine(i + 1 + " песня записана на диск " + (q + 1));
						q++;
						f = true;
					}
				}
			}
			Console.WriteLine("колличество дисков = " + q);
			Console.ReadLine();
		}
		static void Insert(ref int[] array, int value, int index) // метод для добавления в массив 
		{
			int[] newArray = new int[array.Length + 1];

			newArray[index] = value;

			for (int i = 0; i < index; i++)
				newArray[i] = array[i];
			for (int i = index; i < array.Length; i++)
				newArray[i + 1] = array[i];
			array = newArray;
		}
	}
}