// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the DdosProtectionPlanData type. </summary>
    [CodeGenSuppress("PublicIPAddresses")]
    [CodeGenSuppress("VirtualNetworks")]
    public partial class DdosProtectionPlanData
    {
        /// <summary> Gets or sets the PublicIPAddresses compatibility property. </summary>
        [WirePath("properties.publicIPAddresses")]
        public IReadOnlyList<WritableSubResource> PublicIPAddresses => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.PublicIPAddresses);
        /// <summary> Gets or sets the VirtualNetworks compatibility property. </summary>
        [WirePath("properties.virtualNetworks")]
        public IReadOnlyList<WritableSubResource> VirtualNetworks => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.VirtualNetworks);
    }
}
