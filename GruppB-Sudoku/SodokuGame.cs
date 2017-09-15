using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GruppB_Sudoku
{
    public class SodokuGame
    {
        // Fields
        private static string _sodoku;

        // Constructor
        public SodokuGame(string filename)
        {
            ReadFromFile(filename);
            PrintSodoku();
            
        }

        private static string ReadFromFile(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                _sodoku = reader.ReadLine();
            }
            return _sodoku;
        }

        private static void PrintSodoku()
        {
            Console.WriteLine(_sodoku);
        }


        private static void CreateGrid()
        {
            
        }
    }
}
