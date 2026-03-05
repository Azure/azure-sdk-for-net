// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp
{
    /// <summary>
    /// Backward-compatible wrapper for volume collection operations.
    /// This type is deprecated. Use <see cref="VolumeCollection"/> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class NetAppVolumeCollection : ArmCollection
    {
        /// <summary> Initializes a new instance of <see cref="NetAppVolumeCollection"/>. </summary>
        protected NetAppVolumeCollection()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetAppVolumeCollection"/>. </summary>
        internal NetAppVolumeCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }
    }
}
