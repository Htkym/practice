using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Calculator
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, HostBuilderContext context)
        {
            services.AddSingleton<Form1>();
            return services;
        }
    }
}
