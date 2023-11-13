// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text.Json;

namespace Azure.Communication.JobRouter
{
    public partial class WeightedAllocationQueueSelectorAttachment : IUtf8JsonSerializable
    {
        /// <summary> Initializes a new instance of WeightedAllocationQueueSelectorAttachment. </summary>
        /// <param name="allocations"> A collection of percentage based weighted allocations. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="allocations"/> is null. </exception>
        public WeightedAllocationQueueSelectorAttachment(IEnumerable<QueueWeightedAllocation> allocations)
        {
            Argument.AssertNotNull(allocations, nameof(allocations));

            Kind = "weighted-allocation-queue-selector";
            Allocations = allocations.ToList();
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("allocations"u8);
            writer.WriteStartArray();
            foreach (var item in Allocations)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            writer.WriteEndObject();
        }
    }
}
