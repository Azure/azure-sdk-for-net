// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network
{
    public partial class SubnetData
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> IPAllocations => default;
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Network.Models.NetworkIPConfigurationProfile> IPConfigurationProfiles => default;
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Network.Models.NetworkIPConfiguration> IPConfigurations => Properties is null ? default : Properties.IpConfigurations;
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.VirtualNetworkPrivateEndpointNetworkPolicy> PrivateEndpointNetworkPolicy
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.VirtualNetworkPrivateLinkServiceNetworkPolicy> PrivateLinkServiceNetworkPolicy
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }
}
