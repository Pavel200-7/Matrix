namespace ProjectMatrica.Matrix;

public class matrixColumnReverser : MatrixOperationBase
{
    public int[,] reverseColumns(int[,] oldMatrix)
    {
        setOldMatrixProperties(oldMatrix);
        
        int[] matrixInfo = getInfoForNewMatrix_reverseColumns();
        int[,] newBlankMatrix = getNewBlankMatrix(matrixInfo);
        setNewBlankMatrixProperties(newBlankMatrix);
        
        return fillMatrix_reverseColumns();
    }
    
    private int[] getInfoForNewMatrix_reverseColumns()
    {
        // такая же
        return [matrixRows, matrixCols];
    }
    
    private int[,] fillMatrix_reverseColumns()
    {
        for (int row = 0; row < matrixRows; row++)
        {
            for (int col = 0; col < matrixCols; col++)
            {
                int opositeindex = (matrixCols - 1) - col;
                blankMatrix[row, col] = matrix[row, opositeindex];
            }
        }
        
        return blankMatrix;
    }
    
}