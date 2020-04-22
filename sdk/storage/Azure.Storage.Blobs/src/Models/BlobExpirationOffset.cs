// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Enum to specify when a blob's ExpiriesOn time should be relative
    /// to.
    /// </summary>
    public enum BlobExpirationOffset
    {
        /// <summary>
        /// Blob's ExpiriesOn property should be set relative to
        /// the blob CreatedOn time.
        /// </summary>
        CreationTime,

        /// <summary>
        /// Blob's ExpiriesOn property should be set relative to
        /// the current time.
        /// </summary>
        Now
    }
}
