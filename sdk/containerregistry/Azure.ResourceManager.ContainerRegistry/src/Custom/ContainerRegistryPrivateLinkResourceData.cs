// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ContainerRegistry
{
    // Backward compatibility: the PrivateLinkResource is not generated as an ARM resource
    // in the new TypeSpec-based code. This custom Data class preserves the old API surface
    // with GroupId, RequiredMembers, and RequiredZoneNames properties.
    /// <summary>
    /// A class representing the ContainerRegistryPrivateLinkResource data model.
    /// </summary>
    public partial class ContainerRegistryPrivateLinkResourceData : ResourceData
    {
        /// <summary> The private link resource group id. </summary>
        [WirePath("properties.groupId")]
        public string GroupId { get; }

        /// <summary> The private link resource required member names. </summary>
        [WirePath("properties.requiredMembers")]
        public IReadOnlyList<string> RequiredMembers { get; }

        /// <summary> The private link resource private link DNS zone name. </summary>
        [WirePath("properties.requiredZoneNames")]
        public IReadOnlyList<string> RequiredZoneNames { get; }
    }
}
