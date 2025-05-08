// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Volume resource. </summary>
    [CodeGenSerialization(nameof(IsRestoring), "isRestoring")]
    public partial class NetAppVolumeGroupVolume
    {
        /// <summary> Restoring. ReadOnly property indicating if volume is being resored </summary>
        public bool? IsRestoring
        {
            get;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set;
        }
    }
}
