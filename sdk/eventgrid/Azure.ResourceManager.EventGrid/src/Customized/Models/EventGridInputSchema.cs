// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid.Models
{
    [CodeGenSuppress("CloudEventSchemaV10")]
    public readonly partial struct EventGridInputSchema
    {
        /// <summary> CloudEventSchemaV1_0. </summary>
        public static EventGridInputSchema CloudEventSchemaV1_0 { get; } = new("CloudEventSchemaV1_0");
    }
}
