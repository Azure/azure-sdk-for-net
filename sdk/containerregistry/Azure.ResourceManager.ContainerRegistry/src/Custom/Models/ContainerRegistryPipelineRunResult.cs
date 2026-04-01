// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    // The old autorest SDK constructor returns an IReadOnlyList<string>, while the new TypeSpec SDK returns a List<string>
    public partial class ContainerRegistryPipelineRunResult
    {
        /// <summary> The artifacts imported in the pipeline run. </summary>
        [WirePath("importedArtifacts")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<string> ImportedArtifacts { get; }
    }
}
