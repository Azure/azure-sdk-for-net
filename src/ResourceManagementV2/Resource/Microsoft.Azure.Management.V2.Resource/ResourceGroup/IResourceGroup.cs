using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using Microsoft.Azure.Management.V2.Resource.ResourceGroup.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.ResourceGroup
{
    public interface IResourceGroup :
        IIndexable,
        IResource,
        IRefreshable<IResourceGroup>,
        IWrapper<ResourceManager.Models.ResourceGroup>,
        IUpdatable<IUpdate>
    {
        string ProvisioningState { get; }
    }
}
