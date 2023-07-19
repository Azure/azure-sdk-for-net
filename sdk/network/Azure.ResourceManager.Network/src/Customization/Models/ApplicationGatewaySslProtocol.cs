// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Ssl protocol enums. </summary>
    public readonly partial struct ApplicationGatewaySslProtocol : IEquatable<ApplicationGatewaySslProtocol>
    {
#pragma warning disable CA1707
        /// <summary> TLS 1.0. </summary>
        [CodeGenMember("TLSv10")]
        public static ApplicationGatewaySslProtocol Tls1_0 { get; } = new ApplicationGatewaySslProtocol(Tls1_0Value);
        /// <summary> TLS 1.1. </summary>
        [CodeGenMember("TLSv11")]
        public static ApplicationGatewaySslProtocol Tls1_1 { get; } = new ApplicationGatewaySslProtocol(Tls1_1Value);
        /// <summary> TLS 1.2. </summary>
        [CodeGenMember("TLSv12")]
        public static ApplicationGatewaySslProtocol Tls1_2 { get; } = new ApplicationGatewaySslProtocol(Tls1_2Value);
#pragma warning restore CA1707
    }
}
