// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    // In the old SDK (autorest-based), these types were plain models returned directly by device resource methods.
    // In the new SDK (TypeSpec-based), they are full ARM sub-resources with their own resource classes
    // (DataBoxEdgeDeviceUpdateSummaryResource) and data classes (DataBoxEdgeDeviceUpdateSummaryData).
    // These stubs are kept only for ApiCompat backward compatibility. All members throw NotSupportedException
    // at runtime; callers should migrate to GetDataBoxEdgeDeviceUpdateSummary().Get().Data.
    /// <summary>
    /// Details about ongoing updates and availability of updates on the device.
    /// This class is obsolete; use <see cref="DataBoxEdgeDeviceUpdateSummaryData"/> via
    /// <c>GetDataBoxEdgeDeviceUpdateSummary().Get().Data</c> instead.
    /// </summary>
    [Obsolete("Use DataBoxEdgeDeviceUpdateSummaryData via GetDataBoxEdgeDeviceUpdateSummary().Get().Data instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class DataBoxEdgeDeviceUpdateSummary : ResourceData, IJsonModel<DataBoxEdgeDeviceUpdateSummary>
    {
        /// <summary> Initializes a new instance of <see cref="DataBoxEdgeDeviceUpdateSummary"/>. </summary>
        public DataBoxEdgeDeviceUpdateSummary() { }

        /// <summary> The current version of the device in format: 1.2.17312.13. </summary>
        public string DeviceVersionNumber { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> The current version of the device in text format. </summary>
        public string FriendlyDeviceVersionName { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> The last time when a scan was done on the device. </summary>
        public DateTimeOffset? DeviceLastScannedOn { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> The time when the last scan job was completed (success/cancelled/failed) on the appliance. </summary>
        public DateTimeOffset? LastCompletedScanJobOn { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> Time when the last scan job is successfully completed. </summary>
        public DateTimeOffset? LastSuccessfulScanJobOn { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> The time when the last Download job was completed (success/cancelled/failed) on the appliance. </summary>
        public DateTimeOffset? LastCompletedDownloadJobOn { get => throw new NotSupportedException(); }
        /// <summary> JobId of the last ran download job.(Can be success/cancelled/failed). </summary>
        public ResourceIdentifier LastCompletedDownloadJobId { get => throw new NotSupportedException(); }
        /// <summary> JobStatus of the last ran download job. </summary>
        public DataBoxEdgeJobStatus? LastDownloadJobStatus { get => throw new NotSupportedException(); }
        /// <summary> The time when the Last Install job was completed successfully on the appliance. </summary>
        public DateTimeOffset? LastSuccessfulInstallJobOn { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> The time when the last Install job was completed (success/cancelled/failed) on the appliance. </summary>
        public DateTimeOffset? LastCompletedInstallJobOn { get => throw new NotSupportedException(); }
        /// <summary> JobId of the last ran install job.(Can be success/cancelled/failed). </summary>
        public ResourceIdentifier LastCompletedInstallJobId { get => throw new NotSupportedException(); }
        /// <summary> JobStatus of the last ran install job. </summary>
        public DataBoxEdgeJobStatus? LastInstallJobStatus { get => throw new NotSupportedException(); }
        /// <summary> The number of updates available for the current device version as per the last device scan. </summary>
        public int? TotalNumberOfUpdatesAvailable { get => throw new NotSupportedException(); }
        /// <summary> The total number of items pending download. </summary>
        public int? TotalNumberOfUpdatesPendingDownload { get => throw new NotSupportedException(); }
        /// <summary> The total number of items pending install. </summary>
        public int? TotalNumberOfUpdatesPendingInstall { get => throw new NotSupportedException(); }
        /// <summary> Indicates if updates are available and at least one of the updates needs a reboot. </summary>
        public InstallRebootBehavior? RebootBehavior { get => throw new NotSupportedException(); }
        /// <summary> The current update operation. </summary>
        public DataBoxEdgeUpdateOperation? OngoingUpdateOperation { get => throw new NotSupportedException(); }
        /// <summary> The job ID of the download job in progress. </summary>
        public ResourceIdentifier InProgressDownloadJobId { get => throw new NotSupportedException(); }
        /// <summary> The job ID of the install job in progress. </summary>
        public ResourceIdentifier InProgressInstallJobId { get => throw new NotSupportedException(); }
        /// <summary> The time when the currently running download (if any) started. </summary>
        public DateTimeOffset? InProgressDownloadJobStartedOn { get => throw new NotSupportedException(); }
        /// <summary> The time when the currently running install (if any) started. </summary>
        public DateTimeOffset? InProgressInstallJobStartedOn { get => throw new NotSupportedException(); }
        /// <summary> The list of updates available for install. </summary>
        public IReadOnlyList<string> UpdateTitles { get => throw new NotSupportedException(); }
        /// <summary> The list of updates available for install. </summary>
        public IReadOnlyList<DataBoxEdgeUpdateDetails> Updates { get => throw new NotSupportedException(); }
        /// <summary> The total size of updates available for download in bytes. </summary>
        public double? TotalUpdateSizeInBytes { get => throw new NotSupportedException(); }
        /// <summary> The total time in Minutes. </summary>
        public int? TotalTimeInMinutes { get => throw new NotSupportedException(); }

        /// <inheritdoc/>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException();

        DataBoxEdgeDeviceUpdateSummary IJsonModel<DataBoxEdgeDeviceUpdateSummary>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException();
        void IJsonModel<DataBoxEdgeDeviceUpdateSummary>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException();
        DataBoxEdgeDeviceUpdateSummary IPersistableModel<DataBoxEdgeDeviceUpdateSummary>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException();
        string IPersistableModel<DataBoxEdgeDeviceUpdateSummary>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => throw new NotSupportedException();
        BinaryData IPersistableModel<DataBoxEdgeDeviceUpdateSummary>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException();
    }
}