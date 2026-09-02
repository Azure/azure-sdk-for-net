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
    /// <summary> Compatibility declaration for the VpnServerConfigurationPolicyGroupData type. </summary>
    [CodeGenSuppress("P2SConnectionConfigurations")]
    public partial class VpnServerConfigurationPolicyGroupData
    {
        /// <summary> Gets or sets the P2SConnectionConfigurations compatibility property. </summary>
        [WirePath("properties.p2SConnectionConfigurations")]
        public IReadOnlyList<WritableSubResource> P2SConnectionConfigurations => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.P2SConnectionConfigurations);
    }
}
