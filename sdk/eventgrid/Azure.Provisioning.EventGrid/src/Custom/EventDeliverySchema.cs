// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.EventGrid;

/// <summary> The schema used for event delivery. </summary>
// The TypeSpec declaration order changes the generated numeric values. Preserve the released
// ordinals because these enum values can be cast to and from their underlying integers.
[CodeGenType("EventDeliverySchema")]
public enum EventDeliverySchema
{
    /// <summary> CloudEvents schema version 1.0. </summary>
    CloudEventSchemaV1_0 = 0,
    /// <summary> Event Grid schema. </summary>
    EventGridSchema = 1,
    /// <summary> Custom input schema. </summary>
    CustomInputSchema = 2,
}
