// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ResourceHealth.Models
{
#pragma warning disable CS1591
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ResourceHealthAvailabilityStatus : ResourceData, IJsonModel<ResourceHealthAvailabilityStatus>, IPersistableModel<ResourceHealthAvailabilityStatus>
    {
        private readonly AzureLocation? _location;
        private readonly ResourceHealthAvailabilityStatusProperties _properties;

        // This constructor only exists to satisfy the legacy shape of the GA 1.0.0 compatibility wrapper.
        internal ResourceHealthAvailabilityStatus()
        {
        }

        // This wrapper is required because AvailabilityStatusData has a different base type and property layout,
        // so no TypeSpec decorator can reproduce the GA 1.0.0 ResourceData-derived shape with Location and Properties.
        internal ResourceHealthAvailabilityStatus(AvailabilityStatusData data)
        {
            if (data == null)
                return;

            _location = string.IsNullOrEmpty(data.Location) ? (AzureLocation?)null : new AzureLocation(data.Location);
            _properties = data.Properties;
        }

        /// <summary> Azure Resource Manager geo location of the resource. </summary>
        // Re-exposes Location on the GA 1.0.0 wrapper because the generated model no longer inherits ResourceData in the same way.
        public AzureLocation? Location => _location;

        /// <summary> Properties of availability state. </summary>
        // Re-exposes the old Properties accessor so existing callers keep the GA 1.0.0 object shape.
        public ResourceHealthAvailabilityStatusProperties Properties => _properties;

        // Centralizes the generated-to-compat conversion used by the mapped pageable shims and single-item responses.
        internal static ResourceHealthAvailabilityStatus FromData(AvailabilityStatusData data)
        {
            if (data == null)
                return null;
            return new ResourceHealthAvailabilityStatus(data);
        }

        // Deserializes through AvailabilityStatusData first because the wire shape still matches the generated model, then wraps it in the GA-compatible type.
        ResourceHealthAvailabilityStatus IJsonModel<ResourceHealthAvailabilityStatus>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using var document = JsonDocument.ParseValue(ref reader);
            var data = AvailabilityStatusData.DeserializeAvailabilityStatusData(document.RootElement, options);
            return FromData(data);
        }

        // Provides the minimal writer required by the SDK serialization interfaces even though this compatibility wrapper is intended for reading existing APIs.
        void IJsonModel<ResourceHealthAvailabilityStatus>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        // BinaryData deserialization follows the same generated-model-first path so framework helpers can materialize the compatibility type.
        ResourceHealthAvailabilityStatus IPersistableModel<ResourceHealthAvailabilityStatus>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using var document = JsonDocument.Parse(data);
            var statusData = AvailabilityStatusData.DeserializeAvailabilityStatusData(document.RootElement, options);
            return FromData(statusData);
        }

        // Returns JSON because that is the only supported persistence format for this compatibility wrapper.
        string IPersistableModel<ResourceHealthAvailabilityStatus>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        // Provides the minimal BinaryData writer required for IPersistableModel even though the wrapper primarily exists for backward-compatible reads.
        BinaryData IPersistableModel<ResourceHealthAvailabilityStatus>.Write(ModelReaderWriterOptions options)
        {
            return BinaryData.FromString("{}");
        }
    }
#pragma warning restore CS1591
}
