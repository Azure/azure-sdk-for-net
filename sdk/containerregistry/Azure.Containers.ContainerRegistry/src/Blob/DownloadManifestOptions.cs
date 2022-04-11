// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// Options for configuring the download manifest operation.
    /// </summary>
    public class DownloadManifestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadManifestOptions"/> class.
        /// </summary>
        /// <param name="tag">Tag of the manifest.</param>
        /// <param name="digest">Digest of the manifest.</param>
        public DownloadManifestOptions(string tag = null, string digest = null)
        {
            if (tag == null && digest == null)
                throw new ArgumentException("Exactly one of tag or digest must be specified.");
            if (tag != null && digest != null)
                throw new ArgumentException("Exactly one of tag or digest must be specified.");

            Tag = tag;
            Digest = digest;
        }

        /// <summary>
        /// Tag identifier of the manifest.
        /// </summary>
        public string Tag { get; }

        /// <summary>
        /// Digest identifier of the manifest.
        /// </summary>
        public string Digest { get; }
    }
}
