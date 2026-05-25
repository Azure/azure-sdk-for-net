// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    // Preserve the legacy class name "UnknownAlertsMetaDataProperties" for binary compatibility
    // with the AutoRest-based v1.1.1 SDK. The new TypeSpec generator emits this discriminator
    // fallback as "UnknownServiceAlertMetadataProperties" (reflecting the @@clientName rename of
    // AlertsMetaDataProperties to ServiceAlertMetadataProperties); the [CodeGenType] mapping
    // restores the original name.
    [CodeGenType("UnknownServiceAlertMetadataProperties")]
    internal partial class UnknownAlertsMetaDataProperties
    { }
}
