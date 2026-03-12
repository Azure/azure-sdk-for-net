// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage
{
    public partial class ObjectReplicationPolicyData
    {
        /// <summary> Backward-compatible alias for MetricsEnabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsMetricsEnabled
        {
            get => MetricsEnabled;
            set => MetricsEnabled = value;
        }

        /// <summary> Backward-compatible alias for PriorityReplicationEnabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsPriorityReplicationEnabled
        {
            get => PriorityReplicationEnabled;
            set => PriorityReplicationEnabled = value;
        }
    }
}
