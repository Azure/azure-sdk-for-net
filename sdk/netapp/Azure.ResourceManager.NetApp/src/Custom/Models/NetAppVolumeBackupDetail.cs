// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeBackupDetail
    {
        /// <summary> Policy enabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsPolicyEnabled => PolicyEnabled;
    }
}
