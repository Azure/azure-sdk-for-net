using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.CollectionActions
{
    public interface ISupportsGettingByGroup<T>
    {
        Task<T> GetByGroupAsync(string resourceGroupName, string name);

        T GetByGroup(string resourceGroupName, string name);
    }
}
