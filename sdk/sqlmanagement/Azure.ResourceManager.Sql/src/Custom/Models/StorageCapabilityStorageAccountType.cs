// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql.Models
{
    public readonly partial struct StorageCapabilityStorageAccountType
    {
        /// <summary> GRS. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static StorageCapabilityStorageAccountType Grs => GRS;

        /// <summary> LRS. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static StorageCapabilityStorageAccountType Lrs => LRS;

        /// <summary> ZRS. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static StorageCapabilityStorageAccountType Zrs => ZRS;

        /// <summary> GZRS. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static StorageCapabilityStorageAccountType Gzrs => GZRS;
    }
}
