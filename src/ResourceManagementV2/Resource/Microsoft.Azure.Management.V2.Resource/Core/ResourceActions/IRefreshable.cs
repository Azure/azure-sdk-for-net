using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.ResourceActions
{
    interface IRefreshable<IFluentResourceT>
    {
        Task<IFluentResourceT> Refresh();
    }
}
