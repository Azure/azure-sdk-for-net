using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.ResourceActions
{
    public abstract class CreatableUpdatable<IFluentResourceT, InnerResourceT, FluentResourceT> 
        : Creatable<IFluentResourceT, InnerResourceT, FluentResourceT> 
            where IFluentResourceT: class, IResource
            where FluentResourceT: class
    {
        protected CreatableUpdatable(string name, InnerResourceT innerObject) : base(name, innerObject) { }

        public async Task<IFluentResourceT> ApplyAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            return await CreateAsync(cancellationToken, multiThreaded);
        }
    }
}
