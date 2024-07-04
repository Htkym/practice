using Calculator.Extensions;
using Calculator.Models;
using Calculator.State.Factory;

namespace Calculator.State;

public sealed class NumberBState(IStateFactory stateFactory) : IState
{
    public IState OnInputClear(ICalculatorModel calculator)
    {
        calculator.Clear();
        return stateFactory.Get<NumberBState>();
    }

    public IState OnInputEqual(ICalculatorModel calculator)
    {
        calculator.SaveOperation();
        calculator.SaveNumberToB();
        calculator.DoOperation();
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
        calculator.SaveOperation();
        calculator.SaveNumberToB();
        calculator.DoOperation();
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
        return stateFactory.Get<NumberBState>();
    }
}