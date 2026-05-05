// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class GalleryTargetExtendedLocation
    {
        // Customization: the previously-shipped surface exposed two storage-account-type properties:
        // - GalleryStorageAccountType (EdgeZoneStorageAccountType) — restored via @@clientName rename
        //   of the new generated `storageAccountType` enum property.
        // - StorageAccountType (ImageStorageAccountType) — a legacy holdover. Both enums share their
        //   primary string values (Standard_LRS, Standard_ZRS, Premium_LRS), so this shim bridges
        //   them through the underlying string representation.
        /// <summary> Specifies the storage account type to be used to store the image. This property is not updatable. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageStorageAccountType? StorageAccountType
        {
            get => GalleryStorageAccountType?.ToString();
            set => GalleryStorageAccountType = value?.ToString();
        }
    }
}
