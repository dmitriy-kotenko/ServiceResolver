using System;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceResolver.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSingletonFactory<TService, TImplementation>(this IServiceCollection services)
            where TImplementation : TService
        {
            return services.AddSingleton<Func<object[], TService>>(
                provider =>
                {
                    return args => ActivatorUtilities.CreateInstance<TImplementation>(provider, args);
                });
        }
    }
}
