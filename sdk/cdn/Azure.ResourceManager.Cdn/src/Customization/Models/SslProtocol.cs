// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> The protocol of an established TLS connection. </summary>
    public readonly partial struct SslProtocol : IEquatable<SslProtocol>
    {
#pragma warning disable CA1707
        /// <summary> TLS 1.0. </summary>
        [CodeGenMember("TLSv1")]
        public static SslProtocol Tls1_0 { get; } = new SslProtocol(Tls1_0Value);
        /// <summary> TLS 1.1. </summary>
        [CodeGenMember("TLSv11")]
        public static SslProtocol Tls1_1 { get; } = new SslProtocol(Tls1_1Value);
        /// <summary> TLS 1.2. </summary>
        [CodeGenMember("TLSv12")]
        public static SslProtocol Tls1_2 { get; } = new SslProtocol(Tls1_2Value);
#pragma warning restore CA1707
    }
}
