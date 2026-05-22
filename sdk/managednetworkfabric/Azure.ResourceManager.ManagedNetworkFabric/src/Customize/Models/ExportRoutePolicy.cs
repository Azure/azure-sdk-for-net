// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class ExportRoutePolicy
    {
        /// <summary> ARM Resource ID of the IPv4 RoutePolicy. </summary>
        public ResourceIdentifier ExportIPv4RoutePolicyId
        {
            get => ExportIpv4RoutePolicyId;
            set => ExportIpv4RoutePolicyId = value;
        }

        /// <summary> ARM Resource ID of the IPv6 RoutePolicy. </summary>
        public ResourceIdentifier ExportIPv6RoutePolicyId
        {
            get => ExportIpv6RoutePolicyId;
            set => ExportIpv6RoutePolicyId = value;
        }
    }
}
