// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

#nullable disable

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    /// <summary> Storage profile for the container service cluster. </summary>
    [CodeGenSuppress("IsEnabled")]
    public partial class ManagedClusterStorageProfile
    {
        /// <summary> Whether to enable AzureDisk CSI Driver. The default value is true. </summary>
        public bool? IsDiskCsiDriverEnabled
        {
            get => DiskCsiDriver is null ? default : DiskCsiDriver.IsDiskCsiDriverEnabled;
            set
            {
                if (DiskCsiDriver is null)
                    DiskCsiDriver = new ManagedClusterStorageProfileDiskCsiDriver();
                DiskCsiDriver.IsDiskCsiDriverEnabled = value;
            }
        }

        /// <summary> Whether to enable AzureFile CSI Driver. The default value is true. </summary>
        public bool? IsFileCsiDriverEnabled
        {
            get => FileCsiDriver is null ? default : FileCsiDriver.IsFileCsiDriverEnabled;
            set
            {
                if (FileCsiDriver is null)
                    FileCsiDriver = new ManagedClusterStorageProfileFileCsiDriver();
                FileCsiDriver.IsFileCsiDriverEnabled = value;
            }
        }

        /// <summary> Whether to enable Snapshot Controller. The default value is true. </summary>
        public bool? IsSnapshotControllerEnabled
        {
            get => SnapshotController is null ? default : SnapshotController.IsSnapshotControllerEnabled;
            set
            {
                if (SnapshotController is null)
                    SnapshotController = new ManagedClusterStorageProfileSnapshotController();
                SnapshotController.IsSnapshotControllerEnabled = value;
            }
        }

        /// <summary> Whether to enable AzureBlob CSI Driver. The default value is false. </summary>
        public bool? IsBlobCsiDriverEnabled
        {
            get => BlobCsiDriver is null ? default : BlobCsiDriver.IsBlobCsiDriverEnabled;
            set
            {
                if (BlobCsiDriver is null)
                    BlobCsiDriver = new ManagedClusterStorageProfileBlobCsiDriver();
                BlobCsiDriver.IsBlobCsiDriverEnabled = value;
            }
        }
    }
}
