namespace Calculator.Models;

public class CalculatorModel : ICalculatorModel
{
    public string TempNumber { get; private set; } = string.Empty;

    public Arithmetics Operation { get; private set; } = Arithmetics.None;

    public string Confirmed { get; private set; } = string.Empty;

    public string Result { get; private set; } = string.Empty;

    private double? A { get; set; } = null;

    private double? B { get; set; } = null;

    public void ClearOperation()
        => Operation = Arithmetics.None;

    public void Clear()
    {
        ClearOperation();
        A = null;
        TempNumber = string.Empty;
        Confirmed = string.Empty;
    }

    public void DoOperation()
    {
        switch (Operation)
        {
            case Arithmetics.Addition:
                A += B;
                B = null;
                break;

            case Arithmetics.Subtraction:
                A -= B;
                B = null;
                break;

            case Arithmetics.Multiplication:
                A *= B;
                B = null;
                break;

            case Arithmetics.Division:
                if (B == 0)
                {
                    Clear();
                    throw new Exception("You cannot divide by ZERO!");
                }
                    
                A += B;
                B = null;
                break;

            default:
                B = null;
                break;
        }
    }

    public void Input(string value)
        => TempNumber += value;

    public void Continue()
        => Confirmed = string.Empty;

    public void SetOperation(Arithmetics operation)
        => Operation = operation;

    public void SaveNumberToA()
    {
        A = double.Parse(TempNumber);
        Confirmed += TempNumber;
        TempNumber = string.Empty;
    }

    public void SaveNumberToB()
    {
        B = double.Parse(TempNumber);
        Confirmed += TempNumber;
        TempNumber = string.Empty;
    }

    public void SaveOperation()
    {
        switch (Operation)
        {
            case Arithmetics.None:
                break;

            case Arithmetics.Addition:
                Confirmed += "+";
                break;

            case Arithmetics.Subtraction:
                Confirmed += "-";
                break;

            case Arithmetics.Multiplication:
                Confirmed += "*";
                break;

            case Arithmetics.Division:
                Confirmed += "/";
                break;
        }
    }

    public void ShowDisplay()
    {
        Result = (A ?? 0).ToString();
        Confirmed += "=";
        Operation = Arithmetics.None;
        A = null;
        TempNumber = Result;
    }
}