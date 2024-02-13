// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenSerialization(nameof(ExpiresAfter), SerializationValueHook = nameof(WriteExpiresAfter), DeserializationValueHook = nameof(ReadExpiresAfter))]
    public partial class RouterWorkerSelector
    {
        /// <summary> Describes how long this label selector is valid for. </summary>
        [CodeGenMember("ExpiresAfterSeconds")]
        public TimeSpan? ExpiresAfter { get; set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteExpiresAfter(Utf8JsonWriter writer)
        {
            writer.WriteNumberValue(ExpiresAfter.Value.TotalSeconds);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadExpiresAfter(JsonProperty property, ref Optional<TimeSpan> expiresAfter)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            var value = property.Value.GetDouble();
            expiresAfter = TimeSpan.FromSeconds(value);
        }

        [CodeGenMember("Value")]
        private BinaryData _value
        {
            get
            {
                return BinaryData.FromObjectAsJson(Value.Value);
            }
            set
            {
                Value = new RouterValue(value.ToObjectFromJson());
            }
        }

        /// <summary> The value to compare against the actual label value with the given operator. Values must be primitive values - number, string, boolean. </summary>
        public RouterValue Value { get; internal set; }

        /// <summary> Pushes the job to the front of the queue as long as this selector is active. </summary>
        public bool? Expedite { get; set; }

        /// <summary> Initializes a new instance of WorkerSelector. </summary>
        /// <param name="key"> The label key to query against. </param>
        /// <param name="labelOperator"> Describes how the value of the label is compared to the value defined on the label selector. </param>
        /// <param name="value"> The value to compare against the actual label value with the given operator. </param>
        public RouterWorkerSelector(string key, LabelOperator labelOperator, RouterValue value)
        {
            Key = key;
            LabelOperator = labelOperator;
            Value = value;
        }
    }
}
