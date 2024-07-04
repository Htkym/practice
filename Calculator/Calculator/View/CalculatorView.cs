namespace Calculator.View;

public partial class CalculatorView : Form, IView
{
    public CalculatorView()
    {
        InitializeComponent();
    }

    public Button Button0 => button0;
    public Button Button1 => button1;
    public Button Button2 => button2;
    public Button Button3 => button3;
    public Button Button4 => button4;
    public Button Button5 => button5;
    public Button Button6 => button6;
    public Button Button7 => button7;
    public Button Button8 => button8;
    public Button Button9 => button9;
    public Button ButtonPoint => buttonPoint;
    public Button ButtonPlus => buttonPlus;
    public Button ButtonMinus => buttonMinus;
    public Button ButtonMultiply => buttonMultiply;
    public Button ButtonDivide => buttonDivide;
    public Button ButtonEquel => buttonEqual;
    public Button ButtonClancel => buttonCancel;
    public TextBox TextBox => textBox;
    public Label Label => labelResult;

}