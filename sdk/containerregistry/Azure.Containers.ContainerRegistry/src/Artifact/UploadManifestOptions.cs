// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// </summary>
    public class UploadManifestOptions
    {
        /// <summary>
        /// </summary>
        /// <param name="mediaType"></param>
        public UploadManifestOptions(ManifestMediaType mediaType = default)
        {
            // Set default to Docker Manifest V2 format.
            if (mediaType == default)
            {
                mediaType = ManifestMediaType.DockerManifestV2;
            }

            MediaType = mediaType;
        }

        /// <summary>
        /// </summary>
        //public string MediaType { get; set; }
        public ManifestMediaType MediaType { get; }
    }
}
