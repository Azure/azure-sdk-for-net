// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

#nullable disable

namespace Azure.ResourceManager.ContainerService.Models
{
    /// <summary> Describes an available Compute SKU Location Information. </summary>
    public partial class ContainerServiceVmSkuLocationInfo
    {
        /// <summary> Location of the SKU. </summary>
        [CodeGenMember("Location")]
        public AzureLocation? Location { get; }
    }
}
