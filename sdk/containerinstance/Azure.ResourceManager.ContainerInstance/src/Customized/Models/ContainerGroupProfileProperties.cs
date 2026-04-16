// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    [CodeGenSuppress("OSType")]
    internal partial class ContainerGroupProfileProperties
    {
        /// <summary> The operating system type required by the containers in the container group. </summary>
        public ContainerInstanceOperatingSystemType? OSType { get; set; }
    }
}
