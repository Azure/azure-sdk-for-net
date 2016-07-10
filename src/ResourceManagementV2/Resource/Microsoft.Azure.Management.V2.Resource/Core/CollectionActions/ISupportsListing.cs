using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.Collections
{
    public interface ISupportsListing<T>
    {
        Task<List<T>> List();
    }
}
