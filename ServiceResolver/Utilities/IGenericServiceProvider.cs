using System.Collections.Generic;

namespace ServiceResolver.Utilities
{
    public interface IGenericServiceProvider
    {
        T Get<T>(params KeyValuePair<string, object>[] args);
    }
}
