// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Consumption.Models
{
    // Although this type is internal, the v1.1.0 baseline assembly emits
    // [PersistableModelProxyAttribute(typeof(UnknownReservationRecommendation))] on the
    // PUBLIC discriminator base type ConsumptionReservationRecommendation. That attribute
    // argument captures the internal type's name into the public metadata of a public type,
    // so renaming the generator default 'UnknownConsumptionReservationRecommendation' back to
    // the v1.1.0 'UnknownReservationRecommendation' is required for binary compatibility
    // (ApiCompat: CannotChangeAttribute on PersistableModelProxyAttribute).
    [CodeGenType("UnknownConsumptionReservationRecommendation")]
    internal partial class UnknownReservationRecommendation
    {
    }
}
