// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.HybridCompute.Models
{
    public static partial class ArmHybridComputeModelFactory
    {
        /// <summary>
        /// Creates an ArcSettings for mocking.
        /// This method preserves the AutoRest-generated model factory API for backward compatibility.
        /// Use <see cref="ArcSettingsData(ResourceIdentifier, string, ResourceType, Azure.ResourceManager.Models.SystemData, string, ResourceIdentifier)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ArcSettings ArcSettings(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = default, Guid? tenantId = default, ResourceIdentifier gatewayResourceId = default)
            => new ArcSettings(id, name, resourceType, systemData, tenantId, gatewayResourceId, serializedAdditionalRawData: null);

        /// <summary>
        /// Creates a HybridComputePrivateEndpointConnectionProperties for mocking.
        /// This overload accepts <see cref="ResourceIdentifier"/> for <paramref name="privateEndpointId"/> for backward compatibility.
        /// Use the overload that accepts a string privateEndpointId instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HybridComputePrivateEndpointConnectionProperties HybridComputePrivateEndpointConnectionProperties(ResourceIdentifier privateEndpointId, HybridComputePrivateLinkServiceConnectionStateProperty connectionState = default, string provisioningState = default, IEnumerable<string> groupIds = default)
            => new HybridComputePrivateEndpointConnectionProperties(new PrivateEndpointProperty(privateEndpointId, additionalBinaryDataProperties: null), connectionState, provisioningState, groupIds is null ? new List<string>() : new List<string>(groupIds), additionalBinaryDataProperties: null);
    }
}
