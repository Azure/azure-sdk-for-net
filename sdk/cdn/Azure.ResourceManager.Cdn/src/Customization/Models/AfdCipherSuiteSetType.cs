// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Cdn.Models
{
    // Reason: Backward compatibility — the old SDK (v1.5.1) shipped enum members
    // with underscored names (Tls1_0_2019, Tls1_2_2022, Tls1_2_2023), while the
    // generator now produces ALL_CAPS names (TLS102019, TLS122022, TLS122023).
    // These properties preserve the old public API to avoid breaking existing callers.
    //
    // Cannot rename type from Afd to FrontDoor — this type is used as the property
    // type of generated class FrontDoorCustomDomainHttpsContent.CipherSuiteSetType.
    // Renaming causes an unfixable ApiCompat break (property type change on a
    // generated class that cannot be overridden via customization).
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
