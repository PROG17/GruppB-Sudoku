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

        // Constructor
        public SudokuGame(string filename)
        {
            
            Grid gameGrid = new Grid(ReadFromFile(filename));
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


        private static void CreateGrid()
        {
            
        }
    }
}
