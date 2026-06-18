// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the NetworkPrivateLinkServiceConnection type. </summary>
    public partial class NetworkPrivateLinkServiceConnection
    {
        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Network.Models.NetworkPrivateLinkServiceConnectionState ConnectionState
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }
}
