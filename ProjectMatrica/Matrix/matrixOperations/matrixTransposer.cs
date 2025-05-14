namespace ProjectMatrica.Matrix;

public class matrixTransposer : MatrixOperationBase
{
    public int[,] transposeMatrix(int[,] oldMatrix)
    {
        setOldMatrixProperties(oldMatrix);
        
        int[] matrixInfo = getInfoForNewMatrix_tranpose();
        int[,] newBlankMatrix = getNewBlankMatrix(matrixInfo);
        setNewBlankMatrixProperties(newBlankMatrix);

        return fillMatrix_traispose(); 
    }

    public int[] getInfoForNewMatrix_tranpose()
    {
        // Меняются местами
        return [matrixCols, matrixRows]; 
    }

    public int[,] fillMatrix_traispose()
    {
        for (int row = 0; row < matrixRows; row++)
        {
            for (int col = 0; col < matrixCols; col++)
            {
                blankMatrix[col, row] = matrix[row, col];
            }
        }
        
        return blankMatrix;
    }
    
}