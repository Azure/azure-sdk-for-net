// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Why: Baseline constructor took EdgeFileSourceInfo and DataBoxEdgeRoleSinkInfo wrapper types.
// New generator flattened these to ResourceIdentifier. This adds backward-compatible constructor overload.

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    public partial class EdgeFileEventTrigger
    {
        /// <summary> Initializes a new instance of <see cref="EdgeFileEventTrigger"/>. </summary>
        /// <param name="sourceInfo"> File event source details. </param>
        /// <param name="sinkInfo"> Compute role sink info. </param>
        public EdgeFileEventTrigger(EdgeFileSourceInfo sourceInfo, DataBoxEdgeRoleSinkInfo sinkInfo)
            : this(sourceInfo?.ShareId, sinkInfo?.RoleId)
        {
        }
    }
}
