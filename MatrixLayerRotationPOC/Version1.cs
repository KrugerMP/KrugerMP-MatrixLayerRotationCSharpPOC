using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixLayerRotationPOC
{
    public static class Version1
    {
        public static void matrixRotation(List<List<int>> matrix, int r)
        {
            if (r != 0)
            {
                List<List<int>> final_matrix = matrix;

                int matrixCountRow = matrix.Count();
                int matrixCountCol = matrix[0].Count();

                int fromTopBottom = 0;


                for (int box = 0; box < (matrix.Count() / 2) - 1 + 1; box++)
                {
                    // Build a queue that we can manipulate : Done
                    List<int> boxLineList = new List<int>();
                    fromTopBottom++;

                    // Add the first row of the boxes to the list  : Done
                    int topRow = box;
                    for (int col = 0 + topRow; col < matrixCountCol - topRow; col++)
                    {
                        boxLineList.Add(matrix[topRow][col]);
                    }

                    // Add the right column to the list : Done
                    int rightColumn = matrixCountCol - box;
                    for (int row = (0 + box) + 1; row < matrixCountRow - box; row++)
                    {
                        boxLineList.Add(matrix[row][rightColumn - 1]);
                    }

                    // Add the bottom row to the list : Done
                    int bottomRow = matrixCountRow - box;
                    for (int col = (matrixCountCol - box) - 1; col > box; col--)
                    {
                        boxLineList.Add(matrix[bottomRow - 1][col - 1]);
                    }

                    // Add the left column to the list : Done
                    int leftColumn = box;
                    int totalRowWork = fromTopBottom * 2;
                    for (int row = (matrixCountRow - totalRowWork) + box; row >= leftColumn + fromTopBottom - box; row--)
                    {
                        boxLineList.Add(matrix[row][leftColumn]);
                    }

                    // -------------------------------------------------------------------------------------------
                    // Now alter the list to match the amount it needs to turn : Done
                    for (int turn = 0; turn < r; turn++)
                    {
                        int firstEntry = boxLineList.First();
                        boxLineList.RemoveAt(0);
                        boxLineList.Add(firstEntry);
                    }
                    // -------------------------------------------------------------------------------------------

                    // Now load it back into the new matrix
                    int countInList = 0;

                    // Fix Top Row : Done
                    for (int col = 0 + topRow; col < matrixCountCol - topRow; col++)
                    {
                        final_matrix[topRow][col] = boxLineList[countInList];
                        countInList++;
                    }
                    // Fix the Rigth column : Done
                    for (int row = (0 + box) + 1; row < matrixCountRow - box; row++)
                    {
                        final_matrix[row][rightColumn - 1] = boxLineList[countInList];
                        countInList++;
                    }
                    // Fix the bottom row : Done
                    for (int col = (matrixCountCol - box) - 1; col > box; col--)
                    {
                        final_matrix[bottomRow - 1][col - 1] = boxLineList[countInList];
                        countInList++;
                    }
                    // Fix the left column : Done
                    for (int row = (matrixCountRow - totalRowWork) + box; row >= leftColumn + fromTopBottom - box; row--)
                    {
                        final_matrix[row][leftColumn] = boxLineList[countInList];
                        countInList++;
                    }
                }

                PrintMatrix(final_matrix);
            }
            else
            {
                PrintMatrix(matrix);
            }
        }
        static void PrintMatrix(List<List<int>> matrix)
        {
            // Write in sqaure form : Done
            foreach (List<int> row in matrix)
            {
                row.ForEach(x => { Console.Write(x + "\t"); });
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
