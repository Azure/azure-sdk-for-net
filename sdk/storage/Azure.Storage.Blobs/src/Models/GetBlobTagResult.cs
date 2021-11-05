// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// The result of BlobBaseClient.GetTags() call.
    /// </summary>
    public class GetBlobTagResult
    {
        /// <summary>
        /// Blob Tags.
        /// </summary>
        public Tags Tags { get; internal set; }
    }
}
