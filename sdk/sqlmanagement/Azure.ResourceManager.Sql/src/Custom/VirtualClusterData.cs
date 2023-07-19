// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Sql
{
    /// <summary> A class representing the VirtualCluster data model. </summary>
    public partial class VirtualClusterData
    {
        /// <summary> If the service has different generations of hardware, for the same SKU, then that can be captured here. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Family { get; set; }
        /// <summary> Specifies maintenance configuration id to apply to this virtual cluster. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier MaintenanceConfigurationId { get; set; }
    }
}
