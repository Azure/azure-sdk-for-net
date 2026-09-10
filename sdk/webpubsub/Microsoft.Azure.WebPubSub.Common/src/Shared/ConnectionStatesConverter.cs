// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// Converter to turn the ConnectionStates dictionary into a regular JSON
    /// object works for data transport over http between server and service.
    /// </summary>
    internal class ConnectionStatesConverter : JsonConverter<IReadOnlyDictionary<string, BinaryData>>
    {
        private static readonly Dictionary<string, BinaryData> EmptyDictionary = new();

        public static JsonSerializerOptions Options = RegisterSerializerOptions();

        /// <inheritdoc/>
        public override IReadOnlyDictionary<string, BinaryData> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
                using var jsonDocument = JsonDocument.ParseValue(ref reader);
                return ReadCore(jsonDocument.RootElement);
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
            WriteCore(writer, value);
        }

        internal static Dictionary<string, BinaryData> Decode(string connectionStates)
        {
            if (string.IsNullOrEmpty(connectionStates))
            {
                return null;
            }

            try
            {
                using JsonDocument jsonDocument = JsonDocument.Parse(Convert.FromBase64String(connectionStates));
                return ReadCore(jsonDocument.RootElement);
            }
            catch
            {
                // States not set via SDK and users need to read from Header themselves.
                // Avoid partial results and return a non-null value.
                return new Dictionary<string, BinaryData>(EmptyDictionary);
            }
        }

        internal static string Encode(IReadOnlyDictionary<string, BinaryData> value)
        {
            using MemoryStream stream = new();
            using (Utf8JsonWriter writer = new(stream))
            {
                WriteCore(writer, value);
            }

            return Convert.ToBase64String(stream.ToArray());
        }

        private static Dictionary<string, BinaryData> ReadCore(JsonElement element)
        {
            var dict = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                dict[property.Name] = BinaryData.FromBytes(property.Value.GetBytesFromBase64());
            }
            return dict;
        }

        private static void WriteCore(Utf8JsonWriter writer, IReadOnlyDictionary<string, BinaryData> value)
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

        private static JsonSerializerOptions RegisterSerializerOptions()
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new ConnectionStatesConverter());
            return options;
        }
    }
}
