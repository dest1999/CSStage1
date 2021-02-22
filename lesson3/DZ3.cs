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
                Console.WriteLine("Выберите пункт домашнего задания (цифры 1-5, q-для выхода)");
                userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "1":
                        {// вывести диагональ двумерного массива
                            Console.Clear();
                            uint arrayDim;
                            do
                            {
                                Console.Write("Введите размер n для массива [n*n]: ");
                            } while (!uint.TryParse(Console.ReadLine(), out arrayDim) || arrayDim == 0);
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
                        {// Телефонный справочник: массив 5х2
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
                        {// Написать программу, выводящую введённую пользователем строку в обратном порядке
                            Console.Clear();

                            Console.WriteLine("Введите строку:");
                            string userString = Console.ReadLine();
                            Console.WriteLine("Перевернутая строка:");
                            for (int i = userString.Length; i > 0 ; i--)
                            {
                                Console.Write(userString[i-1]);
                            }
                            Console.WriteLine();
                        }
                        break;
                    case "4":
                        {//Смещение элементов одномерного массива на заданное количество позиций
                            Console.Clear();
                            uint arraySize;
                            do
                            {
                                Console.Write($"Введите количество элементов массива: ");
                            } while (!uint.TryParse(Console.ReadLine(), out arraySize) || arraySize == 0 );
                            int[] arr = new int[arraySize];
                            Console.WriteLine("Массив заполнен случайными значениями:");
                            for (int i = 0; i < arr.Length; i++)
                            {
                                arr[i] = rnd.Next(10, 100);
                                Console.Write(arr[i] + " ");
                            }
                            int offset, tmp;
                            do
                            {
                                Console.Write("\nВведите сдвиг: ");
                            } while (!int.TryParse(Console.ReadLine(), out offset));
                            offset %= arr.Length; // противодействие лишним вычислениям если пользователь ввёл сдвиг больше длины массива

                            #region Сдвигаем циклически
                            if (offset > 0) // 0 не рассматриваем, т.к. ничего никуда не перемещается
                            {//выполняем если сдвиг положительный
                                for (int i = 0; i < offset; i++)
                                {
                                    tmp = arr[arr.Length - 1];
                                    for (int j = arr.Length - 2; j >= 0 ; j--)
                                    {
                                        arr[j + 1] = arr[j];
                                    }
                                    arr[0] = tmp;
                                }
                            }
                            if (offset < 0)
                            {//выполняем если сдвиг отрицательный
                                for (int i = 0; i > offset; i--)
                                {
                                    tmp = arr[0];
                                    for (int j = 0; j < arr.Length - 1; j++)
                                    {
                                        arr[j] = arr[j + 1];
                                    }
                                    arr[arr.Length - 1] = tmp;
                                }
                            }
                            #endregion

                            Console.WriteLine("Результат:");
                            for (int i = 0; i < arr.Length; i++)
                            {
                                Console.Write(arr[i] + " ");
                            }
                            Console.WriteLine();
                        }
                        break;
                    case "5":
                        {//TODO *«Морской бой»: вывести на экран массив 10х10, состоящий из символов X и O, где Х — элементы кораблей, а О — свободные клетки
                            Console.Clear();
                            char[,] sea = {
                                {'X', 'O', 'O', 'X', 'O', 'O', 'O', 'O', 'O', 'O' },
                                {'X', 'O', 'O', 'X', 'O', 'O', 'O', 'O', 'X', 'O' },
                                {'O', 'O', 'O', 'X', 'O', 'O', 'O', 'O', 'O', 'O' },
                                {'O', 'X', 'O', 'O', 'O', 'O', 'X', 'O', 'O', 'O' },
                                {'O', 'X', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O' },
                                {'O', 'X', 'O', 'X', 'X', 'O', 'O', 'O', 'O', 'O' },
                                {'O', 'X', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O' },
                                {'O', 'O', 'O', 'O', 'O', 'O', 'O', 'X', 'O', 'O' },
                                {'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O' },
                                {'X', 'X', 'X', 'O', 'X', 'X', 'O', 'O', 'O', 'X' },};
                            
                            for (int i = 0; i < sea.GetLength(0); i++) //показали итоговый массив
                            {
                                for (int j = 0; j < sea.GetLength(1); j++)
                                {
                                    if (sea[i, j] == 'O' )
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                    }
                                    if (sea[i,j] == 'X' )
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                    }
                                    Console.Write(" " + sea[i, j]);
                                }
                                Console.WriteLine();
                            }

                            Console.ResetColor();

                        }
                        break;
                    case "q":
                    case "Q":
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
