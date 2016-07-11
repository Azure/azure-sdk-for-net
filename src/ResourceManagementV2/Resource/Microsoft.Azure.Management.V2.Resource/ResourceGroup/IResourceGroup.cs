using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;

namespace Microsoft.Azure.Management.V2.Resource
{
    public interface IResourceGroup :
        IIndexable,
        IResource,
        IRefreshable<IResourceGroup>,
        IWrapper<ResourceManager.Models.ResourceGroup>,
        IUpdatable<ResourceGroup.Update.IUpdate>
    {
        string ProvisioningState { get; }
    }
}
