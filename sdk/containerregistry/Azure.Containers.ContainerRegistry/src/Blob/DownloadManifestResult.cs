// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// The result from downloading an OCI manifest from the registry.
    /// </summary>
    public class DownloadManifestResult
    {
        internal DownloadManifestResult(string digest, OciManifest manifest)
        {
            Digest = digest;
            Manifest = manifest;
        }

        /// <summary>
        /// The manifest's digest, calculated by the registry.
        /// </summary>
        public string Digest { get; }

        /// <summary>
        /// The OCI manifest that was downloaded.
        /// </summary>
        public OciManifest Manifest { get; }
    }
}
