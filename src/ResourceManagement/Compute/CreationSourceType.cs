// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    public enum CreationSourceType
    {
        /// <summary>
        /// Indicates that disk or snapshot is created from Os disk image of a virtual machine
        /// platform or virtual machine user image.
        /// </summary>
        FromOSDiskImage,
        /// <summary>
        /// Indicates that disk or snapshot is created from data disk image of a virtual machine
        /// platform or virtual machine user image.
        /// </summary>
        FromDataDiskImage,
        /// <summary>
        /// Indicates that disk or snapshot is created by importing a blob in a storage account.
        /// </summary>
        ImportedFromVHD,
        /// <summary>
        /// Indicates that disk or snapshot is created by copying a snapshot.
        /// </summary>
        CopiedFromSnapshot,
        /// <summary>
        /// Indicates that disk or snapshot is created by copying another managed disk.
        /// </summary>
        CopiedFromDisk,
        /// <summary>
        /// Indicates that disk or snapshot is created as empty disk.
        /// </summary>
        Empty,
        /// <summary>
        /// Unknown source.
        /// </summary>
        Unknown
    }
}
