// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// </summary>
    public class ManifestDownloadResult
    {
        internal ManifestDownloadResult(Stream content, IReadOnlyList<ArtifactLayerProperties> layers)
        {
            Content = content;
            Layers = layers;
        }

        /// <summary>
        /// </summary>
        public Stream Content { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<ArtifactLayerProperties> Layers { get; }
    }
}
