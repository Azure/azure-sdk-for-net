// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp
{
    // CodeGenType renames the generated NetAppBackupVaultBackupData to NetAppBackupData to
    // preserve the GA-shipped type name. The members below existed on the old NetAppBackupData
    // but are not present on the new generated type:
    //   - Location: kept as a settable property (the new type derives from TrackedResourceData
    //     and exposes Location from the base, but the GA setter is preserved here).
    //   - VolumeName: deprecated; the service no longer populates this for the backup-vault-
    //     scoped contract, so it is read-only and always default. TODO: drop after the next
    //     major version (tracked via the spec doc-fix in PR #40224).
    //   - BackupPolicyArmResourceId: deprecated and hidden; backup policies are now associated
    //     via the backup vault, not directly on the backup. Kept for source compat.
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenType("NetAppBackupVaultBackupData")]
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

        /// <summary> Volume name. Not populated by the service for this contract. </summary>
        public string VolumeName { get; }

        /// <summary> ResourceId used to identify the backup policy. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier BackupPolicyArmResourceId { get; set; }
    }
}
