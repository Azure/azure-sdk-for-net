// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

// Preserve enum ordinals from Azure.Provisioning.EventGrid 1.1.0.
[assembly: CodeGenEnumValue("EventDeliverySchema", "CloudEventSchemaV1_0", 0)]
[assembly: CodeGenEnumValue("EventDeliverySchema", "EventGridSchema", 1)]
[assembly: CodeGenEnumValue("EventDeliverySchema", "CustomInputSchema", 2)]
[assembly: CodeGenEnumValue("EventGridInputSchema", "CloudEventSchemaV1_0", 0)]
[assembly: CodeGenEnumValue("EventGridInputSchema", "EventGridSchema", 1)]
[assembly: CodeGenEnumValue("EventGridInputSchema", "CustomEventSchema", 2)]
