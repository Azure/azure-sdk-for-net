// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Network
{
    public partial class PublicIPPrefixData
    {
        // Preserve the 1.15.0 setter signature over the current service-populated, read-only reference.
        /// <summary> Reference to the frontend ip address configuration defined in regional loadbalancer. </summary>
        /// <remarks> The setter is retained for compatibility with version 1.15.0. Assignments have no effect because the current service model treats this reference as read-only. </remarks>
        [WirePath("properties.loadBalancerFrontendIpConfiguration.id")]
        public ResourceIdentifier LoadBalancerFrontendIPConfigurationId
        {
            get => Properties is null ? default : Properties.LoadBalancerFrontendIPConfigurationId;
            set
            {
                // The current service model does not accept this reference in requests.
            }
        }
    }
}
