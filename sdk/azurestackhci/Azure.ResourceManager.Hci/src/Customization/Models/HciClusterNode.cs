// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci.Models
{
    /// <summary> Cluster node details. </summary>
    public partial class HciClusterNode
    {
        /// <summary> Most recent licensing timestamp. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? LastLicensingTimestamp { get; }
    }
}
