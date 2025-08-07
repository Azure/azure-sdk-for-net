// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using Azure.ResourceManager.Chaos.Models;
using System.Text.Json;

namespace Azure.ResourceManager.Chaos
{
    public partial class ChaosCapabilityTypeData : IUtf8JsonSerializable, IJsonModel<ChaosCapabilityTypeData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ChaosCapabilityTypeData>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<ChaosCapabilityTypeData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ChaosCapabilityTypeData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ChaosCapabilityTypeData)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(Location))
            {
                writer.WritePropertyName("location"u8);
                writer.WriteStringValue(Location.Value);
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (options.Format != "W" && Optional.IsDefined(Publisher))
            {
                writer.WritePropertyName("publisher"u8);
                writer.WriteStringValue(Publisher);
            }
            if (options.Format != "W" && Optional.IsDefined(TargetType))
            {
                writer.WritePropertyName("targetType"u8);
                writer.WriteStringValue(TargetType);
            }
            if (options.Format != "W" && Optional.IsDefined(DisplayName))
            {
                writer.WritePropertyName("displayName"u8);
                writer.WriteStringValue(DisplayName);
            }
            if (options.Format != "W" && Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(Description);
            }
            if (options.Format != "W" && Optional.IsDefined(ParametersSchema))
            {
                writer.WritePropertyName("parametersSchema"u8);
                writer.WriteStringValue(ParametersSchema);
            }
            if (options.Format != "W" && Optional.IsDefined(Urn))
            {
                writer.WritePropertyName("urn"u8);
                writer.WriteStringValue(Urn);
            }
            if (options.Format != "W" && Optional.IsDefined(Kind))
            {
                writer.WritePropertyName("kind"u8);
                writer.WriteStringValue(Kind);
            }
            if (Optional.IsCollectionDefined(AzureRbacActions))
            {
                writer.WritePropertyName("azureRbacActions"u8);
                writer.WriteStartArray();
                foreach (var item in AzureRbacActions)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(AzureRbacDataActions))
            {
                writer.WritePropertyName("azureRbacDataActions"u8);
                writer.WriteStartArray();
                foreach (var item in AzureRbacDataActions)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(RuntimeProperties))
            {
                writer.WritePropertyName("runtimeProperties"u8);
                writer.WriteObjectValue(RuntimeProperties, options);
            }
            writer.WriteEndObject();
        }

        ChaosCapabilityTypeData IJsonModel<ChaosCapabilityTypeData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ChaosCapabilityTypeData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ChaosCapabilityTypeData)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeChaosCapabilityTypeData(document.RootElement, options);
        }

        internal static ChaosCapabilityTypeData DeserializeChaosCapabilityTypeData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            AzureLocation? location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            ResourceManager.Models.SystemData systemData = default;
            string publisher = default;
            string targetType = default;
            string displayName = default;
            string description = default;
            string parametersSchema = default;
            string urn = default;
            string kind = default;
            IList<string> azureRbacActions = default;
            IList<string> azureRbacDataActions = default;
            ChaosCapabilityTypeRuntimeProperties runtimeProperties = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("location"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    location = new AzureLocation(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<ResourceManager.Models.SystemData>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("publisher"u8))
                        {
                            publisher = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("targetType"u8))
                        {
                            targetType = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("displayName"u8))
                        {
                            displayName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("description"u8))
                        {
                            description = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("parametersSchema"u8))
                        {
                            parametersSchema = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("urn"u8))
                        {
                            urn = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("kind"u8))
                        {
                            kind = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("azureRbacActions"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<string> array = new List<string>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(item.GetString());
                            }
                            azureRbacActions = array;
                            continue;
                        }
                        if (property0.NameEquals("azureRbacDataActions"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<string> array = new List<string>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(item.GetString());
                            }
                            azureRbacDataActions = array;
                            continue;
                        }
                        if (property0.NameEquals("runtimeProperties"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            runtimeProperties = ChaosCapabilityTypeRuntimeProperties.DeserializeChaosCapabilityTypeRuntimeProperties(property0.Value, options);
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ChaosCapabilityTypeData(
                id,
                name,
                type,
                systemData,
                location,
                publisher,
                targetType,
                displayName,
                description,
                parametersSchema,
                urn,
                kind,
                azureRbacActions ?? new ChangeTrackingList<string>(),
                azureRbacDataActions ?? new ChangeTrackingList<string>(),
                runtimeProperties,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ChaosCapabilityTypeData>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ChaosCapabilityTypeData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerChaosContext.Default);
                default:
                    throw new FormatException($"The model {nameof(ChaosCapabilityTypeData)} does not support writing '{options.Format}' format.");
            }
        }

        ChaosCapabilityTypeData IPersistableModel<ChaosCapabilityTypeData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ChaosCapabilityTypeData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeChaosCapabilityTypeData(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ChaosCapabilityTypeData)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ChaosCapabilityTypeData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
