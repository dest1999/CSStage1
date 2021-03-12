using System;
using System.Collections.Generic;
using System.Text;

namespace lesson6
{

    class Person
    {
        string Name;
        string Position;
        string Email;
        string Phone;
        int Salary;
        public int Age { get; }

        public Person(string name, string position, string email, string phone, int salary, int age)
        {
            Name = name;
            Position = position;
            //проверка корректности адреса эл.почты, если не пройдена - выкидываем исключение
            if (string.IsNullOrEmpty(email) || email.ToLower() == "none" || email.ToLower() == "нет")
            {
                Email = "none";
            }else if (email.Contains("@"))
            {
                Email = email;
            }
            else
            {
                throw new PersonCreateExeption($"Вызвано исключение при создании сотрудника /{name}/, проверьте корректность адреса эл.почты");
            }
            Phone = phone;
            Salary = salary;
            Age = age;
        }
        public void Show()
        {
            Console.WriteLine($"Имя: {Name},\n\tДолжность: {Position},\n\tE-mail: {Email},\n\tТелефон: {Phone},\n\tЗарплата: {Salary},\n\tВозраст: {Age}");
        }

    }
}
