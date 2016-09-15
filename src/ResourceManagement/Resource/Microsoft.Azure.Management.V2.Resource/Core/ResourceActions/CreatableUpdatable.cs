using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.ResourceActions
{
    public abstract class CreatableUpdatable<IFluentResourceT, InnerResourceT, FluentResourceT, IResourceT, IUpdatableT> 
        : Creatable<IFluentResourceT, InnerResourceT, FluentResourceT, IResourceT>, 
        ICreatable<IFluentResourceT>, 
        IUpdatable<IUpdatableT>
        where IFluentResourceT: class, IResourceT
        where FluentResourceT: class
        where IResourceT: class
        where IUpdatableT: class
    {
        protected CreatableUpdatable(string name, InnerResourceT innerObject) : base(name, innerObject) { }

        #region Implementation of IUpdatable interface

        public virtual IUpdatableT Update()
        {
            return this as IUpdatableT;
        }

        #endregion
        public IFluentResourceT Apply()
        {
            return ApplyAsync(CancellationToken.None, true).Result;
        }

        public virtual async Task<IFluentResourceT> ApplyAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            return await CreateAsync(cancellationToken, multiThreaded) as IFluentResourceT;
        }

    }
}
