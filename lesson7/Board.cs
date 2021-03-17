using System;

namespace lesson7
{
    class Board
    {
        public Cell[,] cells = null;
        int inLine, freeCells;
        public Board(int s, int inline)
        {
            inLine = inline;
            cells = new Cell[s, s];
            for (int y = 0; y < cells.GetLength(1); y++)
            {
                for (int x = 0; x < cells.GetLength(0); x++)
                {
                    cells[x, y] = new Cell(x, y);
                }
            }
            freeCells = cells.Length;
        }
        public void Show()
        {
            Console.Clear();
             for (int y = 0; y < cells.GetLength(1); y++)
             {
                for (int x = 0; x < cells.GetLength(0); x++)
                {
                    Console.Write(cells[x, y]);
                }
                Console.WriteLine();
             }
        }

        internal bool TryCaptureCell(int x, int y, bool userOrAI)
        {
            if (cells[x, y].Own != null)
            {//Занято!!!
                return false;
            }
            else
            {
                cells[x, y].MarkCell(userOrAI);
                freeCells--;
                return true;
            }
        }

        internal bool isWinnerAppeared(bool userOrAI) //user true, AI false
        {
            for (int y = 0; y < cells.GetLength(1); y++)
            {
                for (int x = 0; x < cells.GetLength(0); x++)
                {
                    if ( cells[x, y].Own == userOrAI )
                    {
                        if (x + inLine <= cells.GetLength(0) && CheckToRight(x, y, inLine, userOrAI))
                        {
                            return true;
                        }
                        if (x + inLine <= cells.GetLength(0) && y + inLine <= cells.GetLength(1) && CheckToRightDown(x, y, inLine, userOrAI))
                        {
                            return true;
                        }
                        if (y + inLine <= cells.GetLength(1) && CheckToDown(x, y, inLine, userOrAI))
                        {
                            return true;
                        }

                        if (x >= inLine - 1 && y + inLine <= cells.GetLength(1) && CheckToLeftDown(x, y, inLine, userOrAI))
                        {
                            return true;
                        }

                    }
                }
            }

            return false;
        }

        internal bool isFull()
        {
            if (freeCells != 0)
                return false;
            else
                return true;
        }
        private bool CheckToLeftDown(int x, int y, int inLine, bool userOrAI)
        {
            for (int tmp = 0 ; tmp < inLine; tmp++, x--, y++)
            {
                if (cells[x, y].Own != userOrAI)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckToDown(int x, int y, int inLine, bool userOrAI)
        {
            for ( int tmp = 0; tmp < inLine; tmp++, y++)
            {
                if (cells[x, y].Own != userOrAI)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckToRightDown(int x, int y, int inLine, bool userOrAI)
        {
            for ( int tmp = 0; tmp < inLine; tmp++, x++, y++)
            {
                if (cells[x, y].Own != userOrAI)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckToRight(int x, int y, int inLine, bool userOrAI)
        {
            for ( int tmp = 0; tmp < inLine ; tmp++, x++)
            {
                if (cells[x, y].Own != userOrAI)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
