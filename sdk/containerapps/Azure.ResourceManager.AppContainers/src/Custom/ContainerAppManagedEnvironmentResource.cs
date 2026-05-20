// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AppContainers
{
    // TODO: Remove these detector property suppressions after https://github.com/Azure/azure-sdk-for-net/issues/59322 is fixed.
    [CodeGenSuppress("GetContainerAppManagedEnvironmentDetectorResourceProperties")]
    [CodeGenSuppress("GetContainerAppManagedEnvironmentDetectorResourceProperty", typeof(CancellationToken))]
    [CodeGenSuppress("GetContainerAppManagedEnvironmentDetectorResourcePropertyAsync", typeof(CancellationToken))]
    public partial class ContainerAppManagedEnvironmentResource
    {
        // Preserve the 1.5.0 convenience accessor. The generated overload returns
        // Response<T> and accepts an optional CancellationToken.
        /// <summary> Get the properties of a Managed Environment. </summary>
        public virtual ContainerAppManagedEnvironmentDetectorResourcePropertyResource GetContainerAppManagedEnvironmentDetectorResourceProperty()
        {
            return new ContainerAppManagedEnvironmentDetectorResourcePropertyResource(Client, ContainerAppManagedEnvironmentDetectorResourcePropertyResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name));
        }
    }
}
