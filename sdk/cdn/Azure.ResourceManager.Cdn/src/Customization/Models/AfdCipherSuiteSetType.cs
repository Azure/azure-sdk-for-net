// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    public readonly partial struct AfdCipherSuiteSetType
    {
        [CodeGenMember("TLS102019")]
        /// <summary> TLS1.0_2019. </summary>
        public static AfdCipherSuiteSetType Tls1_0_2019 { get; } = new AfdCipherSuiteSetType(Tls1_0_2019Value);
        [CodeGenMember("TLS122022")]
        /// <summary> TLS1.2_2022. </summary>
        public static AfdCipherSuiteSetType Tls1_2_2022 { get; } = new AfdCipherSuiteSetType(Tls1_2_2022Value);
        [CodeGenMember("TLS122023")]
        /// <summary> TLS1.2_2023. </summary>
        public static AfdCipherSuiteSetType Tls1_2_2023 { get; } = new AfdCipherSuiteSetType(Tls1_2_2023Value);
    }
}