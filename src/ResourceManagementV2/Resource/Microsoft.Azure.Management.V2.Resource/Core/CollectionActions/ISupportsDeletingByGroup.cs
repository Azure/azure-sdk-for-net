using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.Collections
{
    public interface ISupportsDeletingByGroup
    {
        Task Delete(string resourceGroupName, string name);
    }
}
