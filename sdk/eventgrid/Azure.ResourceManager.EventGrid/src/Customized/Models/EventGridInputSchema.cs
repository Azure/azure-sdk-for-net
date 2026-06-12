// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.EventGrid.Models
{
    public readonly partial struct EventGridInputSchema
    {
        /// <summary> CloudEventSchemaV1_0. </summary>
        public static EventGridInputSchema CloudEventSchemaV1_0 => CloudEventSchemaV10;
    }
}
