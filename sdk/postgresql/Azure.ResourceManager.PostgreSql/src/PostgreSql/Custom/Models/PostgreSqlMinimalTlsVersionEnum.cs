// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.PostgreSql.Models
{
    /// <summary> Enforce a minimal Tls version for the server. </summary>
    public readonly partial struct PostgreSqlMinimalTlsVersionEnum : IEquatable<PostgreSqlMinimalTlsVersionEnum>
    {
#pragma warning disable CA1707
        /// <summary> TLS1_0. </summary>
        [CodeGenMember("TLS10")]
        public static PostgreSqlMinimalTlsVersionEnum Tls1_0 { get; } = new PostgreSqlMinimalTlsVersionEnum(Tls1_0Value);
        /// <summary> TLS1_1. </summary>
        [CodeGenMember("TLS11")]
        public static PostgreSqlMinimalTlsVersionEnum Tls1_1 { get; } = new PostgreSqlMinimalTlsVersionEnum(Tls1_1Value);
        /// <summary> TLS1_2. </summary>
        [CodeGenMember("TLS12")]
        public static PostgreSqlMinimalTlsVersionEnum Tls1_2 { get; } = new PostgreSqlMinimalTlsVersionEnum(Tls1_2Value);
#pragma warning restore CA1707
    }
}
