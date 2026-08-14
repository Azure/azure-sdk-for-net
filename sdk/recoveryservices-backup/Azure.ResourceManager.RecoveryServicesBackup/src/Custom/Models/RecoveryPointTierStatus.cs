// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// NOTE: The following customization is intentionally retained for backward compatibility.
// Spec change: RecoveryPointTierStatus was changed from fixed enum to extensible enum (struct).
namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
    /// <summary> Recovery point tier status. </summary>
    public enum RecoveryPointTierStatus
    {
        /// <summary> Invalid. </summary>
        Invalid,
        /// <summary> Valid. </summary>
        Valid,
        /// <summary> Disabled. </summary>
        Disabled,
        /// <summary> Deleted. </summary>
        Deleted,
        /// <summary> Rehydrated. </summary>
        Rehydrated
    }
}
