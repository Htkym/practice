using Calculator.Extensions;
using Calculator.Models;
using Calculator.State.Factory;

namespace Calculator.State;

public sealed class OperationState(IStateFactory stateFactory) : IState
{
    public IState OnInputClear(ICalculatorModel calculator)
    {
        calculator.Clear();
        return stateFactory.Get<OperationState>();
    }

    public IState OnInputEqual(ICalculatorModel calculator)
    {
        calculator.ClearOperation();
        calculator.ShowDisplay();
        return stateFactory.Get<ResultState>();
    }

    public IState OnInputNumber(ICalculatorModel calculator, int number)
    {
        calculator.Input(number.ToString());
        return stateFactory.Get<NumberBState>();
    }

    public IState OnInputOperation(ICalculatorModel calculator, Arithmetics operation)
    {
        calculator.SetOperation(operation);
        return stateFactory.Get<OperationState>();
    }

    public IState OnInputPeriod(ICalculatorModel calculator)
    {
        if (calculator.TempNumber.IsNullOrWhiteSpace())
            calculator.Input(0.ToString());

        calculator.Input(".");
        return stateFactory.Get<NumberBState>();
    }
}