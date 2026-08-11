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
            // Intentionally broken (CS0103): references a property name that does not exist
            // so the auto-build-repair agent has a deterministic, single-iteration break to
            // repair end-to-end. The agent should rename this back to the real property BlobUri.
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
