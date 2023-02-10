// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Redis.Models
{
    /// <summary>
    /// Optional: requires clients to use a specified TLS version (or higher) to connect (e,g, &apos;1.0&apos;, &apos;1.1&apos;, &apos;1.2&apos;)
    /// Serialized Name: TlsVersion
    /// </summary>
    public readonly partial struct RedisTlsVersion : IEquatable<RedisTlsVersion>
    {
#pragma warning disable CA1707
        /// <summary>
        /// 1.0
        /// Serialized Name: TlsVersion.1.0
        /// </summary>
        [CodeGenMember("One0")]
        public static RedisTlsVersion Tls1_0 { get; } = new RedisTlsVersion(Tls1_0Value);
        /// <summary>
        /// 1.1
        /// Serialized Name: TlsVersion.1.1
        /// </summary>
        [CodeGenMember("One1")]
        public static RedisTlsVersion Tls1_1 { get; } = new RedisTlsVersion(Tls1_1Value);
        /// <summary>
        /// 1.2
        /// Serialized Name: TlsVersion.1.2
        /// </summary>
        [CodeGenMember("One2")]
        public static RedisTlsVersion Tls1_2 { get; } = new RedisTlsVersion(Tls1_2Value);
#pragma warning restore CA1707
    }
}
