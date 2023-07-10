// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> Capability for the PostgreSQL server. </summary>
    public partial class PostgreSqlFlexibleServerCapabilityProperties : CapabilityBase
    {
        /// <summary> List of supported flexible server editions. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<PostgreSqlFlexibleServerEditionCapability> SupportedFlexibleServerEditions
        {
            get => SupportedServerEditions;
        }
        /// <summary> A value indicating whether fast provisioning is supported in this region. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? FastProvisioningSupported
        {
            get => SupportFastProvisioning is null ? false : SupportFastProvisioning == PostgreSqlFlexibleServerFastProvisioningSupportedEnum.Enabled;
        }
        /// <summary> A value indicating whether a new server in this region can have geo-backups to paired region. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsGeoBackupSupported
        {
            get => GeoBackupSupported is null ? false : GeoBackupSupported == PostgreSqlFlexibleServerGeoBackupSupportedEnum.Enabled;
        }
        /// <summary> A value indicating whether a new server in this region can be zone redundant HA enabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsZoneRedundantHASupported
        {
            get => ZoneRedundantHaSupported is null ? false : ZoneRedundantHaSupported == PostgreSqlFlexibleServerZoneRedundantHaSupportedEnum.Enabled;
        }
        /// <summary> A value indicating whether a new server in this region can have geo-backups to paired region and have zone redundant HA enabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsZoneRedundantHAAndGeoBackupSupported
        {
            get => ZoneRedundantHaAndGeoBackupSupported is null ? false : ZoneRedundantHaAndGeoBackupSupported == PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupportedEnum.Enabled;
        }
        /// <summary> The status. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new string Status { get; }
    }
}
