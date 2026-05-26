// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class ImportRoutePolicyInformation
    {
        /// <summary> Import IPv4 Route Policy Id. </summary>
        public ResourceIdentifier ImportIPv4RoutePolicyId
        {
            get => ImportIpv4RoutePolicyId;
            set => ImportIpv4RoutePolicyId = value;
        }

        /// <summary> Import IPv6 Route Policy Id. </summary>
        public ResourceIdentifier ImportIPv6RoutePolicyId
        {
            get => ImportIpv6RoutePolicyId;
            set => ImportIpv6RoutePolicyId = value;
        }
    }
}
