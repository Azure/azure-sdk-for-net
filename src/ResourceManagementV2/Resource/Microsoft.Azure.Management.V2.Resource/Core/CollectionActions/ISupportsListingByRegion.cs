using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.Collections
{
    interface ISupportsListingByRegion<T>
    {
        Task<List<T>> ListByRegion(string regionName);

        // TODO Task<List<T>> ListByRegion(Region regionName);
    }
}
