// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        /// <param name="mediaType"></param>
        public DownloadManifestOptions(ManifestMediaType mediaType = default)
        {
            // Set default to Docker Manifest V2 format.
            if (mediaType == default)
            {
                mediaType = ManifestMediaType.DockerManifestV2;
            }

            MediaType = mediaType;
        }

        /// <summary>
        /// Manifest media type.
        /// </summary>
        public ManifestMediaType MediaType { get; }
    }
}
