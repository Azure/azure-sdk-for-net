// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Cdn.Models
{
    // Reason: Backward compatibility — the old SDK (v1.5.1) shipped enum members
    // with underscored names (Tls1_0_2019, Tls1_2_2022, Tls1_2_2023). The new
    // TypeSpec generator produces ALL_CAPS names (TLS102019, TLS122022, TLS122023)
    // from spec member names (TLS10_2019), which duplicate the underscored names
    // that shipped in v1.5.1. The generator-produced duplicates are suppressed
    // below via [CodeGenSuppress], and the underscored members are re-added to
    // preserve the v1.5.1 public API.
    //
    // Cannot rename type from Afd to FrontDoor — this type is used as the property
    // type of generated class FrontDoorCustomDomainHttpsContent.CipherSuiteSetType.
    // Renaming causes an unfixable ApiCompat break (property type change on a
    // generated class that cannot be overridden via customization).
    [CodeGenSuppress("TLS102019")]
    [CodeGenSuppress("TLS122022")]
    [CodeGenSuppress("TLS122023")]
    public readonly partial struct AfdCipherSuiteSetType
    {
        /// <summary> Gets the Tls1_0_2019. </summary>
        public static AfdCipherSuiteSetType Tls1_0_2019 { get; } = new AfdCipherSuiteSetType(TLS102019Value);

        /// <summary> Gets the Tls1_2_2022. </summary>
        public static AfdCipherSuiteSetType Tls1_2_2022 { get; } = new AfdCipherSuiteSetType(TLS122022Value);

        /// <summary> Gets the Tls1_2_2023. </summary>
        public static AfdCipherSuiteSetType Tls1_2_2023 { get; } = new AfdCipherSuiteSetType(TLS122023Value);
    }
}
