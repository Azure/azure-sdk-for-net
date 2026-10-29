// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility alias for VPN packet capture stop parameters. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This class is obsolete and will be removed in a future release", false)]
    public partial class VpnPacketCaptureStopParameters : VpnPacketCaptureStopContent
    {
        /// <summary> Initializes a new instance of <see cref="VpnPacketCaptureStopParameters"/>. </summary>
        public VpnPacketCaptureStopParameters()
        {
        }
    }
}
