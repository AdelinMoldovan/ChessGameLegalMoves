using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheesBoardModel
{
    public class Cell
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }

        public bool IsOccupied { get; set; }

        public bool LegalNextMove { get; set; }

        public Cell( int x, int y)
        {
            RowNumber = x;
            ColumnNumber = y;

        }

        

    }
}
