// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class MachineLearningPartialManagedServiceIdentity : IUtf8JsonSerializable, IJsonModel<MachineLearningPartialManagedServiceIdentity>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<MachineLearningPartialManagedServiceIdentity>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<MachineLearningPartialManagedServiceIdentity>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MachineLearningPartialManagedServiceIdentity>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MachineLearningPartialManagedServiceIdentity)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(ManagedServiceIdentityType))
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(ManagedServiceIdentityType.Value.ToString());
            }
            if (Optional.IsCollectionDefined(UserAssignedIdentities))
            {
                writer.WritePropertyName("userAssignedIdentities"u8);
                writer.WriteStartObject();
                foreach (var item in UserAssignedIdentities)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(item.Value.ToString()).RootElement);
#endif
                }
                writer.WriteEndObject();
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

        MachineLearningPartialManagedServiceIdentity IJsonModel<MachineLearningPartialManagedServiceIdentity>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MachineLearningPartialManagedServiceIdentity>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MachineLearningPartialManagedServiceIdentity)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMachineLearningPartialManagedServiceIdentity(document.RootElement, options);
        }

        internal static MachineLearningPartialManagedServiceIdentity DeserializeMachineLearningPartialManagedServiceIdentity(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Azure.ResourceManager.Models.ManagedServiceIdentityType managedServiceIdentityType = default;
            IDictionary<string, BinaryData> userAssignedIdentities = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("managedServiceIdentityType"u8))
                {
                    managedServiceIdentityType = new Azure.ResourceManager.Models.ManagedServiceIdentityType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("userAssignedIdentities"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, BinaryData> dictionary = new Dictionary<string, BinaryData>();
                    foreach (var property1 in property.Value.EnumerateObject())
                    {
                        if (property1.Value.ValueKind == JsonValueKind.Null)
                        {
                            dictionary.Add(property1.Name, null);
                        }
                        else
                        {
                            dictionary.Add(property1.Name, BinaryData.FromString(property1.Value.GetRawText()));
                        }
                    }
                    userAssignedIdentities = dictionary;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new MachineLearningPartialManagedServiceIdentity(managedServiceIdentityType, userAssignedIdentities, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<MachineLearningPartialManagedServiceIdentity>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MachineLearningPartialManagedServiceIdentity>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(MachineLearningPartialManagedServiceIdentity)} does not support '{options.Format}' format.");
            }
        }

        MachineLearningPartialManagedServiceIdentity IPersistableModel<MachineLearningPartialManagedServiceIdentity>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MachineLearningPartialManagedServiceIdentity>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeMachineLearningPartialManagedServiceIdentity(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MachineLearningPartialManagedServiceIdentity)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<MachineLearningPartialManagedServiceIdentity>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
