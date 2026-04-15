// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Volume patch resource. </summary>
    public partial class NetAppVolumePatch : TrackedResourceData
    {
        /// <summary> DataProtection type volumes include an object containing details of the replication. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppVolumePatchDataProtection DataProtection { get; set; }

        /// <summary> DataProtection type volumes include an object containing details of the replication. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier SnapshotPolicyId
        {
            get => DataProtection?.SnapshotPolicyId;
            set
            {
                if (DataProtection is null)
                    DataProtection = new NetAppVolumePatchDataProtection();
                DataProtection.SnapshotPolicyId = value;
            }
        }

        /// <summary> The service level of the file system. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppFileServiceLevel? ServiceLevel { get; set; }

        /// <summary> Maximum storage quota allowed for a file system in bytes. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? UsageThreshold { get; set; }

        /// <summary> Set of protocol types. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> ProtocolTypes { get; }

        /// <summary> Maximum throughput in MiB/s. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ThroughputMibps { get; set; }

        /// <summary> Set of export policy rules. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<NetAppVolumeExportPolicyRule> ExportRules { get; }

        /// <summary> Specifies if default quota is enabled for the volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsDefaultQuotaEnabled { get; set; }

        /// <summary> Default user quota for volume in KiBs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? DefaultUserQuotaInKiBs { get; set; }

        /// <summary> Default group quota for volume in KiBs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? DefaultGroupQuotaInKiBs { get; set; }

        /// <summary> UNIX permissions for NFS volume accepted in octal 4 digit format. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string UnixPermissions { get; set; }

        /// <summary> Specifies whether Cool Access(tiering) is enabled for the volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsCoolAccessEnabled { get; set; }

        /// <summary> Specifies the number of days after which data that is not accessed by clients will be tiered. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? CoolnessPeriod { get; set; }

        /// <summary> coolAccessRetrievalPolicy determines the data retrieval behavior from the cool tier to standard storage. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CoolAccessRetrievalPolicy? CoolAccessRetrievalPolicy { get; set; }

        /// <summary> Tiering policy for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CoolAccessTieringPolicy? CoolAccessTieringPolicy { get; set; }

        /// <summary> If enabled (true) the volume will contain a read-only snapshot directory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsSnapshotDirectoryVisible { get; set; }

        /// <summary> Enables access-based enumeration share property for SMB Shares. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SmbAccessBasedEnumeration? SmbAccessBasedEnumeration { get; set; }

        /// <summary> Enables non-browsable property for SMB Shares. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SmbNonBrowsable? SmbNonBrowsable { get; set; }
    }
}
