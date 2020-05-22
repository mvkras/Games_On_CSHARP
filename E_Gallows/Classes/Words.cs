using System;
using System.Collections.Generic;
using System.Text;

namespace E_Gallows.Classes
{
    public class Words //здесь будут загадываться слова
    {
        private string text { get; }
        private bool correct_Answer { get; }
        public string rightWord { get; }

        //создаем конструктор, который будет принимать эти параметры
        public Words(string text, bool correct_Answer, string rightWord)
        {
            this.text = text;
            this.correct_Answer = correct_Answer;
            this.rightWord = rightWord;
        }
    }
}
