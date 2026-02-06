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
        /// <summary> Status of the backup mirror relationship. </summary>
        public NetAppRelationshipStatus? RelationshipStatus { get; }

        /// <summary> Gets or sets the IsHealthy property. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsHealthy => Healthy;
    }
}
