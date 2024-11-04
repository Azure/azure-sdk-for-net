// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Models
{
    public partial class ManagedMaintenanceWindowStatus
    {
        /// <summary> Last window update time in UTC. </summary>
        ///
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? LastWindowStatusUpdatedOn { get => LastWindowStatusUpdateAtUTC; }

        /// <summary> Last window start time in UTC. </summary>
        ///
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? LastWindowStartOn { get => LastWindowStartTimeUTC; }

        /// <summary> Last window end time in UTC. </summary>
        ///
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? LastWindowEndOn { get => LastWindowEndTimeUTC; }
    }
}
