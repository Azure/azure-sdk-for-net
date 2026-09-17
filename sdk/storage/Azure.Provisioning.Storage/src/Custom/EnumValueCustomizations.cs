// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

// TypeSpec orders these values differently; preserve the shipped numeric values.
[assembly: CodeGenEnumValue("StoragePublicAccessType", "None", 0)]
[assembly: CodeGenEnumValue("StoragePublicAccessType", "Container", 1)]
[assembly: CodeGenEnumValue("StoragePublicAccessType", "Blob", 2)]

// TypeSpec emits the replacement Tls10-Tls13 names only; retain the shipped Tls1_0-Tls1_3 aliases and ordinals.
[assembly: CodeGenEnumValue(
    "StorageMinimumTlsVersion",
    "Tls1_0",
    0,
    WireName = "TLS1_0",
    EditorBrowsableNever = true,
    ObsoleteMessage = "Use Tls10 instead.")]
[assembly: CodeGenEnumValue(
    "StorageMinimumTlsVersion",
    "Tls1_1",
    1,
    WireName = "TLS1_1",
    EditorBrowsableNever = true,
    ObsoleteMessage = "Use Tls11 instead.")]
[assembly: CodeGenEnumValue(
    "StorageMinimumTlsVersion",
    "Tls1_2",
    2,
    WireName = "TLS1_2",
    EditorBrowsableNever = true,
    ObsoleteMessage = "Use Tls12 instead.")]
[assembly: CodeGenEnumValue(
    "StorageMinimumTlsVersion",
    "Tls1_3",
    3,
    WireName = "TLS1_3",
    EditorBrowsableNever = true,
    ObsoleteMessage = "Use Tls13 instead.")]
