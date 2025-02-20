// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.ComponentModel;

#nullable disable

namespace Azure.ResourceManager.ContainerService.Models
{
    /// <summary> Storage profile for the container service cluster. </summary>
    [CodeGenSuppress("IsEnabled")]
    public partial class ManagedClusterStorageProfile
    {
        /// <summary> Whether to enable AzureDisk CSI Driver. The default value is true. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsDiskCsiDriverEnabled
        {
            get => DiskCsiDriver is null ? default : DiskCsiDriver.IsEnabled;
            set
            {
                if (DiskCsiDriver is null)
                    DiskCsiDriver = new ManagedClusterStorageProfileDiskCsiDriver();
                DiskCsiDriver.IsEnabled = value;
            }
        }

        /// <summary> Whether to enable AzureFile CSI Driver. The default value is true. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsFileCsiDriverEnabled
        {
            get => FileCsiDriver is null ? default : FileCsiDriver.IsEnabled;
            set
            {
                if (FileCsiDriver is null)
                    FileCsiDriver = new ManagedClusterStorageProfileFileCsiDriver();
                FileCsiDriver.IsEnabled = value;
            }
        }

        /// <summary> Whether to enable Snapshot Controller. The default value is true. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsSnapshotControllerEnabled
        {
            get => SnapshotController is null ? default : SnapshotController.IsEnabled;
            set
            {
                if (SnapshotController is null)
                    SnapshotController = new ManagedClusterStorageProfileSnapshotController();
                SnapshotController.IsEnabled = value;
            }
        }

        /// <summary> Whether to enable AzureBlob CSI Driver. The default value is false. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsBlobCsiDriverEnabled
        {
            get => BlobCsiDriver is null ? default : BlobCsiDriver.IsEnabled;
            set
            {
                if (BlobCsiDriver is null)
                    BlobCsiDriver = new ManagedClusterStorageProfileBlobCsiDriver();
                BlobCsiDriver.IsEnabled = value;
            }
        }
    }
}
