// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudVolumeData
    {
        // Backward compat: AllocatedInSizeMiB was flattened in old autorest code but not in new generator.

        /// <summary> The size of the allocation for this volume in Mebibytes. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? AllocatedInSizeMiB => Properties?.AllocatedInSizeMiB;

        // Backward compat: old API had ExtendedLocation as 2nd parameter; new API has it last.
        /// <summary> Initializes a new instance of <see cref="NetworkCloudVolumeData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkCloudVolumeData(AzureLocation location, ExtendedLocation extendedLocation, long sizeInMiB)
            : this(location, sizeInMiB, extendedLocation) { }
    }
}
