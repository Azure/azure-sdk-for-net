// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.EventGrid.Models
{
    public readonly partial struct EventGridInputSchema : IEquatable<EventGridInputSchema>
    {
        /// <summary> CloudEventSchemaV1_0. </summary>
        [CodeGenMember("CloudEventSchemaV10")]
#pragma warning disable CA1707
        public static EventGridInputSchema CloudEventSchemaV1_0 { get; } = new EventGridInputSchema(CloudEventSchemaV1_0Value);
#pragma warning restore CA1707
    }
}
