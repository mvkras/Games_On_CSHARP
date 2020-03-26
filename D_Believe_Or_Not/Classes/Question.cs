using System;
using System.Collections.Generic;
using System.Text;

namespace D_Believe_Or_Not
{
    public class Question
    {
        public string text { get; }
        public bool correctAnswer { get; }
        public string explorion { get; }

        //создаем конструктор, который будет принимать текст
        public Question(string text, bool correctAnswer, string explonation) //вопрос или утверждение
        {
            this.text = text;
            this.correctAnswer = correctAnswer;
            this.explorion = explonation;
        }
    }
}
