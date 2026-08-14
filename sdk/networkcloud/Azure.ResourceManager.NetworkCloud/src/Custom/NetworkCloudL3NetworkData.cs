// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudL3NetworkData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkCloudL3NetworkData"/>. </summary>
        public NetworkCloudL3NetworkData(AzureLocation location, ExtendedLocation extendedLocation, ResourceIdentifier l3IsolationDomainId, long vlan)
            : base(location)
        {
            Argument.AssertNotNull(extendedLocation, nameof(extendedLocation));
            Argument.AssertNotNull(l3IsolationDomainId, nameof(l3IsolationDomainId));
            Properties = new L3NetworkProperties(l3IsolationDomainId, vlan);
            ExtendedLocation = extendedLocation;
        }

        /// <summary> The extended location of the cluster associated with the resource. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get; set; }
    }
}
