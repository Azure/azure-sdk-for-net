// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// </summary>
    public class UploadManifestResult
    {
        internal UploadManifestResult(string digest)
        {
            Digest = digest;
        }

        /// <summary>
        /// </summary>
        public string Digest { get; }
    }
}
