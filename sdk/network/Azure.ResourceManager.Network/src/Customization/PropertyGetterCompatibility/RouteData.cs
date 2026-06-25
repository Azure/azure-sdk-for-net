// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the RouteData type. </summary>
    public partial class RouteData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.String NextHopIPAddress
        {
            get => NextHopIpAddress;
            set => NextHopIpAddress = value;
        }
    }
}
