// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumePatch : TrackedResourceData
    {
        private VolumePatchProperties WritableProperties
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new VolumePatchProperties();
                }

                return Properties;
            }
        }

        /// <summary> DataProtection type volumes include an object containing details of the replication. </summary>
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

        // VolumePatch.properties is flattened in the spec, but the generator only lifts
        // CoolAccess and SnapshotDirectoryVisible onto NetAppVolumePatch. Keep forwarding
        // properties for the remaining GA patch members so callers can set them and still have
        // the values serialized into the nested PATCH payload.
        /// <summary> DataProtection type volumes include an object containing details of the replication. </summary>
        public NetAppVolumePatchDataProtection DataProtection
        {
            get => Properties?.DataProtection;
            set => WritableProperties.DataProtection = value;
        }

        /// <summary> The service level of the file system. </summary>
        public NetAppFileServiceLevel? ServiceLevel
        {
            get => Properties?.ServiceLevel;
            set => WritableProperties.ServiceLevel = value;
        }

        /// <summary> Maximum storage quota allowed for a file system in bytes. </summary>
        public long? UsageThreshold
        {
            get => Properties?.UsageThreshold;
            set => WritableProperties.UsageThreshold = value;
        }

        /// <summary> Set of protocol types. </summary>
        public IList<string> ProtocolTypes => WritableProperties.ProtocolTypes;

        /// <summary> Maximum throughput in MiB/s. </summary>
        public float? ThroughputMibps
        {
            get => Properties?.ThroughputMibps;
            set => WritableProperties.ThroughputMibps = value;
        }

        /// <summary> Set of export policy rules. </summary>
        public IList<NetAppVolumeExportPolicyRule> ExportRules => WritableProperties.ExportRules;

        /// <summary> Specifies if default quota is enabled for the volume. </summary>
        public bool? IsDefaultQuotaEnabled
        {
            get => Properties?.IsDefaultQuotaEnabled;
            set => WritableProperties.IsDefaultQuotaEnabled = value;
        }

        /// <summary> Default user quota for volume in KiBs. </summary>
        public long? DefaultUserQuotaInKiBs
        {
            get => Properties?.DefaultUserQuotaInKiBs;
            set => WritableProperties.DefaultUserQuotaInKiBs = value;
        }

        /// <summary> Default group quota for volume in KiBs. </summary>
        public long? DefaultGroupQuotaInKiBs
        {
            get => Properties?.DefaultGroupQuotaInKiBs;
            set => WritableProperties.DefaultGroupQuotaInKiBs = value;
        }

        /// <summary> UNIX permissions for NFS volume accepted in octal 4 digit format. </summary>
        public string UnixPermissions
        {
            get => Properties?.UnixPermissions;
            set => WritableProperties.UnixPermissions = value;
        }

        /// <summary> Specifies the number of days after which data that is not accessed by clients will be tiered. </summary>
        public int? CoolnessPeriod
        {
            get => Properties?.CoolnessPeriod;
            set => WritableProperties.CoolnessPeriod = value;
        }

        /// <summary> coolAccessRetrievalPolicy determines the data retrieval behavior from the cool tier to standard storage. </summary>
        public CoolAccessRetrievalPolicy? CoolAccessRetrievalPolicy
        {
            get => Properties?.CoolAccessRetrievalPolicy;
            set => WritableProperties.CoolAccessRetrievalPolicy = value;
        }

        /// <summary> Tiering policy for a volume. </summary>
        public CoolAccessTieringPolicy? CoolAccessTieringPolicy
        {
            get => Properties?.CoolAccessTieringPolicy;
            set => WritableProperties.CoolAccessTieringPolicy = value;
        }

        /// <summary> Enables access-based enumeration share property for SMB Shares. </summary>
        public SmbAccessBasedEnumeration? SmbAccessBasedEnumeration
        {
            get => Properties?.SmbAccessBasedEnumeration;
            set => WritableProperties.SmbAccessBasedEnumeration = value;
        }

        /// <summary> Enables non-browsable property for SMB Shares. </summary>
        public SmbNonBrowsable? SmbNonBrowsable
        {
            get => Properties?.SmbNonBrowsable;
            set => WritableProperties.SmbNonBrowsable = value;
        }
    }
}
