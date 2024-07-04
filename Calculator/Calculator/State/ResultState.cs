using Calculator.Models;
using Calculator.State.Factory;

namespace Calculator.State;

public sealed class ResultState(IStateFactory stateFactory) : IState
{
    public IState OnInputClear(ICalculatorModel calculator)
    {
        calculator.Clear();
        return stateFactory.Get<ResultState>();
    }

    public IState OnInputEqual(ICalculatorModel calculator)
        => stateFactory.Get<ResultState>();

    public IState OnInputNumber(ICalculatorModel calculator, int number)
    {
        calculator.Clear();
        calculator.Input(number.ToString());
        return stateFactory.Get<NumberAState>();
    }

    public IState OnInputOperation(ICalculatorModel calculator, Arithmetics operation)
    {
        calculator.Continue();
        calculator.SaveNumberToA();
        calculator.SetOperation(operation);
        return stateFactory.Get<OperationState>();
    }

    public IState OnInputPeriod(ICalculatorModel calculator)
        => stateFactory.Get<ResultState>();
}