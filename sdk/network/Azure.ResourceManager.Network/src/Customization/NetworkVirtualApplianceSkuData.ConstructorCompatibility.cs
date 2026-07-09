// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the NetworkVirtualApplianceSkuData type. </summary>
    [CodeGenSuppress("NetworkVirtualApplianceSkuData")]
    public partial class NetworkVirtualApplianceSkuData
    {
        /// <summary> Initializes a new instance of the NetworkVirtualApplianceSkuData class. </summary>
        public NetworkVirtualApplianceSkuData()
        {
        }
    }
}
