// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Volume resource. </summary>
    public partial class NetAppVolumeGroupVolume
    {
        /// <summary> Restoring. </summary>
        public bool? IsRestoring { get; set; }
    }
}
