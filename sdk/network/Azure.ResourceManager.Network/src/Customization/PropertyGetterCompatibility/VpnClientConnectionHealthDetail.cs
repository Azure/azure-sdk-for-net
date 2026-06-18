// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the VpnClientConnectionHealthDetail type. </summary>
    public partial class VpnClientConnectionHealthDetail
    {
        // TypeSpec customization restores the shipped acronym/unit names, but these output-only
        // properties are still emitted only through serialization/constructor code. Add the public
        // surface with backing storage so generated deserialization returns the service values.
        /// <summary> The assigned private IP of a connected VPN client. </summary>
        public string PrivateIPAddress { get; private set; }
        /// <summary> The public IP of a connected VPN client. </summary>
        public string PublicIPAddress { get; private set; }
        /// <summary> The duration time of a connected VPN client in seconds. </summary>
        public long? VpnConnectionDurationInSeconds { get; private set; }
        /// <summary> The start time of a connected VPN client. </summary>
        public DateTimeOffset? VpnConnectionOn { get; private set; }
    }
}
