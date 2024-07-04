using Calculator.Extensions;
using Calculator.View;
using Calculator.ViewModels;
using Microsoft.Extensions.Logging;

namespace Calculator.Presenters;

public class CalculatorPresenter : PresenterBase<CalculatorView, CalculatorViewModel>
{
    public CalculatorPresenter(CalculatorView view, CalculatorViewModel viewModel) : base(view, viewModel)
    {
        View.Button0.Bind(ViewModel.OnButtonNumberCommand, 0);
        View.Button1.Bind(ViewModel.OnButtonNumberCommand, 1);
        View.Button2.Bind(ViewModel.OnButtonNumberCommand, 2);
        View.Button3.Bind(ViewModel.OnButtonNumberCommand, 3);
        View.Button4.Bind(ViewModel.OnButtonNumberCommand, 4);
        View.Button5.Bind(ViewModel.OnButtonNumberCommand, 5);
        View.Button6.Bind(ViewModel.OnButtonNumberCommand, 6);
        View.Button7.Bind(ViewModel.OnButtonNumberCommand, 7);
        View.Button8.Bind(ViewModel.OnButtonNumberCommand, 8);
        View.Button9.Bind(ViewModel.OnButtonNumberCommand, 9);
        View.ButtonPoint.Bind(ViewModel.OnButtonNumberCommand);
        View.ButtonPlus.Bind(ViewModel.OnButtonOperationCommand, Arithmetics.Addition);
        View.ButtonMinus.Bind(ViewModel.OnButtonOperationCommand, Arithmetics.Subtraction);
        View.ButtonMultiply.Bind(ViewModel.OnButtonOperationCommand, Arithmetics.Multiplication);
        View.ButtonDivide.Bind(ViewModel.OnButtonOperationCommand, Arithmetics.Division);
        View.ButtonEquel.Bind(ViewModel.OnButtonEquelCommand);
        View.ButtonClancel.Bind(ViewModel.OnButtonClearCommand);
        View.TextBox.Bind(() => ViewModel.Display.Value);
        View.Label.Bind(() => ViewModel.TempDisplay.Value);
    }
}