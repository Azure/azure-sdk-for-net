// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    // In the old SDK (autorest-based), these types were plain models returned directly by device resource methods.
    // In the new SDK (TypeSpec-based), they are full ARM sub-resources with their own resource classes
    // (DataBoxEdgeDeviceNetworkSettingsResource) and data classes (DataBoxEdgeDeviceNetworkSettingsData).
    // These stubs are kept only for ApiCompat backward compatibility. All members throw NotSupportedException
    // at runtime; callers should migrate to GetDataBoxEdgeDeviceNetworkSettings().Get().Data.
    /// <summary>
    /// The network settings of a device.
    /// This class is obsolete; use <see cref="DataBoxEdgeDeviceNetworkSettingsData"/> via
    /// <c>GetDataBoxEdgeDeviceNetworkSettings().Get().Data</c> instead.
    /// </summary>
    [Obsolete("Use DataBoxEdgeDeviceNetworkSettingsData via GetDataBoxEdgeDeviceNetworkSettings().Get().Data instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class DataBoxEdgeDeviceNetworkSettings : ResourceData, IJsonModel<DataBoxEdgeDeviceNetworkSettings>
    {
        /// <summary> Initializes a new instance of <see cref="DataBoxEdgeDeviceNetworkSettings"/>. </summary>
        public DataBoxEdgeDeviceNetworkSettings() { }

        /// <summary> The network adapter list on the device. </summary>
        public IReadOnlyList<DataBoxEdgeNetworkAdapter> NetworkAdapters { get => throw new NotSupportedException(); }

        /// <inheritdoc/>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException();

        DataBoxEdgeDeviceNetworkSettings IJsonModel<DataBoxEdgeDeviceNetworkSettings>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException();
        void IJsonModel<DataBoxEdgeDeviceNetworkSettings>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException();
        DataBoxEdgeDeviceNetworkSettings IPersistableModel<DataBoxEdgeDeviceNetworkSettings>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException();
        string IPersistableModel<DataBoxEdgeDeviceNetworkSettings>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => throw new NotSupportedException();
        BinaryData IPersistableModel<DataBoxEdgeDeviceNetworkSettings>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException();
    }
}