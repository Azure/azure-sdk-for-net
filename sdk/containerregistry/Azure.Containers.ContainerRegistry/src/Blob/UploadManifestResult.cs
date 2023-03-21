// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// The result from uploading a manifest.
    /// </summary>
    public class UploadManifestResult
    {
        internal UploadManifestResult(string digest)
        {
            Digest = digest;
        }

        /// <summary>
        /// The digest of the uploaded manifest, calculated by the registry.
        /// </summary>
        public string Digest { get; }
    }
}
