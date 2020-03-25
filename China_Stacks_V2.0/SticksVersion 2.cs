using System;
using System.Collections.Generic;
using System.Text;

namespace China_Stacks_V2._0
{
    public enum Player //выбор, кто будет ходить
    {
        Human,
        Computer
    }
    public enum GameStatus  //Текущий статус игры, тоже enum
    {
        NotStarted,
        InProgress,
        Finished
    }
    class SticksVersion_2
    {
        private readonly Random randomaizer; //рандомайзер для генерации чисел
        public int DefualtStickNumber { get; } //количество палок

        //Свойство, кто должен делать ход
        public Player Turn { get; private set; }

        //Свойство, которое будет показывать сколько палочек осталось
        public int SticksLeft { get; private set; }

        //Текущий статус игры, тоже enum
        public GameStatus GameStatus { get; private set; } //будет модифицироваться изнутри класса

        //Используем делегат
        public event Action<int> ComputerPlayed; //в int будем передавать кол-во палок, которое взяла машина
        public event EventHandler<int> HumanTurn; //игрок играет

        //это событие будет посылать себя
        public event Action<Player> EndOfGame;

        //Создаем конструктор, который будет принимать начальное количество палок 
        //и аргумент player, определяет кто будет делать первым ход
        public SticksVersion_2(int DefualtStickNumber, Player whoFirstMove)
        {
            if (DefualtStickNumber < 7 || DefualtStickNumber > 30)
            {
                throw new ArgumentException("Начальное количество палок должно быть от 7 до 30");
            }
            //инициализируем рандомайзер
            randomaizer = new Random();
            GameStatus = GameStatus.NotStarted; //статус пока не начали
            this.DefualtStickNumber = DefualtStickNumber;
            SticksLeft = DefualtStickNumber; //изначально они равны
            Turn = whoFirstMove;
        }

        //выкатываем метод Start, который будет вызывать внешним кодом
        public void Start()
        {
            if (GameStatus == GameStatus.Finished) //Если текущий статус Finished
            {
                SticksLeft = DefualtStickNumber; //то кол-во палок переставляется метод будет давать перезапуск игры
            }
            if (GameStatus == GameStatus.InProgress) //если игра начата 
            {
                throw new InvalidOperationException("Нельзя вызывать старт, когда игра начата");//выбрасываем исключение
            }
            GameStatus = GameStatus.InProgress;

            //запускаем цикл
            while (GameStatus == GameStatus.InProgress) //основываем наше решение на событиях
            {
                if (Turn == Player.Computer) //делаем проверку, если текущий ход за компьютером
                {
                    ComputerMakesMove(); //вызовем вспомогательный метод
                }
                else
                {
                    HumanMakesMove();
                }
                //Метод который будет вызывать конец игры, если потребуется
                SavedEngOfGameIfNeeded();
                //После каждого хода должны менять очередность
                //Если текущий ход равен компьютеру, то в Turn надо присваивать Human иначе компьютер
                Turn = Turn == Player.Computer ? Player.Human : Player.Computer; //делаем инверсию
            }
        }

        private void SavedEngOfGameIfNeeded()
        {
            //будет проверять
            if(SticksLeft == 0)
            {
                GameStatus = GameStatus.Finished;
                if(EndOfGame != null) //если кто-то подписался, вызываем
                {
                    EndOfGame(Turn == Player.Computer ? Player.Human : Player.Computer); //передаем победителя 
                }
            }
        }

        private void HumanMakesMove()
        {
            if (HumanTurn != null)
            {
                HumanTurn(this, SticksLeft); //то передать управление верхнему коду. Передали ссылку на наш экземпляр
            }                                   // и количество оставшихся палок
        }

        private void ComputerMakesMove() //Как делает компьютер ход
        {                                                        //максимальное число для генерации
            int maxRandom = SticksLeft >= 3 ? 3 : SticksLeft; //необходимо сгенерировать число если осталось палок 3 или меньше, макс число 3
            int sticks = randomaizer.Next(1, maxRandom);

            TakeSticks(sticks);
            if (ComputerPlayed != null)
            {
                ComputerPlayed(sticks); //вызываем ComputerPlayed
            }
        }

        private void TakeSticks(int sticks) //уменьшаем количество палочек
        {
            SticksLeft -= sticks;
        }
        public void HumanTakesSticks(int sticks) //защита от дурака
        {
            if(sticks < 1 || sticks > 3)
            {
                throw new ArgumentException("Некорректные значения, нужно от 1 до 3х"); //выбрасываем исключение
            }
            if(sticks > SticksLeft)
            {
                throw new ArgumentException($"Ты не можешь взять больше, чем осталось! Не больше: {SticksLeft}");
            }
            TakeSticks(sticks); //если все ок, вызываем этот метод
        }
    }

}  
        
    

