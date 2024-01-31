// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

[assembly: CodeGenSuppressType("LiveEventInput")]

namespace Azure.ResourceManager.Media.Models
{
    public partial class LiveEventInput : IUtf8JsonSerializable, IJsonModel<LiveEventInput>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<LiveEventInput>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<LiveEventInput>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LiveEventInput>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(LiveEventInput)} does not support '{format}' format.");
            }
            writer.WriteStartObject();
            writer.WritePropertyName("streamingProtocol"u8);
            writer.WriteStringValue(StreamingProtocol.ToString());
            if (Optional.IsDefined(AccessControl))
            {
                if (AccessControl != null)
                {
                    writer.WritePropertyName("accessControl"u8);
                    writer.WriteObjectValue(AccessControl);
                }
                else
                {
                    writer.WriteNull("accessControl");
                }
            }
            if (Optional.IsDefined(KeyFrameIntervalDuration))
            {
                writer.WritePropertyName("keyFrameIntervalDuration"u8);
                writer.WriteStringValue(KeyFrameIntervalDuration.Value, "P");
            }
            if (Optional.IsDefined(AccessToken))
            {
                writer.WritePropertyName("accessToken"u8);
                writer.WriteStringValue(AccessToken);
            }
            if (Optional.IsCollectionDefined(Endpoints))
            {
                writer.WritePropertyName("endpoints"u8);
                writer.WriteStartArray();
                foreach (var item in Endpoints)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        LiveEventInput IJsonModel<LiveEventInput>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LiveEventInput>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(LiveEventInput)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeLiveEventInput(document.RootElement, options);
        }

        internal static LiveEventInput DeserializeLiveEventInput(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            LiveEventInputProtocol streamingProtocol = default;
            Optional<LiveEventInputAccessControl> accessControl = default;
            Optional<TimeSpan> keyFrameIntervalDuration = default;
            Optional<string> accessToken = default;
            Optional<IList<LiveEventEndpoint>> endpoints = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("streamingProtocol"u8))
                {
                    streamingProtocol = new LiveEventInputProtocol(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("accessControl"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        accessControl = null;
                        continue;
                    }
                    accessControl = LiveEventInputAccessControl.DeserializeLiveEventInputAccessControl(property.Value);
                    continue;
                }
                if (property.NameEquals("keyFrameIntervalDuration"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    if (property.Value.ValueKind == JsonValueKind.String && String.IsNullOrWhiteSpace(property.Value.GetString()))
                    {
                        keyFrameIntervalDuration = default;
                        continue;
                    }
                    keyFrameIntervalDuration = property.Value.GetTimeSpan("P");
                    continue;
                }
                if (property.NameEquals("accessToken"u8))
                {
                    accessToken = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("endpoints"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<LiveEventEndpoint> array = new List<LiveEventEndpoint>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(LiveEventEndpoint.DeserializeLiveEventEndpoint(item));
                    }
                    endpoints = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new LiveEventInput(streamingProtocol, accessControl.Value, Optional.ToNullable(keyFrameIntervalDuration), accessToken.Value, Optional.ToList(endpoints), serializedAdditionalRawData);
        }
        BinaryData IPersistableModel<LiveEventInput>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LiveEventInput>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(LiveEventInput)} does not support '{options.Format}' format.");
            }
        }

        LiveEventInput IPersistableModel<LiveEventInput>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LiveEventInput>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeLiveEventInput(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(LiveEventInput)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<LiveEventInput>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
