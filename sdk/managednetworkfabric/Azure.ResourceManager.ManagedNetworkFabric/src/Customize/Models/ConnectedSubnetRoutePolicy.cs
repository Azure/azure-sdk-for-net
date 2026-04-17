// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // Backward compatibility shim for the swagger upgrade from package-2023-06-15 to package-2025-07-15.
    // The new API version removed the ExportRoutePolicyId property (replaced by the ExportRoutePolicy
    // nested object). This shim preserves the v1.1.2 property.
    public partial class ConnectedSubnetRoutePolicy
    {
        /// <summary> ARM Resource ID of the Route Policy. This is used for the backward compatibility. </summary>
        public ResourceIdentifier ExportRoutePolicyId { get; set; }
    }
}
