using CheesBoardModel;
using System;

namespace Chess
{
    class Program
    {
        static Board myBoard = new Board(8);
        static void Main(string[] args)
        {
            // tabla goala de sah
            printBoard(myBoard);
            // introdu coordonatele unde sa fie pozitionata piesa

            Cell currentCell = setCurrentCell();
            currentCell.IsOccupied = true;
            // calculeaza toate miscarile legale

            Console.WriteLine("Enter the piece:");
            String piece = Console.ReadLine();
            myBoard.MarkNextLegalMoves(currentCell, piece);
            // print pentru tabla de sah

            printBoard(myBoard);

            Console.ReadLine();
        }

        private static Cell setCurrentCell()
        {
            //luam coordonatele x si y de la user si le trimitem la grid
            Console.WriteLine("Enter the row number:");
            int currentRow = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the column number:");
            int currentColumn = int.Parse(Console.ReadLine());

            //myBoard.theGrid[currentRow, currentColumn].IsOccupied = true;
            return myBoard.theGrid[currentRow, currentColumn];

        }

        private static void printBoard(Board myBoard)
        {
            // print tabla de saf in consola
            for( int i=0; i< myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    Cell c = myBoard.theGrid[i, j];
                    if(c.IsOccupied == true)
                    {
                        Console.Write("X");

                    }
                    else if (c.LegalNextMove == true)
                    {
                        Console.Write("+");

                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------------------------------------");
        }
    }
}
