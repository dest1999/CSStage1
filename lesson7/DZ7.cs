using System;

namespace lesson7
{
    class DZ7
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            int size = 7, //размер поля
                inline = 4; //ряд для победы
            bool isUserTurn = false;
            if (size < inline)
            {
                throw new Exception("Условие победы недостижимо");
            }

            Board board = new Board(size, inline);
            board.Show();

            while (true) // главный цикл
            {
                isUserTurn = !isUserTurn;

                if (isUserTurn)
                {
                    UserTurn(board);
                }
                else
                {
                    AITurn(board);
                }

                board.Show();
                if (board.isWinnerAppeared(isUserTurn))
                {
                    Console.WriteLine(Congratulations( isUserTurn ? "X" : "O" ));
                    break;
                }
                else if (board.isFull())
                {
                    Console.WriteLine("Ничья");
                    break;
                }
            }
            Console.ReadKey();
        }

        private static void UserTurn(Board board)
        {
            int x, y;
            bool t;
            do 
            {
                (x, y) = CheckInputUserTurn(board.cells.GetLength(0));
                t = board.TryCaptureCell(x, y, true);
                if (!t)
                {
                    Console.WriteLine("Занято");
                }
            } while (!t);

        }

        private static void AITurn(Board board)
        {
            int x, y;
            do
            {
                x = rnd.Next(0, board.cells.GetLength(0));
                y = rnd.Next(0, board.cells.GetLength(1));

            } while (!board.TryCaptureCell(x, y, false));

        }

        private static string Congratulations(string user)
        {
            return $"Подравляем, победил пользователь {user}!";
        }

        private static (int x, int y) CheckInputUserTurn(int size)
        {
            string str;
            string[] strArr = null;

            do
            {
                Console.Write($"\nВведите координаты x y: ");
                str = Console.ReadLine();
                if (str.Contains(" "))
                {
                    strArr = str.Split(' ');
                }
                else if (str.Contains(","))
                {
                    strArr = str.Split(',');
                }
                else
                {
                    Console.WriteLine("Для разделения координат используйте пробел или запятую");
                    continue;
                }
                if (!int.TryParse(strArr[0], out int x) || !int.TryParse(strArr[1], out int y))
                {
                    Console.WriteLine("Нужны 2 числа");
                    continue;
                }
                if (x < 1 || y < 1 || x > size || y > size)
                {
                    Console.WriteLine("Координаты вне границ поля");
                    continue;
                }
                return (--x, --y);

            } while (true);
        }
    }
}
