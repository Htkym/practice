using Microsoft.Extensions.DependencyInjection;

namespace Calculator.State.Factory;

public class StateFactory(IServiceScopeFactory scopeFactory) : IStateFactory
{
    private readonly IServiceScope _scope = scopeFactory.CreateScope();

    public T Get<T>() where T : IState
        => _scope.ServiceProvider.GetService<T>();
}