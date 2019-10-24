// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.Specialized
{
    /// <summary>
    /// Defines the batch operations supported by Storage.
    /// </summary>
    internal enum BlobBatchOperationType
    {
        Delete,
        SetAccessTier
    }
}
