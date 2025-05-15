namespace ProjectMatrica.Matrix.MatriRrepresentation;

public class matrixConsolePrinter
{
    public void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetUpperBound(0) + 1;

        // if (rows == 0)
        // {
        //     Console.WriteLine("Матрица пуста");
        //     return;
        // }
        
        int columns = matrix.Length / rows;
        
        int[] maxWidth = getMaxWidthOfColumn(matrix);
        string gorizontalLine = getGorizontalLine(maxWidth);
        
        Console.WriteLine(gorizontalLine);
        for (int i = 0; i < rows; i++)
        {
            Console.Write("|");
            for (int j = 0; j < columns; j++)
            {
                string item = matrix[i, j].ToString();
                string itemWithPadding = item.PadLeft(maxWidth[j]);
                Console.Write($" {itemWithPadding} |");
            }
            Console.Write("\n");
            Console.WriteLine(gorizontalLine);
        }
    }

    private int[] getMaxWidthOfColumn(int[,] matrix)
    {
        int rows = matrix.GetUpperBound(0) + 1;
        int columns = matrix.Length / rows;
        
        int[] maxWidth = new int[columns];

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                int elLength = matrix[j, i].ToString().Length;
                if (maxWidth[i] < elLength)
                {
                    maxWidth[i] = elLength;
                }
            }
        }

        return maxWidth;
    }

    private string getGorizontalLine(int[] maxWidth)
    {
        int extraSimbols = (2 + 1);
        int totalWidth = 1 + maxWidth.Sum() + (maxWidth.Length * (extraSimbols));
        return new string('_',  totalWidth);
    }
}