// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// The result of a get manifest operation.
    /// </summary>
    public class GetManifestResult
    {
        internal GetManifestResult(string digest, ManifestMediaType mediaType, BinaryData manifest)
        {
            Digest = digest;
            MediaType = mediaType;
            Manifest = manifest;
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
        /// The manifest JSON.
        /// </summary>
        public BinaryData Manifest { get; }
    }
}
