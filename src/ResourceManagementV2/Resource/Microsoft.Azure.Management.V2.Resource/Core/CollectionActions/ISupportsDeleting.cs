using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.CollectionActions
{
    public interface ISupportsDeleting
    {
        Task DeleteAsync(string id);

        void Delete(string id);
    }
}
