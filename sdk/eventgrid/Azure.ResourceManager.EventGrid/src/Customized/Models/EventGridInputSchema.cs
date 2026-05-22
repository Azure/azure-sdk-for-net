// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.EventGrid.Models
{
    public partial struct EventGridInputSchema
    {
        // Back-compat alias: the generator collapses "V1_0" -> "V10" when synthesizing
        // the property identifier from the wire value "CloudEventSchemaV1_0".
        /// <summary> CloudEventSchemaV1_0 (back-compat alias for <see cref="CloudEventSchemaV10"/>). </summary>
        public static EventGridInputSchema CloudEventSchemaV1_0 => CloudEventSchemaV10;
    }
}
