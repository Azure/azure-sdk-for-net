// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System;
using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
   /// <summary> Backup status. </summary>
   public partial class NetAppVolumeBackupStatus
     {
        /// <summary> Gets or sets the relationship status. </summary>
        public virtual NetAppRelationshipStatus? RelationshipStatus
        {
            get => VolumeBackupRelationshipStatus.HasValue
                ? new NetAppRelationshipStatus(VolumeBackupRelationshipStatus.Value.ToString())
                : null;
        }
    }
}
