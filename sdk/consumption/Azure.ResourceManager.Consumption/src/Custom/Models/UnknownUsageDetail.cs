// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Consumption.Models
{
    // Although this type is internal, the v1.1.0 baseline assembly emits
    // [PersistableModelProxyAttribute(typeof(UnknownUsageDetail))] on the PUBLIC discriminator
    // base type ConsumptionUsageDetail. That attribute argument captures the internal type's
    // name into the public metadata of a public type, so renaming the generator default
    // 'UnknownConsumptionUsageDetail' back to the v1.1.0 'UnknownUsageDetail' is required for
    // binary compatibility (ApiCompat: CannotChangeAttribute on PersistableModelProxyAttribute).
    [CodeGenType("UnknownConsumptionUsageDetail")]
    internal partial class UnknownUsageDetail
    {
    }
}
