using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задание 1.
            // Заказчик просит вас написать приложение по учёту финансов
            // и продемонстрировать его работу.
            // Суть задачи в следующем: 
            // Руководство фирмы по 12 месяцам ведет учет расходов и поступлений средств. 
            // За год получены два массива – расходов и поступлений.
            // Определить прибыли по месяцам
            // Количество месяцев с положительной прибылью.
            // Добавить возможность вывода трех худших показателей по месяцам, с худшей прибылью, 
            // если есть несколько месяцев, в некоторых худшая прибыль совпала - вывести их все.
            // Организовать дружелюбный интерфейс взаимодействия и вывода данных на экран

            // Пример
            //       
            // Месяц      Доход, тыс. руб.  Расход, тыс. руб.     Прибыль, тыс. руб.
            //     1              100 000             80 000                 20 000
            //     2              120 000             90 000                 30 000
            //     3               80 000             70 000                 10 000
            //     4               70 000             70 000                      0
            //     5              100 000             80 000                 20 000
            //     6              200 000            120 000                 80 000
            //     7              130 000            140 000                -10 000
            //     8              150 000             65 000                 85 000
            //     9              190 000             90 000                100 000
            //    10              110 000             70 000                 40 000
            //    11              150 000            120 000                 30 000
            //    12              100 000             80 000                 20 000
            // 
            // Худшая прибыль в месяцах: 7, 4, 1, 5, 12
            // Месяцев с положительной прибылью: 10

            Random rnd = new Random();
            int[] dohod = new int[12], rashod = new int[12], pribil = new int[12];
            int min1 = int.MaxValue, min2 = int.MaxValue, min3 = int.MaxValue, plusMonths = 0;

            Console.WriteLine($"{"Месяц",5} {"Доход, руб.",15} {"Расход, руб.",15} {"Прибыль, руб.",15}");

            for (int i = 0; i < dohod.Length; i++)
            {
                dohod[i] = rnd.Next(1, 16) * 10000;
                rashod[i] = rnd.Next(1, 16) * 10000;
                pribil[i] = dohod[i] - rashod[i];
                if (pribil[i] > 0) plusMonths++;
                Console.WriteLine($"{i + 1,5} {dohod[i],15} {rashod[i],15} {pribil[i],15}");
            }

            for (int i = 0; i < pribil.Length; i++)
            {
                for (int j = 0; j < pribil.Length; j++)
                {
                    for (int k = 0; k < pribil.Length; k++)
                    {
                        if (pribil[k] < min1) min1 = pribil[k];
                    }
                    if (pribil[j] < min2 && pribil[j] > min1) min2 = pribil[j];
                }
                if (pribil[i] < min3 && pribil[i] > min1 && pribil[i] > min2) min3 = pribil[i];
            }

            Console.WriteLine($"Месяцев с положительной прибылью: {plusMonths}");
            Console.Write("Худшие месяцы: ");
            for (int i = 0; i < pribil.Length; i++)
            {
                if (pribil[i] == min1 || pribil[i] == min2 || pribil[i] == min3)
                {
                    Console.Write($"{i + 1} ");
                }
            }

            Console.ReadKey();
        }
    }
}
