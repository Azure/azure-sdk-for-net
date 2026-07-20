// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: Use CodeGenMember to rename generated enum members to maintain
    // the underscored naming from the previous SDK (v1.5.1: Tls1_0_2019, Tls1_2_2022,
    // Tls1_2_2023). The TypeSpec generator produces ALL_CAPS names from the spec
    // member names (TLS10_2019 -> TLS102019, etc.). CodeGenMember maps the generated
    // names to the old underscored names to preserve public API naming compatibility.
    //
    // Cannot rename type from Afd to FrontDoor — this type is used as the property
    // type of generated class FrontDoorCustomDomainHttpsContent.CipherSuiteSetType.
    // Renaming causes an unfixable ApiCompat break (property type change on a
    // generated class that cannot be overridden via customization).
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
