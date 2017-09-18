using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppB_Sudoku.Entities
{
    public class Grid
    {
        //Fields
        Cell[,] cells = new Cell[9, 9];
        //Box[,] boxes = new Box[3,3];

        //Constructor
        public Grid(string sudokuString)
        {
            //MakeBoxes();
            MakeGridFromString(sudokuString);
            TestPrint();
        }
        private void MakeGridFromString(string sudokuString)
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    // Bad Practice att ändra enstaka element i en sträng
                    //int number = int.Parse(sudokuString.ElementAt(Cell.cellCount).ToString()); 
                    int number = sudokuString[x * 9 + y] - '0';
                    cells[x, y] = new Cell(x, y, number);
                    cells[x, y].TestCell();
                }
            }
        }


        private int[] DetermineMyBox(int xPosition, int yPosition)
        {
            // Divide by 3 to get starting position of box
            int xPos = xPosition/3;
            int yPos = yPosition/3;
            int[] xyPos = { xPos, yPos };

            return xyPos;
            // Nybörjaraktigt att lösa lätta beräkningar med if satser
            //if (xPosition < 3)
            //{
            //    xPos = 0;
            //}
            //else if (xPosition < 6)
            //{
            //    xPos = 1;
            //}
            //else
            //{
            //    xPos = 2;
            //}

            //if (yPosition < 3)
            //{
            //    yPos = 0;
            //}
            //else if (yPosition < 6)
            //{
            //    yPos = 1;
            //}
            //else
            //{
            //    yPos = 2;
            //}


        }

        private void TestPrint()
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (cells[x, y].number == 0)
                    {
                        Console.Write("0 ");
                    }
                    else
                    {
                        Console.Write($"{cells[x, y].number} ");
                    }
                }
                Console.WriteLine();
            }
        }


        //private void MakeBoxes()
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        for (int j = 0; j < 3; j++)
        //        {
        //            boxes[i, j] = new Box(i * 3, j * 3);
        //        }
        //    }
        //}

    }
}
