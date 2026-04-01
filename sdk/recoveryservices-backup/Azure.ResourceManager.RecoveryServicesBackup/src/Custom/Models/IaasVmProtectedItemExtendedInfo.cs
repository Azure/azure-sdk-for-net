// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
    public partial class IaasVmProtectedItemExtendedInfo
    {
        /// <summary> The oldest backup copy available for this backup item in vault tier. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? OldestRecoveryPointInVault { get => OldestRecoverOnInVault; set => OldestRecoverOnInVault = value; }
        /// <summary> The oldest backup copy available for this backup item in archive tier. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? OldestRecoveryPointInArchive { get => OldestRecoverOnInArchive; set => OldestRecoverOnInArchive = value; }
        /// <summary> The latest backup copy available for this backup item in archive tier. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? NewestRecoveryPointInArchive { get => NewestRecoverOnInArchive; set => NewestRecoverOnInArchive = value; }
    }
}
