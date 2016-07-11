using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.CollectionActions
{
    public interface ISupportsDeletingByGroup
    {
        Task Delete(string resourceGroupName, string name);
    }
}
