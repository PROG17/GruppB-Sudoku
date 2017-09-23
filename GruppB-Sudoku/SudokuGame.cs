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

        // Tries to solve a sudoku grid and returns false if it is unsolvable
        public bool SolveSudoku()
        {
            while(true) // Go until a value is returned
            {
                bool hasUnsolvedCells = false;
                noCellsChanged = true; // No cells have been changed yet, gets value in SolveCell() method
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
                                return false; // This grid is unsolvable, cell with 0 possible numbers
                            }
                        }
                    }
                }
                
                if (!hasUnsolvedCells) // No unsolved cells remain, the grid is solved.
                {
                    Console.WriteLine("SUDOKU SOLVED:");
                    TestPrint();
                    return true;
                }
                else if (noCellsChanged) // Found all possible logical solutions and the sudoku hasnt been solved yet
                {
                    Console.WriteLine("ALL LOGICAL SOLUTIONS FOUND - FIND AN EMPTY CELL AND GUESS");
                    bool solved = GuessSolution();
                    if (solved)
                    {
                        return true; // Grid was solved after making a guess
                    }
                    return false; // When all guesses failed this grid is unsolvable
                }
            } 
        }

        // Finds an unsolved cell and assumes a value for it, then attempts to solve a grid
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

                        // Attempt to solve the sudoku by using each of the possible numbers of the unsolved cell
                        for (int i = 0; i < possibleNumbers.Count; i++)
                        {
                            StringBuilder sb = new StringBuilder(MakeStringFromGrid());
                            char ch = (char)(48 + possibleNumbers[i]);
                            sb[(x * 9) + y] = ch;
                            string modifiedSudoku = sb.ToString();

                            Console.WriteLine("GUESS #" + (i + 1) + "/" + possibleNumbers.Count() + ":");
                            
                            // Make a new SudokuGame with the guess inserted in to the grid
                            SudokuGame sudokuGuess = new SudokuGame(modifiedSudoku);
                            bool solved = sudokuGuess.SolveSudoku(); // Try to solve the new sudoku
                            if (solved)
                            {
                                return true; // Solved the new sudoku
                            }
                        }
                        Console.WriteLine("OUT OF POSSIBLE NUMBERS - RETURN TO PREVIOUS EMPTY CELL AND KEEP GUESSING");
                        return false;
                    }
                }
            }
            return true; // Unreachable, this whole method is only called if there are unsolved cells.
        }


        // Check possible numbers for a cell and "solve" it
        private bool SolveCell(int xPos, int yPos)
        {
            List<int> possibleNumbers = GetRowColBoxNumbers(xPos, yPos);
            if (cells[xPos, yPos] == 0)
            {
                if (possibleNumbers.Count == 1) // If cell has a logial solution
                {
                    cells[xPos, yPos] = possibleNumbers.ElementAt(0); // Set the last remaining number as the cell value
                    noCellsChanged = false;
                }
                else if (possibleNumbers.Count == 0) // If there are no possible numbers this cell & grid is unsolvable
                {
                    Console.WriteLine("INVALID GUESS - TRY NEXT POSSIBLE NUMBER");
                    return true; 
                }
            }
            return false;
        }

        // Check relevant numbers in row/col/box for a cell
        private List<int> GetRowColBoxNumbers(int xPos, int yPos)
        {
            List<int> usedNumbers = new List<int>();

            for (int y = 0; y < 9; y++) // Check row
            {
                // if solved cell take cell value add to list of tempnumbers
                if (cells[xPos, y] != 0)
                {
                    int currentNumber = cells[xPos, y];
                    if (!usedNumbers.Contains(currentNumber)) // Only add new numbers
                    {
                        usedNumbers.Add(currentNumber);
                    }
                }
            }

            for (int x = 0; x < 9; x++) // Check col
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
            // Find the "starting position" of the box
            int xxPos = (xPos / 3) * 3; // Divide by 3 to remove decimal values then multiply by 3.
            int yyPos = (yPos / 3) * 3;

            for (int x = xxPos; x < xxPos + 3; x++) // Check box
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

            // Start with possibleNumbers 1-9 and remove the usedNumbers to get the remaining possible numbers
            int[] allNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> possibleNumbers = allNumbers.ToList<int>();
            foreach (var number in usedNumbers)
            {
                possibleNumbers.Remove(number); // Remove used numbers from possible numbers list
            }
            return possibleNumbers;
        }

        // Parse string to grid
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

        // Parse grid to string
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
