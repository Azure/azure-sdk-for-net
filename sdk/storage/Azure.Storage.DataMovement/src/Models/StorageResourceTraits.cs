// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement.Models
{
    /// <summary>
    /// Specifies trait information to be included when listing storage resources.
    /// operations.
    /// </summary>
    [Flags]
    public enum StorageResourceTraits
    {
        /// <summary>
        /// Flag specifying only the default information for blobs
        /// should be included.
        ///
        /// Applies only to Blobs
        /// </summary>
        None = 0,

        /// <summary>
        /// Flag specifying that metadata related to any current
        /// or previous copy operation should be included.
        ///
        /// Applies only to Blobs
        /// </summary>
        CopyStatus = 1,

        /// <summary>
        /// Flag specifying that the blob's metadata should be
        /// included.
        ///
        /// Applies only to Blobs
        /// </summary>
        Metadata = 2,

        /// <summary>
        /// Flag specifying that the blob's tags should be included.
        ///
        /// Applies only to Blobs
        /// </summary>
        Tags = 4,

        /// <summary>
        /// Flag specifying that the blob's immutibility policy should be included.
        ///
        /// Applies only to Blobs
        /// </summary>
        ImmutabilityPolicy = 8,

        /// <summary>
        /// Flag specifying that the blob's legal hold should be included.
        ///
        /// Applies only to Blobs
        /// </summary>
        LegalHold = 16,

        /// <summary>
        /// Flag specifying that all traits should be included.
        ///
        /// APplies only to Blobs
        /// </summary>
        All = ~None
    }
}
