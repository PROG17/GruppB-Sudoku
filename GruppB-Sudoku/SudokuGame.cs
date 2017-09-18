using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GruppB_Sudoku.Entities;

namespace GruppB_Sudoku
{
    public class SudokuGame
    {
        // Fields
        private static string sudoku;
        Grid gameGrid;
        // Constructor
        public SudokuGame(string filename)
        {
            gameGrid = new Grid(ReadFromFile(filename));
            PrintSudoku();
        }

        private static string ReadFromFile(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                sudoku = reader.ReadLine();
            }
            return sudoku;
        }

        private static void PrintSudoku()
        {
            Console.WriteLine(sudoku);
        }

        public void SolveGrid()
        {

            foreach (var cell in gameGrid.cells)
            {
                List<int> tempNumbers = new List<int>();
                if (cell.number == 0)
                {
                    //check row, col, box value compare with possible nrs
                    for (int y = 0; y < 9; y++) // row
                    {
                        tempNumbers.Add(gameGrid.cells[cell.xPosition, y].number);
                    }
                    for (int x = 0; x < 9; x++) // row
                    {
                        tempNumbers.Add(gameGrid.cells[x, cell.yPosition].number);
                    }

                    //int[] boxStartPosition = gameGrid.DetermineMyBox(cell.xPosition, cell.yPosition);
                    int xPos = cell.xPosition / 3;
                    int yPos = cell.yPosition / 3;

                    for (int x = xPos*3; x < xPos * 3 + 3; x++)
                    {

                        for (int y = yPos*3; y < yPos * 3 + 3; y++)
                        {
                           Console.WriteLine((xPos + x) + " " + (yPos + y));
                            tempNumbers.Add(gameGrid.cells[x, y].number);
                        }
                    }
                }
                foreach (var item in tempNumbers)
                {
                    if (item != 0)
                    {
                        Console.Write(item);
                    }

                }
                Console.WriteLine();
            }

        }

    }
}
