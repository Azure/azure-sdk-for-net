// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetApp.Models;
using Microsoft.TypeSpec.Generator.Customizations;
using AzureLocation = Azure.Core.AzureLocation;

namespace Azure.ResourceManager.NetApp
{
    // Backward-compat: v1.15 GA used asymmetric backup naming. The data type was
    // `NetAppBackupData`, while the resource, collection, and patch types were
    // `NetAppBackupVaultBackupResource`, `NetAppBackupVaultBackupCollection`, and
    // `NetAppBackupVaultBackupPatch`.
    //
    // The TypeSpec model must keep `@@clientName(Backup, "NetAppBackupVaultBackup",
    // "csharp")` so the resource/collection/patch names stay GA-compatible. Changing
    // that decorator to `NetAppBackup` would fix this data type but would break the
    // other three shipped names. [CodeGenType] is therefore used here to rename only
    // the generated data class from NetAppBackupVaultBackupData to NetAppBackupData.
    /// <summary>
    /// A class representing the NetAppBackup data model.
    /// Backup of a Volume
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [CodeGenType("NetAppBackupVaultBackupData")]
    public partial class NetAppBackupData
    {
        /// <summary> Initializes a new instance of <see cref="NetAppBackupData"/>. </summary>
        /// <param name="location"> Resource location. </param>
        public NetAppBackupData(AzureLocation location)
        {
            Location = location;
        }

        /// <summary> Resource location. </summary>
        public AzureLocation Location { get; set; }

        /// <summary> Volume name. </summary>
        public string VolumeName { get; }

        /// <summary> ResourceId used to identify the backup policy. </summary>
        public string BackupPolicyResourceId
        {
            get { return BackupPolicyArmResourceId?.ToString(); }
        }
    }
}
