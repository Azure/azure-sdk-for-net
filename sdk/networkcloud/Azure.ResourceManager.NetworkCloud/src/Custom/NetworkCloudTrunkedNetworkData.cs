// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudTrunkedNetworkData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkCloudTrunkedNetworkData"/>. </summary>
        public NetworkCloudTrunkedNetworkData(AzureLocation location, ExtendedLocation extendedLocation, IEnumerable<ResourceIdentifier> isolationDomainIds, IEnumerable<long> vlans)
            : base(location)
        {
            Argument.AssertNotNull(extendedLocation, nameof(extendedLocation));
            Argument.AssertNotNull(isolationDomainIds, nameof(isolationDomainIds));
            Argument.AssertNotNull(vlans, nameof(vlans));
            Properties = new TrunkedNetworkProperties(isolationDomainIds, vlans);
            ExtendedLocation = extendedLocation;
        }

        /// <summary> The extended location of the cluster associated with the resource. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get; set; }
    }
}
