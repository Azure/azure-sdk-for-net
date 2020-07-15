// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Linq;

    /// <summary>
    /// A disk to encrypt.
    /// </summary>
    public enum DiskEncryptionTarget
    {
        /// <summary>
        /// The OS Disk on the compute node is encrypted.
        /// </summary>
        OsDisk,

        /// <summary>
        /// The temporary disk on the compute node is encrypted. On Linux this encryption applies to other partitions (such as those on mounted data disks) when encryption occurs at boot time.
        /// </summary>
        TemporaryDisk,
    }
}
