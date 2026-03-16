// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudVolumeData
    {
        /// <summary> The size of the allocation for this volume in Mebibytes. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? AllocatedInSizeMiB => AllocatedSizeMiB;
    }
}
