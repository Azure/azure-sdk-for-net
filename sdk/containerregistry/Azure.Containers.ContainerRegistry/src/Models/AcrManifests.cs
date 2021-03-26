// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> Manifest attributes. </summary>
    internal partial class AcrManifests
    {
        /// <summary> List of manifests. </summary>
        [CodeGenMember("Manifests")]
        public IReadOnlyList<RegistryArtifactProperties> RegistryArtifacts { get; }
    }
}
