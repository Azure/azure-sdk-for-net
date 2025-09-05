// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    public readonly partial struct AfdCipherSuiteSetType
    {
        /// <summary> TLS1_0_2019. </summary>
        [CodeGenMember("TLS102019")]
        public static AfdCipherSuiteSetType Tls1_0_2019 { get; } = new AfdCipherSuiteSetType(Tls1_0_2019Value);
        /// <summary> TLS1_2_2022. </summary>
        [CodeGenMember("TLS122022")]
        public static AfdCipherSuiteSetType Tls1_2_2022 { get; } = new AfdCipherSuiteSetType(Tls1_2_2022Value);
        /// <summary> TLS1_2_2023. </summary>
        [CodeGenMember("TLS122023")]
        public static AfdCipherSuiteSetType Tls1_2_2023 { get; } = new AfdCipherSuiteSetType(Tls1_2_2023Value);
    }
}