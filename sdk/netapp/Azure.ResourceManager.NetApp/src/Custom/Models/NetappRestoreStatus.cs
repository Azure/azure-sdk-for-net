// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Restore status. </summary>
    public partial class NetAppRestoreStatus
    {
        /// <summary> Gets or sets the relationship status. </summary>
        public virtual NetAppRelationshipStatus? RelationshipStatus
        {
            get => VolumeRestoreRelationshipStatus.HasValue
                ? new NetAppRelationshipStatus(VolumeRestoreRelationshipStatus.Value.ToString())
                : null;
        }
    }
}
