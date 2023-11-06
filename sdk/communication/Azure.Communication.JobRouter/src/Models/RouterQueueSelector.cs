// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.Communication.JobRouter
{
    public partial class RouterQueueSelector : IUtf8JsonSerializable
    {
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

        /// <summary> The value to compare against the actual label value with the given operator. </summary>
        public RouterValue Value { get; internal set; }

        /// <summary> Initializes a new instance of QueueSelector. </summary>
        /// <param name="key"> The label key to query against. </param>
        /// <param name="labelOperator"> Describes how the value of the label is compared to the value defined on the label selector. </param>
        /// <param name="value"> The value to compare against the actual label value with the given operator. </param>
        public RouterQueueSelector(string key, LabelOperator labelOperator, RouterValue value)
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
                writer.WriteObjectValue(_value.ToObjectFromJson());
            }
            writer.WriteEndObject();
        }
    }
}
