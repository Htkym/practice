using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Calculator
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; } = default!;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            ServiceProvider = CreateHostBuilder().Build().Services;
            Application.Run(ServiceProvider.GetService<Form1>()
                ?? throw new ArgumentNullException("Cannot Run Application"));
        }

        static IHostBuilder CreateHostBuilder()
            => Host.CreateDefaultBuilder()
                   .ConfigureServices((c, s) => s.AddServices(c));
    }
}