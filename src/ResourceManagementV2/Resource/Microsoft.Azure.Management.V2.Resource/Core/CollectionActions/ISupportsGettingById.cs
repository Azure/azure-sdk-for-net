using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.CollectionActions
{
    public interface ISupportsGettingById<T>
    {
        Task<T> GetById(string id);
    }
}
