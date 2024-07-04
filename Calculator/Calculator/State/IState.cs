using Calculator.Models;

namespace Calculator.State;

public interface IState
{
    IState OnInputNumber(ICalculatorModel calculator, int number);

    IState OnInputPeriod(ICalculatorModel calculator);

    IState OnInputOperation(ICalculatorModel calculator, Arithmetics operation);

    IState OnInputEqual(ICalculatorModel calculator);

    IState OnInputClear(ICalculatorModel calculator);
}