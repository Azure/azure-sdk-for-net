// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid.Models
{
    public readonly partial struct EventDeliverySchema
    {
        /// <summary> CloudEventSchemaV1_0. </summary>
        [CodeGenMember("CloudEventSchemaV10")]
        public static EventDeliverySchema CloudEventSchemaV1_0 { get; } = new("CloudEventSchemaV1_0");
    }
}
