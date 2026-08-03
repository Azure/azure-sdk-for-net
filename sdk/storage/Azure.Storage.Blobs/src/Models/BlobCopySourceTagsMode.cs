// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Blob copy source tags mode.
    /// </summary>
    [CodeGenType("BlobCopySourceTags")]
    public enum BlobCopySourceTagsMode
    {
        /// <summary>
        /// Default.  The tags on the destination blob will be set to <see cref="BlobCopyFromUriOptions.Tags"/>.
        /// </summary>
        Replace,

        /// <summary>
        /// The tags on the source blob will be copied to the destination blob.
        /// Not compatible with <see cref="BlobCopyFromUriOptions.Tags"/>.
        /// </summary>
        Copy
    }
}
