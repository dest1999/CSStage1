using System;

namespace lesson3
{
    class DZ4
    {
        enum Season //перечисление к заданию 3
        {
            winter,
            spring,
            summer,
            autumn
        }

        static void Main(string[] args)
        {
            string GetFullName(string firstName, string lastName, string patronymic) // метод к заданию 1
            {
                return $"{lastName} {firstName} {patronymic}";
            }

            int Sum(string str) //метод к заданию 2
            {
                string[] strArray = str.Split(' ');
                int res = 0;
                foreach (var item in strArray)
                {
                    int.TryParse(item, out int tmp);
                    res += tmp;
                }
                return res;
            }

            Season? SetSeason(int monthNumber) //метод к заданию 3
            {   // Вопрос по выполнению: возврат nullable норм? или лучше так не делать?
                //                       использовать лучше if или switch?
                switch (monthNumber)
                {
                    case 1:
                    case 2:
                    case 12:
                        {
                            return Season.winter;
                        }
                    case 3:
                    case 4:
                    case 5:
                        {
                            return Season.spring;
                        }
                    case 6:
                    case 7:
                    case 8:
                        {
                            return Season.summer;
                        }
                    case 9:
                    case 10:
                    case 11:
                        {
                            return Season.autumn;
                        }
                    default:
                        return null;
                }
            }

            string ShowSeason(Season? season) //еще метод к заданию 3
            {
                switch (season)
                {
                    case Season.winter:
                        {
                            return "Зима";
                        }
                    case Season.spring:
                        {
                            return "Весна";
                        }
                    case Season.summer:
                        {
                            return "Лето";
                        }
                    case Season.autumn:
                        {
                            return "Осень";
                        }
                    default:
                        {
                            return "Ошибка: введите число от 1 до 12";
                        }
                }
            }

            string userInput;
            do
            {
                Console.WriteLine("Выберите пункт домашнего задания (цифры 1-4, что угодно другое-для выхода)");
                userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "1":
                        {// TODO Написать метод GetFullName(string firstName, string lastName, string patronymic), принимающий на вход ФИО в разных аргументах и возвращающий объединённую строку с ФИО. Используя метод, написать программу, выводящую в консоль 3–4 разных ФИО
                            Console.Clear();
                            string[,] names =
                            {
                                {"Иванов", "Иван", "Иванович", },
                                {"Петров", "Петр", "Петрович", },
                                {"Сидоров", "Сидор", "Сидорович", }
                            };

                            for (int i = 0; i < names.GetLength(0); i++)
                            {
                                Console.WriteLine(GetFullName( names[i,1], names[i, 0], names[i, 2]) );
                            }

                        }
                        break;
                    case "2":
                        {// TODO Написать программу, принимающую на вход строку — набор чисел, разделенных пробелом, и возвращающую число — сумму всех чисел в строке. Ввести данные с клавиатуры и вывести результат на экран.
                            Console.Clear();
                            Console.WriteLine("Введите последовательность чисел для сложения, разделитель - пробел: ");
                            Console.WriteLine(Sum(Console.ReadLine()));
                        }
                        break;
                    case "3":
                        {// TODO Написать метод по определению времени года. На вход подаётся число – порядковый номер месяца. На выходе — значение из перечисления (enum) — Winter, Spring, Summer, Autumn
                            Console.Clear();
                            int number;
                            do
                            {
                                Console.Write("Введите порядковый номер месяца: ");

                            } while (!int.TryParse(Console.ReadLine(), out number));

                            Console.WriteLine( ShowSeason (SetSeason(number)));

                        }
                        break;
                    case "4":
                        {// TODO (*) Написать программу, вычисляющую число Фибоначчи для заданного значения рекурсивным способом
                            Console.Clear();

                        }
                        break;

                    default:
                        {
                            userInput = "exit";
                        }
                        break;
                }
            } while (userInput != "exit");
        }
    }
}
