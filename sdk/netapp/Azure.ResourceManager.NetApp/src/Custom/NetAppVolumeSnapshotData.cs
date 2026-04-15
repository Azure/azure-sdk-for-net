// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp
{
    /// <summary> Backward-compat shims for NetAppVolumeSnapshotData. </summary>
    public partial class NetAppVolumeSnapshotData
    {
        /// <summary> Initializes a new instance of <see cref="NetAppVolumeSnapshotData"/>. </summary>
        /// <param name="location"> Resource location. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppVolumeSnapshotData(AzureLocation location) : this(location.ToString())
        {
        }
    }
}
