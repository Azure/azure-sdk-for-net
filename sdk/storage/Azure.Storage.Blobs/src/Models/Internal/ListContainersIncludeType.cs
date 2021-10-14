// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// The ListContainersIncludeType.
    /// </summary>
    internal enum ListContainersIncludeType
    {
        /// <summary>
        /// metadata.
        /// </summary>
        Metadata,

        /// <summary>
        /// deleted.
        /// </summary>
        Deleted,

        /// <summary>
        /// system.
        /// </summary>
        System
    }
}
