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
        internal DownloadManifestResult(Stream content, IReadOnlyList<ArtifactBlobProperties> artifactFiles)
        {
            Content = content;
            ArtifactFiles = artifactFiles;
        }

        /// <summary>
        /// </summary>
        public Stream Content { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<ArtifactBlobProperties> ArtifactFiles { get; }
    }
}
