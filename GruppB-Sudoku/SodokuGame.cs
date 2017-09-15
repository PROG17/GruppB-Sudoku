using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GruppB_Sudoku
{
    class SodokuGame
    {
        private static string ReadFromFile(string filename)
        {
            string sodoku;
            using (StreamReader reader = new StreamReader(filename))
            {
                sodoku = reader.ReadLine();
            }
            return sodoku;
        }

        private static void CreateGrid()
        {
            
        }
    }
}
