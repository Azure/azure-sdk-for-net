// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.IotFirmwareDefense.Models
{
    // Preserve the legacy class name "UnknownSummaryResourceProperties" for binary compatibility
    // with the AutoRest-based v1.1.1 SDK. The new TypeSpec generator emits this discriminator
    // fallback as "UnknownFirmwareAnalysisSummaryProperties" after the C# client-name rename of
    // SummaryResourceProperties to FirmwareAnalysisSummaryProperties; the [CodeGenType] mapping
    // restores the original name.
    [CodeGenType("UnknownFirmwareAnalysisSummaryProperties")]
    internal partial class UnknownSummaryResourceProperties
    { }
}
