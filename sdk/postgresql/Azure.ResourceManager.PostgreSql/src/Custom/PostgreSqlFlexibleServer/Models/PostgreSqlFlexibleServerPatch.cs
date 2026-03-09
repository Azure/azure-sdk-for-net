// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> Represents a server to be updated. </summary>
    [CodeGenSuppress("AdministratorLogin")]
    [CodeGenSuppress("AuthConfig")]
    [CodeGenSuppress("Backup")]
    [CodeGenSuppress("HighAvailability")]
    [CodeGenSuppress("MaintenanceWindow")]
    public partial class PostgreSqlFlexibleServerPatch
    {
        /// <summary> Compute tier and size of a server (internal, for serialization). </summary>
        [CodeGenMember("Sku")]
        internal SkuForPatch InternalSku { get; set; }

        /// <summary> Compute tier and size of a server. </summary>
        [WirePath("sku")]
        public PostgreSqlFlexibleServerSku Sku
        {
            get => InternalSku is null ? null : new PostgreSqlFlexibleServerSku(InternalSku.Name, InternalSku.Tier ?? default);
            set => InternalSku = value is null ? null : new SkuForPatch { Name = value.Name, Tier = value.Tier };
        }

        /// <summary> Name of the login designated as the first password based administrator. </summary>
        [WirePath("properties.administratorLogin")]
        public string AdministratorLogin
        {
            get => Properties is null ? default : Properties.AdministratorLogin;
            set
            {
                if (Properties is null)
                    Properties = new ServerPropertiesForPatch();
                Properties.AdministratorLogin = value;
            }
        }

        /// <summary> Authentication configuration properties of a server. </summary>
        [WirePath("properties.authConfig")]
        public PostgreSqlFlexibleServerAuthConfig AuthConfig
        {
            get
            {
                if (Properties?.AuthConfig is null)
                    return null;
                var ac = Properties.AuthConfig;
                return new PostgreSqlFlexibleServerAuthConfig
                {
                    ActiveDirectoryAuth = ac.ActiveDirectoryAuth,
                    PasswordAuth = ac.PasswordAuth,
                    TenantId = ac.TenantId != null ? Guid.Parse(ac.TenantId) : null,
                };
            }
            set
            {
                if (Properties is null)
                    Properties = new ServerPropertiesForPatch();
                Properties.AuthConfig = value is null
                    ? null
                    : new AuthConfigForPatch
                    {
                        ActiveDirectoryAuth = value.ActiveDirectoryAuth,
                        PasswordAuth = value.PasswordAuth,
                        TenantId = value.TenantId?.ToString(),
                    };
            }
        }

        /// <summary> Backup properties of a server. </summary>
        [WirePath("properties.backup")]
        public PostgreSqlFlexibleServerBackupProperties Backup
        {
            get
            {
                if (Properties?.Backup is null)
                    return null;
                var b = Properties.Backup;
                return new PostgreSqlFlexibleServerBackupProperties
                {
                    BackupRetentionDays = b.BackupRetentionDays,
                };
            }
            set
            {
                if (Properties is null)
                    Properties = new ServerPropertiesForPatch();
                Properties.Backup = value is null
                    ? null
                    : new BackupForPatch
                    {
                        BackupRetentionDays = value.BackupRetentionDays,
                    };
            }
        }

        /// <summary> High availability properties of a server. </summary>
        [WirePath("properties.highAvailability")]
        public PostgreSqlFlexibleServerHighAvailability HighAvailability
        {
            get
            {
                if (Properties?.HighAvailability is null)
                    return null;
                var ha = Properties.HighAvailability;
                return new PostgreSqlFlexibleServerHighAvailability
                {
                    Mode = ha.Mode,
                    StandbyAvailabilityZone = ha.StandbyAvailabilityZone,
                };
            }
            set
            {
                if (Properties is null)
                    Properties = new ServerPropertiesForPatch();
                Properties.HighAvailability = value is null
                    ? null
                    : new HighAvailabilityForPatch
                    {
                        Mode = value.Mode,
                        StandbyAvailabilityZone = value.StandbyAvailabilityZone,
                    };
            }
        }

        /// <summary> Maintenance window properties of a server. </summary>
        [WirePath("properties.maintenanceWindow")]
        public PostgreSqlFlexibleServerMaintenanceWindow MaintenanceWindow
        {
            get
            {
                if (Properties?.MaintenanceWindow is null)
                    return null;
                var mw = Properties.MaintenanceWindow;
                return new PostgreSqlFlexibleServerMaintenanceWindow
                {
                    CustomWindow = mw.CustomWindow,
                    StartHour = mw.StartHour,
                    StartMinute = mw.StartMinute,
                    DayOfWeek = mw.DayOfWeek,
                };
            }
            set
            {
                if (Properties is null)
                    Properties = new ServerPropertiesForPatch();
                Properties.MaintenanceWindow = value is null
                    ? null
                    : new MaintenanceWindowForPatch
                    {
                        CustomWindow = value.CustomWindow,
                        StartHour = value.StartHour,
                        StartMinute = value.StartMinute,
                        DayOfWeek = value.DayOfWeek,
                    };
            }
        }

        /// <summary> Max storage allowed for a server. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.storage.storageSizeGB")]
        public int? StorageSizeInGB
        {
            get => Storage is null ? default : Storage.StorageSizeInGB;
            set
            {
                if (Storage is null)
                    Storage = new PostgreSqlFlexibleServerStorage();
                Storage.StorageSizeInGB = value;
            }
        }

        /// <summary> Location for the server. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("location")]
        public AzureLocation? Location { get; set; }
    }
}
