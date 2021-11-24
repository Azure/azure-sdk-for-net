// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

// This is shared between WPS.Common and WPS.AspNetCore

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// Converter to turn the ConnectionStates dictionary into a regular JSON
    /// object.
    /// </summary>
    internal class ConnectionStatesConverter : JsonConverter<IReadOnlyDictionary<string, BinaryData>>
    {
        /// <inheritdoc/>
        public override IReadOnlyDictionary<string, BinaryData> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            throw new NotImplementedException();

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, IReadOnlyDictionary<string, BinaryData> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            if (value != null)
            {
                foreach (KeyValuePair<string, BinaryData> pair in value)
                {
                    writer.WritePropertyName(pair.Key);

                    // Since STJ doesn't allow you to write raw JSON,
                    // we have to hack around it by deserializing to an object
                    // and then serializing it back into our writer
                    object val = pair.Value.ToObjectFromJson<object>(options);
                    JsonSerializer.Serialize(writer, val, options);
                }
            }
            writer.WriteEndObject();
        }
    }
}
