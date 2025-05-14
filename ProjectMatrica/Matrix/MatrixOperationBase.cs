namespace ProjectMatrica.Matrix;

public abstract class MatrixOperationBase
{
    protected int [,] matrix;
    protected int matrixRows;
    protected int matrixCols;
    
    protected int [,] blankMatrix;
    protected int blankMatrixRows;
    protected int blankMatrixCols;

    protected void setOldMatrixProperties(int[,] inputMatrix)
    {
        matrix = inputMatrix;
        matrixRows = inputMatrix.GetUpperBound(0) + 1;
        matrixCols = inputMatrix.GetLength(1);
    }
    
    protected void setNewBlankMatrixProperties(int[,] inputMatrix)
    {
        blankMatrix = inputMatrix;
        blankMatrixRows = inputMatrix.GetUpperBound(0) + 1;
        blankMatrixCols = inputMatrix.GetLength(1);
    }
    
    protected int[,] getNewBlankMatrix(int[] matrixInfo)
    {
        return new int[matrixInfo[0], matrixInfo[1]];
    }
}