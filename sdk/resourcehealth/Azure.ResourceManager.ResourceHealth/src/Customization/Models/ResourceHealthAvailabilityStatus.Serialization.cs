// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.ResourceHealth;

namespace Azure.ResourceManager.ResourceHealth.Models
{
    // This serialization bridge lets the GA compatibility model reuse the generated ResourceHealthAvailabilityStatusData wire format.
    public partial class ResourceHealthAvailabilityStatus : IJsonModel<ResourceHealthAvailabilityStatus>, IPersistableModel<ResourceHealthAvailabilityStatus>
    {
        ResourceHealthAvailabilityStatus IJsonModel<ResourceHealthAvailabilityStatus>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            ResourceHealthAvailabilityStatusData data = ResourceHealthAvailabilityStatusData.DeserializeResourceHealthAvailabilityStatusData(document.RootElement, options);
            return FromData(data);
        }

        void IJsonModel<ResourceHealthAvailabilityStatus>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ((IJsonModel<ResourceHealthAvailabilityStatusData>)ToData()).Write(writer, options);
        }

        ResourceHealthAvailabilityStatus IPersistableModel<ResourceHealthAvailabilityStatus>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data);
            ResourceHealthAvailabilityStatusData statusData = ResourceHealthAvailabilityStatusData.DeserializeResourceHealthAvailabilityStatusData(document.RootElement, options);
            return FromData(statusData);
        }

        string IPersistableModel<ResourceHealthAvailabilityStatus>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            return ((IPersistableModel<ResourceHealthAvailabilityStatusData>)ToData()).GetFormatFromOptions(options);
        }

        BinaryData IPersistableModel<ResourceHealthAvailabilityStatus>.Write(ModelReaderWriterOptions options)
        {
            return ((IPersistableModel<ResourceHealthAvailabilityStatusData>)ToData()).Write(options);
        }

        private ResourceHealthAvailabilityStatusData ToData()
        {
            return new ResourceHealthAvailabilityStatusData(Id, Name, ResourceType, Location, additionalBinaryDataProperties: null, Properties);
        }
    }
}
