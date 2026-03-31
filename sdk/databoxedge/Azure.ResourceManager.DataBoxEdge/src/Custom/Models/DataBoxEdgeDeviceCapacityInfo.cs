// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Baseline had this type in Models namespace as a plain model. New generator creates it as
// DataBoxEdgeDeviceCapacityInfoData in the base namespace. This subclass provides backward-compatible
// type name and namespace.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    /// <summary> The device capacity info. </summary>
    public partial class DataBoxEdgeDeviceCapacityInfo : DataBoxEdgeDeviceCapacityInfoData,
        IJsonModel<DataBoxEdgeDeviceCapacityInfo>,
        IPersistableModel<DataBoxEdgeDeviceCapacityInfo>
    {
        /// <summary> Initializes a new instance of <see cref="DataBoxEdgeDeviceCapacityInfo"/>. </summary>
        public DataBoxEdgeDeviceCapacityInfo() : base()
        {
        }

        // Baseline had setters on these output-only properties. Shadow with new + no-op setter for backward compat.
        /// <summary> Cluster Compute Data. </summary>
        public new EdgeClusterCapacityViewInfo ClusterComputeCapacityInfo
        {
            get => base.ClusterComputeCapacityInfo;
            set { }
        }

        /// <summary> Cluster Storage Data. </summary>
        public new EdgeClusterStorageViewInfo ClusterStorageCapacityInfo
        {
            get => base.ClusterStorageCapacityInfo;
            set { }
        }

        /// <summary> The time stamp of the capacity info. </summary>
        public new DateTimeOffset? TimeStamp
        {
            get => base.TimeStamp;
            set { }
        }

        internal DataBoxEdgeDeviceCapacityInfo(DataBoxEdgeDeviceCapacityInfoData data)
            : base(data.Id, data.Name, data.ResourceType, data.SystemData, null, data.Properties)
        {
        }

        void IJsonModel<DataBoxEdgeDeviceCapacityInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<DataBoxEdgeDeviceCapacityInfoData>)this).Write(writer, options);

        DataBoxEdgeDeviceCapacityInfo IJsonModel<DataBoxEdgeDeviceCapacityInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var data = ((IJsonModel<DataBoxEdgeDeviceCapacityInfoData>)this).Create(ref reader, options);
            return new DataBoxEdgeDeviceCapacityInfo(data);
        }

        BinaryData IPersistableModel<DataBoxEdgeDeviceCapacityInfo>.Write(ModelReaderWriterOptions options)
        {
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                ((IJsonModel<DataBoxEdgeDeviceCapacityInfo>)this).Write(writer, options);
            }
            return new BinaryData(stream.ToArray());
        }

        DataBoxEdgeDeviceCapacityInfo IPersistableModel<DataBoxEdgeDeviceCapacityInfo>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            var reader = doc.RootElement.EnumerateObject().GetEnumerator();
            var utf8Reader = new Utf8JsonReader(data);
            return ((IJsonModel<DataBoxEdgeDeviceCapacityInfo>)this).Create(ref utf8Reader, options);
        }

        string IPersistableModel<DataBoxEdgeDeviceCapacityInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
