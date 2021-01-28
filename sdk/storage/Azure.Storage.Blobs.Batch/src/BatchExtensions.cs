// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Batch.Models;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.Batch
{
    internal static class BatchExtensions
    {
        // TODO
        public static BatchAccessTier ToBatchAccessTier(this AccessTier accessTier)
        {
            return BatchAccessTier.P10;
        }

        // TODO
        public static BatchRehydratePriority? ToBatchRehydratePriority(this RehydratePriority? rehydratePriority)
        {
            return null;
        }
    }
}
