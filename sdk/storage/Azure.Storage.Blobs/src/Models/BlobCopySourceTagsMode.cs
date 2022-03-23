// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Blobs.Models
{
    /// <summary> The BlobCopySourceTags. </summary>
    [CodeGenModel("BlobCopySourceTags")]
    public enum BlobCopySourceTagsMode
    {
        /// <summary> REPLACE. </summary>
        Replace,
        /// <summary> COPY. </summary>
        Copy
    }
}
