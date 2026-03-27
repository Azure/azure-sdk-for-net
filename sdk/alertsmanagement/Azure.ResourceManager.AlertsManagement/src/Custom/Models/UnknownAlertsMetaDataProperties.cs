// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    // Backward compatibility: the old SDK (AutoRest-based, v1.1.1) named the unknown
    // discriminator fallback class "UnknownAlertsMetaDataProperties". The new TypeSpec generator
    // produces "UnknownServiceAlertMetadataProperties" (reflecting the @@clientName rename of
    // AlertsMetaDataProperties to ServiceAlertMetadataProperties). This [CodeGenType] mapping
    // preserves the old class name for binary compatibility.
    [CodeGenType("UnknownServiceAlertMetadataProperties")]
    internal partial class UnknownAlertsMetaDataProperties
    { }
}
