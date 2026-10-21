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

    // NOTE: The following customization is intentionally retained for backward compatibility.
    // Spec change: RecoveryPointTierType was changed from fixed enum to extensible enum (struct).
    /// <summary> Recovery point tier type. </summary>
    public enum RecoveryPointTierType
    {
        /// <summary> Invalid. </summary>
        Invalid,
        /// <summary> Instant RP. </summary>
        InstantRP,
        /// <summary> Hardened RP. </summary>
        HardenedRP,
        /// <summary> Archived RP. </summary>
        ArchivedRP,
        /// <summary> Instant Access snapshot tier, retained for the policy's instantAccessDurationMinutes. </summary>
        IASnapshotRP
    }
}
