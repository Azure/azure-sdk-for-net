// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// The result from downloading an OCI manifest from the registry.
    /// </summary>
    public class DownloadManifestResult : IDisposable
    {
        internal DownloadManifestResult(string digest, OciManifest manifest, Stream manifestStream)
        {
            Digest = digest;
            Manifest = manifest;
            ManifestStream = manifestStream;
        }

        /// <summary>
        /// The manifest's digest, calculated by the registry.
        /// </summary>
        public string Digest { get; }

        /// <summary>
        /// The OCI manifest that was downloaded.
        /// </summary>
        public OciManifest Manifest { get; }

        /// <summary>
        /// The manifest stream that was downloaded.
        /// </summary>
        public Stream ManifestStream { get; }

        /// <summary>
        /// Disposes the <see cref="DownloadManifestResult"/> by calling <c>Dispose()</c> on the underlying <see cref="ManifestStream"/> stream.
        /// </summary>
        public void Dispose()
        {
            ManifestStream?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
