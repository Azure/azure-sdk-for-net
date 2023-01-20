// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// The result from downloading an OCI manifest from the registry.
    /// </summary>
    public class DownloadManifestResult
    {
        internal DownloadManifestResult(string digest, OciManifest manifest, BinaryData content)
        {
            Digest = digest;
            Manifest = manifest;
            Content = content;
        }

        /// <summary>
        /// The manifest's digest, calculated by the registry.
        /// </summary>
        public string Digest { get; }

        /// <summary>
        /// The OCI manifest that was downloaded.
        /// </summary>
        public ArtifactManifest Manifest { get; }

        /// <summary>
        /// The serialized content that was downloaded.
        /// </summary>
        public BinaryData Content { get; }
    }
}
