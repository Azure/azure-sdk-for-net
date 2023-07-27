// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// JSON converter to make it easier to deserialize a <see cref="BasicDigitalTwin"/>.
    /// </summary>
    internal class BasicDigitalTwinJsonConverter : JsonConverter<BasicDigitalTwin>
    {
        /// <inheritdoc/>
        public override BasicDigitalTwin Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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
            var twin = new BasicDigitalTwin();

            // Until we reach the end of the object we began reading
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                string propertyName = reader.GetString();

                reader.Read(); // advance to the next token

                if (propertyName == DigitalTwinsJsonPropertyNames.DigitalTwinId)
                {
                    twin.Id = reader.GetString();
                }
                else if (propertyName == DigitalTwinsJsonPropertyNames.DigitalTwinETag)
                {
                    string etagString = reader.GetString();
                    twin.ETag = etagString != null ? new ETag(etagString) : (ETag?)null;
                }
                else if (propertyName == DigitalTwinsJsonPropertyNames.DigitalTwinMetadata)
                {
                    // Extract lastUpdatedTime from twin metadata, if available
                    JsonElement metadataBlock = JsonSerializer.Deserialize<JsonElement>(ref reader, options);

                    if (metadataBlock.TryGetProperty(DigitalTwinsJsonPropertyNames.MetadataLastUpdateTime, out JsonElement lastUpdateTime))
                    {
                        twin.LastUpdatedOn = lastUpdateTime.TryGetDateTimeOffset(out DateTimeOffset lastUpdateTimeValue) ? lastUpdateTimeValue : null;
                    }

                    twin.Metadata = JsonSerializer.Deserialize<DigitalTwinMetadata>(metadataBlock.GetRawText(), options);
                }
                else
                {
                    twin.Contents[propertyName] = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
                }

                reader.Read(); // Finished consuming the token
            }

            return twin;
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, BasicDigitalTwin value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString(DigitalTwinsJsonPropertyNames.DigitalTwinId, value.Id);
            writer.WriteString(DigitalTwinsJsonPropertyNames.DigitalTwinETag, value.ETag?.ToString());

            foreach (KeyValuePair<string, object> p in value.Contents)
            {
                writer.WritePropertyName(p.Key);
                JsonSerializer.Serialize(writer, p.Value, options);
            }

            writer.WritePropertyName(DigitalTwinsJsonPropertyNames.DigitalTwinMetadata);

            // Inject lastUpdatedTime into twin metadata object
            string partialMetadata = JsonSerializer.Serialize<DigitalTwinMetadata>(value.Metadata, options);
            JsonDocument partialMetadataDocument = JsonDocument.Parse(partialMetadata);

            var rootElement = partialMetadataDocument.RootElement;
            if (rootElement.ValueKind != JsonValueKind.Object)
            {
                throw new NotSupportedException();
            }

            writer.WriteStartObject();
            foreach (var property in rootElement.EnumerateObject())
            {
                property.WriteTo(writer);
            }

            if (value.LastUpdatedOn != null)
            {
                writer.WritePropertyName(DigitalTwinsJsonPropertyNames.MetadataLastUpdateTime);
                JsonSerializer.Serialize<DateTimeOffset>(writer, value.LastUpdatedOn.Value, options);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
    }
}
