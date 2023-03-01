// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Azure.Core;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeBackupConfiguration
    {
        public ResourceIdentifier VaultId { get; set; }

        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal NetAppVolumeBackupConfiguration(ResourceIdentifier backupPolicyId, bool? isPolicyEnforced, ResourceIdentifier vaultId, bool? isBackupEnabled)
        {
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
