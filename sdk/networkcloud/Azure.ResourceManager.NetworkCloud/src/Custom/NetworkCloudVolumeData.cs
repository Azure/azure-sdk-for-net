// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetworkCloud
{
    [CodeGenSuppress("NetworkCloudVolumeData", typeof(AzureLocation), typeof(long), typeof(ExtendedLocation))]
    public partial class NetworkCloudVolumeData
    {
        // Backward compat: AllocatedInSizeMiB was flattened in old autorest code but not in new generator.

        /// <summary> The size of the allocation for this volume in Mebibytes. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? AllocatedInSizeMiB => Properties?.AllocatedInSizeMiB;

        /// <summary> Initializes a new instance of <see cref="NetworkCloudVolumeData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="sizeInMiB"> The size of the volume in Mebibytes. </param>
        public NetworkCloudVolumeData(AzureLocation location, ExtendedLocation extendedLocation, long sizeInMiB)
            : base(location)
        {
            Argument.AssertNotNull(extendedLocation, nameof(extendedLocation));
            Properties = new VolumeProperties(sizeInMiB);
            ExtendedLocation = extendedLocation;
        }

        /// <summary> The extended location of the cluster associated with the resource. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get; set; }
    }
}
