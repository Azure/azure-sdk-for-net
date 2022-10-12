// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// Options for tuning the artifact download operation.
    /// </summary>
    public class ArtifactDownloadToOptions
    {
        /// <summary>
        /// The maximum number of concurrent worker tasks to use during download.
        /// </summary>
        public int? MaxConcurrency { get; set; }

        /// <summary>
        /// The maximum individual chunk size to request when downloading artifact layers.
        /// </summary>
        public long? MaxDownloadSize { get; set; }
    }
}
