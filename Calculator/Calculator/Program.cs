using Calculator.Presenters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Calculator;

internal static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; } = default!;

    [STAThread]
    private static void Main()
    {
        Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

        ApplicationConfiguration.Initialize();
        ServiceProvider = CreateHostBuilder()
            .ConfigureLogging((context, logging) =>
            {
                logging.ClearProviders();
                logging.AddLog4Net(log4NetConfigFile: "log4net.config");
                logging.AddConsole();
                logging.AddDebug();
            })
            .Build()
            .Services;

        var presenter = ServiceProvider.GetService<CalculatorPresenter>();
        Application.Run(presenter.View
            ?? throw new ArgumentNullException("Cannot Run Application"));
    }

    static IHostBuilder CreateHostBuilder()
        => Host.CreateDefaultBuilder()
               .ConfigureServices((c, s) => s.AddServices(c));

    static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        => ShowExceptionDetails(e.Exception);

    static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        => ShowExceptionDetails(e.ExceptionObject as Exception);

    static void ShowExceptionDetails(Exception ex)
        => MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
}