using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.ResourceActions
{
    interface IApplicable<IFluentResourceT> : IIndexable
    {
        Task<IFluentResourceT> Apply();
    }
}
