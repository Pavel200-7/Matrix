namespace ProjectMatrica.Matrix;

public class matrixRowDeleter : MatrixOperationBase
{
    private int delRowIndex;
    
    public int[,] deleteRow(int[,] oldMatrix, int rowNumber)
    {
        delRowIndex = rowNumber - 1;
        
        setOldMatrixProperties(oldMatrix);
        
        int[] matrixInfo = getInfoForNewMatrix_delRow();
        int[,] newBlankMatrix = getNewBlankMatrix(matrixInfo);
        setNewBlankMatrixProperties(newBlankMatrix);
        
        return fillMatrix_delRow();
    }
    
    private int[] getInfoForNewMatrix_delRow()
    {
        int newRows = matrixRows - 1;
        int newCols = getMinNeedColumns(); 
        
        return [newRows, newCols];
    }

    private int getMinNeedColumns()
    {
        int colsWeCanRemove = 0;
        
        bool isBreak = false;
        for (int row = 0; row < matrixRows; row++)
        {
            if (isBreak)
                break;
            if (row == delRowIndex)
                continue;
            for (int col = matrixCols - 1; col >= 0; col--)
            {
                int element = matrix[row, col];
                if (element != 0)
                {
                    isBreak = true;
                    break;
                }
            }
            if (!isBreak)
                colsWeCanRemove++;
        }

        int minColumns = matrixCols - colsWeCanRemove;
        return minColumns;
    }
    
    private int[,] fillMatrix_delRow()
    {
        int newMatrixRowIndex = 0;
        for (int row = 0; row < matrixRows; row++)
        {
            if (row == delRowIndex)
                continue;
            for (int col = 0; col < blankMatrixCols; col++)
            {
                blankMatrix[newMatrixRowIndex, col] = matrix[row, col];
            }
            newMatrixRowIndex++;
        }
        
        return blankMatrix;
    }
    
}