using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.CollectionActions
{
    public interface ISupportsListingByRegion<T>
    {
        Task<List<T>> ListByRegion(string regionName);

        // TODO Task<List<T>> ListByRegion(Region regionName);
    }
}
