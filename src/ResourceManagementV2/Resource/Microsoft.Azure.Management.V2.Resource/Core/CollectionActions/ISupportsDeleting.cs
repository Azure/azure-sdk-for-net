using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.Collections
{
    public interface ISupportsDeleting
    {
        Task Delete(string id);
    }
}
