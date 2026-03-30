// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    // Backward compat: The old Swagger/AutoRest API exposed an ExtendedLocation property using
    // the local model type and a constructor accepting it. The new TypeSpec-generated code uses
    // the ARM common ExtendedLocation type. This file preserves the old constructor and property
    // to avoid breaking existing consumers.
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
