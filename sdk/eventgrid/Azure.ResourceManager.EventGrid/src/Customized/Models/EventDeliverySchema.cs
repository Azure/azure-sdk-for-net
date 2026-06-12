// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.EventGrid.Models
{
    public readonly partial struct EventDeliverySchema
    {
        /// <summary> CloudEventSchemaV1_0. </summary>
        public static EventDeliverySchema CloudEventSchemaV1_0 => CloudEventSchemaV10;
    }
}
