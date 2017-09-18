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
        public int xPosition;
        public int yPosition;
        public int number;
        bool solved;
        List<int> possibleNums = new List<int>();

        // Constructor
        public Cell(int xPosition, int yPosition, int value)
        {
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            number = value;
            solved = false;

            MakeListIfZero();
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
