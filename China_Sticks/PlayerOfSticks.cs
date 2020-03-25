using System;
using System.Collections.Generic;
using System.Text;

namespace China_Sticks
{
    enum WhoPlays_InSticks //выбор, кто первый ходит
    {
        Human,
        Computer
    }
    class PlayerOfSticks
    {
      public int maxSticks { get; private set; } = 10; //максимальное кол-во палочек
      private WhoPlays_InSticks whoPlays;  //перечисление, кто играет
      
        //создаем конструктор
        public PlayerOfSticks(int maxSticks=10, WhoPlays_InSticks whoPlays = WhoPlays_InSticks.Human)
        {
            this.maxSticks = maxSticks;
            this.whoPlays = whoPlays;
        }

        //Метод запуск программы
        public void Start()
        {
            if(whoPlays == WhoPlays_InSticks.Human) //если ходит первым человек
            {
                HumanTakeSticks();
            }
            else
            {
                ComputerTakeSticks(); //если ходит первым компьютер
            }
        }

//------------------------------------------------Реализуем логику для Человека--------------------------------------------------
        public void HumanTakeSticks()
        {
            int turn = 1; //Счетчик ходов
            Console.WriteLine("Возьмите от 1 до 3х палочек");
            
            while (maxSticks >= 0) //цикл пока кол-во палочек больше либо равно 0
            {
                string str = Console.ReadLine(); //ввод чисел от пользователя
                bool result = int.TryParse(str, out int userNumber); //фильтрация ввода
                if (result)
                {
                    if (userNumber == 1 || userNumber == 2 || userNumber == 3 && maxSticks > userNumber) //если игрок ввел 1, 2, 3 игра идет дальше
                    {
                        maxSticks -= userNumber; //кол-во палочек уменьшается
                        Console.WriteLine($"Ход: {turn}, Игрок взял: {userNumber}, Количество палочек осталось: {maxSticks}."); //вывод на экран
                        if(maxSticks == 0)
                        {
                            Console.WriteLine("Игра окончена! Выиграл игрок!");
                        }
                    }
                    else //если ввел неверные значения
                    {
                        Console.WriteLine("Необходимо ввести только числа 1, 2 или 3");                      
                    }               
                }
                else
                {
                    Console.WriteLine("Неверные значения, необходимо ввести число от 1 до 3х");
                }
                Random rand = new Random(); //рандомайзер от компьютера ввод его значений
                int computerTake = rand.Next(1, 3); //компьютер берет от 1 до 3х палочек
                if (maxSticks == 1) //если палочек осталось 1
                {
                    computerTake = rand.Next(1, 1); //компьютер введет только число 1
                }
                else if (maxSticks == 2) //если осталось 2
                {
                    computerTake = rand.Next(1, 2); //комп введет числа 1 или 2
                }
                else if (maxSticks == 3) //если 3
                {
                    computerTake = rand.Next(1, 3); //от 1 до 3х
                }
                else if (maxSticks == 0) //если 0 - игра окончена
                {
                    Console.WriteLine("Игра окончена! Поздравляю! Выиграл компьютер!");
                    break;
                }
                maxSticks -= computerTake; //уменьшениче числа палочек от компьютерных значений

                turn++; //увеличение хода на +1
                Console.WriteLine($"Ход: {turn}, Компьютер взял: {computerTake}, Количество палочек осталось: {maxSticks}."); //вывод информации

            }
           
        }

        //-----------------------------------------------Реализуем логику для Компьютера-------------------------------------------------
        public void ComputerTakeSticks() //Ходит первый компьютер
        {
            int turn = 1;  //счетчик равен 1 изначально
            while (maxSticks >= 0) //пока кол-во палочек не равно 0
            {
                Console.WriteLine("Ходит компьютер:");
                Random rand = new Random(); //рандом для компьютера
                int computerTake = rand.Next(1, 3); //компьютер берет от 1 до 3х палочек
                if (maxSticks == 1) //если палочек осталось 1
                {
                    computerTake = rand.Next(1, 1); //компьютер введет только число 1
                }
                else if (maxSticks == 2) //если 2
                {
                    computerTake = rand.Next(1, 2); //введет от 1 до 2
                }
                else if (maxSticks == 3) //если 3
                {
                    computerTake = rand.Next(1, 3); //число от 1 до 3х 
                }
                else if (maxSticks == 0) //если кол-во палочек равно 0, конец цикла игра окончена
                {
                    Console.WriteLine("Игра окончена! Поздравляю! Выиграл игрок!");
                    break;
                }
                maxSticks -= computerTake;  //уменьшение кол-во палочек у компа     
                Console.WriteLine($"Ход: {turn}, Компьютер взял: {computerTake}, Количество палочек осталось: {maxSticks}.");
                turn++; //следующий ход
                Console.WriteLine("Возьмите от 1 до 3х палочек");
                string str = Console.ReadLine();  //пользователь вводит значения
                bool result = int.TryParse(str, out int userNumber); //проверка входных данных от пользователя
                if (result) //если результат верен
                {
                    if (userNumber == 1 || userNumber == 2 || userNumber == 3 && maxSticks > userNumber)
                    {
                        maxSticks -= userNumber; //кол-во палочек уменьшается
                        Console.WriteLine($"Ход: {turn}, Игрок взял: {userNumber}, Количество палочек осталось: {maxSticks}.");
                        if (maxSticks == 0)
                            {
                            Console.WriteLine("Игра окончена! Поздравляю! Выиграл компьютер!");
                            break;                           
                            }
                       
                        turn++;                       
                    }
                    else
                    {
                        Console.WriteLine("Необходимо ввести только числа 1, 2 или 3");
                    }
                }
                else
                {
                    Console.WriteLine("Неверные значения, необходимо ввести число от 1 до 3х");
                }
                
            }

        }
    }
}
