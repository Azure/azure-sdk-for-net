// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Compatibility shim for the former backup properties model name. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class VolumeBackupProperties : NetAppVolumeBackupConfiguration
    {
    }
}
