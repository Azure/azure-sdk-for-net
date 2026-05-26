// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // Preserve the acronym-cased route policy ID properties shipped by the previous SDK.
    // Removing these aliases would force callers to move from IPv4/IPv6 to Ipv4/Ipv6 names.
    public partial class ExportRoutePolicy
    {
        /// <summary> ARM resource ID of RoutePolicy. </summary>
        public ResourceIdentifier ExportIPv4RoutePolicyId
        {
            get => ExportIpv4RoutePolicyId;
            set => ExportIpv4RoutePolicyId = value;
        }

        /// <summary> ARM resource ID of RoutePolicy. </summary>
        public ResourceIdentifier ExportIPv6RoutePolicyId
        {
            get => ExportIpv6RoutePolicyId;
            set => ExportIpv6RoutePolicyId = value;
        }
    }
}
