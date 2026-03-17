// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudRackData
    {
        // Backward compat: old API had ExtendedLocation as 2nd parameter; new API has it last.
        /// <summary> Initializes a new instance of <see cref="NetworkCloudRackData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkCloudRackData(AzureLocation location, ExtendedLocation extendedLocation, string availabilityZone, string rackLocation, string rackSerialNumber, ResourceIdentifier rackSkuId)
            : this(location, availabilityZone, rackLocation, rackSerialNumber, rackSkuId, extendedLocation) { }
    }
}
