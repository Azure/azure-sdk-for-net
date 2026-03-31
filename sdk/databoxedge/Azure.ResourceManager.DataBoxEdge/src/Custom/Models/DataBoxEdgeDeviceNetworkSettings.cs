// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Why: Baseline had this type in Models namespace as a plain model. New generator creates it as
// DataBoxEdgeDeviceNetworkSettingsData in the base namespace. This subclass provides backward-compatible
// type name and namespace.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    /// <summary> The network settings of a device. </summary>
    public partial class DataBoxEdgeDeviceNetworkSettings : DataBoxEdgeDeviceNetworkSettingsData,
        IJsonModel<DataBoxEdgeDeviceNetworkSettings>,
        IPersistableModel<DataBoxEdgeDeviceNetworkSettings>
    {
        /// <summary> Initializes a new instance of <see cref="DataBoxEdgeDeviceNetworkSettings"/>. </summary>
        public DataBoxEdgeDeviceNetworkSettings() : base()
        {
        }

        internal DataBoxEdgeDeviceNetworkSettings(DataBoxEdgeDeviceNetworkSettingsData data)
            : base(data.Id, data.Name, data.ResourceType, data.SystemData, null, data.Properties)
        {
        }

        void IJsonModel<DataBoxEdgeDeviceNetworkSettings>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<DataBoxEdgeDeviceNetworkSettingsData>)this).Write(writer, options);

        DataBoxEdgeDeviceNetworkSettings IJsonModel<DataBoxEdgeDeviceNetworkSettings>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var data = ((IJsonModel<DataBoxEdgeDeviceNetworkSettingsData>)this).Create(ref reader, options);
            return new DataBoxEdgeDeviceNetworkSettings(data);
        }

        BinaryData IPersistableModel<DataBoxEdgeDeviceNetworkSettings>.Write(ModelReaderWriterOptions options)
        {
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                ((IJsonModel<DataBoxEdgeDeviceNetworkSettings>)this).Write(writer, options);
            }
            return new BinaryData(stream.ToArray());
        }

        DataBoxEdgeDeviceNetworkSettings IPersistableModel<DataBoxEdgeDeviceNetworkSettings>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var utf8Reader = new Utf8JsonReader(data);
            return ((IJsonModel<DataBoxEdgeDeviceNetworkSettings>)this).Create(ref utf8Reader, options);
        }

        string IPersistableModel<DataBoxEdgeDeviceNetworkSettings>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
