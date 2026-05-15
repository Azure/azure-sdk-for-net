// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility shim: preserves the old ResourceHealthAvailabilityStatus type from GA 1.0.0.
// GA 1.0.0 returned Pageable<ResourceHealthAvailabilityStatus> from extension methods like
// GetAvailabilityStatuses(). The new TypeSpec-generated SDK uses AvailabilityStatusData (which
// inherits from a different base class and has a different property structure). This type cannot
// be reproduced via @@clientName or any decorator — it requires a custom wrapper class that
// adapts AvailabilityStatusData to the old type shape (inheriting ResourceData with Location
// and Properties accessors). The IJsonModel/IPersistableModel implementations enable
// ModelReaderWriter serialization support required by the SDK framework.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ResourceHealth.Models
{
    /// <summary> availabilityStatus of a resource. </summary>
    // GA 1.0.0 backward compatibility type. The old SDK returned this type from methods like
    // GetAvailabilityStatuses(). The new SDK uses AvailabilityStatusData which has a different
    // base class and property structure. This wrapper adapts AvailabilityStatusData to the old
    // type shape (ResourceData base + Location + Properties). Marked EditorBrowsable(Never) so
    // new code uses AvailabilityStatusData instead.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ResourceHealthAvailabilityStatus : ResourceData, IJsonModel<ResourceHealthAvailabilityStatus>, IPersistableModel<ResourceHealthAvailabilityStatus>
    {
        private readonly AzureLocation? _location;
        private readonly ResourceHealthAvailabilityStatusProperties _properties;

        /// <summary> Initializes a new instance of ResourceHealthAvailabilityStatus. </summary>
        internal ResourceHealthAvailabilityStatus()
        {
        }

        /// <summary> Initializes a new instance wrapping an AvailabilityStatusData. </summary>
        // Converts string Location to AzureLocation? and copies Properties reference.
        internal ResourceHealthAvailabilityStatus(AvailabilityStatusData data)
        {
            if (data == null)
                return;

            _location = string.IsNullOrEmpty(data.Location) ? (AzureLocation?)null : new AzureLocation(data.Location);
            _properties = data.Properties;
        }

        /// <summary> Azure Resource Manager geo location of the resource. </summary>
        public AzureLocation? Location => _location;

        /// <summary> Properties of availability state. </summary>
        public ResourceHealthAvailabilityStatusProperties Properties => _properties;

        /// <summary> Factory method to create a ResourceHealthAvailabilityStatus from AvailabilityStatusData. </summary>
        // Used by MappedPageable/MappedAsyncPageable as the selector function.
        internal static ResourceHealthAvailabilityStatus FromData(AvailabilityStatusData data)
        {
            if (data == null)
                return null;
            return new ResourceHealthAvailabilityStatus(data);
        }

        /// <summary> IJsonModel.Create — deserializes JSON into the compat type via AvailabilityStatusData. </summary>
        ResourceHealthAvailabilityStatus IJsonModel<ResourceHealthAvailabilityStatus>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using var document = JsonDocument.ParseValue(ref reader);
            var data = AvailabilityStatusData.DeserializeAvailabilityStatusData(document.RootElement, options);
            return FromData(data);
        }

        /// <summary> IJsonModel.Write — minimal implementation for SDK framework compliance. </summary>
        void IJsonModel<ResourceHealthAvailabilityStatus>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        /// <summary> IPersistableModel.Create — deserializes BinaryData into the compat type. </summary>
        ResourceHealthAvailabilityStatus IPersistableModel<ResourceHealthAvailabilityStatus>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using var document = JsonDocument.Parse(data);
            var statusData = AvailabilityStatusData.DeserializeAvailabilityStatusData(document.RootElement, options);
            return FromData(statusData);
        }

        /// <summary> IPersistableModel.GetFormatFromOptions — returns JSON format. </summary>
        string IPersistableModel<ResourceHealthAvailabilityStatus>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> IPersistableModel.Write — minimal implementation for SDK framework compliance. </summary>
        BinaryData IPersistableModel<ResourceHealthAvailabilityStatus>.Write(ModelReaderWriterOptions options)
        {
            return BinaryData.FromString("{}");
        }
    }
}