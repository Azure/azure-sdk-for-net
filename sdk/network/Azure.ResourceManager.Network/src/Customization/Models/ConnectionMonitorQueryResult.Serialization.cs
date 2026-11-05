// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    public partial class ConnectionMonitorQueryResult : IJsonModel<ConnectionMonitorQueryResult>
    {
        void IJsonModel<ConnectionMonitorQueryResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConnectionMonitorQueryResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConnectionMonitorQueryResult)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(SourceStatus))
            {
                writer.WritePropertyName("sourceStatus"u8);
                writer.WriteStringValue(SourceStatus.Value.ToString());
            }
            if (Optional.IsCollectionDefined(States))
            {
                writer.WritePropertyName("states"u8);
                writer.WriteStartArray();
                foreach (ConnectionStateSnapshot item in States)
                {
                    writer.WriteObjectValue(item, options);
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
                    using (JsonDocument document = JsonDocument.Parse(item.Value, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        ConnectionMonitorQueryResult IJsonModel<ConnectionMonitorQueryResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConnectionMonitorQueryResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConnectionMonitorQueryResult)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeConnectionMonitorQueryResult(document.RootElement, options);
        }

        internal static ConnectionMonitorQueryResult DeserializeConnectionMonitorQueryResult(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ConnectionMonitorSourceStatus? sourceStatus = default;
            IReadOnlyList<ConnectionStateSnapshot> states = default;
            var serializedAdditionalRawData = new Dictionary<string, BinaryData>();
            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("sourceStatus"u8))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        sourceStatus = new ConnectionMonitorSourceStatus(property.Value.GetString());
                    }
                    continue;
                }
                if (property.NameEquals("states"u8))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        var array = new List<ConnectionStateSnapshot>();
                        foreach (JsonElement item in property.Value.EnumerateArray())
                        {
                            array.Add(ConnectionStateSnapshot.DeserializeConnectionStateSnapshot(item, options));
                        }
                        states = array;
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            return new ConnectionMonitorQueryResult(sourceStatus, states ?? new ChangeTrackingList<ConnectionStateSnapshot>(), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ConnectionMonitorQueryResult>.Write(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConnectionMonitorQueryResult>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerNetworkContext.Default);
                default:
                    throw new FormatException($"The model {nameof(ConnectionMonitorQueryResult)} does not support writing '{options.Format}' format.");
            }
        }

        ConnectionMonitorQueryResult IPersistableModel<ConnectionMonitorQueryResult>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConnectionMonitorQueryResult>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeConnectionMonitorQueryResult(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ConnectionMonitorQueryResult)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ConnectionMonitorQueryResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
