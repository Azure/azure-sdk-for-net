// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.FrontDoor.Models;
using System.Collections.Generic;
using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.FrontDoor
{
    // The shipped SDK inherited TrackedResourceData. This partial restores that base type after
    // removing the spec-side alternateType for ResourcewithSettableName.
    public partial class FrontDoorNetworkExperimentProfileData : TrackedResourceData
    {
        // The generated public parameterless constructor was not part of the shipped API. Keep this
        // constructor internal so generation has an implementation hook without expanding public API.
        internal FrontDoorNetworkExperimentProfileData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="FrontDoorNetworkExperimentProfileData"/>. </summary>
        /// <param name="location"> The location. </param>
        public FrontDoorNetworkExperimentProfileData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of <see cref="FrontDoorNetworkExperimentProfileData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="properties"> The properties. </param>
        /// <param name="eTag"> The ETag. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        internal FrontDoorNetworkExperimentProfileData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ProfileProperties properties, ETag? eTag, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(id, name, resourceType, systemData, tags, location)
        {
            Properties = properties;
            ETag = eTag;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }
        // This method body is copied from the generated PersistableModelCreateCore; the customization changes
        // only the return type from FrontDoorNetworkExperimentProfileData to ResourceData so it matches TrackedResourceData.
        // Remove this workaround after https://github.com/Azure/azure-sdk-for-net/issues/60297 is fixed.
        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual ResourceData PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FrontDoorNetworkExperimentProfileData>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeFrontDoorNetworkExperimentProfileData(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(FrontDoorNetworkExperimentProfileData)} does not support reading '{options.Format}' format.");
            }
        }

        // This method body is copied from the generated JsonModelWriteCore; the customization changes
        // the method modifier from "virtual" to "override" and calls the restored TrackedResourceData
        // base writer so inherited resource fields keep their previous wire shape.
        // Remove this workaround after https://github.com/Azure/azure-sdk-for-net/issues/60297 is fixed.
        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FrontDoorNetworkExperimentProfileData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FrontDoorNetworkExperimentProfileData)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(Properties))
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteObjectValue(Properties, options);
            }
            if (Optional.IsDefined(ETag))
            {
                writer.WritePropertyName("etag"u8);
                writer.WriteStringValue(ETag.Value.ToString());
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
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
        }

        // This method body is copied from the generated JsonModelCreateCore; the customization changes
        // only the return type from FrontDoorNetworkExperimentProfileData to ResourceData so it matches TrackedResourceData.
        // Remove this workaround after https://github.com/Azure/azure-sdk-for-net/issues/60297 is fixed.
        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual ResourceData JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FrontDoorNetworkExperimentProfileData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FrontDoorNetworkExperimentProfileData)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFrontDoorNetworkExperimentProfileData(document.RootElement, options);
        }

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        FrontDoorNetworkExperimentProfileData IPersistableModel<FrontDoorNetworkExperimentProfileData>.Create(BinaryData data, ModelReaderWriterOptions options) => (FrontDoorNetworkExperimentProfileData)PersistableModelCreateCore(data, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        FrontDoorNetworkExperimentProfileData IJsonModel<FrontDoorNetworkExperimentProfileData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (FrontDoorNetworkExperimentProfileData)JsonModelCreateCore(ref reader, options);
        internal static FrontDoorNetworkExperimentProfileData DeserializeFrontDoorNetworkExperimentProfileData(JsonElement element, ModelReaderWriterOptions options)
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
            ProfileProperties properties = default;
            ETag? eTag = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (FrontDoorSerializationHelpers.TryReadTrackedResourceDataProperty(prop, options, ref id, ref name, ref resourceType, ref systemData, ref tags, ref location))
                {
                    continue;
                }
                if (prop.NameEquals("properties"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        properties = ProfileProperties.DeserializeProfileProperties(prop.Value, options);
                    }
                    continue;
                }
                if (prop.NameEquals("etag"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        eTag = new ETag(prop.Value.GetString());
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new FrontDoorNetworkExperimentProfileData(id, name, resourceType, systemData, tags ?? new ChangeTrackingDictionary<string, string>(), location, properties, eTag, additionalBinaryDataProperties);
        }
    }
}