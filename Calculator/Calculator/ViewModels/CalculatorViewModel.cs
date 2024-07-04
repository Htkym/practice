using Calculator.Commands;
using Calculator.Models;
using Calculator.State;
using Calculator.State.Factory;
using Microsoft.Extensions.Logging;
using Reactive.Bindings;
using System.Windows.Input;

namespace Calculator.ViewModels;

public class CalculatorViewModel : ViewModelBase<ICalculatorModel>
{
    private readonly ILogger _logger;

    public ReactiveProperty<string> Display { get; set; } = new();

    public ReactiveProperty<string> TempDisplay { get; set; } = new();

    private IState State { get; set; }

    public ICommand OnButtonNumberCommand { get; }

    public ICommand OnButtonOperationCommand { get; }

    public ICommand OnButtonEquelCommand { get; }

    public ICommand OnButtonClearCommand { get; }

    public CalculatorViewModel(ICalculatorModel calculator, IStateFactory stateFactory, ILogger<CalculatorViewModel> logger) : base(calculator)
    {
        _logger = logger;
        State = stateFactory.Get<NumberAState>();

        OnButtonNumberCommand = new RelayCommand(o =>
        {
            if (o is int i)
                State = State.OnInputNumber(Model, i);
            else
                State = State.OnInputPeriod(Model);

            Show();
        });

        OnButtonOperationCommand = new RelayCommand(o => { State = State.OnInputOperation(Model, (Arithmetics)o); ShowTemp(); });

        OnButtonEquelCommand = new RelayCommand(_ => { State = State.OnInputEqual(Model); ShowResult(); });

        OnButtonClearCommand = new RelayCommand(_ => { State = State.OnInputClear(Model); Show(); });
    }

    private void Show()
    {
        Display.Value = Model.TempNumber;

        _logger.LogInformation("Display {Display}", Display.Value);
    }

    private void ShowTemp()
    {
        TempDisplay.Value = $"{Model.Confirmed}{Model.Operation switch
        {
            Arithmetics.Addition => "+",
            Arithmetics.Subtraction => "-",
            Arithmetics.Multiplication => "*",
            Arithmetics.Division => "/",
            _ => string.Empty
        }}";

        _logger.LogInformation("Temp Display {TempDisplay}", TempDisplay.Value);
    }

    private void ShowResult()
    {
        ShowTemp();
        Display.Value = Model.Result;

        _logger.LogInformation("Display {Display}", Display.Value);
    }
}