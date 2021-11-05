// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlobType values.
    /// </summary>
    public enum BlobType
    {
        /// <summary>
        /// BlockBlob
        /// </summary>
        [CodeGenMember("BlockBlob")]
        Block,

        /// <summary>
        /// PageBlob
        /// </summary>
        [CodeGenMember("PageBlob")]
        Page,

        /// <summary>
        /// AppendBlob
        /// </summary>
        [CodeGenMember("AppendBlob")]
        Append
    }
}
