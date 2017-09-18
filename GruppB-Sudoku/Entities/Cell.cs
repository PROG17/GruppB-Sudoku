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
        private static int number;
        static bool solved;
        //skapa en global variabel för antal cells
       static List<int> possibleNums = new List<int>();

        Box myBox;

        // Properties
        public int Number { get => number; private set => number = value; }

        // Constructor
        public Cell(int xPosition, int yPosition, int value, Box myBox)
        {
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            Number = value;
            this.myBox = myBox;
            solved = false;

            MakeListIfZero();


        }
        private static void MakeListIfZero()
        {
            if (number == 0)
            {
                int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                possibleNums.AddRange(numbers);
            }
            else
            {
                solved = true;
            }
        }

    }

}
