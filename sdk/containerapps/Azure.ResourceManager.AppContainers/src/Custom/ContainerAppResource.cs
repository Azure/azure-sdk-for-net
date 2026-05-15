// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.AppContainers
{
    public partial class ContainerAppResource
    {
        // Preserve the previous zero-argument overload; the resource implementation is generated.
        /// <summary> Get the properties of a Container App. </summary>
        public virtual ContainerAppDetectorPropertyResource GetContainerAppDetectorProperty()
        {
            return GetContainerAppDetectorProperty(default);
        }
    }
}
