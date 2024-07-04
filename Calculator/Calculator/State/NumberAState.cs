using Calculator.Extensions;
using Calculator.Models;
using Calculator.State.Factory;

namespace Calculator.State;

public sealed class NumberAState(IStateFactory stateFactory) : IState
{
    public IState OnInputClear(ICalculatorModel calculator)
    {
        calculator.Clear();
        return stateFactory.Get<NumberAState>();
    }

    public IState OnInputEqual(ICalculatorModel calculator)
    {
        calculator.SaveNumberToA();
        calculator.ShowDisplay();
        return stateFactory.Get<ResultState>();
    }

    public IState OnInputNumber(ICalculatorModel calculator, int number)
    {
        calculator.Input(number.ToString());
        return stateFactory.Get<NumberAState>();
    }

    public IState OnInputOperation(ICalculatorModel calculator, Arithmetics operation)
    {
        calculator.SaveNumberToA();
        calculator.SetOperation(operation);
        return stateFactory.Get<OperationState>();
    }

    public IState OnInputPeriod(ICalculatorModel calculator)
    {
        if (0 <= calculator.TempNumber.IndexOf('.'))
            return stateFactory.Get<NumberAState>();

        if (calculator.TempNumber.IsNullOrWhiteSpace())
            calculator.Input(0.ToString());

        calculator.Input(".");
        return stateFactory.Get<NumberAState>();
    }
}