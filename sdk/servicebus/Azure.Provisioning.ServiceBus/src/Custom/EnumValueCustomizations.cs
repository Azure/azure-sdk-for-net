// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

[assembly: CodeGenEnumValue("ServiceBusMessagingEntityStatus", "Unknown", 0)]
[assembly: CodeGenEnumValue(
    "ServiceBusMinimumTlsVersion",
    "Tls1_0",
    0,
    WireName = "1.0",
    EditorBrowsableNever = true,
    ObsoleteMessage = "Use Tls10 instead.")]
[assembly: CodeGenEnumValue(
    "ServiceBusMinimumTlsVersion",
    "Tls1_1",
    1,
    WireName = "1.1",
    EditorBrowsableNever = true,
    ObsoleteMessage = "Use Tls11 instead.")]
[assembly: CodeGenEnumValue(
    "ServiceBusMinimumTlsVersion",
    "Tls1_2",
    2,
    WireName = "1.2",
    EditorBrowsableNever = true,
    ObsoleteMessage = "Use Tls12 instead.")]
[assembly: CodeGenEnumValue(
    "ServiceBusMinimumTlsVersion",
    "Tls1_3",
    3,
    WireName = "1.3",
    EditorBrowsableNever = true,
    ObsoleteMessage = "Use Tls13 instead.")]
