// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.MySql.Models
{
    [CodeGenModel("MySqlMinimalTlsVersionEnum")]
    public readonly partial struct MySqlMinimalTlsVersionEnum
    {
        /// <summary> TLS1_0. </summary>
        [CodeGenMember("TLS10")]
        public static MySqlMinimalTlsVersionEnum Tls1_0 { get; } = new MySqlMinimalTlsVersionEnum(Tls1_0Value);
        /// <summary> TLS1_1. </summary>
        [CodeGenMember("TLS11")]
        public static MySqlMinimalTlsVersionEnum Tls1_1 { get; } = new MySqlMinimalTlsVersionEnum(Tls1_1Value);
        /// <summary> TLS1_2. </summary>
        [CodeGenMember("TLS12")]
        public static MySqlMinimalTlsVersionEnum Tls1_2 { get; } = new MySqlMinimalTlsVersionEnum(Tls1_2Value);
    }
}
