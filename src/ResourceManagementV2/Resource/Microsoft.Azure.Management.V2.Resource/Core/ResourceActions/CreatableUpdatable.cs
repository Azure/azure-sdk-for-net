using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.ResourceActions
{
    public abstract class CreatableUpdatable<IFluentResourceT, InnerResourceT, FluentResourceT, IResourceT> 
        : Creatable<IFluentResourceT, InnerResourceT, FluentResourceT, IResourceT> 
            where IFluentResourceT: class, IResourceT
            where FluentResourceT: class
            where IResourceT: class
    {
        protected CreatableUpdatable(string name, InnerResourceT innerObject) : base(name, innerObject) { }
    }
}
