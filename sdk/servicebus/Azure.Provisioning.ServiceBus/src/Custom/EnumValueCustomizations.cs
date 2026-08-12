// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

[assembly: CodeGenEnumValue("ServiceBusMessagingEntityStatus", "Unknown", 0)]
[assembly: CodeGenEnumValue("ServiceBusMinimumTlsVersion", "Tls1_0", 0, WireName = "1.0")]
[assembly: CodeGenEnumValue("ServiceBusMinimumTlsVersion", "Tls1_1", 1, WireName = "1.1")]
[assembly: CodeGenEnumValue("ServiceBusMinimumTlsVersion", "Tls1_2", 2, WireName = "1.2")]
[assembly: CodeGenEnumValue("ServiceBusMinimumTlsVersion", "Tls1_3", 3, WireName = "1.3")]
