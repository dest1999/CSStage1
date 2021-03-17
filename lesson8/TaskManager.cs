using System;
using System.Diagnostics;
// TODO Написать консольное приложение Task Manager, которое выводит на экран запущенные процессы и позволяет завершить указанный процесс.
//      Предусмотреть возможность завершения процессов с помощью указания его ID или имени процесса.
//      В качестве примера можно использовать консольные утилиты Windows tasklist и taskkill

// TODO Создать библиотеку с методом привествия, создать второе консольное приложение, которое выводит это приветствие

namespace lesson8
{
    class TaskManager
    {
        static void Main(string[] args)
        {
            string processNameOrID;
            while (true)
            {
                Process[] processes = Process.GetProcesses();
                Console.Write("\tИмя процесса");
                Console.SetCursorPosition(40, Console.CursorTop);
                Console.WriteLine("ID процесса");
                foreach (var item in processes)
                {
                    Console.Write(item.ProcessName);
                    Console.SetCursorPosition(40, Console.CursorTop);
                    Console.WriteLine(item.Id);
                }

                Console.Write("Введите имя процесса или его номер для его завершения: ");
                processNameOrID = Console.ReadLine();
                if (int.TryParse(processNameOrID, out int processID))
                {
                    Process.GetProcessById(processID).Kill();
                 
                    while (isProcessExist(processID)) ;
                }
                else
                {
                    foreach (var item in Process.GetProcessesByName(processNameOrID))
                    {
                        item.Kill();
                    }
                    while (isProcessExist(processNameOrID)) ;
                }
            }
        }

        private static bool isProcessExist(int processID)
        {
            foreach (var item in Process.GetProcesses())
            {
                if (item.Id == processID)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool isProcessExist(string processName)
        {
            foreach (var item in Process.GetProcesses())
            {
                if (item.ProcessName == processName)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
