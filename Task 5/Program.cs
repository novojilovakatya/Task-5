using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
{
    class Program
    {
        /// <summary>
        /// Проверка ввода натуральных чисел
        /// </summary>
        /// <returns>Натуральное число</returns>
        public static int ReadPositive()
        {
            int k = 0; bool ok;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out k);
                if (!ok || k <= 0) Console.WriteLine("Неправильный ввод. Ожидалось натуральное число. Пожалуйста, повторите ввод");
            }
            while (!ok || k <= 0);
            return k;
        }


        static void Main(string[] args)
        {
            // Вводим значение N
            Console.WriteLine("Введите размерность матрицы");
            int N = ReadPositive();
            int[,] matrix = new int[N, N];      // Матрица n-ого порядка 
            char[] ch = { ' ' };
            // Считываем значение матрицы по строкам и запоминаем (с проверкой ввода)
            for (int i = 0; i < N; i++)
            {
                bool ok = false;
                Console.WriteLine("Введите строку матрицы через пробел");
                do
                {
                    string[] str = Console.ReadLine().Split(ch, StringSplitOptions.RemoveEmptyEntries);
                    if (str.Length >= N)
                        for (int j = 0; j < N; j++)
                        {
                            ok = int.TryParse(str[j], out matrix[i, j]);
                            if (!ok)
                            {
                                Console.WriteLine("Ошибка ввода. Введите строку заново");
                                break;
                            }
                        }
                    else Console.WriteLine("Недостаточно элементов");
                } while (!ok);
            }

            // Составляем ряд минимальных элементов
            int[] b = new int[N];
            b[0] = 1;               // В 1ой строке нет элементов до главной диагонали
            // Последовательно находим минимальные элементы
            for (int i = 1; i < N; i++)
            {
                int min = matrix[i, 0];
                for (int j = 1; j < i; j++)
                    if (matrix[i, j] < min) min = matrix[i, j];
                b[i] = min;
            }
            // Ввывод последовательности
            Console.WriteLine("Полученный ряд:");
            for (int i = 0; i < N; i++)
                Console.Write("{0} ", b[i]);
            Console.ReadLine();
        }
    }
}
