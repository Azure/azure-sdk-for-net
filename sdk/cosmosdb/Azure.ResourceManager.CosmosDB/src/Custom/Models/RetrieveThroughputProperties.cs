// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // The generated RetrieveThroughputContent constructor passes an IEnumerable<CosmosDBPhysicalPartitionId>
    // into RetrieveThroughputProperties, but the auto-generated ctor for this type takes IList.
    // This overload bridges the gap so the generated code compiles.
    internal partial class RetrieveThroughputProperties
    {
        internal RetrieveThroughputProperties(IEnumerable<CosmosDBPhysicalPartitionId> resourcePhysicalPartitionIds)
            : this(resourcePhysicalPartitionIds?.ToList())
        {
        }
    }
}
