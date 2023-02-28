// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Microsoft.Azure.Functions.Worker
{
    /// Copied from: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Microsoft.Azure.WebPubSub.Common/src/Shared/ConnectionStatesConverter.cs
    /// <summary>
    /// Converter to turn the ConnectionStates dictionary into a regular JSON
    /// object works for data transport over http between server and service.
    /// </summary>
    internal class ConnectionStatesJsonConverter : JsonConverter<IReadOnlyDictionary<string, BinaryData>>
    {
        private static readonly Dictionary<string, BinaryData> EmptyDictionary = new();

        public static JsonSerializerOptions Options = RegisterSerializerOptions();

        /// <inheritdoc/>
        public override IReadOnlyDictionary<string, BinaryData> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
                var dict = new Dictionary<string, BinaryData>();
                using var jsonDocument = JsonDocument.ParseValue(ref reader);
                var element = jsonDocument.RootElement;
                foreach (var elementInfo in element.EnumerateObject())
                {
                    // Use Base64 decode mapping to encode to avoid data loss.
                    var decoded = elementInfo.Value.GetBytesFromBase64();
                    dict.Add(elementInfo.Name, BinaryData.FromBytes(decoded));
                }
                return dict;
            }
            catch
            {
                // States not set via SDK and users need to read from Header themselves.
                // Avoid partial results and return a non-null value.
                return EmptyDictionary;
            }
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, IReadOnlyDictionary<string, BinaryData> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            if (value != null)
            {
                foreach (KeyValuePair<string, BinaryData> pair in value)
                {
                    // Use Base64 encode to avoid data loss when source is pure binary/string instead of object.
                    writer.WriteBase64String(pair.Key, pair.Value.ToArray());
                }
            }
            writer.WriteEndObject();
        }

        private static JsonSerializerOptions RegisterSerializerOptions()
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new ConnectionStatesJsonConverter());
            return options;
        }
    }
}
