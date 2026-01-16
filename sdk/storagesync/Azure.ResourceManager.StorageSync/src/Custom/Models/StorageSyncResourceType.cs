// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.StorageSync.Models
{
    /// <summary> The resource type. Must be set to Microsoft.StorageSync/storageSyncServices. </summary>
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenType("StorageSyncResourceType")]
    public readonly partial struct StorageSyncResourceType
    {
        /// <summary> Gets the Microsoft_StorageSync_StorageSyncServices. </summary>
        public static StorageSyncResourceType Microsoft_StorageSync_StorageSyncServices { get; } = new StorageSyncResourceType(MicrosoftStorageSyncStorageSyncServicesValue);
    }
}
