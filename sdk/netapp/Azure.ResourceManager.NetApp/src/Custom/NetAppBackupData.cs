// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp
{
    /// <summary>
    /// Renames the generated <c>NetAppBackupVaultBackupData</c> type to
    /// <c>NetAppBackupData</c> to preserve API compatibility with the
    /// pre-TypeSpec SDK, and supplies members that existed on the old type.
    /// </summary>
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
