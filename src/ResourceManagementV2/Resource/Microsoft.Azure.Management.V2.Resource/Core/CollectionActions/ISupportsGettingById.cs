using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.CollectionActions
{
    public interface ISupportsGettingById<T>
    {
        Task<T> GetByIdAsync(string id);

        T GetById(string id);
    }
}
