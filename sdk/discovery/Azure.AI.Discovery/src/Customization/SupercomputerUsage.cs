// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.Discovery
{
    public partial class SupercomputerUsage
    {
        /// <summary> Node pool utilization for each node pool for a supercomputer. </summary>
        [CodeGenMember("Nodepools")]
        public IDictionary<string, NodePoolUsage> NodePools { get; }
    }
}
