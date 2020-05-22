using E_Gallows.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace E_Gallows
{
    public  enum GameStatus  //создали перечисления для статуса игры, чтобы определить, игра окончена либо нет
    {
        GameInProgress,
        Finished
    }
    class Gallows_Game
    {
        private readonly List<Words> words; //поле для считывание слов
        private readonly int maxMistakes;
        private int counter;  //заводим счетчик. он будет изменяемым, поэтому не будем его делать readonly 
        private int mistakes; //количество ошибок, которое сделал пользователь

       // public event EventHandler<> //создаем событие для запуска игры
        public GameStatus gameStatus { get; set; }

        //создаем конструктор
        public Gallows_Game(string pathFile, int maxMistakes = 6)
        {
            //делаем проверку, если файл не найден
            if(pathFile == null)
            {
                throw new ArgumentNullException("Путь указан не верно");
            }
            //проверка на пустоту
            if(pathFile == "")
            {
                throw new ArgumentException("Файл пуст");
            }
            List<Words> ourWords;
        }
    }
}
