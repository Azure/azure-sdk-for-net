// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Volume Backup Properties. </summary>
    public partial class NetAppVolumeBackupConfiguration
    {
        /// <summary> Vault Resource ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier VaultId { get; set; }
    }
}
