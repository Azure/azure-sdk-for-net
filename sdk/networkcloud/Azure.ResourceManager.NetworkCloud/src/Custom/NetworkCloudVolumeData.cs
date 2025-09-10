// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    /// <summary>
    /// A class representing the NetworkCloudVolume data model.
    /// Volume represents storage made available for use by resources running on the cluster.
    /// </summary>
    public partial class NetworkCloudVolumeData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkCloudVolumeData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="sizeInMiB"> The size of the allocation for this volume in Mebibytes. </param>

        /// <exception cref="ArgumentNullException"> <paramref name="extendedLocation"/> is null. </exception>
        public NetworkCloudVolumeData(AzureLocation location, ExtendedLocation extendedLocation, long sizeInMiB)
            : this(location, sizeInMiB, extendedLocation)
        {
        }
    }
}