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

        public void PlayGame()
        {
            bool unSolved = true;
            while (unSolved)
            {
                unSolved = SolveGrid();
            }
            gameGrid.TestPrint();
        }
        public void GuessSolution()
        {

        }
        public bool SolveGrid()//returns true when game is solved
        {
            bool cellHasChanged = false;
            bool hasUnsolvedCells = false;
            for (int xPos = 0; xPos < 9; xPos++)
            {
                for (int yPos = 0; yPos < 9; yPos++)
                {
                    List<int> tempNumbers = new List<int>();

                    // If cell is unsolved
                    if (gameGrid.cells[xPos, yPos].Count > 1)
                    {
                        hasUnsolvedCells = true;
                        //check row, col, box value compare with possible nrs
                        for (int y = 0; y < 9; y++) // row
                        {
                            // if solved cell take cell value add to list of tempnumbers
                            if (gameGrid.cells[xPos, y].Count == 1)
                            {
                                int currentNumber = gameGrid.cells[xPos, y].ElementAt(0);
                                if (!tempNumbers.Contains(currentNumber))
                                {
                                    tempNumbers.Add(currentNumber);
                                }
                            }
                        }

                        for (int x = 0; x < 9; x++) // col
                        {
                            if (gameGrid.cells[x, yPos].Count == 1)
                            {
                                int currentNumber = gameGrid.cells[x, yPos].ElementAt(0);
                                if (!tempNumbers.Contains(currentNumber))
                                {
                                    tempNumbers.Add(currentNumber);
                                }
                            }
                        }
                        // Divide by 3 to remove decimal values then multiply by 3.
                        int xxPos = (xPos / 3) * 3;
                        int yyPos = (yPos / 3) * 3;

                        //Box check
                        for (int x = xxPos; x < xxPos + 3; x++)
                        {
                            for (int y = yyPos; y < yyPos + 3; y++)
                            {
                                int currentNumber = gameGrid.cells[x, y].ElementAt(0);
                                if (!tempNumbers.Contains(currentNumber) && gameGrid.cells[x, y].Count == 1)
                                {
                                    tempNumbers.Add(currentNumber);
                                }
                            }
                        }
                        //If SolveCell() changes any numbers it returns true
                        cellHasChanged = SolveCell(gameGrid.cells[xPos, yPos], tempNumbers);
                    }
                }
            }
            if (!hasUnsolvedCells)
            {
                return false;
            }
            //else if (!hasChanged && hasUnsolvedCells)
            //{
            //    GuessSolution();
            //    return true;

            //}
            else return true;

        }
        // Compare possible numbers in cell with numbers from that cells row/col/box and remove them
        public bool SolveCell(List<int> possibleNumbers, List<int> tempNumbers)
        {
            bool changed = false;

            if (possibleNumbers.Count > 1)
            {
                foreach (int number in tempNumbers)
                {
                    if (possibleNumbers.Contains(number))
                    {
                        possibleNumbers.Remove(number);
                        changed = true;
                    }
                }
            }
            foreach (var item in possibleNumbers)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            return changed;

        }

    }
}
