// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    /// <summary>
    /// The caching type for an OS disk. For information about the caching options see: https://blogs.msdn.microsoft.com/windowsazurestorage/2012/06/27/exploring-windows-azure-drives-disks-and-images/
    /// </summary>
    public enum CachingType
    {
        /// <summary>
        /// No caching is enabled.
        /// </summary>
        None,

        /// <summary>
        /// The caching mode for the disk is read only.
        /// </summary>
        ReadOnly,

        /// <summary>
        /// The caching mode for the disk is read/write.
        /// </summary>
        ReadWrite
    }
}
