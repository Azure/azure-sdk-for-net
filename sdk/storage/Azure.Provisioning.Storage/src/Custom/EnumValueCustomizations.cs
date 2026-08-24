// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

// TypeSpec uses new TLS member names and reorders public access values. Preserve the shipped
// aliases and numeric values so compiled callers and serialized enum values remain compatible.
[assembly: CodeGenEnumValue("StorageMinimumTlsVersion", "Tls1_0", 0, WireName = "TLS1_0")]
[assembly: CodeGenEnumValue("StorageMinimumTlsVersion", "Tls1_1", 1, WireName = "TLS1_1")]
[assembly: CodeGenEnumValue("StorageMinimumTlsVersion", "Tls1_2", 2, WireName = "TLS1_2")]
[assembly: CodeGenEnumValue("StorageMinimumTlsVersion", "Tls1_3", 3, WireName = "TLS1_3")]
[assembly: CodeGenEnumValue("StoragePublicAccessType", "None", 0)]
[assembly: CodeGenEnumValue("StoragePublicAccessType", "Container", 1)]
[assembly: CodeGenEnumValue("StoragePublicAccessType", "Blob", 2)]
