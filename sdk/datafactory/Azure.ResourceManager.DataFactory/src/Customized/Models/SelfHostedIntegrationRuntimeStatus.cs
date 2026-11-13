// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.DataFactory.Models
{
    // Restores the public Nodes/Links read-only properties that the GA package exposed but the MPG
    // generator no longer emits. Generator bug: https://github.com/Azure/azure-sdk-for-net/issues/59298
    // TODO: remove once the generator emits these properties.
    public partial class SelfHostedIntegrationRuntimeStatus
    {
        /// <summary> The list of nodes for this integration runtime. </summary>
        public IReadOnlyList<SelfHostedIntegrationRuntimeNode> Nodes { get; }

        /// <summary> The list of linked integration runtimes that are created to share with this integration runtime. </summary>
        public IReadOnlyList<LinkedIntegrationRuntime> Links { get; }
    }
}
