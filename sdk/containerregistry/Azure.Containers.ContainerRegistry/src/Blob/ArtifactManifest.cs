// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    [CodeGenModel("Manifest")]
    internal partial class ArtifactManifest
    {
        /// <summary> Media type for this Manifest. </summary>
        public string MediaType { get; set; }
    }
}
