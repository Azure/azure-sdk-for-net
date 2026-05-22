// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class AccessControlListMatchConfiguration
    {
        /// <summary> Type of IP Address. IPv4 or IPv6. </summary>
        public NetworkFabricIPAddressType? IPAddressType
        {
            get => IpAddressType;
            set => IpAddressType = value;
        }
    }
}
