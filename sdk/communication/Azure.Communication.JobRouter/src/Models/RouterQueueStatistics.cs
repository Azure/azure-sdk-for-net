// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenSerialization(nameof(EstimatedWaitTimes), SerializationValueHook = nameof(WriteEstimatedWaitTimes), DeserializationValueHook = nameof(ReadEstimatedWaitTimes))]
    public partial class RouterQueueStatistics
    {
        /// <summary>
        /// The estimated wait time of this queue rounded up to the nearest minute, grouped
        /// by job priority
        /// </summary>
        [CodeGenMember("EstimatedWaitTimeMinutes")]
        public IDictionary<int, TimeSpan> EstimatedWaitTimes { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteEstimatedWaitTimes(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            foreach (var item in EstimatedWaitTimes)
            {
                writer.WritePropertyName(item.Key.ToString());
                writer.WriteNumberValue(item.Value.TotalMinutes);
            }
            writer.WriteEndObject();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadEstimatedWaitTimes(JsonProperty property, ref IDictionary<int, TimeSpan> estimatedWaitTimes)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            var result = new Dictionary<int, TimeSpan>();
            foreach (var property0 in property.Value.EnumerateObject())
            {
                result.Add(int.Parse(property0.Name), TimeSpan.FromMinutes(property0.Value.GetDouble()));
            }
            estimatedWaitTimes = result;
        }
    }
}
