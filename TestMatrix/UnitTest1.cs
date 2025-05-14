
using NUnit.Framework.Constraints;
using ProjectMatrica.Matrix;


namespace TestMatrix;

public class Tests
{
    private matrixOperations matrixOperations;
    
    [SetUp]
    public void Setup()
    {
        matrixOperations = new matrixOperations();
        
    }
    
    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
    
    [Test]
    public void TestAddingRow()
    {
        int[,] inputMatrix = new int[3, 3] {{5, 82, 25},{39, 2,71}, {32, 85, 48}};
        int[] inputingRow = new int[] { 29, 62, 15 };
        
        matrixOperations.AddRow(ref inputMatrix, inputingRow);
        
        int[,] outputMatrix = new int[4, 3] {{5, 82, 25},{39, 2, 71}, {32, 85, 48}, { 29, 62, 15 }};
        
        AreEqual(inputMatrix, outputMatrix);
    }

    [Test]
    public void TestDeletingRow()
    {
        int[,] inputMatrix = new int[3, 3] {{5, 82, 25},{39, 2,71}, {32, 85, 48}};
        int inputingRowNumber = 2;
        
        matrixOperations.DelRow(ref inputMatrix, inputingRowNumber);
        
        int[,] outputMatrix = new int[2, 3] {{5, 82, 25}, {32, 85, 48}};
        
        AreEqual(inputMatrix, outputMatrix);
    }

    [Test]
    public void TestTransposing()
    {
        int[,] inputMatrix = new int[3, 3] {{5, 82, 25},{39, 2,71}, {32, 85, 48}};
        
        matrixOperations.TransposeMatrix(ref inputMatrix);
        
        int[,] outputMatrix = new int[3, 3] {{5, 39, 32},{82, 2, 85},{25, 71, 48}};
        
        AreEqual(inputMatrix, outputMatrix);
    }
    
    [Test]
    public void TestExpanding()
    {
        int[,] inputMatrix = new int[3, 3] {{5, 82, 25},{39, 2,71}, {32, 85, 48}};
        
        matrixOperations.ExpandMatrix(ref inputMatrix);
        
        int[,] outputMatrix = new int[3, 3] {{32, 39, 5}, {85, 2, 82}, {48, 71, 25}};
        
        AreEqual(inputMatrix, outputMatrix);
    }
    
    [Test]
    public void TestSortingAsk()
    {
        int[,] inputMatrix = new int[3, 3] {{5, 82, 25},{39, 2,71}, {32, 85, 48}};
        
        matrixOperations.SortMatrixRowsASK(ref inputMatrix);
        
        int[,] outputMatrix = new int[3, 3] {{5, 25, 82}, {2, 39, 71}, {32, 48, 85}};
        
        AreEqual(inputMatrix, outputMatrix);
    }
    
    [Test]
    public void TestSortingDesk()
    {
        int[,] inputMatrix = new int[3, 3] {{5, 82, 25},{39, 2,71}, {32, 85, 48}};
        
        matrixOperations.SortMatrixRowsDESK(ref inputMatrix);
        
        int[,] outputMatrix = new int[3, 3] {{82, 25, 5}, {71, 39,2}, {85, 48, 32}};
        
        AreEqual(inputMatrix, outputMatrix);
    }
    
    [Test]
    public void TestReversingColumns()
    {
        int[,] inputMatrix = new int[3, 3] {{5, 82, 25},{39, 2, 71}, {32, 85, 48}};
        
        matrixOperations.ReverseColumns(ref inputMatrix);
        
        int[,] outputMatrix = new int[3, 3] {{25, 82, 5},{71, 2, 39}, {48, 85, 32}};
        
        AreEqual(inputMatrix, outputMatrix);
    }

    
    

    public void AreEqual(int[,] inputMatrix, int[,] outputMatrix)
    {
        bool IsItCorrect = CompareMatrices(inputMatrix, outputMatrix);
        returnResult(IsItCorrect);
    }
    
    public bool CompareMatrices(int[,] A, int[,] B)
    {
        if (A.GetLength(0) != B.GetLength(0) || A.GetLength(1) != B.GetLength(1))
            return false;

        for (int i = 0; i < A.GetLength(0); i++)
        {
            for (int j = 0; j < A.GetLength(1); j++)
            {
                if (A[i, j] != B[i, j])
                    return false; // нашли отличия
            }
        }

        return true;
    }

    public void returnResult(bool isCorrect)
    {
        if (isCorrect)
        {
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }
    }
}