namespace Calculator.Models;

public interface ICalculatorModel : IModel
{
    string TempNumber { get; }

    string Confirmed { get; }

    string Result { get; }

    Arithmetics Operation { get; }

    void Input(string value);

    void Continue();

    void SetOperation(Arithmetics operation);

    void DoOperation();

    void ShowDisplay();

    void SaveNumberToA();

    void SaveNumberToB();

    void SaveOperation();

    void ClearOperation();

    void Clear();
}