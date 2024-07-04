using Calculator.Models;
using Calculator.Presenters;
using Calculator.State;
using Calculator.State.Factory;
using Calculator.View;
using Calculator.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Calculator;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, HostBuilderContext context)
    {
        services.AddSingleton<CalculatorView>();
        services.AddSingleton<CalculatorPresenter>();
        services.AddSingleton<CalculatorViewModel>();
        services.AddSingleton<IStateFactory, StateFactory>();
        services.AddSingleton<ICalculatorModel, CalculatorModel>();
        services.AddStates();
        return services;
    }

    private static void AddStates(this IServiceCollection services)
    {
        var states = typeof(Program).Assembly.GetTypes()
            .Where(t => !t.IsInterface && typeof(IState).IsAssignableFrom(t)).ToList();
        states.ForEach(s => services.AddSingleton(s));
    }
}