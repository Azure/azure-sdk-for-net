// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [JsonConverter(typeof(PolymorphicWriteOnlyJsonConverter<ExceptionAction>))]
    public abstract partial class ExceptionAction : IUtf8JsonSerializable
    {
        /// <summary> The type discriminator describing a sub-type of ExceptionAction. </summary>
        public string Kind { get; protected set; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            writer.WriteStringValue(Kind);
            writer.WriteEndObject();
        }
    }
}
