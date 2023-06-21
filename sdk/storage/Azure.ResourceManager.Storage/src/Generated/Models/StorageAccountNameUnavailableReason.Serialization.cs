// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Storage.Models
{
    internal static partial class StorageAccountNameUnavailableReasonExtensions
    {
        public static string ToSerialString(this StorageAccountNameUnavailableReason value) => value switch
        {
            StorageAccountNameUnavailableReason.AccountNameInvalid => "AccountNameInvalid",
            StorageAccountNameUnavailableReason.AlreadyExists => "AlreadyExists",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown StorageAccountNameUnavailableReason value.")
        };

        public static StorageAccountNameUnavailableReason ToStorageAccountNameUnavailableReason(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "AccountNameInvalid")) return StorageAccountNameUnavailableReason.AccountNameInvalid;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "AlreadyExists")) return StorageAccountNameUnavailableReason.AlreadyExists;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown StorageAccountNameUnavailableReason value.");
        }
    }
}
