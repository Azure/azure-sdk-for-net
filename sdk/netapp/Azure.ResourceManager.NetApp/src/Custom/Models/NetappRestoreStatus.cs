// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Restore status. </summary>
    public partial class NetAppRestoreStatus
    {
        /// <summary> Status of the restore SnapMirror relationship. </summary>
        public NetAppRelationshipStatus? RelationshipStatus { get; }

        /// <summary> Gets or sets the IsHealthy property. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsHealthy => Healthy;
    }
}
