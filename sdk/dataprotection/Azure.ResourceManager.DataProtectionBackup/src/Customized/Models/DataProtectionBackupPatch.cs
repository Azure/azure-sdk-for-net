// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    /// <summary> Patch Request content for Microsoft.DataProtection resources. </summary>
    [Obsolete("DataProtectionBackupPatch is obsolete and will be removed in a future release. Please do not use it any longer.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class DataProtectionBackupPatch
    {
        /// <summary> Initializes a new instance of DataProtectionBackupPatch. </summary>
        public DataProtectionBackupPatch()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Input Managed Identity Details. </summary>
        public ManagedServiceIdentity Identity { get; set; }
        /// <summary> Resource properties. </summary>
        internal PatchBackupVaultInput Properties { get; set; }
        /// <summary> Gets or sets the alert settings for all job failures. </summary>
        public AzureMonitorAlertsState? AlertSettingsForAllJobFailures
        {
            get => Properties is null ? default : Properties.AlertSettingsForAllJobFailures;
            set
            {
                if (Properties is null)
                    Properties = new PatchBackupVaultInput();
                Properties.AlertSettingsForAllJobFailures = value;
            }
        }

        /// <summary> Resource tags. </summary>
        public IDictionary<string, string> Tags { get; }
    }
}
