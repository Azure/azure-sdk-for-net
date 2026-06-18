// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the BgpConnectionData type. </summary>
    public partial class BgpConnectionData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.String PeerIP
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }
}
