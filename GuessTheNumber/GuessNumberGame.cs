using System;
using System.Collections.Generic;
using System.Text;

namespace A_GuessTheNumber
{
    enum GuessingPlayer //выбираем, кто будет играть
    {
        Human,
        Computer
    }
    class GuessNumberGame
    {      
        private readonly int max;
        private readonly int maxTries;
        private readonly GuessingPlayer guessingPlayer;
        //создаем конструктор с полями:
        public GuessNumberGame(int max = 100, int maxTries = 7, GuessingPlayer guessingPlayer = GuessingPlayer.Human)
        {
            this.max = max;
            this.maxTries = maxTries;
            this.guessingPlayer = guessingPlayer;
        }
        public void Start() //Метод для запуска игры
        {
            if(guessingPlayer == GuessingPlayer.Human)
            {
                HumanGuesses(); //если выбран человек, человек отгадывет
            }
            else
            {
                ComputerGuesses(); //если выбран компьютер, комп отгадывет
            }
        }

//--------------------------------------------------Логика для человека---------------------------------------------------------------------
        private void HumanGuesses() //логика когда отгадывает человек
        {
            //Сперва компьютер должен загодать число
            Random rand = new Random();
            int guessNumber = rand.Next(0, max); //Загаданное число в пределах от 0 до 100            
           
            int lastGuess = -1; // Заведем крайняя попытка(последнее введеное число пользователем)  по умолчанию равен -1          
            int tries = 1; //заведем счетчик
            Console.WriteLine("Правила: Угадайте число от 0 до 100, у вас есть 6 попыток!");
            Console.WriteLine("Введите число от 0 до 100:");
            
            
                //Игра будет идти до тех пор, пока пользователь не угадал число, либо не исчерпано количество попыток          
                while (lastGuess != guessNumber && tries < maxTries)
                {
                    string str = Console.ReadLine();
                    bool result = int.TryParse(str, out lastGuess);
                  if (result)
                  {
                    if (lastGuess == guessNumber)
                    {
                        Console.WriteLine($"Верно, вы угадали! это число: {guessNumber}.");
                        break;
                    }
                    else if (lastGuess < guessNumber)
                    {
                        Console.WriteLine($"Мало! Твое число меньше, загаданного! Попытка: {tries}.");
                    }
                    else
                    {
                        Console.WriteLine($"Перебор! Твои число больше загаданного! Попытка: {tries}.");
                    }
                    tries++; //Количество попыток увеличивается с каждым ходом, достигнет 6, игра окончена
                    if (tries == maxTries)
                    {
                        Console.WriteLine("Game Over! Ты не отгадал за 6 попыток!");
                        break;
                    }
                  }
                    else
                    {
                        Console.WriteLine("Вы ввели не число, попробуйте еще раз.");
                    }
            
                }
           
           
        }
//----------------------------------------------------Логика для компьютера------------------------------------------------------------------

        private void ComputerGuesses() //логика, когда отгадывает компьютер
        {
            //Когда машина угадывает, реализуем логику бинарного поиска числа, т.к. это наиболее эффективная стратегия (сечение на пополам)
            /*Первое число, которое надо загадать = 50, так как 100/2 = 50. 
             * Если пользователь загадал большее число, то число находится между 50 и 100, выбираем среднее — 75. 
             * Если меньше, то диапазон от 50 до 75. 
             * Выбираем среднее. Каждый раз, при каждом угадывании сокращаем диапазон поиска на 2. 
             */
            Console.WriteLine("Задайте число");
            int guessNumber = -1;
            //Пока пользователь не введет число в указанном диапазоне, будет цикл, который будет просить ввести число от 0 до 100
            
            while (guessNumber == -1)
            {
                string str = Console.ReadLine();
                bool result = int.TryParse(str, out int parsedNumber);
                if (result)
                {
                    if(parsedNumber >0 && parsedNumber <= this.max)
                    {
                        guessNumber = parsedNumber;  //Указанное значение будет принадлежать загаданному числу
                    }
                }
            }

            //Прописываем компьютерную логику поиска числа:
            int lastGuess = -1; //Последняя указанное число (по умолчанию -1)
            int min = 0;  //нижняя гранца диапазона
            int max = this.max; //верхняя граница
            //Так как мы будем использовать бинарный поиск - эти границы будут сдвигаться
            int tries = 0; //количество попыток

            //Запускаем точно такой же цикл
            while (lastGuess != guessNumber && tries < maxTries)
            {
                //необходимо брать серединное значение, то есть каждый раз диапазон делить на 2
                lastGuess = (max + min) / 2; //будет изначально браться 50
                Console.WriteLine($"Вы загадали это число? {lastGuess}");
                Console.WriteLine("Если да, напишите 'yes'");
                Console.WriteLine("Если число компьютера меньше вашего, напишите 'b' (bigger)");
                Console.WriteLine("Если число компьютера больше вашего, напишите 'l'(less/lower)");
                string answer = Console.ReadLine(); 
                if(answer == "yes")
                {
                    Console.WriteLine($"Компьютер отгадал ваше число! оно было: {guessNumber}");
                    break;
                }
                else if(answer == "b")
                {
                    //сдвигаем нижнюю границу диапазона
                    min = lastGuess;
                }
                else
                {
                    max = lastGuess;
                }
                
                if(lastGuess == guessNumber) //Если игрок захочет обмануть компьютер, компьютер явно сравнит свое и число игрока
                {
                    Console.WriteLine("Не пытайся обмануть компьютер! Число компьютера равно твоему! Машины выйграли!");
                }
                tries++;
                if(tries == maxTries)
                {
                    Console.WriteLine("Game Over. Компьютер проиграл");
                }
            }

        }
    }
}
