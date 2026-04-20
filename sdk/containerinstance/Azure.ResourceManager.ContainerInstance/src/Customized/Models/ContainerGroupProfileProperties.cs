// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ContainerInstance.Models
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/58288:
    // changes the OSType property from non-nullable (as defined in the spec) to nullable,
    // matching the old SDK's Nullable<ContainerInstanceOperatingSystemType> signature.
    // Since ContainerGroupProfileData.OSType is flattened from this property, it becomes nullable too.
    // Remove this customization once issue #58288 is fixed.
    internal partial class ContainerGroupProfileProperties
    {
        /// <summary> The operating system type required by the containers in the container group. </summary>
        public ContainerInstanceOperatingSystemType? OSType { get; set; }
    }
}
