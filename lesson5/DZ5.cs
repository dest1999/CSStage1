using System;
using System.IO;

namespace lesson5
{
    class DZ5
    {
        static void Main(string[] args)
        {
            string userInput;
            do
            {
                Console.WriteLine("Выберите пункт домашнего задания (цифры 1-4, что угодно другое-для выхода)");
                userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "1":
                        {// TODO Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл
                            Console.Clear();
                            string[] strFromUserArr = new string[0];
                            string strFromUser, userFileName = "file.txt";
                            int strCounter = 0;
                            bool? isOverwrite = null;

                            if ( File.Exists(userFileName) && new FileInfo(userFileName).Length != 0 ) //Проверка существования и наполнения файла
                            {
                                string[] linesInFile = File.ReadAllLines(userFileName);
                                Console.WriteLine($"Файл {userFileName} существует и содержит в себе информацию:");
                                foreach (var item in linesInFile) // выводим старое содержимое файла (если есть)
                                {
                                    Console.WriteLine(item);
                                }

                                do
                                {
                                    Console.WriteLine("Вы хотите перезаписать его (r) или добавить в конец (i)?");
                                    strFromUser = Console.ReadLine();
                                    if (strFromUser == "r")
                                    {
                                        isOverwrite = true;
                                    }
                                    if (strFromUser == "i")
                                    {
                                        isOverwrite = false;
                                    }
                                } while (isOverwrite == null);
                            }

                            Console.WriteLine($"Введите строки для записи в файл {userFileName}, q для выхода");

                            while (true)
                            {
                                strFromUser = Console.ReadLine();
                                if (strFromUser == "q")
                                {
                                    break;
                                }
                                Array.Resize(ref strFromUserArr, strCounter + 1);
                                strFromUserArr[strCounter] = strFromUser;
                                strCounter++;
                            }

                            if (strFromUserArr.Length != 0) // проверка есть ли что для записи в файл
                            {
                                if (isOverwrite == true) //файл перезаписать или добавить инфу в конец
                                {
                                    File.WriteAllLines(userFileName, strFromUserArr);
                                }
                                else
                                {
                                    File.AppendAllLines(userFileName, strFromUserArr);
                                }
                            }
                        }
                        break;
                    case "2":
                        {// TODO Написать программу, которая при старте дописывает текущее время в файл «startup.txt»
                            Console.Clear();

                        }
                        break;
                    case "3":
                        {// TODO Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный файл
                            Console.Clear();

                        }
                        break;
                    case "4":
                        {// TODO (*)
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
