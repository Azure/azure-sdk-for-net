// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.HybridCompute.Models
{
    public static partial class ArmHybridComputeModelFactory
    {
        /// <summary>
        /// Creates a HybridComputePrivateEndpointConnectionProperties for mocking.
        /// This overload accepts <see cref="ResourceIdentifier"/> for <paramref name="privateEndpointId"/> for backward compatibility.
        /// Use the overload that accepts a string privateEndpointId instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HybridComputePrivateEndpointConnectionProperties HybridComputePrivateEndpointConnectionProperties(ResourceIdentifier privateEndpointId, HybridComputePrivateLinkServiceConnectionStateProperty connectionState = default, string provisioningState = default, IEnumerable<string> groupIds = default)
            => HybridComputePrivateEndpointConnectionProperties(privateEndpointId?.ToString(), connectionState, provisioningState, groupIds);
    }
}
