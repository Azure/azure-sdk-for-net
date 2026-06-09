// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.DataFactory.Models
{
    public partial class SelfHostedIntegrationRuntimeStatus
    {
        /// <summary> The list of nodes for this integration runtime. </summary>
        public IReadOnlyList<SelfHostedIntegrationRuntimeNode> Nodes { get; }

        /// <summary> The list of linked integration runtimes that are created to share with this integration runtime. </summary>
        public IReadOnlyList<LinkedIntegrationRuntime> Links { get; }
    }
}
