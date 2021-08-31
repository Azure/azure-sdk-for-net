// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// </summary>
    public class DownloadManifestOptions
    {
        /// <summary>
        /// </summary>
        public ManifestMediaType MediaType { get; set; } = ManifestMediaType.OciManifest;
    }
}
