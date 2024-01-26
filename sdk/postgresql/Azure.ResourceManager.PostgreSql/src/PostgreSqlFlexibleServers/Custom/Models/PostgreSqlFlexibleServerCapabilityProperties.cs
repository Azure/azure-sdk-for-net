// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> Capability for the PostgreSQL server. </summary>
    public partial class PostgreSqlFlexibleServerCapabilityProperties : PostgreSqlBaseCapability
    {
        /// <summary> List of supported flexible server editions. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<PostgreSqlFlexibleServerEditionCapability> SupportedFlexibleServerEditions
        {
            get => SupportedServerEditions;
        }
        /// <summary> Gets the supported hyperscale node editions. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<PostgreSqlFlexibleServerHyperscaleNodeEditionCapability> SupportedHyperscaleNodeEditions { get; }
        /// <summary> A value indicating whether fast provisioning is supported in this region. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? FastProvisioningSupported
        {
            get => SupportFastProvisioning is null ? false : SupportFastProvisioning == PostgreSqlFlexibleServerFastProvisioningSupported.Enabled;
        }
        /// <summary> A value indicating whether a new server in this region can have geo-backups to paired region. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsGeoBackupSupported
        {
            get => GeoBackupSupported is null ? false : GeoBackupSupported == PostgreSqlFlexibleServerGeoBackupSupported.Enabled;
        }
        /// <summary> A value indicating whether a new server in this region can be zone redundant HA enabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsZoneRedundantHASupported
        {
            get => ZoneRedundantHaSupported is null ? false : ZoneRedundantHaSupported == PostgreSqlFlexibleServerZoneRedundantHaSupported.Enabled;
        }
        /// <summary> A value indicating whether a new server in this region can have geo-backups to paired region and have zone redundant HA enabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsZoneRedundantHAAndGeoBackupSupported
        {
            get => ZoneRedundantHaAndGeoBackupSupported is null ? false : ZoneRedundantHaAndGeoBackupSupported == PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupported.Enabled;
        }

        /// <summary> zone name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Zone { get; }
        /// <summary> Supported high availability mode. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<string> SupportedHAModes { get; }
    }
}
