using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheesBoardModel
{
    public class Board
    {
        // in mod normal este de 8X8
        public int Size { get; set; }

        public Cell[,] theGrid { get; set; }

        //constructorul 
        public Board(int s)
        {
            //dimensiunea initial este in variabila s
            Size = s;

            //creez un sir in 2D care este tipul celulei
            theGrid = new Cell[Size, Size];

            //umplu array ul cu celule nou, fiecare cu cordonate unice
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }

            }
        }
      
        public void MarkNextLegalMoves(Cell currentCell, string chessPiece)
        {
            //pas 1 - fac clear la toate miscarile anterioare
            for(int i = 0; i< Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    theGrid[i, j].LegalNextMove = false;
                    theGrid[i, j].IsOccupied = false;
                }
            }

            //pas 2- gasesc toate miscarile legale si le tin minte ca fiind "legale"

            switch (chessPiece)
            {
                case "Knight":
                    //if(isSafe(currentCell.RowNumber - 2, currentCell.ColumnNumber-1))
                    theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].LegalNextMove = true;

                    break;

                case "King":
                    theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber -1 ].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber ].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber , currentCell.ColumnNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber , currentCell.ColumnNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber -1, currentCell.ColumnNumber - 1].LegalNextMove = true;

                    break;

                case "Rock":
                    for (int row2 = currentCell.RowNumber + 1; row2 < theGrid.GetLength(0); row2++)
                    { 
                        theGrid[row2, currentCell.ColumnNumber].LegalNextMove = true;
                    }
                    for (int row2 = currentCell.RowNumber - 1; row2 >= 0; row2--)
                    {
                        theGrid[row2, currentCell.ColumnNumber].LegalNextMove = true;
                    }
                    for (int col2 = currentCell.ColumnNumber + 1; col2 < theGrid.GetLength(1); col2++)
                    {  
                        theGrid[currentCell.RowNumber, col2].LegalNextMove = true;
                    }
                    for (int col2 = currentCell.ColumnNumber - 1; col2 >= 0; col2--)
                    {   
                        theGrid[currentCell.RowNumber, col2].LegalNextMove = true;
                    }
                    break;

                case 
                    "Bishop":
                    int row, col;

                    // Top-Right diagonal
                    row = currentCell.RowNumber - 1;
                    col = currentCell.ColumnNumber + 1;
                    while (row >= 0 && col < theGrid.GetLength(1))
                    {
                        theGrid[row, col].LegalNextMove = true;
                        row--;
                        col++;
                    }

                    // Top-Left diagonal
                    row = currentCell.RowNumber - 1;
                    col = currentCell.ColumnNumber - 1;
                    while (row >= 0 && col >= 0)
                    {
                        theGrid[row, col].LegalNextMove = true;
                        row--;
                        col--;
                    }

                    // Bottom-Right diagonal
                    row = currentCell.RowNumber + 1;
                    col = currentCell.ColumnNumber + 1;
                    while (row < theGrid.GetLength(0) && col < theGrid.GetLength(1))
                    {
                        theGrid[row, col].LegalNextMove = true;
                        row++;
                        col++;
                    }

                    // Bottom-Left diagonal
                    row = currentCell.RowNumber + 1;
                    col = currentCell.ColumnNumber - 1;
                    while (row < theGrid.GetLength(0) && col >= 0)
                    {
                        theGrid[row, col].LegalNextMove = true;
                        row++;
                        col--;
                    }

                    break;

                case
                    "Quenn":
                    // Rook-like moves
                    for (int row2 = currentCell.RowNumber + 1; row2 < theGrid.GetLength(0); row2++)
                    {
                        theGrid[row2, currentCell.ColumnNumber].LegalNextMove = true;
                    }
                    for (int row2 = currentCell.RowNumber - 1; row2 >= 0; row2--)
                    {
                        theGrid[row2, currentCell.ColumnNumber].LegalNextMove = true;
                    }
                    for (int col2 = currentCell.ColumnNumber + 1; col2 < theGrid.GetLength(1); col2++)
                    {
                        theGrid[currentCell.RowNumber, col2].LegalNextMove = true;
                    }
                    for (int col2 = currentCell.ColumnNumber - 1; col2 >= 0; col2--)
                    {
                        theGrid[currentCell.RowNumber, col2].LegalNextMove = true;
                    }

                    // Bishop-like moves
                    int row3, col3;

                    // Top-Right diagonal
                    row3 = currentCell.RowNumber - 1;
                    col3 = currentCell.ColumnNumber + 1;
                    while (row3 >= 0 && col3 < theGrid.GetLength(1))
                    {
                        theGrid[row3, col3].LegalNextMove = true;
                        row3--;
                        col3++;
                    }

                    // Top-Left diagonal
                    row = currentCell.RowNumber - 1;
                    col = currentCell.ColumnNumber - 1;
                    while (row >= 0 && col >= 0)
                    {
                        theGrid[row, col].LegalNextMove = true;
                        row--;
                        col--;
                    }

                    // Bottom-Right diagonal
                    row = currentCell.RowNumber + 1;
                    col = currentCell.ColumnNumber + 1;
                    while (row < theGrid.GetLength(0) && col < theGrid.GetLength(1))
                    {
                        theGrid[row, col].LegalNextMove = true;
                        row++;
                        col++;
                    }

                    // Bottom-Left diagonal
                    row = currentCell.RowNumber + 1;
                    col = currentCell.ColumnNumber - 1;
                    while (row < theGrid.GetLength(0) && col >= 0)
                    {
                        theGrid[row, col].LegalNextMove = true;
                        row++;
                        col--;
                    }

                    break;


                default:
                    break;

            }
            theGrid[currentCell.RowNumber, currentCell.ColumnNumber].IsOccupied = true;
        }
    }
}
