// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudCloudServicesNetworkData
    {
        /// <summary> The extended location of the cluster associated with the resource. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get; set; }

        // Backward compat: old API required (location, extendedLocation) constructor.
        // New generated code removed the public constructor. Provide one for API compat.
        /// <summary> Initializes a new instance of <see cref="NetworkCloudCloudServicesNetworkData"/>. </summary>
        public NetworkCloudCloudServicesNetworkData(AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation)
            : base(location)
        {
            Argument.AssertNotNull(extendedLocation, nameof(extendedLocation));
            Properties = new CloudServicesNetworkProperties();
            ExtendedLocation = extendedLocation;
        }
    }
}
