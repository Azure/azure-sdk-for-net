// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class StaticRouterRule : IUtf8JsonSerializable
    {
        /// <summary> The static value this rule always returns. </summary>
        public RouterValue Value { get; set; }

        [CodeGenMember("Value")]
        internal BinaryData _value {
            get
            {
                return BinaryData.FromObjectAsJson(Value.Value);
            }
            set
            {
                Value = new RouterValue(value.ToObjectFromJson());
            }
        }

        /// <summary> Initializes a new instance of StaticRule. </summary>
        /// <param name="value"> The static value this rule always returns. </param>
        public StaticRouterRule(RouterValue value) : this("static-rule", BinaryData.FromObjectAsJson(value.Value))
        {
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(_value))
            {
                writer.WritePropertyName("value"u8);
                writer.WriteObjectValue(_value.ToObjectFromJson<object>());
            }
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            writer.WriteEndObject();
        }
    }
}
