// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Options for configuring the behavior of <see cref="ShareChangeFeedClient"/>.
    /// </summary>
    public class ShareChangeFeedClientOptions
    {
        /// <summary>
        /// The maximum size, in bytes, for a single blob download transfer when reading change feed segments.
        /// If not set, the default transfer size is used.
        /// </summary>
        public long? MaximumTransferSize { get; set; }
    }
}
