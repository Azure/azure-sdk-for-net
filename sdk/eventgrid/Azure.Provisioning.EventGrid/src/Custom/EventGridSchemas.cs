// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.EventGrid;

/// <summary> The schema used for event delivery. </summary>
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

/// <summary> The input schema for events published to an Event Grid resource. </summary>
[CodeGenType("EventGridInputSchema")]
public enum EventGridInputSchema
{
    /// <summary> CloudEvents schema version 1.0. </summary>
    CloudEventSchemaV1_0 = 0,
    /// <summary> Event Grid schema. </summary>
    EventGridSchema = 1,
    /// <summary> Custom event schema. </summary>
    CustomEventSchema = 2,
}
