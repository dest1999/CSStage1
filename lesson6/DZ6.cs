using System;
using System.IO;
using System.Collections.Generic;


namespace lesson6
{
    class DZ6
    {
        static void Main(string[] args)
        {
            Console.Write("Введите путь: ");
            SaveFilesAndDirsListToFile (Console.ReadLine()); // Вызов метода задание 1 (без рекурсии)
        }

        private static void SaveFilesAndDirsListToFile(string path)
        {
            string fileToSave = "FilesAndDirs.txt";
            List<string> filesAndDirsList = new List<string>(); //Коллекции ещё не проходили, но работать с ними удобнее чем с массивами. В коллекцию набираем список
                                                                //файлов и каталогов, а затем его записываем в одно обращение в файл
            try
            {
                foreach (var item in Directory.EnumerateFileSystemEntries(path, "*", SearchOption.AllDirectories))
                {
                    filesAndDirsList.Add(item);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Ошибка доступа к элементу {filesAndDirsList[filesAndDirsList.Count - 1]}\nВыполнение прервано, информация будет сохранена в файл частично");
            }
            catch
            {
                Console.WriteLine("Какая-то ошибка");
            }

            if (filesAndDirsList.Count != 0)
            {
                File.WriteAllLines(fileToSave, filesAndDirsList);
                Console.WriteLine("Список файлов и каталогов по указанному пути сохранен в файл");
            }

            Console.ReadKey();
        }
    }
}
