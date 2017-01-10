using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            Console.WriteLine("Введите Количество элементов массива");
            while (!int.TryParse(Console.ReadLine(), out N))
                Console.WriteLine("Введите ЧИСЛО");

            int[] arr = new int[N];
            Random rand = new Random();
            
            #region генератор
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < i; j++) 
                    while(arr[i] == arr[j] || arr[i] == 0)
                    {
                        arr[i] = rand.Next(-100, 100);
                        j = 0;
                    }

            }
            #endregion

            foreach (int x in arr)
                Console.Write(" {0} ", x);
            Console.WriteLine();

            #region подсчёт смены знаков
            int signChangeCount = 0;
            for (int i = 0; i < N - 1; i++)
                if (Math.Sign(arr[i]) != Math.Sign(arr[i + 1]))
                    signChangeCount++;
            #endregion

            Console.WriteLine();
            Console.WriteLine(" Знак меняется {0} раза", signChangeCount);

            #region переписка
            int[] mas = new int[N];
            {
                int k = N - 1;
                int j = 0;
                for (int i = 0; i < N; i++)
                    if (arr[i] < 0)
                    {
                        mas[j] = arr[i];
                        j++;
                    }
                    else
                    {
                        mas[k] = arr[i];
                        k--;
                    }
            }
            #endregion

            Console.WriteLine();
            foreach (int x in mas)
                Console.Write(" {0} ", x);
            Console.WriteLine();

            #region Задача 3
            int[] days = new int[365];
            int[] winds = new int[8] { 0,0,0,0,0,0,0,0};

            for (int i = 0; i < 365; i++)
            {
                days[i] = rand.Next(0,8);
                winds[days[i]]++;
            }


            Console.WriteLine();
            foreach (int x in winds)
                Console.Write(" {0} ", x);
            Console.WriteLine();
            Console.WriteLine();

            int min = 0;
            for (int i = 0; i < 8; i++)
                if (winds[i] < winds[min])
                    min = i;

            string rc = string.Empty;
            switch (min)
            {
                case 0:
                    rc = "Северная сторона";
                    break;
                case 1:
                    rc = "Южная сторона";
                    break;
                case 2:
                    rc = "Восточная сторона";
                    break;
                case 3:
                    rc = "Западная сторона";
                    break;
                case 4:
                    rc = "Северо-западная сторона";
                    break;
                case 5:
                    rc = "Северо-восточная сторона";
                    break;
                case 6:
                    rc = "Юго-западная сторона";
                    break;
                case 7:
                    rc = "Юго-восточная сторона";
                    break;
            }

            Console.WriteLine(rc);
            #endregion





            Console.ReadKey(true);
        }
    }
}
