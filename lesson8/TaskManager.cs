﻿using System;
using System.Diagnostics;
using ClassLibrary;

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
                    Console.Write(" " + item.ProcessName);
                    Console.SetCursorPosition(40, Console.CursorTop);
                    Console.WriteLine(item.Id);
                }

                Console.Write("Введите имя процесса или его номер для его завершения: ");
                processNameOrID = Console.ReadLine();
                if (int.TryParse(processNameOrID, out int processID))
                {
                    Process.GetProcessById(processID).Kill();
                 
                    while (ServiceClass.isProcessExist(processID)) ;
                }
                else
                {
                    foreach (var item in Process.GetProcessesByName(processNameOrID))
                    {
                        item.Kill();
                    }
                    while (ServiceClass.isProcessExist(processNameOrID)) ;
                }
            }
        }
    }
}
