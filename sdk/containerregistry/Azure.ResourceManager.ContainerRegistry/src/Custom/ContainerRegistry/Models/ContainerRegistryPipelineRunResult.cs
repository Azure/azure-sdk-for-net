// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerRegistry.Models
{
    public partial class ContainerRegistryPipelineRunResult
    {
        /// <summary> The artifacts imported in the pipeline run. </summary>
        [WirePath("importedArtifacts")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<string> ImportedArtifacts { get; }
    }
}
