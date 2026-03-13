using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr14_1_Kaigorodov
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите значение n: ");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (n <= 0)
                {
                    Console.WriteLine("Число должно быть больше 0");
                    return;
                }
                Stack<int> A = new Stack<int>(n);
                for ( int i = 1; i <= n; i++)
                {
                    A.Push(i);
                }
                Console.WriteLine($"n = {n}");
                Console.WriteLine($"Размерность стека {A.Count}");
                Console.WriteLine($"Верхний элемент стека = {A.Peek()}");
                string st = "";
                for (int i = 0; i < n; i++)
                {
                    st += $"{A.Pop()} ";
                }
                Console.WriteLine($"Содержимое стека = {st}");
                Console.WriteLine($"Новая размерность стека {A.Count}");

            }
            catch (System.FormatException)
            {
                Console.WriteLine("Ошибка неверный тип данных");
            }

            Console.ReadKey();
        }
    }
}
