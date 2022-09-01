// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.FrontDoor.Models
{
    /// <summary> The minimum TLS version required from the clients to establish an SSL handshake with Front Door. </summary>
    public readonly partial struct MinimumTlsVersion : IEquatable<MinimumTlsVersion>
    {
#pragma warning disable CA1707
        /// <summary> 1.0. </summary>
        [CodeGenMember("One0")]
        public static MinimumTlsVersion Tls1_0 { get; } = new MinimumTlsVersion(Tls1_0Value);
        /// <summary> 1.2. </summary>
        [CodeGenMember("One2")]
        public static MinimumTlsVersion Tls1_2 { get; } = new MinimumTlsVersion(Tls1_2Value);
#pragma warning restore CA1707
    }
}
