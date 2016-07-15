using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.CollectionActions
{
    public interface ISupportsListingByGroup<T>
    {
        PagedList<T> ListByGroup(string resourceGroupName);
    }
}
