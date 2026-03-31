// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Why: Baseline constructor took DataBoxEdgeRoleSinkInfo wrapper type.
// New generator flattened it to ResourceIdentifier. This adds backward-compatible constructor overload.

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    public partial class PeriodicTimerEventTrigger
    {
        /// <summary> Initializes a new instance of <see cref="PeriodicTimerEventTrigger"/>. </summary>
        /// <param name="sourceInfo"> Periodic timer details. </param>
        /// <param name="sinkInfo"> Compute role sink info. </param>
        public PeriodicTimerEventTrigger(PeriodicTimerSourceInfo sourceInfo, DataBoxEdgeRoleSinkInfo sinkInfo)
            : this(sourceInfo, sinkInfo?.RoleId)
        {
        }
    }
}
