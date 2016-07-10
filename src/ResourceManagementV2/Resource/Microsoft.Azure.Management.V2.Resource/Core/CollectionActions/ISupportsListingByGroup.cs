using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.Collections
{
    public interface ISupportsListingByGroup<T>
    {
        Task<List<T>> ListByGroup(string resourceGroupName);
    }
}
