// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

#nullable disable

namespace Azure.Communication.JobRouter
{
    /// <summary> Trigger for an exception action on exceeding wait time. </summary>
    [CodeGenSerialization(nameof(Threshold), SerializationValueHook = nameof(WriteThresholdSeconds), DeserializationValueHook = nameof(ReadThresholdSeconds))]
    public partial class WaitTimeExceptionTrigger
    {
        /// <summary> Initializes a new instance of WaitTimeExceptionTrigger. </summary>
        /// <param name="threshold"> Threshold for wait time for this trigger. </param>
        public WaitTimeExceptionTrigger(TimeSpan threshold)
        {
            Kind = ExceptionTriggerKind.WaitTime;
            Threshold = threshold;
        }

        /// <summary> Threshold for wait time for this trigger. </summary>
        [CodeGenMember("ThresholdSeconds")]
        public TimeSpan Threshold { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteThresholdSeconds(Utf8JsonWriter writer)
        {
            writer.WriteNumberValue(Threshold.TotalSeconds);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadThresholdSeconds(JsonProperty property, ref TimeSpan threshold)
        {
            threshold = TimeSpan.FromSeconds(property.Value.GetDouble());
        }
    }
}
