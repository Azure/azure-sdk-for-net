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

#pragma warning disable SA1402 // Compatibility shims for multiple removed GA types are grouped intentionally.
namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility alias for VPN packet capture stop parameters. </summary>
    [Obsolete]
    public partial class VpnPacketCaptureStopParameters : VpnPacketCaptureStopContent
    {
        /// <summary> Initializes a new instance of <see cref="VpnPacketCaptureStopParameters"/>. </summary>
        public VpnPacketCaptureStopParameters()
        {
        }
    }
}
