// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Purview.Models
{
    // Backward compatibility: old SDK (1.1.0) had a factory method for PurviewPrivateLinkResourceProperties.
    // The new generator doesn't produce one, so we add it manually to satisfy ApiCompat.
    public static partial class ArmPurviewModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="PurviewPrivateLinkResourceProperties"/>. </summary>
        /// <param name="groupId"> The private link resource group identifier. </param>
        /// <param name="requiredMembers"> The private link resource required member names. </param>
        /// <param name="requiredZoneNames"> The required zone names for private link resource. </param>
        /// <returns> A new <see cref="PurviewPrivateLinkResourceProperties"/> instance for mocking. </returns>
        public static PurviewPrivateLinkResourceProperties PurviewPrivateLinkResourceProperties(string groupId = null, IEnumerable<string> requiredMembers = null, IEnumerable<string> requiredZoneNames = null)
        {
            return new PurviewPrivateLinkResourceProperties(
                groupId,
                requiredMembers?.ToList(),
                requiredZoneNames?.ToList(),
                null);
        }

        // Generator bug: the generated factory method for PurviewPrivateEndpointConnectionData
        // accepted privateEndpointId, connectionState, and provisioningState parameters but
        // passed `default` for the entire PrivateEndpointConnectionProperties object, silently
        // discarding all three values.  Anyone using this factory for mocking would get an empty
        // object.  This override correctly constructs the PrivateEndpointConnectionProperties
        // from the individual parameters, following the same pattern used by PurviewAccountData
        // (which wraps its flattened params into PurviewAccountProperties).
        //
        // Tracked as generator bug: https://github.com/Azure/azure-sdk-for-net/issues/57334
        /// <summary> Initializes a new instance of <see cref="Purview.PurviewPrivateEndpointConnectionData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="privateEndpointId"> The private endpoint identifier. </param>
        /// <param name="connectionState"> The private link service connection state. </param>
        /// <param name="provisioningState"> The provisioning state. </param>
        /// <returns> A new <see cref="Purview.PurviewPrivateEndpointConnectionData"/> instance for mocking. </returns>
        public static PurviewPrivateEndpointConnectionData PurviewPrivateEndpointConnectionData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, ResourceIdentifier privateEndpointId = default, PurviewPrivateLinkServiceConnectionState connectionState = default, string provisioningState = default)
        {
            return new PurviewPrivateEndpointConnectionData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                privateEndpointId is null && connectionState is null && provisioningState is null
                    ? default
                    : new PrivateEndpointConnectionProperties(
                        privateEndpointId is null ? default : new PrivateEndpoint(privateEndpointId, null),
                        connectionState,
                        provisioningState,
                        null));
        }
    }
}
