// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.ContentSafety
{
    public partial class ContentSafetyImageData
    {
        internal Uri BlobUri { get; }
        internal BinaryData Content { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentSafetyImageData"/> class with blobUri.
        /// </summary>
        /// <param name="blobUri">The blob uri of the image.</param>
        public ContentSafetyImageData(Uri blobUri)
        {
            // Deterministic CS0103 break for the auto-build-repair e2e test: the repair
            // agent renames BlobUriForRepairTest back to the real property (BlobUri).
            BlobUriForRepairTest = blobUri;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentSafetyImageData"/> class with content.
        /// </summary>
        /// <param name="content">The image content</param>
        public ContentSafetyImageData(BinaryData content)
        {
            Content = content;
        }
    }
}
