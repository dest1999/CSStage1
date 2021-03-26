using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace lesson6
{
    class DZ6
    {
        static void Main(string[] args)
        {
            #region task1
            MainMethodTask1();
            #endregion
            #region task2
            //MainMethodTask2();
            #endregion
            #region task3
            //MainMethodTask3();
            #endregion
            #region task4
            //MainMethodTask4();
            #endregion
        }

        private static void MainMethodTask4() //task4 method
        {
            Person[] persArray = new Person[0];

            try
            {
                AddNewItemIntoArray(ref persArray, new Person("Иван", "директор", "ceo@corp.ru", "84117534281", int.MaxValue, 45));
                AddNewItemIntoArray(ref persArray, new Person("Юленька", "секретарь", "youl@corp.ru", "84117534281", int.MaxValue / 3, 19));
                AddNewItemIntoArray(ref persArray, new Person("Борис Филиппович", "главный инженер", "gl_inzh@corp.ru", "84117534281", 40000, 50));
                AddNewItemIntoArray(ref persArray, new Person("Андрюха", "старший специалист выездной бригады", "st_mob@corp.ru", "84117534281", 30000, 35));
                AddNewItemIntoArray(ref persArray, new Person("Петрович", "разнорабочий", "-", "84117534281", 12000, 55));// эта строка вызовет исключение в конструкторе
            }
            catch (PersonCreateExeption e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Выборка тех, кому за 40");
            foreach (var item in persArray)
            {
                if (item.Age > 40)
                    item.Show();
            }
        }
        private static void MainMethodTask3()
        {
            string[,] goodArr = new string[,]
            {
                { "1", "1", "1", "1", },
                { "1", "1", "1", "1", },
                { "1", "XX", "1", "1", },
                { "0", "1", "1", "1", }
            };

            string[,] badArr = new string[,]
            {
                { "1", "1", "1", "1", },
                { "1", "1", "1", "1", },
                { "1", "1", "1", "1", }
            };
            try
            {
                Console.WriteLine(GetArray(badArr));
            }
            catch (MyArraySizeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (MyArrayDataException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void MainMethodTask2()
        {
            string fileStoreTasks = "tasks.json";
            ToDo[] toDoArray = new ToDo[0];
            ToDoInitCheckFile(fileStoreTasks, ref toDoArray);
            ToDoMainCycle(ref toDoArray);
            ToDoSaveToFile(fileStoreTasks, ref toDoArray);
        }
        private static void MainMethodTask1()
        {
            Console.Write("Введите путь: ");
            string filesDirsTree = "FilesAndDirs.txt", filesDirsTreeRec = "FilesAndDirsRec.txt";
            string userPath = Console.ReadLine();
            File.Delete(filesDirsTree);
            File.Delete(filesDirsTreeRec);
            SaveFilesAndDirsListToFile(userPath, filesDirsTree); // Вызов метода задание 1 (без рекурсии)
            RunDirectoryRecursively(userPath, filesDirsTreeRec);
        }
        private static int GetArray(string [,] arr)  //task3 method
        {
            int sum = 0;
            if (arr.GetLength(0) !=4 || arr.GetLength(1) !=4)
            {
                throw new MyArraySizeException();
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (int.TryParse(arr[i, j], out int elArr))
                    {
                        sum += elArr;
                    }
                    else
                    {
                        throw new MyArrayDataException(i + 1, j + 1);
                    }

                }
            }
            return sum;
        }
        private static void ToDoMainCycle(ref ToDo[] toDoArray) //task2 method: Главный цикл
        {//Введите номер задачи для закрытия, (А) для создания новой задачи, (Q) для сохранения и выхода
            string userChoice;
            do
            {
                Console.Clear();
                ToDoMainShow(ref toDoArray);
                userChoice = Console.ReadLine(); // Ввод пользователя
                if (int.TryParse(userChoice, out int res) && (res <= toDoArray.Length)) //Если введена цифра и существует такой индекс в масиве...
                {
                    try
                    {
                        toDoArray[res - 1].Completed();
                    }
                    catch (System.IndexOutOfRangeException)
                    {
                        Console.WriteLine("Нечего отмечать, список пуст. Добавьте задачу\nДля продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                    }
                }
                else if (userChoice.ToLower() == "a" || userChoice.ToLower() == "а")//ADD new... Добавляем новое задание
                {
                    --Console.CursorTop;
                    AddNewItemIntoArray(ref toDoArray, ToDoCreateNew());
                }

            } while (userChoice.ToLower() != "q");
        }
        private static void ToDoMainShow(ref ToDo[] toDoArray) //task2 method: Основная отрисовка
        {
            int completedCount = 0;
            Console.WriteLine();
            for (int i = 0; i < toDoArray.Length; i++)
            {
                if (i % 2 ==0)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                if (toDoArray[i].IsDone)
                {
                    completedCount++;
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine($"{i + 1} {toDoArray[i]}");
            }
            Console.ResetColor();
            int tmpCursorPosition = Console.CursorTop;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Всего задач: {toDoArray.Length}, из них выполнено {completedCount}");
            Console.SetCursorPosition(0, tmpCursorPosition);
            Console.WriteLine("Введите номер задачи для её закрытия, (А) для создания новой задачи, (Q) для сохранения и выхода");
        }
        private static void ToDoInitCheckFile(string file, ref ToDo[] toDoArray) //task2 method: Проверка наличия файла
        {
            if (File.Exists(file))
            {
                string stringStoreTasks = File.ReadAllText(file);
                if (stringStoreTasks.Length > 1)
                {
                    try
                    {
                        toDoArray = JsonSerializer.Deserialize<ToDo[]>(stringStoreTasks);
                    }
                    catch
                    {
                        Console.WriteLine("Не удалось восстановить информацию из файла\nДля продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                    }
                }
            }
        }
        private static ToDo ToDoCreateNew() //task2 method: создаём новую задачу
        {
            Console.WriteLine("Введите описание для новой задачи");
            ToDo toDo = new ToDo(Console.ReadLine());
            return toDo;
        }
        private static void ToDoSaveToFile(string fileStoreTasks, ref ToDo[] toDoArray) //task2 method: Сохраняем список задач в файл
        {
            if (toDoArray.Length != 0)
            {
                string json = JsonSerializer.Serialize(toDoArray);
                File.WriteAllText(fileStoreTasks, json);
            }
        }
        private static void SaveFilesAndDirsListToFile(string path, string fileToSave) //task1 method без рекурсии
        {
            string[] filesAndDirsArray = new string[0];
            try
            {
                foreach (var item in Directory.EnumerateFileSystemEntries(path, "*", SearchOption.AllDirectories))
                {
                    AddNewItemIntoArray(ref filesAndDirsArray, item);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Ошибка доступа к элементу {filesAndDirsArray[filesAndDirsArray.Length - 1]}\nВыполнение прервано, информация будет сохранена в файл частично");
            }
            catch
            {
                Console.WriteLine("Какая-то ошибка");
            }

            if (filesAndDirsArray.Length != 0)
            {
                File.WriteAllLines(fileToSave, filesAndDirsArray);
                Console.WriteLine("Сгенерированный список файлов и каталогов по указанному пути сохранен в файл");
            }
            Console.ReadKey();
        }
        private static void AddNewItemIntoArray<T>(ref T[] arr, T newItem) //Common method: добавляем элемент в массив, немного обобщений для переиспользования кода
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = newItem;
        }
        private static void RunDirectoryRecursively(string path, string fileToWrite, int padding = 0)  //task1 method с рекурсией
        {
            foreach (var fileItem in Directory.GetFiles(path))
            {
                File.AppendAllText(fileToWrite, fileItem + "\n");
            }

            foreach (var dirItem in Directory.GetDirectories(path))
            {
                File.AppendAllText(fileToWrite, dirItem + "\n");
                RunDirectoryRecursively(dirItem, fileToWrite, padding + 1);
            }
        }

    }
}
