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
        static Cell[,] cells = new Cell[9, 9];
        static Box[] boxes = new Box[9];

        //Constructor
        public Grid(string sudokuString)
        {
            //MakeBoxes();
            MakeGridFromString(sudokuString);
            TestPrint();
        }
        private static void MakeGridFromString(string sudokuString)
        {
            Box testBox = new Box();
            int[] test = { 1 };

            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    cells[x, y] = new Cell(x, y, test,testBox);
                }
            }
        }
        private static void TestPrint()
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (cells[x, y].Numbers.Length > 1)
                    {
                        Console.Write("0 ");
                    }
                    else
                    {
                        Console.Write($"{cells[x, y].Numbers[0]} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
