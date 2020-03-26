using System;
using System.Collections.Generic;
using System.Text;

namespace D_Believe_Or_Not.Classes
{
    public class GameEventArgs : EventArgs //создадим событие наследуется от EventArgs
    {
       public int questionsPassed { get; }
        public int mistakesMade { get; }
        public bool isWin { get; }
        //конструктор
        public GameEventArgs(int questionsPassed, int mistakesMade, bool isWin) //содержит данные, сколько вопросов было задано, ск-ко ошибок, победа ли?
        {
            this.questionsPassed = questionsPassed;
            this.mistakesMade = mistakesMade;
            this.isWin = isWin;
        }
    }
}
