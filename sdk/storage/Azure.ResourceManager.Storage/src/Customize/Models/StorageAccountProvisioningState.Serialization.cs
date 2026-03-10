// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    internal static partial class StorageAccountProvisioningStateExtensions
    {
        /// <param name="value"> The value to serialize. </param>
        public static string ToSerialString(this StorageAccountProvisioningState value) => value.ToString();

        /// <param name="value"> The value to deserialize. </param>
        public static StorageAccountProvisioningState ToStorageAccountProvisioningState(this string value)
        {
            return new StorageAccountProvisioningState(value);
        }
    }
}
