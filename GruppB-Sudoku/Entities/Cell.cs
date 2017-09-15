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
        int[] value;
        bool solved;

        Box myBox;

        // Constructor
        public Cell(int xPosition, int yPosition, int[] value, Box myBox)
        {
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.value = value;
            
            this.myBox = myBox;

            solved = false;
        }


    }

}
