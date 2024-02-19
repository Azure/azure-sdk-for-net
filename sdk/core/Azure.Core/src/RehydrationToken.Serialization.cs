// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.Core
{
    public partial struct RehydrationToken : IJsonModel<RehydrationToken>
    {
        internal RehydrationToken DeserializeRehydrationToken(JsonElement element, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RehydrationToken>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RehydrationToken)} does not support '{format}' format.");
            }

            if (element.ValueKind == JsonValueKind.Null)
            {
                throw new InvalidOperationException("Cannot deserialize a null value to a non-nullable RehydrationToken");
            }

            string? id = null;
            string version = string.Empty;
            string headerSource = string.Empty;
            string nextRequestUri = string.Empty;
            string initialUri = string.Empty;
            RequestMethod requestMethod = default;
            string? lastKnownLocation = null;
            string finalStateVia = string.Empty;

            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    id = property.Value.GetString();
                }
                if (property.NameEquals("version"u8))
                {
                    version = property.Value.GetString()!;
                    continue;
                }
                if (property.NameEquals("headerSource"u8))
                {
                    headerSource = property.Value.GetString()!;
                    continue;
                }
                if (property.NameEquals("nextRequestUri"u8))
                {
                    nextRequestUri = property.Value.GetString()!;
                    continue;
                }
                if (property.NameEquals("initialUri"u8))
                {
                    initialUri = property.Value.GetString()!;
                    continue;
                }
                if (property.NameEquals("requestMethod"u8))
                {
                    requestMethod = new RequestMethod(property.Value.GetString()!);
                    continue;
                }
                if (property.NameEquals("lastKnownLocation"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    lastKnownLocation = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("finalStateVia"u8))
                {
                    finalStateVia = property.Value.GetString()!;
                    continue;
                }
            }
            return new RehydrationToken(id, version, headerSource, nextRequestUri, initialUri, requestMethod, lastKnownLocation, finalStateVia);
        }

        void IJsonModel<RehydrationToken>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id"u8);
            writer.WriteStringValue(Id);
            writer.WritePropertyName("version"u8);
            writer.WriteStringValue(Version);
            writer.WritePropertyName("headerSource"u8);
            writer.WriteStringValue(HeaderSource.ToString());
            writer.WritePropertyName("nextRequestUri"u8);
            writer.WriteStringValue(NextRequestUri);
            writer.WritePropertyName("initialUri"u8);
            writer.WriteStringValue(InitialUri);
            writer.WritePropertyName("requestMethod"u8);
            writer.WriteStringValue(RequestMethod.ToString());
            writer.WritePropertyName("lastKnownLocation"u8);
            writer.WriteStringValue(LastKnownLocation);
            writer.WritePropertyName("finalStateVia"u8);
            writer.WriteStringValue(FinalStateVia.ToString());
            writer.WriteEndObject();
        }

        RehydrationToken IJsonModel<RehydrationToken>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using var document = JsonDocument.ParseValue(ref reader);
            return DeserializeRehydrationToken(document.RootElement, options);
        }

        BinaryData IPersistableModel<RehydrationToken>.Write(ModelReaderWriterOptions options)
            => ModelReaderWriter.Write(this, options);

        RehydrationToken IPersistableModel<RehydrationToken>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using var document = JsonDocument.Parse(data);
            return DeserializeRehydrationToken(document.RootElement, options);
        }

        string IPersistableModel<RehydrationToken>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
