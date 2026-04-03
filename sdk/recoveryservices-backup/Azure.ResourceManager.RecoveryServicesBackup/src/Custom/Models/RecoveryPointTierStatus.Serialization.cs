// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

// NOTE: The following customization is intentionally retained for backward compatibility.
// Spec change: RecoveryPointTierStatus was changed from fixed enum to extensible enum (struct).
namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
    internal static partial class RecoveryPointTierStatusExtensions
    {
        public static string ToSerialString(this RecoveryPointTierStatus value) => value switch
        {
            RecoveryPointTierStatus.Invalid => "Invalid",
            RecoveryPointTierStatus.Valid => "Valid",
            RecoveryPointTierStatus.Disabled => "Disabled",
            RecoveryPointTierStatus.Deleted => "Deleted",
            RecoveryPointTierStatus.Rehydrated => "Rehydrated",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown RecoveryPointTierStatus value.")
        };

        public static RecoveryPointTierStatus ToRecoveryPointTierStatus(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Invalid")) return RecoveryPointTierStatus.Invalid;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Valid")) return RecoveryPointTierStatus.Valid;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Disabled")) return RecoveryPointTierStatus.Disabled;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Deleted")) return RecoveryPointTierStatus.Deleted;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Rehydrated")) return RecoveryPointTierStatus.Rehydrated;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown RecoveryPointTierStatus value.");
        }
    }
}
