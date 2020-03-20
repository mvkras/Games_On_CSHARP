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
        public GuessNumberGame(int max = 100, int maxTries = 6, GuessingPlayer guessingPlayer = GuessingPlayer.Human)
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

        private void HumanGuesses() //логика когда отгадывает человек
        {
            //Сперва компьютер должен загодать число
            Random rand = new Random();
            int guessNumber = rand.Next(0, max); //Загаданное число в пределах от 0 до 100            
           
            int lastGuess = -1; // Заведем крайняя попытка(последнее введеное число пользователем)  по умолчанию равен -1          
            int tries = 0; //заведем счетчик
            Console.WriteLine("Правила: Угадайте число от 0 до 100, у вас есть 6 попыток!");
            Console.WriteLine("Введите число от 0 до 100:");
            string str = Console.ReadLine();
            bool result = int.TryParse(str, out lastGuess);
            if(result)
            {
                //Игра будет идти до тех пор, пока пользователь не угадал число, либо не исчерпано количество попыток          
                while (lastGuess != guessNumber && tries < maxTries)
                {
                    if(lastGuess == guessNumber)
                    {
                        Console.WriteLine($"Верно, вы угадали! это число: {guessNumber}.");
                        break;
                    }
                    else if(lastGuess < guessNumber)
                    {
                        Console.WriteLine($"Мало! Твое число меньше, загаданного! Попытка: {tries}.");
                    }
                    else
                    {
                        Console.WriteLine($"Перебор! Твои число больше загаданного! Попытка: {tries}.");
                    }
                    tries++; //Количество попыток увеличивается с каждым ходом, достигнет 6, игра окончена
                    if(tries == maxTries)
                    {
                        Console.WriteLine("Game Over! Ты не отгадал за 6 попыток!");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число, попробуйте еще раз.");
            }
           
        }


        private void ComputerGuesses() //логика, когда отгадывает компьютер
        { 

        }
    }
}
