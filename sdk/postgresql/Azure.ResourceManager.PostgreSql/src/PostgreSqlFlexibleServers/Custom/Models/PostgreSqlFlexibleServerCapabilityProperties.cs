// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> Capability for the PostgreSQL server. </summary>
    public partial class PostgreSqlFlexibleServerCapabilityProperties : CapabilityBase
    {
        /// <summary> Initializes a new instance of PostgreSqlFlexibleServerCapabilityProperties. </summary>
        internal PostgreSqlFlexibleServerCapabilityProperties()
        {
            SupportedServerEditions = new ChangeTrackingList<PostgreSqlFlexibleServerEditionCapability>();
            SupportedServerVersions = new ChangeTrackingList<PostgreSqlFlexibleServerServerVersionCapability>();
            SupportedFastProvisioningEditions = new ChangeTrackingList<PostgreSqlFlexibleServerFastProvisioningEditionCapability>();
        }

        /// <summary> Initializes a new instance of PostgreSqlFlexibleServerCapabilityProperties. </summary>
        /// <param name="status"> The status of the capability. </param>
        /// <param name="reason"> The reason for the capability not being available. </param>
        /// <param name="name"> Name of flexible servers capability. </param>
        /// <param name="supportedServerEditions"> List of supported flexible server editions. </param>
        /// <param name="supportedServerVersions"> The list of server versions supported for this capability. </param>
        /// <param name="fastProvisioningSupported"> Gets a value indicating whether fast provisioning is supported. "Enabled" means fast provisioning is supported. "Disabled" stands for fast provisioning is not supported. </param>
        /// <param name="supportedFastProvisioningEditions"> List of supported server editions for fast provisioning. </param>
        /// <param name="geoBackupSupported"> Determines if geo-backup is supported in this region. "Enabled" means geo-backup is supported. "Disabled" stands for geo-back is not supported. </param>
        /// <param name="zoneRedundantHaSupported"> A value indicating whether Zone Redundant HA is supported in this region. "Enabled" means zone redundant HA is supported. "Disabled" stands for zone redundant HA is not supported. </param>
        /// <param name="zoneRedundantHaAndGeoBackupSupported"> A value indicating whether Zone Redundant HA and Geo-backup is supported in this region. "Enabled" means zone redundant HA and geo-backup is supported. "Disabled" stands for zone redundant HA and geo-backup is not supported. </param>
        /// <param name="storageAutoGrowthSupported"> A value indicating whether storage auto-grow is supported in this region. "Enabled" means storage auto-grow is supported. "Disabled" stands for storage auto-grow is not supported. </param>
        /// <param name="onlineResizeSupported"> A value indicating whether online resize is supported in this region for the given subscription. "Enabled" means storage online resize is supported. "Disabled" means storage online resize is not supported. </param>
        /// <param name="restricted"> A value indicating whether this region is restricted. "Enabled" means region is restricted. "Disabled" stands for region is not restricted. </param>
        internal PostgreSqlFlexibleServerCapabilityProperties(PostgreSqlFlexbileServerCapabilityStatus? status, string reason, string name, IReadOnlyList<PostgreSqlFlexibleServerEditionCapability> supportedServerEditions, IReadOnlyList<PostgreSqlFlexibleServerServerVersionCapability> supportedServerVersions, PostgreSqlFlexibleServerFastProvisioningSupportedEnum? fastProvisioningSupported, IReadOnlyList<PostgreSqlFlexibleServerFastProvisioningEditionCapability> supportedFastProvisioningEditions, PostgreSqlFlexibleServerGeoBackupSupportedEnum? geoBackupSupported, PostgreSqlFlexibleServerZoneRedundantHaSupportedEnum? zoneRedundantHaSupported, PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupportedEnum? zoneRedundantHaAndGeoBackupSupported, PostgreSqlFlexibleServerStorageAutoGrowthSupportedEnum? storageAutoGrowthSupported, PostgreSqlFlexibleServerOnlineResizeSupportedEnum? onlineResizeSupported, PostgreSqlFlexibleServerZoneRedundantRestrictedEnum? restricted) : base(status, reason)
        {
            Name = name;
            SupportedServerEditions = supportedServerEditions;
            SupportedServerVersions = supportedServerVersions;
            FastProvisioningSupported = fastProvisioningSupported;
            SupportedFastProvisioningEditions = supportedFastProvisioningEditions;
            GeoBackupSupported = geoBackupSupported;
            ZoneRedundantHaSupported = zoneRedundantHaSupported;
            ZoneRedundantHaAndGeoBackupSupported = zoneRedundantHaAndGeoBackupSupported;
            StorageAutoGrowthSupported = storageAutoGrowthSupported;
            OnlineResizeSupported = onlineResizeSupported;
            Restricted = restricted;
        }

        /// <summary> Name of flexible servers capability. </summary>
        public string Name { get; }
        /// <summary> List of supported flexible server editions. </summary>
        public IReadOnlyList<PostgreSqlFlexibleServerEditionCapability> SupportedServerEditions { get; }
        /// <summary> The list of server versions supported for this capability. </summary>
        /// <summary> List of supported flexible server editions. </summary>
        public IReadOnlyList<PostgreSqlFlexibleServerEditionCapability> SupportedFlexibleServerEditions
        {
            get => SupportedServerEditions;
        }
        /// <summary> The list of server versions supported for this capability. </summary>
        public IReadOnlyList<PostgreSqlFlexibleServerServerVersionCapability> SupportedServerVersions { get; }
        /// <summary> Gets a value indicating whether fast provisioning is supported. "Enabled" means fast provisioning is supported. "Disabled" stands for fast provisioning is not supported. </summary>
        public PostgreSqlFlexibleServerFastProvisioningSupportedEnum? FastProvisioningSupported { get; }
        /// <summary> List of supported server editions for fast provisioning. </summary>
        public IReadOnlyList<PostgreSqlFlexibleServerFastProvisioningEditionCapability> SupportedFastProvisioningEditions { get; }
        /// <summary> Determines if geo-backup is supported in this region. "Enabled" means geo-backup is supported. "Disabled" stands for geo-back is not supported. </summary>
        public PostgreSqlFlexibleServerGeoBackupSupportedEnum? GeoBackupSupported { get; }
        /// <summary> A value indicating whether a new server in this region can have geo-backups to paired region. </summary>
        public bool? IsGeoBackupSupported
        {
            get => GeoBackupSupported is null ? false : GeoBackupSupported == PostgreSqlFlexibleServerGeoBackupSupportedEnum.Enabled;
        }
        /// <summary> A value indicating whether Zone Redundant HA is supported in this region. "Enabled" means zone redundant HA is supported. "Disabled" stands for zone redundant HA is not supported. </summary>
        public PostgreSqlFlexibleServerZoneRedundantHaSupportedEnum? ZoneRedundantHaSupported { get; }
        /// <summary> A value indicating whether a new server in this region can support multi zone HA. </summary>
        public bool? IsZoneRedundantHASupported
        {
            get => ZoneRedundantHaSupported is null ? false : ZoneRedundantHaSupported == PostgreSqlFlexibleServerZoneRedundantHaSupportedEnum.Enabled;
        }
        /// <summary> A value indicating whether Zone Redundant HA and Geo-backup is supported in this region. "Enabled" means zone redundant HA and geo-backup is supported. "Disabled" stands for zone redundant HA and geo-backup is not supported. </summary>
        public PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupportedEnum? ZoneRedundantHaAndGeoBackupSupported { get; }
        /// <summary> A value indicating whether a new server in this region can have geo-backups to paired region. </summary>
        public bool? IsZoneRedundantHAAndGeoBackupSupported
        {
            get => ZoneRedundantHaAndGeoBackupSupported is null ? false : ZoneRedundantHaAndGeoBackupSupported == PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupportedEnum.Enabled;
        }
        /// <summary> A value indicating whether storage auto-grow is supported in this region. "Enabled" means storage auto-grow is supported. "Disabled" stands for storage auto-grow is not supported. </summary>
        public PostgreSqlFlexibleServerStorageAutoGrowthSupportedEnum? StorageAutoGrowthSupported { get; }
        /// <summary> A value indicating whether online resize is supported in this region for the given subscription. "Enabled" means storage online resize is supported. "Disabled" means storage online resize is not supported. </summary>
        public PostgreSqlFlexibleServerOnlineResizeSupportedEnum? OnlineResizeSupported { get; }
        /// <summary> A value indicating whether this region is restricted. "Enabled" means region is restricted. "Disabled" stands for region is not restricted. </summary>
        public PostgreSqlFlexibleServerZoneRedundantRestrictedEnum? Restricted { get; }
        /// <summary> The status. </summary>
        public new string Status { get; }
    }
}
