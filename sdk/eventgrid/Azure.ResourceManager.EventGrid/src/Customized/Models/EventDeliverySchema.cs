// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.EventGrid.Models
{
    public readonly partial struct EventDeliverySchema : IEquatable<EventDeliverySchema>
    {
        /// <summary> CloudEventSchemaV1_0. </summary>
        [CodeGenMember("CloudEventSchemaV10")]
#pragma warning disable CA1707
        public static EventDeliverySchema CloudEventSchemaV1_0 { get; } = new EventDeliverySchema(CloudEventSchemaV1_0Value);
#pragma warning restore CA1707
    }
}
