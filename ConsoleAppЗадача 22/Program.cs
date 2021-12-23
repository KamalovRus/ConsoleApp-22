using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Task22
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int length = int.Parse(Console.ReadLine());
            int[] arr = new int[length];
            //заполняем массив случайными числами
            for (int i = 0; i < length; i++)
            {
                arr[i] = r.Next(0, 101);
            }

            Task<int> task = new Task<int>(() => ArraySum(arr));

            Task task2 = task.ContinueWith(sum => Display(sum.Result));

            Task<int> task3 = task2.ContinueWith((el) => ArrayBiggestEl(arr));

            Task task4 = task3.ContinueWith(el => DisplayElem(el.Result));

            task.Start();
            // ждем окончания 4 задачи
            task4.Wait();
        }
        static int ArraySum(int[] arr)
        {
            int sum = 0;
            foreach (var number in arr)
            {
                sum += number;
            }
            return sum;
        }
        static int ArrayBiggestEl(int[] arr)
        {
            int el = 0;
            foreach (var number in arr)
            {
                if (number > el)
                {
                    el = number;
                }
            }
            return el;
        }
        static void Display(int sum)
        {
            Console.WriteLine($"Сумма: {sum}");
        }
        static void DisplayElem(int el)
        {
            Console.WriteLine($"Наибольший элемент: {el}");
        }
    }
}
