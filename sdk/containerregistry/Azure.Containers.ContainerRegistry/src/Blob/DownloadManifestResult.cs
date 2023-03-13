// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// The result from downloading an OCI manifest from the registry.
    /// </summary>
    public class DownloadManifestResult
    {
        internal DownloadManifestResult(string digest, ManifestMediaType mediaType, BinaryData content)
        {
            Digest = digest;
            MediaType = mediaType;
            Content = content;
        }

        /// <summary>
        /// The manifest's digest, calculated by the registry.
        /// </summary>
        public string Digest { get; }

        /// <summary>
        /// Gets the media type of the downloaded manifest, as indicated by the
        /// Content-Type response header.
        /// </summary>
        public ManifestMediaType MediaType { get; }

        /// <summary>
        /// The serialized content that was downloaded.
        /// </summary>
        public BinaryData Content { get; }

        /// <summary>
        /// Gets the downloaded manifest as an OciImageManifest.
        /// </summary>
        /// <returns></returns>
        public OciImageManifest AsOciManifest()
        {
            return OciImageManifest.DeserializeOciImageManifest(JsonDocument.Parse(Content).RootElement);
        }
    }
}
