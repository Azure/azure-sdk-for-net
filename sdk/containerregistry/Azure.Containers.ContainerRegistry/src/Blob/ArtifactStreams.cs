// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// </summary>
    public class ArtifactStreams
    {
        /// <summary>
        /// </summary>
        public Stream Manifest { get; set; }

        /// <summary>
        /// </summary>
        public Stream Config { get; set; }

        /// <summary>
        /// </summary>
        public IList<Stream> Layers { get; }
    }
}
