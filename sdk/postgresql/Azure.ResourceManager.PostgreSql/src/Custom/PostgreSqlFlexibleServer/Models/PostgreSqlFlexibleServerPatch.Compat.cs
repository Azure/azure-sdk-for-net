// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    [CodeGenSuppress("AuthConfig")]
    [CodeGenSuppress("Backup")]
    [CodeGenSuppress("HighAvailability")]
    [CodeGenSuppress("MaintenanceWindow")]
    [CodeGenSuppress("Sku")]
    [CodeGenSuppress("AdministratorLogin")]
    public partial class PostgreSqlFlexibleServerPatch
    {
        private AzureLocation? _location;

        /// <summary> Authentication configuration properties of a server. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.authConfig")]
        public PostgreSqlFlexibleServerAuthConfig AuthConfig
        {
            get
            {
                if (Properties is null)
                    return default;
                var src = Properties.AuthConfig;
                if (src is null)
                    return default;
                return new PostgreSqlFlexibleServerAuthConfig()
                {
                    ActiveDirectoryAuth = src.ActiveDirectoryAuth,
                    PasswordAuth = src.PasswordAuth,
                    TenantId = Guid.TryParse(src.TenantId, out var tid) ? tid : default(Guid?)
                };
            }
            set
            {
                Properties ??= new ServerPropertiesForPatch();
                if (value is null)
                {
                    Properties.AuthConfig = null;
                }
                else
                {
                    Properties.AuthConfig = new AuthConfigForPatch()
                    {
                        ActiveDirectoryAuth = value.ActiveDirectoryAuth,
                        PasswordAuth = value.PasswordAuth,
                        TenantId = value.TenantId?.ToString()
                    };
                }
            }
        }

        /// <summary> Backup properties of a server. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.backup")]
        public PostgreSqlFlexibleServerBackupProperties Backup
        {
            get
            {
                if (Properties is null)
                    return default;
                var src = Properties.Backup;
                if (src is null)
                    return default;
                return new PostgreSqlFlexibleServerBackupProperties()
                {
                    BackupRetentionDays = src.BackupRetentionDays,
                    GeoRedundantBackup = src.GeoRedundantBackup,
                };
            }
            set
            {
                Properties ??= new ServerPropertiesForPatch();
                if (value is null)
                {
                    Properties.Backup = null;
                }
                else
                {
                    Properties.Backup = new BackupForPatch()
                    {
                        BackupRetentionDays = value.BackupRetentionDays,
                    };
                }
            }
        }

        /// <summary> High availability properties of a server. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.highAvailability")]
        public PostgreSqlFlexibleServerHighAvailability HighAvailability
        {
            get
            {
                if (Properties is null)
                    return default;
                var src = Properties.HighAvailability;
                if (src is null)
                    return default;
                return new PostgreSqlFlexibleServerHighAvailability()
                {
                    Mode = src.Mode,
                    StandbyAvailabilityZone = src.StandbyAvailabilityZone,
                };
            }
            set
            {
                Properties ??= new ServerPropertiesForPatch();
                if (value is null)
                {
                    Properties.HighAvailability = null;
                }
                else
                {
                    Properties.HighAvailability = new HighAvailabilityForPatch()
                    {
                        Mode = value.Mode,
                        StandbyAvailabilityZone = value.StandbyAvailabilityZone,
                    };
                }
            }
        }

        /// <summary> Maintenance window properties of a server. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.maintenanceWindow")]
        public PostgreSqlFlexibleServerMaintenanceWindow MaintenanceWindow
        {
            get
            {
                if (Properties is null)
                    return default;
                var src = Properties.MaintenanceWindow;
                if (src is null)
                    return default;
                return new PostgreSqlFlexibleServerMaintenanceWindow()
                {
                    CustomWindow = src.CustomWindow,
                    StartHour = src.StartHour,
                    StartMinute = src.StartMinute,
                    DayOfWeek = src.DayOfWeek,
                };
            }
            set
            {
                Properties ??= new ServerPropertiesForPatch();
                if (value is null)
                {
                    Properties.MaintenanceWindow = null;
                }
                else
                {
                    Properties.MaintenanceWindow = new MaintenanceWindowForPatch()
                    {
                        CustomWindow = value.CustomWindow,
                        StartHour = value.StartHour,
                        StartMinute = value.StartMinute,
                        DayOfWeek = value.DayOfWeek,
                    };
                }
            }
        }

        /// <summary> Compute tier and size of a server. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("sku")]
        public PostgreSqlFlexibleServerSku Sku
        {
            get
            {
                var src = SkuInternal;
                if (src is null)
                    return default;
                return new PostgreSqlFlexibleServerSku(src.Name, src.Tier ?? default);
            }
            set
            {
                if (value is null)
                {
                    SkuInternal = null;
                }
                else
                {
                    SkuInternal = new SkuForPatch()
                    {
                        Name = value.Name,
                        Tier = value.Tier,
                    };
                }
            }
        }

        internal SkuForPatch SkuInternal { get; set; }

        /// <summary> The administrator&apos;s login name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.administratorLogin")]
        public string AdministratorLogin
        {
            get => Properties is null ? default : Properties.AdministratorLogin;
            set
            {
                // Setter provided for backward compatibility - the server sets this value
            }
        }

        /// <summary> The geo-affinity location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("location")]
        public AzureLocation? Location
        {
            get => _location;
            set => _location = value;
        }
    }
}
