// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// </summary>
    [CodeGenModel("OCIManifest")]
    public partial class OciManifest
    {
        /// <summary>
        /// </summary>
        /// <param name="config"></param>
        /// <param name="layers"></param>
        public OciManifest(ArtifactBlobDescriptor config, IReadOnlyList<ArtifactBlobDescriptor> layers)
        {
            Config = config;
            Layers = layers;
        }

        /// <summary> Additional information provided through arbitrary metadata. </summary>
        internal Annotations Annotations { get; }
    }
}
