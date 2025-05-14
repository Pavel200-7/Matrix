namespace ProjectMatrica.Matrix;

public class matrixExpander : MatrixOperationBase
{
    public int[,] expandMatrixOn_90_deg(int[,] oldMatrix)
    {
        setOldMatrixProperties(oldMatrix);
        
        int[] matrixInfo = getInfoForNewMatrix_expand();
        int[,] newBlankMatrix = getNewBlankMatrix(matrixInfo);
        setNewBlankMatrixProperties(newBlankMatrix);
        
        return fillMatrix_expandOn_90_deg(); 
    }
    
    public int[] getInfoForNewMatrix_expand()
    {
        // Меняются местами
        return [matrixCols, matrixRows]; 
    }
    
    public int[,] fillMatrix_expandOn_90_deg()
    {
        for (int col = 0; col < matrixCols; col++)
        {
            for (int row = 0; row < matrixRows; row++)
            {
                // дентификаторы rew и col изначальной матрицы служат для идентификации их нового места
                blankMatrix[col, blankMatrixCols - 1 - row] = matrix[row, col];
            }
        }
        
        return blankMatrix;
    }
    
}