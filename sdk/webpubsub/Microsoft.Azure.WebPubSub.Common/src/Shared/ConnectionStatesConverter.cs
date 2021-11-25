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
    /// object works for data transport over http between server and service.
    /// </summary>
    internal class ConnectionStatesConverter : JsonConverter<IReadOnlyDictionary<string, BinaryData>>
    {
        /// <inheritdoc/>
        public override IReadOnlyDictionary<string, BinaryData> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dic = new Dictionary<string, BinaryData>();
            var element = JsonDocument.ParseValue(ref reader).RootElement;
            foreach (var elementInfo in element.EnumerateObject())
            {
                var encoded = elementInfo.Value.GetString();
                var decoded = Convert.FromBase64String(encoded);
                dic.Add(elementInfo.Name, BinaryData.FromBytes(decoded));
            }
            return dic;
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, IReadOnlyDictionary<string, BinaryData> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            if (value != null)
            {
                foreach (KeyValuePair<string, BinaryData> pair in value)
                {
                    writer.WriteBase64String(pair.Key, pair.Value.ToArray());
                }
            }
            writer.WriteEndObject();
        }
    }
}
