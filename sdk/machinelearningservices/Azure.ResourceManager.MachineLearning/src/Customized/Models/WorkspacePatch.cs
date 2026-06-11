// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore the legacy flattened public network property; @@clientName does not affect this generated flattened property name.
    [CodeGenType("WorkspaceUpdateParameters")]
    public partial class WorkspacePatch
    {
        /// <summary> Whether requests from Public Network are allowed. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public PublicNetworkAccess? PublicNetworkAccess { get; set; }
    }
}
