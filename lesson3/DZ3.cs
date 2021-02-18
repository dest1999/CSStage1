using System;

namespace lesson3
{
    class DZ3
    {
        static void Main(string[] args)
        {
            Random rnd = new Random(); //это для заполнения массива
            string userInput;
            do
            {
                Console.WriteLine("Выберите пункт домашнего задания (цифры 1-4, q-для выхода)");
                userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "1":
                        {//TODO вывести диагональ двумерного массива
                            Console.Clear();
                            uint arrayDim;
                            do
                            {
                                Console.Write("Введите размер n для массива [n*n]: ");
                            } while (!uint.TryParse(Console.ReadLine(), out arrayDim));
                            int[,] array = new int[arrayDim, arrayDim];
                            //в этом цикле заполняем массив случайными значениями
                            for (int i = 0; i < array.GetLength(0); i++)
                            {
                                for (int j = 0; j < array.GetLength(1); j++)
                                {
                                    array[i, j] = rnd.Next(10, 100);
                                    if ((i == j) || (j == (array.GetLength(1) - i - 1)) )
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write(array[i,j] + " ");
                                        Console.ResetColor();
                                    }
                                    else
                                    {
                                        Console.Write(array[i, j] + " ");
                                    }
                                }
                                Console.WriteLine();
                            }
                            Console.WriteLine("\nПервая диагональ:");
                            for (int i = 0; i < array.GetLength(0); i++)
                            {
                                Console.Write(array[i,i] + " ");
                            }

                            Console.WriteLine("\nВторая диагональ:");
                            for (int i = array.GetLength(0)-1; i >= 0; i--)
                            {
                                Console.Write( array[i, array.GetLength(1) - i - 1] + " " );
                            }
                            Console.WriteLine();
                        }
                        break;
                    case "2":
                        {//TODO Телефонный справочник: массив 5х2
                            Console.Clear();

                            string[,] userList = {
                                {"Alice", "Bob", "Chuck", "Don", "Eva" },
                                {"651981", "6489", "8495", "4577", "3216849" } };

                            Console.WriteLine("Имя\t\tКонтакт\n");
                            for (int i = 0; i < userList.GetLength(1); i++)
                            {
                                Console.WriteLine($"{userList[0, i]}\t\t{userList[1, i]}");
                            }
                            Console.WriteLine();
                        }
                        break;
                    case "3":
                        {//TODO Написать программу, выводящую введённую пользователем строку в обратном порядке
                            Console.WriteLine($"Задание {userInput}");
                        }
                        break;
                    case "4":
                        {//TODO *«Морской бой»: вывести на экран массив 10х10, состоящий из символов X и O, где Х — элементы кораблей, а О — свободные клетки
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
