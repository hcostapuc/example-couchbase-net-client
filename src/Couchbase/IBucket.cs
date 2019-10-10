using System;
using System.Threading.Tasks;
using Couchbase.KeyValue;
using Couchbase.Management.Collections;
using Couchbase.Management.Views;
using Couchbase.Views;

namespace Couchbase
{
    public interface IBucket : IDisposable
    {
        string Name { get; }

        /// NOTE: This is uncommitted functionality and may change at any time.
        Task<IScope> this[string name] { get; }

        Task<IScope> DefaultScopeAsync();

        ICollection DefaultCollection();

        ICollection Collection(string scopeName, string connectionName);

        Task<IViewResult<T>> ViewQueryAsync<T>(string designDocument, string viewName, ViewOptions options = default);

        IViewIndexManager Views { get; }

        ICollectionManager Collections { get; }
    }
}
