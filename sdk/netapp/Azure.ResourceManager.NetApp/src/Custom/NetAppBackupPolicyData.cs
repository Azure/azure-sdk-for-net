// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp
{
    /// <summary>
    /// A class representing the NetAppBackupPolicy data model.
    /// </summary>
    public partial class NetAppBackupPolicyData : TrackedResourceData
    {
        // TODO: 'Enabled' property no longer exists on this standalone class after TypeSpec migration.
        // The Generated equivalent is BackupPolicyData which has 'Enabled' via Properties wrapper.
        // /// <summary> Policy is enabled or not. </summary>
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // public bool? IsEnabled
        // {
        //     get => Enabled;
        //     set => Enabled = value;
        // }
    }
}
