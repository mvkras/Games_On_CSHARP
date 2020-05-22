using System;

namespace IndexMassOfBody
{
    class Program
    {
        static void Main(string[] args)
        {
            BodyMassIndex(); //Рассчет "Индекс массы тела"
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
            Console.WriteLine("*** Ваш результат: ***");

            Console.Write($"Ваше имя: {name},\nВозраст: {ageResult} лет,\nИндекс массы тела равен: {IMT} - ");

            if (IMT <= 16)
            {
                Console.Write("Выраженный дефицит массы тела");
            }
            else if (IMT > 16 && IMT <= 18.5)
            {
                Console.Write("Недостаточная масса тела");
            }
            else if (IMT > 18.5 && IMT <= 24.99)
            {
                Console.Write("Показатели в норме");
            }
            else if (IMT >= 25 && IMT <= 30)
            {
                Console.Write("Избыточная масса тела (ожирение)");
            }
            else if (IMT > 30 && IMT <= 35)
            {
                Console.Write("Ожирение первой степени");
            }
            else if (IMT > 35 && IMT <= 40)
            {
                Console.Write("Ожирение второй степени");
            }
            else if (IMT > 40)
            {
                Console.Write("Ожирение третьей степени (морбидное)");
            }
            Console.WriteLine();
        }
    }
}
