// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.NotificationHubs.Models
{
    public partial class SharedAccessAuthorizationRuleCreateOrUpdateContent : IUtf8JsonSerializable, IJsonModel<SharedAccessAuthorizationRuleCreateOrUpdateContent>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<SharedAccessAuthorizationRuleCreateOrUpdateContent>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<SharedAccessAuthorizationRuleCreateOrUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SharedAccessAuthorizationRuleCreateOrUpdateContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SharedAccessAuthorizationRuleCreateOrUpdateContent)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("properties"u8);
            writer.WriteObjectValue(Properties, options);
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

        SharedAccessAuthorizationRuleCreateOrUpdateContent IJsonModel<SharedAccessAuthorizationRuleCreateOrUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SharedAccessAuthorizationRuleCreateOrUpdateContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SharedAccessAuthorizationRuleCreateOrUpdateContent)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeSharedAccessAuthorizationRuleCreateOrUpdateContent(document.RootElement, options);
        }

        internal static SharedAccessAuthorizationRuleCreateOrUpdateContent DeserializeSharedAccessAuthorizationRuleCreateOrUpdateContent(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            SharedAccessAuthorizationRuleProperties properties = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("properties"u8))
                {
                    properties = SharedAccessAuthorizationRuleProperties.DeserializeSharedAccessAuthorizationRuleProperties(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new SharedAccessAuthorizationRuleCreateOrUpdateContent(properties, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<SharedAccessAuthorizationRuleCreateOrUpdateContent>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SharedAccessAuthorizationRuleCreateOrUpdateContent>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerNotificationHubsContext.Default);
                default:
                    throw new FormatException($"The model {nameof(SharedAccessAuthorizationRuleCreateOrUpdateContent)} does not support writing '{options.Format}' format.");
            }
        }

        SharedAccessAuthorizationRuleCreateOrUpdateContent IPersistableModel<SharedAccessAuthorizationRuleCreateOrUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SharedAccessAuthorizationRuleCreateOrUpdateContent>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeSharedAccessAuthorizationRuleCreateOrUpdateContent(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(SharedAccessAuthorizationRuleCreateOrUpdateContent)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<SharedAccessAuthorizationRuleCreateOrUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
