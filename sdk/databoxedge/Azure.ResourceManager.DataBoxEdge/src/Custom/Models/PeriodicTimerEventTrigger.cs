// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat constructor overload for ApiCompat.
// The new generator safe-flattens DataBoxEdgeRoleSinkInfo (single-property wrapper)
// into a ResourceIdentifier parameter, changing the generated constructor signature
// from (PeriodicTimerSourceInfo, DataBoxEdgeRoleSinkInfo) to
// (PeriodicTimerSourceInfo, ResourceIdentifier). This overload preserves the old signature.

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
