// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs.Batch.Models;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.Batch
{
    internal static class BatchExtensions
    {
        public static BatchAccessTier ToBatchAccessTier(this AccessTier accessTier)
            => new BatchAccessTier(accessTier.ToString());

        public static BatchRehydratePriority? ToBatchRehydratePriority(this RehydratePriority? rehydratePriority)
        {
            if (rehydratePriority == null)
            {
                return null;
            }
            return new BatchRehydratePriority(rehydratePriority.ToString());
        }

        public static DeleteSnapshotsOptionType? ToDeleteSnapshotsOptionType(this DeleteSnapshotsOption deleteSnapshotsOption)
        {
            switch (deleteSnapshotsOption)
            {
                case DeleteSnapshotsOption.None:
                    return null;
                case DeleteSnapshotsOption.IncludeSnapshots:
                    return DeleteSnapshotsOptionType.Include;
                case DeleteSnapshotsOption.OnlySnapshots:
                    return DeleteSnapshotsOptionType.Only;
                default:
                    throw new ArgumentException($"Unknown {nameof(DeleteSnapshotsOption)} value: {deleteSnapshotsOption}");
            }
        }
    }
}
