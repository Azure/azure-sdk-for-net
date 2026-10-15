// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class ImageDisk
    {
        // Preserve the non-virtual flattened properties shipped in Compute 1.18.0 while
        // keeping the underlying ComputeWriteableSubResourceData.Id virtual for GA compatibility.
        // Remove these forwarding compatibility members when the next major version permits it.
        /// <summary> Resource Id. </summary>
        public ResourceIdentifier SnapshotId
        {
            get
            {
                return Snapshot is null ? default : Snapshot.Id;
            }
            set
            {
                Snapshot = new ComputeWriteableSubResourceData(value);
            }
        }

        /// <summary> Resource Id. </summary>
        public ResourceIdentifier ManagedDiskId
        {
            get
            {
                return ManagedDisk is null ? default : ManagedDisk.Id;
            }
            set
            {
                ManagedDisk = new ComputeWriteableSubResourceData(value);
            }
        }

        /// <summary> Resource Id. </summary>
        public ResourceIdentifier DiskEncryptionSetId
        {
            get
            {
                return DiskEncryptionSet is null ? default : DiskEncryptionSet.Id;
            }
            set
            {
                DiskEncryptionSet = new DiskEncryptionSetParameters(value);
            }
        }
    }
}
