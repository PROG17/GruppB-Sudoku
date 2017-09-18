using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppB_Sudoku.Entities
{
    
    class Box
    {
        int xPosition;
        int yPosition;
        
        public Box(int xPosition, int yPosition)
        {
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }
    }
}
