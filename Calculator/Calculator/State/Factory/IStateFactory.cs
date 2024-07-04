namespace Calculator.State.Factory;

public interface IStateFactory
{
    T Get<T>() where T : IState;
}