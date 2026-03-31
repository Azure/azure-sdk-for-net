// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Baseline had this type in Models namespace as a plain model. New generator creates it as
// DataBoxEdgeDeviceUpdateSummaryData in the base namespace. This subclass provides backward-compatible
// type name and namespace.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    /// <summary> Details about ongoing updates and availability of updates on the device. </summary>
    public partial class DataBoxEdgeDeviceUpdateSummary : DataBoxEdgeDeviceUpdateSummaryData,
        IJsonModel<DataBoxEdgeDeviceUpdateSummary>,
        IPersistableModel<DataBoxEdgeDeviceUpdateSummary>
    {
        /// <summary> Initializes a new instance of <see cref="DataBoxEdgeDeviceUpdateSummary"/>. </summary>
        public DataBoxEdgeDeviceUpdateSummary() : base()
        {
        }

        /// <summary> The last time when a scan was done on the device. </summary>
        public new DateTimeOffset? DeviceLastScannedOn
        {
            get => base.DeviceLastScannedOn;
            set { }
        }

        /// <summary> The current version of the device in format: 1.2.17312.13. </summary>
        public new string DeviceVersionNumber
        {
            get => base.DeviceVersionNumber;
            set { }
        }

        /// <summary> The current version of the device in text format. </summary>
        public new string FriendlyDeviceVersionName
        {
            get => base.FriendlyDeviceVersionName;
            set { }
        }

        /// <summary> The last time when a scan was completed successfully. </summary>
        public new DateTimeOffset? LastCompletedScanJobOn
        {
            get => base.LastCompletedScanJobOn;
            set { }
        }

        /// <summary> The time when the last Install job was completed successfully. </summary>
        public new DateTimeOffset? LastSuccessfulInstallJobOn
        {
            get => base.LastSuccessfulInstallJobOn;
            set { }
        }

        /// <summary> The time when the last scan job was completed successfully. </summary>
        public new DateTimeOffset? LastSuccessfulScanJobOn
        {
            get => base.LastSuccessfulScanJobOn;
            set { }
        }

        internal DataBoxEdgeDeviceUpdateSummary(DataBoxEdgeDeviceUpdateSummaryData data)
            : base(data.Id, data.Name, data.ResourceType, data.SystemData, null, data.Properties)
        {
        }

        void IJsonModel<DataBoxEdgeDeviceUpdateSummary>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<DataBoxEdgeDeviceUpdateSummaryData>)this).Write(writer, options);

        DataBoxEdgeDeviceUpdateSummary IJsonModel<DataBoxEdgeDeviceUpdateSummary>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var data = ((IJsonModel<DataBoxEdgeDeviceUpdateSummaryData>)this).Create(ref reader, options);
            return new DataBoxEdgeDeviceUpdateSummary(data);
        }

        BinaryData IPersistableModel<DataBoxEdgeDeviceUpdateSummary>.Write(ModelReaderWriterOptions options)
        {
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                ((IJsonModel<DataBoxEdgeDeviceUpdateSummary>)this).Write(writer, options);
            }
            return new BinaryData(stream.ToArray());
        }

        DataBoxEdgeDeviceUpdateSummary IPersistableModel<DataBoxEdgeDeviceUpdateSummary>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var utf8Reader = new Utf8JsonReader(data);
            return ((IJsonModel<DataBoxEdgeDeviceUpdateSummary>)this).Create(ref utf8Reader, options);
        }

        string IPersistableModel<DataBoxEdgeDeviceUpdateSummary>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
