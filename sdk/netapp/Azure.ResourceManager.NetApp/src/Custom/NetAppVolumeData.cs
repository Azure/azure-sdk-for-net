// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp
{
    /// <summary>
    /// A class representing the NetAppVolume data model.
    /// Volume resource
    /// </summary>
    [CodeGenSerialization(nameof(IsRestoring), "isRestoring")]
    public partial class NetAppVolumeData : TrackedResourceData
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
