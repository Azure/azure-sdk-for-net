// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.EventGrid.Models
{
    // GA-compat private-link surface: the generator emits one generic PrivateLinkResources group; main exposes
    // typed per-resource (Domain/Topic/PartnerNamespace) collections/resources. Rationale: PrivateLinkResourceCompat.cs.
    public static partial class ArmEventGridModelFactory
    {
        /// <summary> Creates a Event Grid Private Link Resource Data model. </summary>
        /// <returns> The operation result. </returns>
        public static global::Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData EventGridPrivateLinkResourceData(
            ResourceIdentifier id = default,
            string name = default,
            ResourceType resourceType = default,
            SystemData systemData = default,
            string groupId = default,
            string displayName = default,
            IEnumerable<string> requiredMembers = default,
            IEnumerable<string> requiredZoneNames = default)
        {
            return new global::Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData(
                id,
                name,
                resourceType,
                systemData,
                groupId,
                displayName,
                requiredMembers is null ? new List<string>() : new List<string>(requiredMembers),
                requiredZoneNames is null ? new List<string>() : new List<string>(requiredZoneNames));
        }
    }
}
