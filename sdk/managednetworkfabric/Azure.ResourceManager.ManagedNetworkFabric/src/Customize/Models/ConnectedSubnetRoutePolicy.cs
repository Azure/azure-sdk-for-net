// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class ConnectedSubnetRoutePolicy
    {
        /// <summary> ARM Resource ID of the Route Policy. </summary>
        public ResourceIdentifier ExportRoutePolicyId { get; set; }
    }
}
