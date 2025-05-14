namespace ProjectMatrica.Matrix;

public class matrixRowAdder : MatrixOperationBase
{
    protected int[] newRow;
    public int[,] addRow(int[,] oldMatrix , int[] row)
    {
        newRow = row;
        
        setOldMatrixProperties(oldMatrix);
        
        int[] matrixInfo = getInfoForNewMatrix_addRow();
        int[,] newBlankMatrix = getNewBlankMatrix(matrixInfo);
        setNewBlankMatrixProperties(newBlankMatrix);
        
        return fillBlankMatrix_addRow();
    }

    private int[] getInfoForNewMatrix_addRow()
    {
        int rowCols = newRow.Length;
        
        int newRows = matrixRows + 1;
        int newCols = matrixCols > rowCols ? matrixCols : rowCols; 
        
        return [newRows, newCols];
    }

    private int[,] fillBlankMatrix_addRow()
    {
        // заполнение новой матрицы содержимым старой
        for (int row = 0; row < matrixRows; row++)
        {
            for (int col = 0; col < matrixCols; col++)
            {
                blankMatrix[row, col] = matrix[row, col];
            }
        }
        
        // заполнение новой матрицы новой строкой
        int lastRowIndex = blankMatrixRows - 1;
        for (int col = 0; col < newRow.Length; col++)
        {
            blankMatrix[lastRowIndex, col] = newRow[col];
        }
        
        return blankMatrix;
    }
    
}