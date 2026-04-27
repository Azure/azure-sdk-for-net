// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Consumption.Models
{
    // Rename the generated UnknownConsumptionUsageDetail to UnknownUsageDetail via [CodeGenType]
    // to keep the internal sentinel discriminator subclass name consistent with the rest of the
    // SDK's "Unknown*" naming convention.
    [CodeGenType("UnknownConsumptionUsageDetail")]
    internal partial class UnknownUsageDetail
    {
    }
}
