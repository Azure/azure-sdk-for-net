// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("RouterWorkerSelector")]
    [CodeGenSuppress("RouterWorkerSelector", typeof(string), typeof(LabelOperator))]
    public partial class RouterWorkerSelector : IUtf8JsonSerializable
    {
        /// <summary> Describes how long this label selector is valid for. </summary>
        public TimeSpan? ExpiresAfter { get; set; }

        [CodeGenMember("ExpiresAfterSeconds")]
        internal double? _expiresAfterSeconds {
            get
            {
                return ExpiresAfter?.TotalSeconds is null or 0 ? null : ExpiresAfter?.TotalSeconds;
            }
            set
            {
                ExpiresAfter = value != null ? TimeSpan.FromSeconds(value.Value) : null;
            }
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
                Value = new LabelValue(value.ToObjectFromJson());
            }
        }

        /// <summary> The value to compare against the actual label value with the given operator. </summary>
        public LabelValue Value { get; set; }

        /// <summary> The time at which this worker selector expires in UTC. </summary>
        public DateTimeOffset? ExpiresAt { get; set; }

        /// <summary> Initializes a new instance of WorkerSelector. </summary>
        /// <param name="key"> The label key to query against. </param>
        /// <param name="labelOperator"> Describes how the value of the label is compared to the value defined on the label selector. </param>
        /// <param name="value"> The value to compare against the actual label value with the given operator. </param>
        public RouterWorkerSelector(string key, LabelOperator labelOperator, LabelValue value)
        {
            Key = key;
            LabelOperator = labelOperator;
            Value = value;
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("key"u8);
            writer.WriteStringValue(Key);
            writer.WritePropertyName("labelOperator"u8);
            writer.WriteStringValue(LabelOperator.ToString());
            if (Optional.IsDefined(_value))
            {
                writer.WritePropertyName("value"u8);
                writer.WriteObjectValue(_value.ToObjectFromJson<object>());
            }
            if (Optional.IsDefined(_expiresAfterSeconds))
            {
                writer.WritePropertyName("expiresAfterSeconds"u8);
                writer.WriteNumberValue(_expiresAfterSeconds.Value);
            }
            if (Optional.IsDefined(Expedite))
            {
                writer.WritePropertyName("expedite"u8);
                writer.WriteBooleanValue(Expedite.Value);
            }
            writer.WriteEndObject();
        }
    }
}
