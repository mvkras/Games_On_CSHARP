using System;

namespace China_Stacks_V2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            SticksVersion_2 sticksGame = new SticksVersion_2(10, Player.Human); //создали экземпляр
            sticksGame.ComputerPlayed += SticksGame_ComputerPlayed;  //подписываемся на событие
            sticksGame.HumanTurn += SticksGame_HumanTurn;
            sticksGame.EndOfGame += SticksGame_EndOfGame;

            //вызываем Старт
            sticksGame.Start();
        }

        private static void SticksGame_EndOfGame(Player player)
        {
            Console.WriteLine($"Победитель! {player}.");
        }

        private static void SticksGame_HumanTurn(object sender, int sticksLeft) //реализация пользователя
        {
            Console.WriteLine($"Выведите статус: {sticksLeft}");
            Console.WriteLine("Возьмите несколько палок: от 1 до 3");

            bool takenCorrect = false;
            while (!takenCorrect) //запрашиваем кол-во палок, которое хочет взять пользователь
            {
                if(int.TryParse(Console.ReadLine(), out int takenSticks))
                {
                    SticksVersion_2 sticksGame = (SticksVersion_2)sender; //Вытаскиваем экземпляр из sender
                    //Вызываем метод, который позволит взять палки из кучи
                    try //обработаем исключения, которые до этого выкинули
                    {
                        sticksGame.HumanTakesSticks(takenSticks);
                        takenCorrect = true; //чтобы выйти из цикла, ставим true
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message); //выводим сообщение
                    }
                }
            }
        }

        private static void SticksGame_ComputerPlayed(int sticksTaken) //когда сыграла машина
        {
            Console.WriteLine($"Компьютер взял: {sticksTaken}");
        }

        /* Предлагаю древнюю китайскую игру в палочки.
         * Играют два игрока.  Есть 10 палочек (по умолчанию). 
         * Игроки по очереди берут от одной до трёх палочек. 
         * Играют до тех пор пока не закончатся палочки. 
         * Тот кто взял последним - тот проиграл.
         * 
         * Реализуйте игру таким образом, чтобы против человек играл компьютер. 
         * Изначально есть 10 палочек. На каждом ходу выводите на консоль текущее количество оставшихся палочек 
         * и просите ввести количество палочек, которое хочет взять игрок 
         * (который делает ход. машина делает ход автоматически при своей очереди, её просить не надо :)). 
         * Не забывайте менять очерёдность игроков и сокращать кол-во палочек. 
         * В конце надо вывести кто победил - человек или машина.
         * 
         * Нюансы реализации могут отличаться. 
         * Кто-то может захотеть реализовать не с 10-ю палочками, а с тем количеством, 
         * которое введёт пользователь (может он хочет играть с 20-ю палочками?).*/
    }
}
