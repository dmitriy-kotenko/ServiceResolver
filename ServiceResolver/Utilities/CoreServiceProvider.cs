using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceResolver.Utilities
{
    public class CoreServiceProvider : IGenericServiceProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public CoreServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public T Get<T>(params KeyValuePair<string, object>[] constructorArguments)
        {
            // We aren't interested in arguments' names since only order matters on creating instances.
            object[] args = constructorArguments
                .Select(a => a.Value)
                .ToArray();

            var factory = _serviceProvider.GetRequiredService<Func<object[], T>>();
            
            T instance = factory(args);
            return instance;
        }
    }
}
