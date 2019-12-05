// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Files.Shares.Models
{
    public static partial class ShareModelFactory
    {
        /// <summary>
        /// Creates a new StorageClosedHandlesSegment instance for mocking.
        /// </summary>
        public static StorageClosedHandlesSegment StorageClosedHandlesSegment(
            string marker,
            int numberOfHandlesClosed)
            => StorageClosedHandlesSegment(
                marker: marker,
                numberOfHandlesClosed: numberOfHandlesClosed,
                numberOfHandlesFailedToClosed: 0);

        /// <summary>
        /// Creates a new ShareProperties instance for mocking.
        /// </summary>
        public static ShareProperties ShareProperties(
            DateTimeOffset? lastModified = default,
            ETag? eTag = default,
            int? quotaInGB = default,
            IDictionary<string, string> metadata = null)
            => ShareProperties(
                lastModified: lastModified,
                eTag: eTag,
                quotaInGB: quotaInGB,
                metadata: metadata);
    }
}
