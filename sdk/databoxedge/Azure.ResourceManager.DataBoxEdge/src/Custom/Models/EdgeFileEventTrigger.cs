// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

// Backward-compat constructor overload for ApiCompat.
// The new generator safe-flattens EdgeFileSourceInfo and DataBoxEdgeRoleSinkInfo
// (single-property wrappers) into ResourceIdentifier parameters, changing the
// generated constructor signature from (EdgeFileSourceInfo, DataBoxEdgeRoleSinkInfo)
// to (ResourceIdentifier, ResourceIdentifier). This overload preserves the old signature.

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    public partial class EdgeFileEventTrigger
    {
        /// <summary> Initializes a new instance of <see cref="EdgeFileEventTrigger"/>. </summary>
        /// <param name="sourceInfo"> File event source details. </param>
        /// <param name="sinkInfo"> Compute role sink info. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EdgeFileEventTrigger(EdgeFileSourceInfo sourceInfo, DataBoxEdgeRoleSinkInfo sinkInfo)
            : this(sourceInfo?.ShareId, sinkInfo?.RoleId)
        {
        }
    }
}
