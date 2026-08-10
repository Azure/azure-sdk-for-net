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
            BlobUri = blobUri;
        }

        // --- Multi-iteration repair test probe (cascading custom-code drift) ---
        // Intentionally broken so the auto-build-repair agent must iterate more than
        // once. Each reference below has a typo whose compiler error is HIDDEN by C#
        // error-type suppression until the line above it is fixed:
        //   Level1Typo_BlobUri -> BlobUri (Uri)
        //   Level2Typo_Host    -> Host    (string)   [hidden until L1 is fixed]
        //   Level3Typo_Length  -> Length  (int)      [hidden until L2 is fixed]
        // `var` is required so each variable inherits the error type from its
        // initializer, which is what suppresses the downstream diagnostic.
        internal int RepairCascadeProbe()
        {
            var uri = BlobUri;
            var host = uri.Host;
            return host.Length;
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
