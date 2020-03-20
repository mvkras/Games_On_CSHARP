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
    }
}
