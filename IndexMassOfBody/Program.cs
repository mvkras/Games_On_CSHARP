using System;
using System.IO;
using System.Text;

namespace IndexMassOfBody
{
    class Program
    {
        static void Main(string[] args)
        {
           BodyMassIndex(); //Рассчет "Индекс массы тела"
         //   ReadResultsOfIMT(); //чтение результатов
        }
        static void BodyMassIndex()
        {
            Console.WriteLine("Введите ваше имя:");
            string name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))  //Подумать, как сделать, чтобы вводить только буквы
            {
                Console.WriteLine("Укажите имя");
                name = Convert.ToString(Console.ReadLine());
            }
            Console.WriteLine("Напишите ваш возраст:");
            string ageQ = Console.ReadLine();
            bool ageA = double.TryParse(ageQ, out double ageResult);
            if (ageA || !ageA)
            {
                while (!(ageResult > 0 && ageResult <= 120))
                {

                    Console.WriteLine("Неверно указан возраст, попробуйте снова!");
                    try
                    {
                        ageResult = Convert.ToDouble(Console.ReadLine());
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Не пропускайте вопрос про возраст!");
                    }
                }

            }

            Console.WriteLine("Укажите ваш рост в (см)");
            string heightQ = Console.ReadLine();
            bool heightAsk = double.TryParse(heightQ, out double resultHeight);
            if (heightAsk || !heightAsk)
            {
                while (!(resultHeight >= 55 && resultHeight <= 220))
                {
                    Console.WriteLine("Укажите корректный рост");
                    try
                    {
                        resultHeight = double.Parse(Console.ReadLine());
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Не пропускайте вопрос про Ваш рост, это важно для рассчета!");
                    }

                }

            }

            Console.WriteLine("Напишите ваш вес в (кг)");
            string weightQ = Console.ReadLine();
            bool weightA = double.TryParse(weightQ, out double resultWeight);
            if (weightA || !weightA)
            {
                while (!(resultWeight > 3 && resultWeight <= 180))
                {
                    Console.WriteLine("Укажите корректный вес");
                    try
                    {
                        resultWeight = double.Parse(Console.ReadLine());
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Необходимо указать Ваш вес для расчета ИМТ!");
                    }

                }
            }

            Console.WriteLine();
            double IMT = resultWeight / (resultHeight / 100 * resultHeight / 100);
            IMT = Math.Round(IMT, 2);


            //   Console.Write(fullResultOfIMT);
            //  Console.WriteLine("*** Ваш результат: ***");

            //Console.Write($"Ваше имя: {name},\nВозраст: {ageResult} лет,\nИндекс массы тела равен: {IMT} - ");
            string totalResult = null;          
            string fullResultOfIMT = null; 
            if (IMT <= 16)
            {
                totalResult = "Выраженный дефицит массы тела";
             
            }
            else if (IMT > 16 && IMT <= 18.5)
            {
                totalResult = "Недостаточная масса тела";
              
            }
            else if (IMT > 18.5 && IMT <= 24.99)
            {
                totalResult = "Показатели в норме";
             
            }
            else if (IMT >= 25 && IMT <= 30)
            {
                totalResult = "Избыточная масса тела (ожирение)";
              
            }
            else if (IMT > 30 && IMT <= 35)
            {
                totalResult = "Ожирение первой степени";
               
            }
            else if (IMT > 35 && IMT <= 40)
            {
                totalResult = "Ожирение второй степени";
               
            }
            else if (IMT > 40)
            {
                totalResult = "Ожирение третьей степени (морбидное)";
              
            }
            
            string yourResultOfIMT = "\n*** Ваш результат: ***\n";
            fullResultOfIMT = yourResultOfIMT + $"Ваше имя: {name},\nВозраст: {ageResult} лет,\nИндекс массы тела равен: {IMT} - " + totalResult;
            Console.WriteLine(fullResultOfIMT);
            Console.WriteLine();
            
          
            //запись результата в файл
            using (StreamWriter writeResult = new StreamWriter(@"C:\Users\User\Desktop\IMT.txt", true, Encoding.UTF8))
            {
                 writeResult.WriteLine(fullResultOfIMT);                   
            }
           
        }

        static void ReadResultsOfIMT()
        {
            using (StreamReader readResult = new StreamReader(@"C:\Users\User\Desktop\IMT.txt", Encoding.UTF8))
            {
                string readingText = readResult.ReadToEnd();
                Console.WriteLine(readingText);
            }
        }
    }
}
