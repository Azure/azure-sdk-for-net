// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Network
{
    public partial class PublicIPPrefixData
    {
        /// <summary> Reference to the frontend ip address configuration defined in regional loadbalancer. </summary>
        [WirePath("properties.loadBalancerFrontendIPConfiguration")]
        public ResourceIdentifier LoadBalancerFrontendIPConfigurationId
        {
            get => LoadBalancerFrontendIpConfigurationId;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }
}
