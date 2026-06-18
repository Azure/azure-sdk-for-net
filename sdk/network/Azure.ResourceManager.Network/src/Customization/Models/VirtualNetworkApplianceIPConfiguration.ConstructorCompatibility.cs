// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the VirtualNetworkApplianceIPConfiguration type. </summary>
    [CodeGenSuppress("VirtualNetworkApplianceIPConfiguration")]
    public partial class VirtualNetworkApplianceIPConfiguration
    {
        /// <summary> Initializes a new instance of the VirtualNetworkApplianceIPConfiguration class. </summary>
        public VirtualNetworkApplianceIPConfiguration()
        {
        }
    }
}
