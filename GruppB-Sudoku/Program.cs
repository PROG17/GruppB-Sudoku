﻿using System;
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
            string sudoku1 = "403870060000540002700690100009008050301905607080100300004057006600089000020016503";
            string sudoku2 = "037060000205000800006908000000600024001503600650009000000302700009000402000050360";
            string sudoku3 = "000000601003900750060308040004000080950184027030000500010703060087002400302000000";
            Console.WriteLine("NEW GAME");
            SudokuGame sudoku = new SudokuGame(sudoku2);
            sudoku.SolveSudoku();
        }
    }
}
