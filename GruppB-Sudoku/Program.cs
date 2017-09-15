using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppB_Sudoku
{   
    class Program
    {
        static void Main(string[] args)
        {
            string filename = Environment.CurrentDirectory + @"\unsolvedsodoku.txt";
            var sodoku = new SudokuGame(filename);
        }
    }
}
