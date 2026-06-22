// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: map the generated WorkspaceUpdateParameters model so the generated update operation
    // can coexist with GA MachineLearningWorkspacePatch compatibility overloads.
    [CodeGenType("WorkspaceUpdateParameters")]
    public partial class WorkspacePatch
    {
        /// <summary> Whether requests from Public Network are allowed. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public PublicNetworkAccess? PublicNetworkAccess { get; set; }
    }
}
