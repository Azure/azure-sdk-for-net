// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudL2NetworkData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkCloudL2NetworkData"/>. </summary>
        public NetworkCloudL2NetworkData(AzureLocation location, ExtendedLocation extendedLocation, ResourceIdentifier l2IsolationDomainId)
            : base(location)
        {
            Argument.AssertNotNull(extendedLocation, nameof(extendedLocation));
            Argument.AssertNotNull(l2IsolationDomainId, nameof(l2IsolationDomainId));
            Properties = new L2NetworkProperties(l2IsolationDomainId);
            ExtendedLocation = extendedLocation;
        }

        /// <summary> The extended location of the cluster associated with the resource. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get; set; }
    }
}
