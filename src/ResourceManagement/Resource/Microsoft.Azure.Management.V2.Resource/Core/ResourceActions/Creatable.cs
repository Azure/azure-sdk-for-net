using System;
using System.Threading.Tasks;
using System.Threading;

namespace Microsoft.Azure.Management.V2.Resource.Core.ResourceActions
{
    /// <summary>
    /// The base class for all creatable resource.
    /// </summary>
    /// <typeparam name="IFluentResourceT">The fluent model type representing the creatable resource</typeparam>
    /// <typeparam name="InnerResourceT">The model inner type that the fluent model type wraps</typeparam>
    /// <typeparam name="FluentResourceT">The fluent model implementation type</typeparam>
    /// <typeparam name="IResourceT">The fluent resourced or one of the base interface from which inherits</typeparam>
    public abstract class Creatable<IFluentResourceT, InnerResourceT, FluentResourceT, IResourceT> :
        IndexableRefreshableWrapper<IFluentResourceT, InnerResourceT>
        where FluentResourceT : class
        where IFluentResourceT : class, IResourceT
        where IResourceT : class
    {
        protected string Name { get; private set; }

        protected Creatable(string name, InnerResourceT innerObject) : base(name, innerObject)
        {
            Name = name;
        }

        public abstract Task<IFluentResourceT> CreateAsync(CancellationToken cancellationToken, bool multiThreaded);

        public IFluentResourceT Create()
        {
            return CreateAsync(CancellationToken.None, true).Result;
        }
    }
}
