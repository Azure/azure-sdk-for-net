// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network.Models
{
    public partial class NetworkIPConfigurationBgpPeeringAddress
    {
        public global::System.Collections.Generic.IList<global::System.String> CustomBgpIPAddresses => default;
        public global::System.Collections.Generic.IReadOnlyList<global::System.String> DefaultBgpIPAddresses => default;
        public global::System.String IPConfigurationId
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::System.Collections.Generic.IReadOnlyList<global::System.String> TunnelIPAddresses => default;
    }
}
