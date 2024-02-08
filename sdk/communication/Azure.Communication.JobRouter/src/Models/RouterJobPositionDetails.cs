// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenSerialization(nameof(EstimatedWaitTime), SerializationValueHook = nameof(WriteEstimatedWaitTime), DeserializationValueHook = nameof(ReadEstimatedWaitTime))]
    public partial class RouterJobPositionDetails
    {
        /// <summary> Estimated wait time of the job rounded up to the nearest minute. </summary>
        [CodeGenMember("EstimatedWaitTimeMinutes")]
        public TimeSpan EstimatedWaitTime { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteEstimatedWaitTime(Utf8JsonWriter writer)
        {
            writer.WriteNumberValue(EstimatedWaitTime.TotalMinutes);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadEstimatedWaitTime(JsonProperty property, ref TimeSpan estimatedWaitTime)
        {
            estimatedWaitTime = TimeSpan.FromMinutes(property.Value.GetDouble());
        }
    }
}
