using System.Text.RegularExpressions;

namespace ProjectMatrica.Matrix;

public class MatrixController
{
    private Matrix matrix;
    
    // Взаимодействие консолью - это цикл, который завершается при изменении этой переменной
    private bool exid;

    public MatrixController()
    {
        int[] firstRow = getFirstRow();
        matrix = new Matrix(firstRow);
        matrix.consolePrint();
        
        exid = false;
        choseOperation();
    }

    private int[] getFirstRow()
    {
        Console.WriteLine("Введите первую строку матрицы:");
        return getRow();
    }

    private void choseOperation()
    {
        Console.WriteLine("Выберите операцию:");
        Console.WriteLine("show (show) - отобразить матрицу");
        Console.WriteLine("add (add) - добавить строку");
        Console.WriteLine("delete (del) - удалить строку");
        Console.WriteLine("transpose (tra) - транспонировать");
        Console.WriteLine("expand (exp) - повернуть на 90 градусов");
        Console.WriteLine("reserver (res) - поменять порядок стосбцов");
        Console.WriteLine("sortAsk (sask) - отсортировать строки по возрастанию");
        Console.WriteLine("sortDesk (sdesk) - отсортировать строки по возрастанию");
        Console.WriteLine("exid (exid) - завершение работы программы");
        
        exid = false;

        while (!exid)
        {
            string operation = InputOperation();
            performOperation(operation);
        }
    }

    private string InputOperation()
    {
        while (true)
        {
            string inputOper = Console.ReadLine();
            inputOper = getRefacroredText(inputOper);

            if (getWordCount(inputOper) != 1)
            {
                Console.WriteLine("Каждая команда состоит только из одного слова.");
                continue;
            }

            if (HasNumber(inputOper))
            {
                Console.WriteLine("Ни одна команда не содержит числа.");
                continue;
            }

            if (getOperation(inputOper) == "false")
            {
                Console.WriteLine("Такой команды нет.");
                continue;
            }
            
            return getOperation(inputOper);
            
        }
        
        
    }

    private int getWordCount(string text)
    {
        return text.Split(new char[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }
    
    private bool HasNumber(string text)
    {
        return Regex.IsMatch(text, @"\d+");;
    }

    private string getRefacroredText(string text)
    {
        return text.ToLower();
    }
    
    private string getOperation(string inputOper)
    {
        switch (inputOper)
        {
            case "show":
                return "show";
            case "add":
                return "add";
            case "delete":
            case "del":
                return "delete";
            case "transpose":
            case "tra":
                return "transpose";
            case "expand":
            case "exp":
                return "expand";
            case "reserver":
            case "res":
                return "reserver";
            case "sortAsk":
            case "sask":
                return "sortAsk";
            case "sortDesk":
            case "sdesk":
                return "sortDesk";
            case "exid":
                return "exid";
            default:
                return "false";
        }
    }

    private void performOperation(string operation)
    {
        switch (operation)
        {
            case "show":
                showMatrix();
                break;
            case "add":
                addRow();
                break;
            case "delete":
                delRow();
                break;
            case "transpose":
            case "tra":
                transpose();
                break;
            case "expand":
            case "exp":
                expand();
                break;
            case "reserver":
            case "res":
                reserver();
                break;
            case "sortAsk":
            case "sask":
                sortAsk();
                break;
            case "sortDesk":
            case "sdesk":
                sortDesk();
                break;
            case "exid":
                fifishProgram();
                break;
        }
    }

    private void showMatrix()
    {
        matrix.consolePrint();
    }

    private void addRow()
    {
        int[] row = getRow();
        matrix.addRow(row);
        Console.WriteLine("Строка добавлена");
    }
    
    private int[] getRow()
    {
        Console.WriteLine("Введите строку матрицы:");
        Console.WriteLine("(Записывать целые числа через пробел)");

        int[] row = new int[3];
        bool sureItCorrect = false;
        
        while (!sureItCorrect)
        {
            sureItCorrect = true;
            string input = Console.ReadLine();
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            row = new int[parts.Length];
            
            for (int i = 0; i < parts.Length; i++)
            {
                if (int.TryParse(parts[i], out int num))
                {
                    row[i] = num;
                }
                else
                {
                    Console.WriteLine($"Введено некорректное число: {parts[i]}");
                    sureItCorrect = false;
                }
            }
        }
        
        return row;
    }

    private void delRow()
    {
        if (!IsThereColumns())
        {
            Console.WriteLine("В матрице нечего удалять");
            return;
        }
        int row = getRowNumber();
        matrix.delRow(row);
        Console.WriteLine("Строка удалена");

    }

    private int getRowNumber()
    {
        Console.WriteLine("Введите номер удаляемой строки:");

        int rowNumber = 0;
        bool sureItCorrect = false;
        
        while (!sureItCorrect)
        {
            sureItCorrect = true;
            
            string input = Console.ReadLine();
            
            if (int.TryParse(input, out int num))
            {
                rowNumber = num;
            }
            else
            {
                Console.WriteLine($"Введено некорректное значение: {num}");
                sureItCorrect = false;
            }

            if (sureItCorrect)
            {
                if (!IsColumnExist(rowNumber))
                {
                    Console.WriteLine("Строки с таким номером нет");
                    sureItCorrect = false;
                }
            }
        }
        
        return rowNumber;
        
    }

    private bool IsThereColumns()
    {
        if (matrix.matrix.Length != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
    

    private bool IsColumnExist(int rowNumber)
    {
        // rowNumber = rowNumber - 1;
        int lastRowIndex = matrix.matrix.GetUpperBound(0);
        if (rowNumber >= 0 && rowNumber <= lastRowIndex)
        {
            return true;
        } 
            return false;
    }

    private void transpose()
    {
        matrix.transpose();
        Console.WriteLine("Матрица транспонированна");
    }

    private void expand()
    {
        matrix.expand();
        Console.WriteLine("Матрица перевернута");
    }

    private void reserver()
    {
        matrix.reverseColumns();
        Console.WriteLine("Матрица развернута");
    }

    private void sortAsk()
    {
        matrix.sortASK();
        Console.WriteLine("Матрица отсортирована по возровтанию");
    }

    private void sortDesk()
    {
        matrix.sortDESK();
        Console.WriteLine("Матрица отсортирована по удыванию");
    }

    private void fifishProgram()
    {
        exid = true;
        Console.WriteLine("Выполнение программы завершается");
    }
}