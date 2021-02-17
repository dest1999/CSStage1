using System;

namespace lesson3
{
    class DZ3
    {
        static void Main(string[] args)
        {
            string userInput;
            do
            {
                Console.WriteLine("Выберите пункт домашнего задания (цифры 1-4, q-для выхода)");
                userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "1":
                        {
                            Console.WriteLine($"Задание {userInput}");
                        }
                        break;
                    case "2":
                        {
                            Console.WriteLine($"Задание {userInput}");
                        }
                        break;
                    case "3":
                        {
                            Console.WriteLine($"Задание {userInput}");
                        }
                        break;
                    case "4":
                        {
                            Console.WriteLine($"Задание {userInput}");
                        }
                        break;
                    case "q":
                        return;


                    default:
                        {
                            Console.WriteLine("Введено что-то непонятное, повторите ввод");
                        }
                        break;
                }






            } while (true);




        }
    }
}
