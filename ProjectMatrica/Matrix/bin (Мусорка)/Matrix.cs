//
// // See https://aka.ms/new-console-template for more information
// using System;
// using System.Globalization;
//
// int[,] matrix = new int[3,3] {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}};
//
// Matrix matrixObj = new Matrix(matrix);
// // matrixObj.workWithMatrica();
// // matrixObj.showMatrix();
// //
// matrixObj.addRow([1, 4, 3, 4]);
// matrixObj.showMatrix();
// // matrixObj.delRow(4);
// // matrixObj.showMatrix();
//
//
//
// // class matrixController
// // {
//     // private string consoleText = "Выберите одну из следующих комманд:\n" +
//     //                              "Show - Вывести матрицу в консоль.\n" +
//     //                              "Add - добавить строку\n" +
//     //                              "Update - изменить сроку по номеру\n";
//     // private enum Operation
//     // {
//     //     Show,
//     //     Add,
//     //     Update
//     // }
//     // public void workWithMatrica()
//     // {
//     //     Console.WriteLine(consoleText);
//     //     string command = Console.ReadLine();
//     //     
//     //     Operation operation = checkCommad(command);
//     //
//     //     if (operation == Operation.Add)
//     //     {
//     //         Console.WriteLine("Да");
//     //     }
//     //     else
//     //     {
//     //         Console.WriteLine("Нет");
//     //     }
//     //
//     //
//     // }
//     //
//     // private Operation checkCommad(string command)
//     // {
//     //     string strCommand = command.ToLower();
//     //     
//     //     // Вродебы переводит первуюбукву к верхниму регистру
//     //     strCommand = char.ToUpper(strCommand[0]) + strCommand.Substring(1);
//     //     
//     //     
//     //     Console.WriteLine(strCommand);
//     //     
//     //     
//     //
//     //
//     //     return Operation.Show;
//     // }
// // }
//
//
//
//
// class Matrix
// {
//     
//     private matrixPrinter matrixPrinter;
//     private matrixChanger matrixChanger;
//     
//     private int[,] matrix;
//
//     
//     public Matrix(int[,] newMatrix)
//     { 
//         matrix = newMatrix;;
//         matrixChanger = new matrixChanger();
//         matrixPrinter = new matrixPrinter();
//     }
//
//     public void addRow(int[] newRow)
//     {
//         matrix = matrixChanger.addRow(matrix, newRow);
//     }
//
//     public void delRow(int newRow)
//     {
//         matrix = matrixChanger.deleteRow(matrix, newRow);
//     }
//     
//
//     public void showMatrix()
//     {
//         matrixPrinter.ShowMatrix(matrix);
//     }
//     
//     
//     
//
// }
//
// class matrixChanger
// {
//     public int[,] addRow(int[,] oldMatrix , int[] row)
//     {   
//         int[] matrixInfo = getInfoForNewMatrix_addRow(oldMatrix, row);
//         int[,] newMatrixBlank = createNewMatrix(matrixInfo);
//         int[,] newMatrix = fillMatrix_addRow(newMatrixBlank, oldMatrix, row);
//         return newMatrix;
//     }
//
//     public int[,] deleteRow(int[,] oldMatrix, int rowNumber)
//     {
//         int delRowIndex = rowNumber - 1;
//         
//         int[] matrixInfo = getInfoForNewMatrix_delRow(oldMatrix, delRowIndex);
//         int[,] newMatrixBlank = createNewMatrix(matrixInfo);
//         int[,] newMatrix = fillMatrix_delRow(newMatrixBlank, oldMatrix, delRowIndex);
//
//         return newMatrix;
//     }
//
//     private int[] getInfoForNewMatrix_addRow(int[,] oldMatrix ,int[] row)
//     {
//         int matrixRows = oldMatrix.GetUpperBound(0) + 1;
//         int matrixCols = oldMatrix.Length / matrixRows;
//
//         int rowCols = row.Length;
//         
//         int newRows = matrixRows + 1;
//         int newCols = matrixCols > rowCols ? matrixCols : rowCols; 
//         
//         return [newRows, newCols];
//     }
//     
//     private int[] getInfoForNewMatrix_delRow(int[,] oldMatrix ,int delRowIndex)
//     {
//         int matrixRows = oldMatrix.GetUpperBound(0) + 1;
//         
//         int newRows = matrixRows - 1;
//         int newCols = getMinNeedColumns(oldMatrix, delRowIndex); 
//         
//         return [newRows, newCols];
//     }
//
//     private int getMinNeedColumns(int[,] oldMatrix, int delRowIndex)
//     {
//         int matrixRows = oldMatrix.GetUpperBound(0) + 1;
//         int matrixCols = oldMatrix.Length / matrixRows; 
//
//         int colsWeCanRemove = 0;
//         bool isBreak = false;
//
//         for (int row = 0; row < matrixRows; row++)
//         {
//             if (isBreak)
//                 break;
//             if (row == delRowIndex)
//                 continue;
//
//             isBreak = false;
//
//             for (int col = matrixCols - 1; col >= 0; col--)
//             {
//                 int element = oldMatrix[row, col];
//                 if (element != 0)
//                 {
//                     isBreak = true;
//                     break;
//                 }
//             }
//             colsWeCanRemove++;
//         }
//
//         int minColumns = matrixCols - colsWeCanRemove;
//         return minColumns;
//     }
//
//     private int[,] createNewMatrix(int[] matrixInfo)
//     {
//         return new int[matrixInfo[0], matrixInfo[1]];
//     }
//
//     private int[,] fillMatrix_addRow(int[,] newMatrixBlank, int[,] oldMatrix, int[] row)
//     {
//         int matrixRows = oldMatrix.GetUpperBound(0) + 1;
//         int matrixCols = oldMatrix.Length / matrixRows;
//         
//         int rowCols = row.Length;
//         int lastRowIndex = newMatrixBlank.GetUpperBound(0) + 1 - 1;
//
//         for (int i = 0; i < matrixRows; i++)
//         {
//             for (int j = 0; j < matrixCols; j++)
//             {
//                 newMatrixBlank[i, j] = oldMatrix[i, j];
//             }
//         }
//
//         for (int i = 0; i < rowCols; i++)
//         {
//             newMatrixBlank[lastRowIndex, i] = row[i];
//         }
//         
//         return newMatrixBlank;
//     }
//     
//     private int[,] fillMatrix_delRow(int[,] newMatrixBlank, int[,] oldMatrix, int delRowIndex)
//     {
//         int matrixRows = oldMatrix.GetUpperBound(0) + 1;
//         int newCols = newMatrixBlank.GetLength(1);
//         
//         
//         int newMatrixRowIndex = 0;
//         for (int i = 0; i < matrixRows; i++)
//         {
//             if (i == delRowIndex)
//                 continue;
//             for (int j = 0; j < newCols; j++)
//             {
//                 newMatrixBlank[newMatrixRowIndex, j] = oldMatrix[i, j];
//             }
//
//             newMatrixRowIndex++;
//         }
//         
//         return newMatrixBlank;
//     }
//     
// }
//
// // class matrixOperations
// // {
// //     public int[,] transposeMatrix(int[,] newMatrix)
// //     {
// //         
// //         
// //     }
// //     
// //     
// // }
//
//
//     
//
// class matrixPrinter
// {
//     public void ShowMatrix(int[,] matrix)
//     {
//         int rows = matrix.GetUpperBound(0) + 1;
//         int columns = matrix.Length / rows;
//         
//         int[] maxWidth = getMaxWidthOfColumn(matrix);
//         string gorizontalLine = getGorizontalLine(maxWidth);
//         
//         Console.WriteLine(gorizontalLine);
//         for (int i = 0; i < rows; i++)
//         {
//             Console.Write("|");
//             for (int j = 0; j < columns; j++)
//             {
//                 string item = matrix[i, j].ToString();
//                 string itemWithPadding = item.PadLeft(maxWidth[j]);
//                 Console.Write($" {itemWithPadding} |");
//             }
//             Console.Write("\n");
//             Console.WriteLine(gorizontalLine);
//         }
//     }
//
//     private int[] getMaxWidthOfColumn(int[,] matrix)
//     {
//         int rows = matrix.GetUpperBound(0) + 1;
//         int columns = matrix.Length / rows;
//         
//         int[] maxWidth = new int[columns];
//
//         for (int i = 0; i < columns; i++)
//         {
//             for (int j = 0; j < rows; j++)
//             {
//                 int elLength = matrix[j, i].ToString().Length;
//                 if (maxWidth[i] < elLength)
//                 {
//                     maxWidth[i] = elLength;
//                 }
//             }
//         }
//
//         return maxWidth;
//     }
//
//     private string getGorizontalLine(int[] maxWidth)
//     {
//         int extraSimbols = (2 + 1);
//         int totalWidth = 1 + maxWidth.Sum() + (maxWidth.Length * (extraSimbols));
//         return new string('_',  totalWidth);
//     }
//     
// }
