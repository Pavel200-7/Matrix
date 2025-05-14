namespace ProjectMatrica.Matrix;

public class matrixRowSorter : MatrixOperationBase
{
    public int[,] sorterRow_Ask(int[,] oldMatrix)
    {
        setOldMatrixProperties(oldMatrix);
        return fillMatrix_SortRowAsk();
    }
    
    public int[,] sorterRow_Desk(int[,] oldMatrix)
    {
        setOldMatrixProperties(oldMatrix);
        return fillMatrix_SortRowDesk();
    }

    private int[,] fillMatrix_SortRowAsk()
    {
        bool IsSwaped;

        for (int row = 0; row < matrixRows; row++)
        {
            do
            {
                IsSwaped = false;
                for (int col = 0; col < matrixCols - 1; col++)
                {
                    int elValue = matrix[row, col];
                    int nextElValue = matrix[row, col + 1];
                    if (nextElValue < elValue)
                    {
                        matrix[row, col] = nextElValue;
                        matrix[row, col + 1] = elValue;  
                        IsSwaped = true;
                    }
                }
            } while (IsSwaped);
            
            
        }
        
        return matrix;
    }
    
    private int[,] fillMatrix_SortRowDesk()
    {
        bool IsSwaped;

        for (int row = 0; row < matrixRows; row++)
        {
            do
            {
                IsSwaped = false;
                for (int col = 0; col < matrixCols - 1; col++)
                {
                    int elValue = matrix[row, col];
                    int nextElValue = matrix[row, col + 1];
                    if (nextElValue > elValue)
                    {
                        matrix[row, col] = nextElValue;
                        matrix[row, col + 1] = elValue;
                        IsSwaped = true;
                    }
                }

            } while (IsSwaped);
        }
        
        return matrix;
    }

}