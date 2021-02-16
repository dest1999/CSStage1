using System;

namespace lesson2
{
    class DZ2
    {
        enum Month
        {
            январь = 1,
            февраль,
            март,
            апрель,
            май,
            июнь,
            июль,
            август,
            сентябрь,
            октябрь,
            ноябрь,
            декабрь
        }
        
        [Flags]
        enum WeekDays
        {
            пн = 0b_0000001,
            вт = 0b_0000010,
            ср = 0b_0000100,
            чт = 0b_0001000,
            пт = 0b_0010000,
            сб = 0b_0100000,
            вс = 0b_1000000
        }
        
        struct Office
        {
            public WeekDays workDays;
        }

        static void Main(string[] args)
        {
            #region Temperature
            /*
            int tempMax, tempMin;

            do //запрашиваем макс.-мин. температуру
            {
                Console.Write("Введите максимальную температуру: ");
                tempMax = int.Parse(Console.ReadLine());
                Console.Write("Введите минимальную температуру: ");
                tempMin = int.Parse(Console.ReadLine());

                Console.WriteLine(tempMax < tempMin ? "Неверный ввод, максимальная температура меньше минимальной" : "Ввод температуры корректен");

            } while (tempMax < tempMin);


            double tempMid = (tempMax + tempMin) / 2.0; //вычисляем среднюю температуру

            Console.Write($"Средняя температура: {tempMid}\nВведите порядковый номер месяца: ");
            int userMonthInput = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Введен месяц {(Month)userMonthInput}");
            //определяем четность-нечетность месяца
            if (userMonthInput <= 12 && userMonthInput > 0)
            {
                if ((userMonthInput % 2) == 0)
                {
                    Console.WriteLine($"А месяц {(Month)userMonthInput}-то чётный");
                }
                else
                {
                    Console.WriteLine($"А месяц {(Month)userMonthInput}-то нечётный");
                }
            }
            else
            {
                Console.WriteLine("Странный месяц, кажется такого не существует");
            }

            switch (userMonthInput)
            {
                case 1:
                case 2:
                case 12:
                    if (tempMid > 0)
                    {
                        Console.WriteLine("Дождливая зима");
                    }
                    break;

                default:
                    break;
            }
            */
            #endregion

            Office office1, office2;
            office1.workDays = WeekDays.вт | WeekDays.ср | WeekDays.чт | WeekDays.пт; // этот офис работает вт-пт
            office2.workDays = (WeekDays)0b_1110111;  // этот офис работает пн-вс

            Console.WriteLine("График работы офиса № 1: " + office1.workDays);
            Console.WriteLine("График работы офиса № 2: " + office2.workDays);



            Console.ReadKey();
        }
    }
}
