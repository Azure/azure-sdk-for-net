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
    // Backward-compat: older NetApp API versions had two backup resources sharing
    // this `NetAppBackupData` model. One resource was deprecated before TypeSpec
    // migration, leaving one current resource for this model but preserving the GA
    // asymmetric names: the data type was `NetAppBackupData`, while the resource,
    // collection, and patch types were `NetAppBackupVaultBackupResource`,
    // `NetAppBackupVaultBackupCollection`, and `NetAppBackupVaultBackupPatch`.
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

        // Backward-compat: v1.15 exposed VolumeName on NetAppBackupData. Newer
        // service API versions replaced it with VolumeResourceId, so there is no
        // current TypeSpec property to document or rename. Keep the read-only
        // property for binary compatibility; it will remain null for responses
        // that no longer include the wire field.
        /// <summary> Volume name. </summary>
        public string VolumeName { get; }

        // Backward-compat: the generated property is BackupPolicyArmResourceId
        // because the TypeSpec property is an ARM resource identifier. v1.15 exposed
        // the same value as a string named BackupPolicyResourceId, so keep this alias.
        /// <summary> ResourceId used to identify the backup policy. </summary>
        public string BackupPolicyResourceId
        {
            get { return BackupPolicyArmResourceId?.ToString(); }
        }
    }
}
