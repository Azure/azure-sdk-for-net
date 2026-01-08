// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ContainerRegistry
{
    /// <summary>
    /// A class representing the ContainerRegistryPrivateLinkResource data model.
    /// A private link resource.
    /// </summary>
    public partial class ContainerRegistryPrivateLinkResourceData : ResourceData
    {
        /// <summary> The private link resource private link DNS zone name. </summary>
        [WirePath("properties.requiredZoneNames")]
        public IReadOnlyList<string> RequiredZoneNames { get; }
    }
}
