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
        Grid gameGrid;
        bool aCellHasChanged = false;
        List<Grid> possibleSolutions = new List<Grid>();

        // Constructor
        public SudokuGame(string sudoku)
        {
            gameGrid = new Grid(sudoku);
            //PrintSudoku();
        }

        public void PlayGame()
        {
            bool solvable = SolveSudoku(); // Returnar false om det är olösligt
            gameGrid.TestPrint();
            if (solvable == false)
            {
                Console.WriteLine("Unsolvable!");
            }
            else
            {
                GuessSolution();
            }
        }

        public void GuessSolution()
        {
            // Create String from Grid 
            string currentSudoku = "";
            foreach (List<int> val in gameGrid.cells)
            {
                if (val.Count > 1)
                {
                    currentSudoku += "0";
                }
                else
                    currentSudoku += val.ElementAt(0);
            }

            // Loopa igenom Grid
            for (int x = 0; x < 9; x++)
            {
                int currentCell = 0; // x*9+y;
                for (int y = 0; y < 9; y++)
                {
                    // Hitta första olösta cellen
                    if (gameGrid.cells[x, y].Count > 1) 
                    {
                        for (int i = 0; i < gameGrid.cells[x, y].Count; i++) // Sätt in en av possibleNumbers i sodoku lösningen
                        {
                            // Sätter in ett av värdena från en cells possibleNumbers lista 
                            StringBuilder sb = new StringBuilder(currentSudoku);
                            char ch = (char)(48 + gameGrid.cells[x, y][i]); 
                            sb[currentCell] = ch;
                            string modifiedSudoku = sb.ToString();

                            // Skapar en ny SodokuGame med gissningen
                            SudokuGame sudokuGuess = new SudokuGame(modifiedSudoku);
                            sudokuGuess.PlayGame(); // Måste kunna hoppa ut ur loopen när den behöver gissa igen.
                        }
                        // Om inget av försöken lyckades är sudokun olöslig, man behöver inte testa alla celler, endast en.
                    }
                    currentCell++;
                }
            }
        }

        public bool SolveSudoku() //returns false if unsolvable
        {
            bool cellIsEmpty = false;
            bool hasUnsolvedCells;

             // För att avgöra att vi behöver börja gissa
            
            do // while (hasUnsolvedCells)
            {
                aCellHasChanged = false;
                hasUnsolvedCells = false;
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
                            //If SolveCell() is an unsolvable cell it returns true
                            cellIsEmpty = SolveCell(gameGrid.cells[xPos, yPos], tempNumbers);
                            if (cellIsEmpty)
                            {
                                return false;
                                // Detta sudoku är olösligt!
                            }
                        }
                    }
                }
                if (aCellHasChanged == false)
                {
                    GuessSolution();
                }
            } while (hasUnsolvedCells);
            return true;
        }

        // Compare possible numbers in cell with numbers from that cells row/col/box and remove them
        public bool SolveCell(List<int> possibleNumbers, List<int> tempNumbers)
        {
            bool cellIsEmpty = false;

            if (possibleNumbers.Count > 1)
            {
                foreach (int number in tempNumbers)
                {
                    if (possibleNumbers.Contains(number))
                    {
                        possibleNumbers.Remove(number);
                        aCellHasChanged = true;

                        if (possibleNumbers.Count == 0)
                        {
                            cellIsEmpty = true; // Om listan av möjliga värden är tom
                        }

                    }
                }
            }
            foreach (var item in possibleNumbers)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            return cellIsEmpty;

        }

    }
}
