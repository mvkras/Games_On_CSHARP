﻿using System;
using System.IO;
using System.Security.Cryptography;

namespace E_Gallows
{
    class Program  //Виселица
    {
        static void Main(string[] args)
        {
            
        }
        /* Старая добрая игра "Виселица" (с недобрым названием).

           Смысл игры:
           Компьютер загадывает любое слово, взятое из словаря (ссылка на словарь прилагается). 
           Человек пытается, называя буквы, угадать слово. 
           Если буква есть в слове, компьютер вскрывает отгаданные буквы. 
           Неотгаданные буквы не вскрываются, а выводятся, например, прочерки (дефисы). 
           Есть ограниченное кол-во попыток (по умолчанию, максимум 6). 
           Если попытки исчерпаны - человек проиграл, 
           игра завершается и показывается загаданное слово и кол-во ошибок допущенных игроком.
 
           Рисовать виселицу в консоли необязательно. Если есть желание - это сделать можно (но огребёте головной боли).

           Ссылка на словарь: https://1drv.ms/t/s!AqtQeAOHZEjQuKEXnwI-VtMds9wAug?e=bGvrIR */



//******************************************************************************************************************************      

        
        static void BubbleSearch() //сортировка пузырьком
        {
            int[] index = { 1, 0, 5, 3, 9, 7, 15, 15, -15, -5, 12, 23 };
            int temp;
            for (int i = 0; i < index.Length-1; i++)
            {
                for (int j = i+1; j < index.Length; j++)
                {
                    if (index[i] > index[j])
                    {
                        temp = index[i];
                        index[i] = index[j];
                        index[j] = temp;
                    }
                }
            }
            foreach (var item in index)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
