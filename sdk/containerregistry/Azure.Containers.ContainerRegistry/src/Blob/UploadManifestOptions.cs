// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// Options for configuring the upload manifest operation.
    /// </summary>
    public class UploadManifestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UploadManifestOptions"/> class.
        /// </summary>
        /// <param name="tag">Tag of the manifest.</param>
        public UploadManifestOptions(string tag = null)
        {
            Tag = tag;
        }

        /// <summary>
        /// A tag to assign to the artifact represented by this manifest.
        /// </summary>
        public string Tag { get; }
    }
}
