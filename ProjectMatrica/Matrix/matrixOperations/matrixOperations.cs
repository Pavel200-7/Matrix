namespace ProjectMatrica.Matrix;

public class matrixOperations
{
    private matrixRowAdder matrixRowAdder;
    private matrixRowDeleter matrixRowDeleter;
    private matrixTransposer matrixTransposer;
    private matrixExpander matrixExpander;
    private matrixRowSorter matrixRowSorter;
    private matrixColumnReverser matrixColumnReverser;
    
    public matrixOperations()
    {
        matrixRowAdder = new matrixRowAdder();
        matrixRowDeleter = new matrixRowDeleter();
        matrixTransposer = new matrixTransposer();
        matrixExpander = new matrixExpander();
        matrixRowSorter = new matrixRowSorter();
        matrixColumnReverser = new matrixColumnReverser();
    }

    public void AddRow(ref int[,] matrix, int[] row)
    {
        int[,] oldMatrix = matrix;
        matrix =  matrixRowAdder.addRow(oldMatrix, row);
    }

    public void DelRow(ref int[,] matrix, int rowNumber)
    {
        int[,] oldMatrix = matrix;
        matrix = matrixRowDeleter.deleteRow(oldMatrix, rowNumber);
    }

    public void TransposeMatrix(ref int[,] matrix)
    {
        int[,] oldMatrix = matrix;
        matrix = matrixTransposer.transposeMatrix(oldMatrix);
    }

    public void ExpandMatrix(ref int[,] matrix)
    {
        int[,] oldMatrix = matrix;
        matrix = matrixExpander.expandMatrixOn_90_deg(oldMatrix);
    }

    public void SortMatrixRowsASK(ref int[,] matrix)
    {
        int[,] oldMatrix = matrix;
        matrix = matrixRowSorter.sorterRow_Ask(oldMatrix);
    }
    
    public void SortMatrixRowsDESK(ref int[,] matrix)
    {
        int[,] oldMatrix = matrix;
        matrix = matrixRowSorter.sorterRow_Desk(oldMatrix);
    }
    
    public void ReverseColumns(ref int[,] matrix)
    {
        int[,] oldMatrix = matrix;
        matrix = matrixColumnReverser.reverseColumns(oldMatrix);
    }
    
}