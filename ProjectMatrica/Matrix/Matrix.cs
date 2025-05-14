using ProjectMatrica.Matrix.MatriRrepresentation;

namespace ProjectMatrica.Matrix;

public class Matrix
{
    public int[,] matrix;
    matrixOperations matrixOperations;
    matrixConsolePrinter consolePrinter;

    public Matrix(int[] firstRow)
    {
        matrixOperations = new matrixOperations();
        consolePrinter =new matrixConsolePrinter();

        matrix = new int[0, 0];
        addRow(firstRow);
    }

    public void addRow(int[] row)
    {
        matrixOperations.AddRow(ref matrix, row);
    }

    public void delRow(int row)
    {
        matrixOperations.DelRow(ref matrix, row);
    }

    public void transpose()
    {
        matrixOperations.TransposeMatrix(ref matrix);
    }

    public void expand()
    {
        matrixOperations.ExpandMatrix(ref matrix);
    }

    public void sortASK()
    {
        matrixOperations.SortMatrixRowsASK(ref matrix);
    }

    public void sortDESK()
    {
        matrixOperations.SortMatrixRowsDESK(ref matrix);
    }

    public void reverseColumns()
    {
        matrixOperations.ReverseColumns(ref matrix);
    }
    
    public void consolePrint()
    {
        
        consolePrinter.PrintMatrix(matrix);
    }
}