using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppB_Sudoku.Entities
{
    class Cell
    {
        // Global Variable
        public static int cellCount = 0;

        // Fields
        public int xPosition;
        public int yPosition;
        private int number;
        bool solved;


        List<int> possibleNums = new List<int>();

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

            cellCount++;
        }

        private void MakeListIfZero()
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
        public void TestCell()
        {
            if (!solved)
            {
                foreach (var item in possibleNums)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            else
                Console.WriteLine(number);
        }

    }

}
