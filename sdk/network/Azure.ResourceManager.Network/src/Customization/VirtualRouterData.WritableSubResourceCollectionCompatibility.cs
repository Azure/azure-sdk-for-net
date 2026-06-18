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
    /// <summary> Compatibility declaration for the VirtualRouterData type. </summary>
    [CodeGenSuppress("Peerings")]
    public partial class VirtualRouterData
    {
        /// <summary> Gets or sets the Peerings compatibility property. </summary>
        [WirePath("properties.peerings")]
        public IReadOnlyList<WritableSubResource> Peerings => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.Peerings);
    }
}
