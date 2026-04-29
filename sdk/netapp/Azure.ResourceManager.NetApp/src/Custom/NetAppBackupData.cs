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
    //   - Location: the new generated type derives from ResourceData (not TrackedResourceData)
    //     and has no Location property; restore the GA settable property.
    //   - VolumeName: backward-compat stub. The new spec (Backup.tsp) does not model a
    //     `volumeName` field on the backup contract — only `volumeResourceId`. We keep this
    //     auto-property (no setter, no backing field; always returns null) purely for source
    //     compat with the GA SDK. There is nothing to update in the spec for this property;
    //     it should be removed in the next major SDK release. Callers that need the volume
    //     name should parse it from VolumeResourceId.
    //   - BackupPolicyArmResourceId: the new generated type exposes BackupPolicyResourceId as
    //     string only; restore the typed ResourceIdentifier accessor for source compat.
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
