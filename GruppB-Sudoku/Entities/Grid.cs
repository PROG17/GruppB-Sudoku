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
        public List<int>[,] cells = new List<int>[9, 9];

        //Constructor
        public Grid(string sudokuString)
        {
            MakeGridFromString(sudokuString);
            TestPrint();
        }
        private void MakeGridFromString(string sudokuString)
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    List<int> possibleNumbers = new List<int>();
                    int number = sudokuString[x * 9 + y] - '0';
                    if (number == 0)
                    {
                        int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                        
                        possibleNumbers.AddRange(nums);
                    }
                    else
                    {
                        possibleNumbers.Add(number);
                    }

                    cells[x, y] = possibleNumbers;
                    //cells[x, y] = new Cell(x, y, number);
                    //cells[x, y].TestCell();
                }
            }
        }

        public void TestPrint()
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (cells[x, y].Count > 1)
                    {
                        Console.Write("0 ");
                    }
                    else
                    {
                        Console.Write($"{cells[x,y].ElementAt(0)} ");
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
