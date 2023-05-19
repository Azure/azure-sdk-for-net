// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class GalleryTargetExtendedLocation
    {
        /// <summary> Specifies the storage account type to be used to store the image. This property is not updatable. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageStorageAccountType? StorageAccountType
        {
            get
            {
                return GalleryStorageAccountType.HasValue ? new ImageStorageAccountType(GalleryStorageAccountType.ToString()) : null;
            }
            set
            {
                if (value == null)
                {
                    GalleryStorageAccountType = null;
                }
                else
                {
                    GalleryStorageAccountType = new EdgeZoneStorageAccountType(value.ToString());
                }
            }
        }
    }
}
