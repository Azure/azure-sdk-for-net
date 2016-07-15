using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.CollectionActions
{
    public interface ISupportsDeletingByGroup
    {
        Task DeleteAsync(string resourceGroupName, string name);

        void Delete(string resourceGroupName, string name);
    }
}
