// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Storage.Blobs.ChangeFeed
{
    /// <summary>
    /// Blob tags that were updated as part of the change feed event.
    /// </summary>
    public class BlobTagsChange
    {
        internal BlobTagsChange() { }

        /// <summary>
        /// Previous Tags.
        /// </summary>
        public Dictionary<string, string> OldTags { get; internal set; }

        /// <summary>
        /// New Tags.
        /// </summary>
        public Dictionary<string, string> NewTags { get; internal set; }
    }
}
