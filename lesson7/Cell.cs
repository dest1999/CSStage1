using System;
using System.Collections.Generic;
using System.Text;

namespace lesson7
{
    class Cell
    {
        public int X { get; }// Координаты понадобятся в дальнейшем
        public int Y { get; }
        public bool? Own { get; set; }
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            string symbol;
            if (Own == true)
            {
                symbol = "X";
            }
            else if (Own == false)
            {
                symbol = "O";
            }
            else
            {
                symbol = " ";
            }
            return $"[{symbol}]";
        }
 
        internal void MarkCell(bool userOrAI)
        {
            Own = userOrAI;
        }
    }
}
