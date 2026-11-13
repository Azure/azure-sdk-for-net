// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.ContainerRegistry.Models;
using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerRegistry
{
    public partial class ConnectedRegistryData
    {
        /// <summary> The mode of the connected registry resource that indicates the permissions of the registry. </summary>
        [WirePath("properties.mode")]
        public ConnectedRegistryMode? Mode { get; set; }
    }
}
