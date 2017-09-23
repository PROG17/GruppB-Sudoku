using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GruppB_Sudoku
{
    public class SudokuGame
    {
        // Fields
        private int[,] cells = new int[9, 9];
        private bool noCellsChanged = true;

        // Constructor
        public SudokuGame(string sudoku)
        {
            MakeGridFromString(sudoku);
            TestPrint();
        }

        public bool SolveSudoku()
        {
            bool hasUnsolvedCells;
            do
            { // while (hasUnsolvedCells)
                hasUnsolvedCells = false;
                noCellsChanged = true; // No cells have been changed yet
                for (int xPos = 0; xPos < 9; xPos++)
                {
                    for (int yPos = 0; yPos < 9; yPos++)
                    {
                        if (cells[xPos, yPos] == 0) // If cell is unsolved
                        {
                            hasUnsolvedCells = true;
                            // Try to solve cell and if cell is unsolvable return false
                            bool cellIsEmpty = SolveCell(xPos, yPos);
                            if (cellIsEmpty)
                            {
                                return false;
                            }
                        }
                    }
                }
                // Has found all possible logical solutions and the sudoku hasnt been solved yet.
                if (noCellsChanged && !hasUnsolvedCells) // Solved without guesses needed
                {
                    Console.WriteLine("SOLVED IN SOLVESUDOKU");
                    TestPrint();
                    return true;
                }
                else if (noCellsChanged) // Needs to make guesses to solve sudoku
                {
                    bool solved = GuessSolution();
                    if (solved)
                    {
                        return true; // Solved
                    }
                    return false; //if all guesses fail this version is unsolvable.
                }
                
            } while (hasUnsolvedCells);
            //Console.WriteLine("SOLVED");
            //TestPrint();
            return true;
        }

        public bool GuessSolution()
        {
            // Find the first unsolved cell
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (cells[x, y] == 0)
                    {
                        List<int> possibleNumbers = GetRowColBoxNumbers(x, y);

                        // Attempt to solve the sudoku by using one of the possible numbers of the unsolved cell
                        for (int i = 0; i < possibleNumbers.Count; i++)
                        {
                            StringBuilder sb = new StringBuilder(MakeStringFromGrid());
                            char ch = (char)(48 + possibleNumbers[i]);
                            sb[(x * 9) + y] = ch;
                            string modifiedSudoku = sb.ToString();

                            // Make a new SudokuGame with the guess inserted in to the grid
                            SudokuGame sudokuGuess = new SudokuGame(modifiedSudoku);
                            bool solved = sudokuGuess.SolveSudoku(); // Try to solve the new sudoku.
                            if (solved)
                            {
                                return true; // Solved 
                            }
                        }
                        Console.WriteLine("OUT OF GUESSES - RETURN TO LAST");
                        return false;
                    }
                }
            }
            return true;
        }


        // look at possible numbers for a cell to solve a cell
        private bool SolveCell(int xPos, int yPos)
        {
            List<int> possibleNumbers = GetRowColBoxNumbers(xPos, yPos);
            if (cells[xPos, yPos] == 0)
            {
                if (possibleNumbers.Count == 1) // If cell has a logial solution
                {
                    cells[xPos, yPos] = possibleNumbers.ElementAt(0); // Set the last remaining number as the cell value
                    noCellsChanged = false;
                    Console.WriteLine("CELL CHANGED");
                }
                else if (possibleNumbers.Count == 0) // if all numbers are already in use the sudoku is unsolvable
                {
                    Console.WriteLine("FAILED GUESS");
                    return true; // If there are no possible numbers the sudoku is unsolvable
                }
            }
            return false;
        }

        //check relevant row, col, box values for a cell
        private List<int> GetRowColBoxNumbers(int xPos, int yPos)
        {
            List<int> usedNumbers = new List<int>();

            for (int y = 0; y < 9; y++) // row
            {
                // if solved cell take cell value add to list of tempnumbers
                if (cells[xPos, y] != 0)
                {
                    int currentNumber = cells[xPos, y];
                    if (!usedNumbers.Contains(currentNumber))
                    {
                        usedNumbers.Add(currentNumber);
                    }
                }
            }

            for (int x = 0; x < 9; x++) // col
            {
                if (cells[x, yPos] != 0)
                {
                    int currentNumber = cells[x, yPos];
                    if (!usedNumbers.Contains(currentNumber))
                    {
                        usedNumbers.Add(currentNumber);
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
                    int currentNumber = cells[x, y];
                    if (!usedNumbers.Contains(currentNumber) && cells[x, y] != 0)
                    {
                        usedNumbers.Add(currentNumber);
                    }
                }
            }

            // Start with possibleNumbers 1-9 and remove the usedNumbers
            int[] allNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> possibleNumbers = allNumbers.ToList<int>();
            foreach (var number in usedNumbers)
            {
                possibleNumbers.Remove(number); // Remove used numbers from possible numbers list
            }
            return possibleNumbers;
        }



        private void MakeGridFromString(string sudokuString)
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    int number = sudokuString[x * 9 + y] - '0';
                    cells[x, y] = number;
                }
            }
        }
        private string MakeStringFromGrid()
        {
            string currentSudoku = "";
            foreach (var number in cells)
            {
                currentSudoku += number;
            }
            return currentSudoku;
        }

        public void TestPrint()
        {
            //for (int x = 0; x < 9; x++)
            //{
            //    if (x % 3 ==0 )
            //    {
            //        Console.WriteLine("- - - - - - - - - - -");
            //    }
            //    for (int y = 0; y < 9; y++)
            //    {
            //        if (y%3 == 0)
            //        {
            //            Console.Write("|");
            //        }
            //        Console.Write(cells[x, y] + " ");
            //    }
            //    Console.WriteLine("|");
            //}
            //Console.WriteLine("- - - - - - - - - - - \n");


            Console.WriteLine(MakeStringFromGrid());
        }

    }
}
