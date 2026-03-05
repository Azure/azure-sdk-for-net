// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    /// <summary>
    /// A class representing the NetAppVolume data model.
    /// Volume resource
    /// This type is deprecated. Use <see cref="VolumeData"/> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [CodeGenSerialization(nameof(IsRestoring), "isRestoring")]
    public partial class NetAppVolumeData : TrackedResourceData, IJsonModel<NetAppVolumeData>, IPersistableModel<NetAppVolumeData>
    {
        /// <summary> Initializes a new instance of <see cref="NetAppVolumeData"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="creationToken"> A unique file path for the volume. </param>
        /// <param name="usageThreshold"> Maximum storage quota allowed for a file system in bytes. </param>
        /// <param name="subnetId"> The Azure Resource URI for a delegated subnet. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppVolumeData(AzureLocation location, string creationToken, long usageThreshold, ResourceIdentifier subnetId) : base(location)
        {
            CreationToken = creationToken;
            UsageThreshold = usageThreshold;
            SubnetId = subnetId?.ToString();
        }

        /// <summary> A unique file path for the volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CreationToken { get; set; }

        /// <summary> Maximum storage quota allowed for a file system in bytes. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long UsageThreshold { get; set; }

        /// <summary> The Azure Resource URI for a delegated subnet. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SubnetId { get; set; }

        /// <summary> Restoring. ReadOnly property indicating if volume is being restored. </summary>
        public bool? IsRestoring
        {
            get;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set;
        }

        /// <summary> Accept any grow capacity pool for short term clone split. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AcceptGrowCapacityPoolForShortTermCloneSplit? AcceptGrowCapacityPoolForShortTermCloneSplit { get; set; }

        /// <summary> Actual throughput in MiB/s for auto qosType volumes calculated based on size and serviceLevel. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ActualThroughputMibps { get; }

        /// <summary> Specifies whether the volume is enabled for Azure VMware Solution (AVS) datastore purpose. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppAvsDataStore? AvsDataStore { get; set; }

        /// <summary> UUID v4 or resource identifier used to identify the Backup. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BackupId { get; set; }

        /// <summary> Unique Baremetal Tenant Identifier. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BaremetalTenantId { get; }

        /// <summary> Pool Resource Id used in case of creating a volume through volume group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier CapacityPoolResourceId { get; set; }

        /// <summary> When a volume is being restored from another volume's snapshot, will show the percentage completion of this cloning process. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? CloneProgress { get; }

        /// <summary> Specifies the number of days after which data that is not accessed by clients will be tiered. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? CoolnessPeriod { get; set; }

        /// <summary> coolAccessRetrievalPolicy determines the data retrieval behavior from the cool tier to standard storage. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CoolAccessRetrievalPolicy? CoolAccessRetrievalPolicy { get; set; }

        /// <summary> Tiering policy for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CoolAccessTieringPolicy? CoolAccessTieringPolicy { get; set; }

        NetAppVolumeData IJsonModel<NetAppVolumeData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("NetAppVolumeData is deprecated. Use VolumeData instead.");
        }

        void IJsonModel<NetAppVolumeData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("NetAppVolumeData is deprecated. Use VolumeData instead.");
        }

        NetAppVolumeData IPersistableModel<NetAppVolumeData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("NetAppVolumeData is deprecated. Use VolumeData instead.");
        }

        string IPersistableModel<NetAppVolumeData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<NetAppVolumeData>.Write(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("NetAppVolumeData is deprecated. Use VolumeData instead.");
        }
    }
}
