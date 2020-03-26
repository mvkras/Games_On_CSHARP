using System;

namespace D_Believe_Or_Not
{
    class Program
    {
        private const int MaxMistakes = 2;

        static void Main(string[] args)
        {
            //построим клиента создадим экземпляр игры
            BelieveOrNot_Game game = new BelieveOrNot_Game("Questions.csv");//передали путь к файлу
            //подписываемся на собитые
            game.EndOfGame += (sender, e) => //вместо того, чтобы исп-ть метод, используем лямбду (указываем входящие аргументы)
            {
                //пишем реализацию
                Console.WriteLine($"Вопросы отвечены: {e.questionsPassed}. Сделано ошибок: {e.mistakesMade}");
                Console.WriteLine(e.isWin ? "Ты выиграл" : "Ты проиграл");
            };
            while (game.GameStatus == GameStatus.GameInProgress)
            {
                Question q = game.GetNextQuestion(); //берем вопросы из списка с помощью метода
                Console.WriteLine("Ты веришь в следующее утверждение? Введи 'y' - да, 'n' - нет");
                Console.WriteLine(q.text); //выводим текст

                string answer = Console.ReadLine(); //читаем ответ
                bool boolAnswer = answer == "y"; //значит true
                
                if(q.correctAnswer == boolAnswer) //если это правильный ответ
                {
                    Console.WriteLine("Поздравляем! Ты правильно ответил!");
                }
                else
                {
                    Console.WriteLine("Ты ошибся! Вот пояснение");
                    Console.WriteLine("Пояснение: "+q.explorion); //выводим пояснение
                }
                game.GiveAnswer(boolAnswer); //В конце даем ответ самой логике, чтобы засчитала наш ответ
            }
        }

        
        /* Скачать файл по ссылке: https://1drv.ms/u/s!AqtQeAOHZEjQuKEZv8A5ZbC3cVyiRw?e=UK4qxh

  В файле лежат данные в csv формате. Данные предназначены для игры в "верю-не-верю".
  Смысл игры:
  Комьютер задаёт вопросы или даёт некоторые утверждения человеку, 
  а человек отвечает да\нет или верит он или не верит в утверждение. 
  Компьютер берёт вопросы из файла, правильные ответы и пояснения к ответу тоже. 
  Можете записать свои данные в файл.

  Кол-во ошибок ограничено и по умолчанию равно 2. 
  Компьютер задаёт вопросы из файла и если человек ответил на все вопросы, 
  не допустив более максимально разрешённого кол-ва ошибок, то игрок победил, в противном случае проиграл.

  Если игрок ошибся при ответе, компьютер выводит пояснение к ответу.
  Диалог реализуйте в виде, который сочтёте наиболее приемлимым.*/

    }
}
