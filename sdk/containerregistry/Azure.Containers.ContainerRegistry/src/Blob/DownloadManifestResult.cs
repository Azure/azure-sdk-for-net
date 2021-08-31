// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// </summary>
    public class DownloadManifestResult
    {
        internal DownloadManifestResult(string digest, ManifestMediaType mediaType, Stream content, IReadOnlyList<ArtifactBlobProperties> artifactFiles)
        {
            Content = content;
            MediaType = mediaType;
            Digest = digest;
            ArtifactFiles = artifactFiles;
        }

        /// <summary>
        /// </summary>
        public string Digest { get; }

        /// <summary>
        /// </summary>
        public ManifestMediaType MediaType { get; }

        /// <summary>
        /// </summary>
        public Stream Content { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<ArtifactBlobProperties> ArtifactFiles { get; }
    }
}
