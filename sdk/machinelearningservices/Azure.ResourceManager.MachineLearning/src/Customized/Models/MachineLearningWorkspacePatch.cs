// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore shipped constructors/properties that latest TypeSpec generation normalized but cannot remove from the GA API surface.
    public partial class MachineLearningWorkspacePatch
    {
        /// <summary> Whether requests from Public Network are allowed. </summary>
        public MachineLearningPublicNetworkAccess? PublicNetworkAccess
        {
            get => PublicNetworkAccessType.HasValue ? new MachineLearningPublicNetworkAccess(PublicNetworkAccessType.Value.ToString()) : null;
            set => PublicNetworkAccessType = value.HasValue ? new PublicNetworkAccess(value.Value.ToString()) : null;
        }
    }
}
