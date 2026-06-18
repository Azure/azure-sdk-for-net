// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility alias for VPN packet capture stop parameters. </summary>
    [ObsoleteAttribute("This class is obsolete and will be removed in a future release", false)]
    public partial class VpnPacketCaptureStopParameters : VpnPacketCaptureStopContent
    {
        /// <summary> Initializes a new instance of <see cref="VpnPacketCaptureStopParameters"/>. </summary>
        public VpnPacketCaptureStopParameters()
        {
        }
    }
}
