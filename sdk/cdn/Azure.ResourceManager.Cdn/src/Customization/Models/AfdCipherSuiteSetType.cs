// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

using Azure.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file uses CodeGenMember to rename enum members to maintain the naming convention from the previous SDK.
    // Reason: The TypeSpec generator removes separators (underscores, dots) from version numbers to produce member names (e.g., TLS102019),
    // but the old SDK used underscore-separated readable names (e.g., Tls1_0_2019).
    // CodeGenMember attributes map the generated names to the old names to preserve public API naming compatibility.
    // Note: This type retains the original "Afd" prefix because @@clientName cannot rename it without breaking the
    // generated property FrontDoorCustomDomainHttpsContent.CipherSuiteSetType, which uses this type directly.
    public readonly partial struct AfdCipherSuiteSetType
    {
        /// <summary> TLS1_0_2019. </summary>
        [CodeGenMember("TLS102019")]
        public static AfdCipherSuiteSetType Tls1_0_2019 { get; } = new AfdCipherSuiteSetType(TLS102019Value);
        /// <summary> TLS1_2_2022. </summary>
        [CodeGenMember("TLS122022")]
        public static AfdCipherSuiteSetType Tls1_2_2022 { get; } = new AfdCipherSuiteSetType(TLS122022Value);
        /// <summary> TLS1_2_2023. </summary>
        [CodeGenMember("TLS122023")]
        public static AfdCipherSuiteSetType Tls1_2_2023 { get; } = new AfdCipherSuiteSetType(TLS122023Value);
    }
}
