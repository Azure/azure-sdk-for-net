using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.ResourceActions
{
    public interface IRefreshable<IFluentResourceT>
    {
        Task<IFluentResourceT> Refresh();
    }
}
