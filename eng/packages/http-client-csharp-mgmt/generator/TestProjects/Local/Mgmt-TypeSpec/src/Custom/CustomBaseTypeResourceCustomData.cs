// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Generator.MgmtTypeSpec.Tests.Models;
using Azure.ResourceManager.Models;

namespace Azure.Generator.MgmtTypeSpec.Tests
{
    /// <summary> Custom data type used to prove CodeGenResourceData can select handwritten resource data. </summary>
    public partial class CustomBaseTypeResourceCustomData : CustomBaseTypeResourceData, IJsonModel<CustomBaseTypeResourceCustomData>
    {
        internal CustomBaseTypeResourceCustomData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="CustomBaseTypeResourceCustomData"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        public CustomBaseTypeResourceCustomData(AzureLocation location) : base(location)
        {
        }

        internal CustomBaseTypeResourceCustomData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, CustomBaseTypeResourceProperties properties, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(id, name, resourceType, systemData, tags, location, properties, additionalBinaryDataProperties)
        {
        }

        internal static RequestContent ToRequestContent(CustomBaseTypeResourceCustomData customData)
            => customData is null ? null : RequestContent.Create(customData, ModelSerializationExtensions.WireOptions);

        internal static new CustomBaseTypeResourceCustomData FromResponse(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeCustomBaseTypeResourceCustomData(document.RootElement, ModelSerializationExtensions.WireOptions);
        }

        internal static CustomBaseTypeResourceCustomData DeserializeCustomBaseTypeResourceCustomData(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            ResourceIdentifier id = default;
            string name = default;
            ResourceType resourceType = default;
            SystemData systemData = default;
            IDictionary<string, string> tags = default;
            AzureLocation location = default;
            CustomBaseTypeResourceProperties properties = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("id"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        id = new ResourceIdentifier(prop.Value.GetString());
                    }
                    continue;
                }
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        resourceType = new ResourceType(prop.Value.GetString());
                    }
                    continue;
                }
                if (prop.NameEquals("systemData"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        systemData = ModelReaderWriter.Read<SystemData>(BinaryData.FromString(prop.Value.GetRawText()), ModelSerializationExtensions.WireOptions, AzureGeneratorMgmtTypeSpecTestsContext.Default);
                    }
                    continue;
                }
                if (prop.NameEquals("tags"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        var dictionary = new Dictionary<string, string>();
                        foreach (var tag in prop.Value.EnumerateObject())
                        {
                            dictionary.Add(tag.Name, tag.Value.ValueKind == JsonValueKind.Null ? null : tag.Value.GetString());
                        }
                        tags = dictionary;
                    }
                    continue;
                }
                if (prop.NameEquals("location"u8))
                {
                    location = new AzureLocation(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("properties"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        properties = CustomBaseTypeResourceProperties.DeserializeCustomBaseTypeResourceProperties(prop.Value, options);
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }

            return new CustomBaseTypeResourceCustomData(id, name, resourceType, systemData, tags, location, properties, additionalBinaryDataProperties);
        }

        void IJsonModel<CustomBaseTypeResourceCustomData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        CustomBaseTypeResourceCustomData IJsonModel<CustomBaseTypeResourceCustomData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCustomBaseTypeResourceCustomData(document.RootElement, options);
        }

        BinaryData IPersistableModel<CustomBaseTypeResourceCustomData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write(this, options, AzureGeneratorMgmtTypeSpecTestsContext.Default);

        CustomBaseTypeResourceCustomData IPersistableModel<CustomBaseTypeResourceCustomData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeCustomBaseTypeResourceCustomData(document.RootElement, options);
        }

        string IPersistableModel<CustomBaseTypeResourceCustomData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
