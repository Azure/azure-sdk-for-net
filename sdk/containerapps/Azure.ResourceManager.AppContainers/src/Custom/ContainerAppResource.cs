// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AppContainers
{
    // TODO: Remove these detector property suppressions after https://github.com/Azure/azure-sdk-for-net/issues/59322 is fixed.
    [CodeGenSuppress("GetContainerAppDetectorProperties")]
    [CodeGenSuppress("GetContainerAppDetectorProperty", typeof(CancellationToken))]
    [CodeGenSuppress("GetContainerAppDetectorPropertyAsync", typeof(CancellationToken))]
    public partial class ContainerAppResource
    {
        // Preserve the previous zero-argument overload; the resource implementation is generated.
        /// <summary> Get the properties of a Container App. </summary>
        public virtual ContainerAppDetectorPropertyResource GetContainerAppDetectorProperty()
        {
            return new ContainerAppDetectorPropertyResource(Client, ContainerAppDetectorPropertyResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name));
        }
    }
}
