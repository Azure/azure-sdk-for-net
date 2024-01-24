// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

#nullable disable

namespace Azure.Core
{
    internal partial struct RehydrationToken : IJsonModel<RehydrationToken>
    {
        private RehydrationToken DeserializeRehydrationToken(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return default;
            }
            string version = string.Empty;
            HeaderSource headerSource = default;
            string nextRequestUri = string.Empty;
            string initialUri = string.Empty;
            RequestMethod requestMethod = default;
            bool originalResponseHasLocation = default;
            Optional<string> lastKnownLocation = default;
            OperationFinalStateVia finalStateVia = default;

            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("version"u8))
                {
                    version = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("headerSource"u8))
                {
                    if (!Enum.TryParse(property.Value.GetString(), out headerSource))
                    {
                        headerSource = default;
                    }
                    continue;
                }
                if (property.NameEquals("nextRequestUri"u8))
                {
                    nextRequestUri = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("initialUri"u8))
                {
                    initialUri = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("requestMethod"u8))
                {
                    requestMethod = new RequestMethod(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("originalResponseHasLocation"u8))
                {
                    originalResponseHasLocation = property.Value.GetBoolean();
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
                    if (!Enum.TryParse(property.Value.GetString(), out finalStateVia))
                    {
                        finalStateVia = default;
                    }
                    continue;
                }
            }
            return new RehydrationToken(version, headerSource, nextRequestUri, initialUri, requestMethod, originalResponseHasLocation, lastKnownLocation.Value, finalStateVia);
        }

        void IJsonModel<RehydrationToken>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
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
            writer.WritePropertyName("originalResponseHasLocation"u8);
            writer.WriteBooleanValue(OriginalResponseHasLocation);
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
