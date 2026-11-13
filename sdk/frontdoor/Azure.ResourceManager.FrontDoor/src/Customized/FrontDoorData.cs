// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.FrontDoor.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.FrontDoor
{
    // The shipped SDK inherited TrackedResourceData. This partial restores that base type after
    // removing the spec-side alternateType for Microsoft.Network.Resource.
    public partial class FrontDoorData : TrackedResourceData
    {
        // The generated public parameterless constructor was not part of the shipped API. Keep this
        // constructor internal so generation has an implementation hook without expanding public API.
        internal FrontDoorData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="FrontDoorData"/>. </summary>
        /// <param name="location"> The location. </param>
        public FrontDoorData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of <see cref="FrontDoorData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="properties"> The properties. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        internal FrontDoorData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, FrontDoorProperties properties, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(id, name, resourceType, systemData, tags, location)
        {
            Properties = properties;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }
        // This method body is copied from the generated PersistableModelCreateCore; the customization changes
        // only the return type from FrontDoorData to ResourceData so it matches TrackedResourceData.
        // TODO: Remove this workaround after https://github.com/Azure/azure-sdk-for-net/issues/60675 is fixed.
        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual ResourceData PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FrontDoorData>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeFrontDoorData(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(FrontDoorData)} does not support reading '{options.Format}' format.");
            }
        }

        // This method body is copied from the generated JsonModelCreateCore; the customization changes
        // only the return type from FrontDoorData to ResourceData so it matches TrackedResourceData.
        // TODO: Remove this workaround after https://github.com/Azure/azure-sdk-for-net/issues/60675 is fixed.
        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual ResourceData JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FrontDoorData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FrontDoorData)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFrontDoorData(document.RootElement, options);
        }

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        FrontDoorData IPersistableModel<FrontDoorData>.Create(BinaryData data, ModelReaderWriterOptions options) => (FrontDoorData)PersistableModelCreateCore(data, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        FrontDoorData IJsonModel<FrontDoorData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (FrontDoorData)JsonModelCreateCore(ref reader, options);
        internal static FrontDoorData DeserializeFrontDoorData(JsonElement element, ModelReaderWriterOptions options)
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
            FrontDoorProperties properties = default;
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
                        properties = FrontDoorProperties.DeserializeFrontDoorProperties(prop.Value, options);
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new FrontDoorData(id, name, resourceType, systemData, tags ?? new ChangeTrackingDictionary<string, string>(), location, properties, additionalBinaryDataProperties);
        }
    }
}
