using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;

namespace Microsoft.Azure.Management.V2.Resource
{
    public interface IResourceGroup :
        IIndexable,
        IResource,
        IRefreshable<IResourceGroup>,
        IUpdatable<ResourceGroup.Update.IUpdate>,
        IWrapper<ResourceManager.Models.ResourceGroupInner>
    {
        string ProvisioningState { get; }
    }
}
