// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.LoadTesting.Models
{
    public partial class LoadTestingCmkIdentity : IUtf8JsonSerializable, IJsonModel<LoadTestingCmkIdentity>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<LoadTestingCmkIdentity>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<LoadTestingCmkIdentity>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LoadTestingCmkIdentity>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(LoadTestingCmkIdentity)} does not support '{format}' format.");
            }
            writer.WriteStartObject();
            if (Optional.IsDefined(IdentityType))
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(IdentityType.Value.ToString());
            }
            if (Optional.IsDefined(ResourceId))
            {
                if (ResourceId != null)
                {
                    writer.WritePropertyName("resourceId"u8);
                    writer.WriteStringValue(ResourceId);
                }
                else
                {
                    writer.WriteNull("resourceId"u8);
                }
            }
            else
            {
                writer.WriteNull("resourceId"u8);
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

        LoadTestingCmkIdentity IJsonModel<LoadTestingCmkIdentity>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LoadTestingCmkIdentity>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(LoadTestingCmkIdentity)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeLoadTestingCmkIdentity(document.RootElement, options);
        }

        internal static LoadTestingCmkIdentity DeserializeLoadTestingCmkIdentity(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            LoadTestingCmkIdentityType? type = default;
            ResourceIdentifier resourceId = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    type = new LoadTestingCmkIdentityType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("resourceId"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        resourceId = null;
                        continue;
                    }
                    resourceId = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new LoadTestingCmkIdentity(type, resourceId, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<LoadTestingCmkIdentity>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LoadTestingCmkIdentity>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerLoadTestingContext.Default);
                default:
                    throw new FormatException($"The model {nameof(LoadTestingCmkIdentity)} does not support '{options.Format}' format.");
            }
        }

        LoadTestingCmkIdentity IPersistableModel<LoadTestingCmkIdentity>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LoadTestingCmkIdentity>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeLoadTestingCmkIdentity(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(LoadTestingCmkIdentity)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<LoadTestingCmkIdentity>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
