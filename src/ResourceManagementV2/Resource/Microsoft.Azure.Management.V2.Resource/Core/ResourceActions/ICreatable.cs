using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.ResourceActions
{
    interface ICreatable<IFluentResourceT> : IIndexable
    {
        Task<IFluentResourceT> Create();
    }
}
