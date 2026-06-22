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
    /// <summary> Compatibility declaration for the NatGatewayData type. </summary>
    [CodeGenSuppress("Subnets")]
    public partial class NatGatewayData
    {
        /// <summary> Gets or sets the Subnets compatibility property. </summary>
        [WirePath("properties.subnets")]
        public IReadOnlyList<WritableSubResource> Subnets => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.Subnets);
    }
}
