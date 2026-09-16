// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

// Preserve enum ordinals shipped by the reflection-based provisioning generator.
[assembly: CodeGenEnumValue("KeyVaultSecretStatus", "Unknown", 0)]
[assembly: CodeGenEnumValue("PublicCertificateLocation", "Unknown", 0)]
[assembly: CodeGenEnumValue(
    "AppServiceSupportedTlsVersion",
    "Tls1_3",
    3,
    WireName = "1.3")]
[assembly: CodeGenEnumValue(
    "AppServiceSupportedTlsVersion",
    "One3",
    3,
    WireName = "1.3",
    EditorBrowsableNever = true,
    ObsoleteMessage = "Use Tls1_3 instead.")]
