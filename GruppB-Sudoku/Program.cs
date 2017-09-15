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
            string filename = @"C:\Users\hobbo\Documents\Program C#\Projects\GruppB-Sudoku\GruppB-Sudoku\unsolvedsodoku.txt";
            var sodoku = new SodokuGame(filename);
        }
    }
}
