// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// JSON converter to make it easier to deserialize a <see cref="BasicDigitalTwinComponent"/>.
    /// </summary>
    internal class BasicDigitalTwinComponentJsonConverter : JsonConverter<BasicDigitalTwinComponent>
    {
        /// <inheritdoc/>
        public override BasicDigitalTwinComponent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException($"Unexpected token type {reader.TokenType} at index {reader.TokenStartIndex}. Expected JsonTokenType.StartObject.");
            }

            reader.Read(); // Advance into our object.
            var component = new BasicDigitalTwinComponent();

            // Until we reach the end of the object we began reading
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                string propertyName = reader.GetString();

                reader.Read(); // advance to the next token

                if (propertyName == DigitalTwinsJsonPropertyNames.DigitalTwinMetadata)
                {
                    JsonElement metadataBlock = JsonSerializer.Deserialize<JsonElement>(ref reader, options);

                    foreach (JsonProperty p in metadataBlock.EnumerateObject())
                    {
                        if (p.Name == DigitalTwinsJsonPropertyNames.MetadataLastUpdateTime)
                        {
                            component.LastUpdatedOn = p.Value.TryGetDateTimeOffset(out DateTimeOffset lastUpdateTimeValue) ? lastUpdateTimeValue : null;
                        }
                        else
                        {
                            component.Metadata[p.Name] = JsonSerializer.Deserialize<DigitalTwinPropertyMetadata>(p.Value.GetRawText(), options);
                        }
                    }
                }
                else
                {
                    component.Contents[propertyName] = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
                }

                reader.Read(); // Finished consuming the token
            }

            return component;
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, BasicDigitalTwinComponent value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(DigitalTwinsJsonPropertyNames.DigitalTwinMetadata);

            // Write component metadata
            writer.WriteStartObject();

            foreach (KeyValuePair<string, DigitalTwinPropertyMetadata> p in value.Metadata)
            {
                writer.WritePropertyName(p.Key);
                JsonSerializer.Serialize<DigitalTwinPropertyMetadata>(writer, p.Value, options);
            }

            if (value.LastUpdatedOn != null)
            {
                writer.WritePropertyName(DigitalTwinsJsonPropertyNames.MetadataLastUpdateTime);
                JsonSerializer.Serialize<DateTimeOffset>(writer, value.LastUpdatedOn.Value, options);
            }

            writer.WriteEndObject();

            foreach (KeyValuePair<string, object> p in value.Contents)
            {
                writer.WritePropertyName(p.Key);
                JsonSerializer.Serialize(writer, p.Value, options);
            }
            writer.WriteEndObject();
        }
    }
}
