using D_Believe_Or_Not.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D_Believe_Or_Not
{
    public enum GameStatus
    {
        GameIsOver,
        GameInProgress
    }
    public class BelieveOrNot_Game //здесь реализуется логика игры
    {
        private readonly List<Question> questions;
        private readonly int maxMistakes;
        private int counter; //заводим счетчик. он будет изменяемым, поэтому не будем его делать readonly 
        private int mistakes; //количество ошибок, которое сделал пользователь
        public event EventHandler<GameEventArgs> EndOfGame;
        public GameStatus GameStatus { get; private set; }
        //конструктор. В конструкторах и свойствах запускать длительные операции не принято, но тут можно
        public BelieveOrNot_Game(string filePath, int maxMistakes = 2)//передаем путь к файлу
        {
            //делаем проверку
            if(filePath == null)
            {
                throw new ArgumentNullException("Неверно указан путь filePath");
            }
            //проверка на пустоту
            if(filePath == "")
            {
                throw new ArgumentException("поле пустое");
            }
            //проверяем maxMistakes
            if(maxMistakes < 2)
            {
                throw new ArgumentException("Максимальное кол-во ошибок должно быть больше 2х");
            }
            List<Question> questions = File.ReadAllLines(filePath) //читаем файл. делаем linq запрос
                                                  .Select(x =>  //селект передает строку, нам ее надо отпарсить
                                                  {
                                                     string[] parts = x.Split(';');
                                                     string text = parts[0];
                                                     bool correctAnswer = parts[1] == "Yes"; //если да, то будет записано true
                                                     string exploration = parts[2];

                                                     return new Question(text, correctAnswer, exploration);
                                                  }).ToList();

            //заведем поле
            this.questions = questions;
            this.maxMistakes = maxMistakes;
            GameStatus = GameStatus.GameInProgress;
        }

       

        //так как будем последовательно проходить по коду, можем выкатить метод
        public Question GetNextQuestion()
        {
            //будет возвращать вопрос по некоторому counter счетчику
            return questions[counter];
        }
        //необходимо выкатить метод, который позволяет клиентскому коду ответить на вопрос
        public void GiveAnswer(bool answer)
        {
            if(questions[counter].correctAnswer != answer) //если в текущем вопросе правильный отв не равен ответу
            {
                mistakes++; //значит пользователь ошибся
            }

            //заканчиваем игру если  questions.Count -1  либо кол-во ошибок привышено допустимое значение
            if (counter == questions.Count -1 || mistakes > maxMistakes)
            {
                GameStatus = GameStatus.GameIsOver;               
            }
            if(EndOfGame != null)//если у нас есть подписчики
            {
                EndOfGame(this, new GameEventArgs(counter, mistakes, mistakes <= maxMistakes)); //то вызываем  EndOfGame и передаем создаем экземпляр, передав данные
            }                                                                               //подебил если mistakes <= maxMistakes кол-во ошибок
            counter++; //увеличиваем счетчик
        }


    }
}
