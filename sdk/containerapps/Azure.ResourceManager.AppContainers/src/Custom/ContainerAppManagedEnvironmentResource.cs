// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.AppContainers
{
    public partial class ContainerAppManagedEnvironmentResource
    {
        // Preserve the 1.5.0 convenience accessor. The generated overload returns
        // Response<T> and accepts an optional CancellationToken.
        /// <summary> Get the properties of a Managed Environment. </summary>
        public virtual ContainerAppManagedEnvironmentDetectorResourcePropertyResource GetContainerAppManagedEnvironmentDetectorResourceProperty()
        {
            return GetContainerAppManagedEnvironmentDetectorResourceProperty(default);
        }
    }
}
