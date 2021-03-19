using System;
using ClassLibrary;

namespace lesson8_1
{
    class WorkWithOuterDll
    {
        static void Main(string[] args)
        {
            Console.Write("Введите своё имя: ");
            Console.WriteLine( ServiceClass.Hi(Console.ReadLine()));
        }
    }
}
