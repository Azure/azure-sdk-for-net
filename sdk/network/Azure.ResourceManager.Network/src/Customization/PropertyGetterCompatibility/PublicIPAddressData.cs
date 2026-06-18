// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the PublicIPAddressData type. </summary>
    public partial class PublicIPAddressData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.String IPAddress
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Network.Models.NetworkIPConfiguration IPConfiguration => IpConfiguration;
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.IPTag> IPTags => default;
    }
}
