using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppB_Sudoku.Entities
{
    class Cell
    {
        // Fields
        int xPosition;
        int yPosition;
        private int[] numbers;
        bool solved;

        Box myBox;

        // Properties
        public int[] Numbers { get => numbers; private set => numbers = value; }

        // Constructor
        public Cell(int xPosition, int yPosition, int[] value, Box myBox)
        {
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            Numbers = value;
            
            this.myBox = myBox;

            solved = false;
        }

        
    }

}
