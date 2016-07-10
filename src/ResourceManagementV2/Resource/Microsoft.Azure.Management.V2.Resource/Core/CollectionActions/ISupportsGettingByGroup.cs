using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.Collections
{
    public interface ISupportsGettingByGroup<T>
    {
        Task<T> GetByGroup(string resourceGroupName, string name);
    }
}
