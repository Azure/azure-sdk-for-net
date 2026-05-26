// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    public partial class ManagedClusterAutoScalerProfile
    {
        /// <summary> DaemonSet pods will be gracefully terminated from empty nodes. </summary>
        [WirePath("daemonset-eviction-for-empty-nodes")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? DaemonsetEvictionForEmptyNodes { get => IsDaemonsetEvictionForEmptyNodesEnabled; set => IsDaemonsetEvictionForEmptyNodesEnabled = value; }

        /// <summary> DaemonSet pods will be gracefully terminated from non-empty nodes. </summary>
        [WirePath("daemonset-eviction-for-occupied-nodes")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? DaemonsetEvictionForOccupiedNodes { get => IsDaemonsetEvictionForOccupiedNodesEnabled; set => IsDaemonsetEvictionForOccupiedNodesEnabled = value; }

        /// <summary> Should CA ignore DaemonSet pods when calculating resource utilization for scaling down. </summary>
        [WirePath("ignore-daemonsets-utilization")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IgnoreDaemonsetsUtilization { get => IsDaemonsetsUtilizationIgnored; set => IsDaemonsetsUtilizationIgnored = value; }
    }
}
