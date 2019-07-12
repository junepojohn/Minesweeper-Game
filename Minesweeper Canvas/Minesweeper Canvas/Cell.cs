using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper_Canvas
{
    public class Cell
    {
        public bool isRevealed = false;
        public bool isBomb;
        public bool isMarked = false;
        public bool isFinal = false;

        public Cell(bool bomb)
        {
            isBomb = bomb;
        }
    }
}
