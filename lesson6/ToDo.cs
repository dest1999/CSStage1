using System;

namespace lesson6
{
    class ToDo
    {
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public DateTime DateTimeLastChange { get; set; }

        public ToDo()
        {
            IsDone = false; //При создании задача будет помечена как невыполненная
            DateTimeLastChange = DateTime.Now;
        }

        public ToDo(string str)
        {
            IsDone = false; //При создании задача будет помечена как невыполненная
            Title = str;
            DateTimeLastChange = DateTime.Now;
            Console.WriteLine("Сформирована задача с описанием\n");
        }
        public void Show()
        {
            ToString();
        }

        public override string ToString()
        {
            return $"{(IsDone ? " [X] " : " [ ] ")}{Title}\nПоследнее изменение статуса задачи: {DateTimeLastChange.ToLocalTime()}";
        }
        public void Completed()
        {
            DateTimeLastChange = DateTime.Now;
            IsDone = true;
        }
    }
}
