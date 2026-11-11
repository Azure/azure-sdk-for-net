// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Infomation about a blob's legal hold.
    /// </summary>
    public class BlobLegalHoldResult
    {
        /// <summary>
        /// If a legal hold is enabled on the blob.
        /// </summary>
        public bool HasLegalHold { get; internal set; }

        /// <summary>
        /// The request priority the service applied to this request.
        /// </summary>
        public int? EffectiveRequestPriority { get; internal set; }
    }
}
