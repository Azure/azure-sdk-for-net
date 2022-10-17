// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Containers.ContainerRegistry
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class ArtifactUploadOptions
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        /// <summary>
        /// The maximum number of concurrent worker tasks to use during upload.
        /// </summary>
        public int? MaxConcurrency { get; set; }

        /// <summary>
        /// The maximum individual chunk size to send when uploading artifact layers.
        /// </summary>
        public long? MaxUploadSize { get; set; }
    }
}
