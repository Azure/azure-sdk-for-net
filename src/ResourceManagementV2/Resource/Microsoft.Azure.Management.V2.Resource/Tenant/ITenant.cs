using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.V2.Resource.Core;

namespace Microsoft.Azure.Management.V2.Resource
{
    public interface ITenant :
        IIndexable,
        IWrapper<TenantIdDescription>
    {
        string TenantId { get; } 
    }
}
