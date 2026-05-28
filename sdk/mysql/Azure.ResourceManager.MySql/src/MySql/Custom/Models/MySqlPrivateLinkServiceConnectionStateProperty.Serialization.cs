// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.MySql.Models
{
    public partial class MySqlPrivateLinkServiceConnectionStateProperty : IUtf8JsonSerializable, IJsonModel<MySqlPrivateLinkServiceConnectionStateProperty>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<MySqlPrivateLinkServiceConnectionStateProperty>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<MySqlPrivateLinkServiceConnectionStateProperty>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MySqlPrivateLinkServiceConnectionStateProperty>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MySqlPrivateLinkServiceConnectionStateProperty)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("status"u8);
            writer.WriteStringValue(Status);
            writer.WritePropertyName("description"u8);
            writer.WriteStringValue(Description);
            if (options.Format != "W" && Optional.IsDefined(ActionsRequired))
            {
                writer.WritePropertyName("actionsRequired"u8);
                writer.WriteStringValue(ActionsRequired);
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

        MySqlPrivateLinkServiceConnectionStateProperty IJsonModel<MySqlPrivateLinkServiceConnectionStateProperty>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MySqlPrivateLinkServiceConnectionStateProperty>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MySqlPrivateLinkServiceConnectionStateProperty)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMySqlPrivateLinkServiceConnectionStateProperty(document.RootElement, options);
        }

        internal static MySqlPrivateLinkServiceConnectionStateProperty DeserializeMySqlPrivateLinkServiceConnectionStateProperty(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string status = default;
            string description = default;
            string actionsRequired = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"u8))
                {
                    status = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("description"u8))
                {
                    description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("actionsRequired"u8))
                {
                    actionsRequired = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new MySqlPrivateLinkServiceConnectionStateProperty(status, description, actionsRequired, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<MySqlPrivateLinkServiceConnectionStateProperty>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MySqlPrivateLinkServiceConnectionStateProperty>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerMySqlContext.Default);
                default:
                    throw new FormatException($"The model {nameof(MySqlPrivateLinkServiceConnectionStateProperty)} does not support writing '{options.Format}' format.");
            }
        }

        MySqlPrivateLinkServiceConnectionStateProperty IPersistableModel<MySqlPrivateLinkServiceConnectionStateProperty>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MySqlPrivateLinkServiceConnectionStateProperty>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeMySqlPrivateLinkServiceConnectionStateProperty(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MySqlPrivateLinkServiceConnectionStateProperty)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MySqlPrivateLinkServiceConnectionStateProperty>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}