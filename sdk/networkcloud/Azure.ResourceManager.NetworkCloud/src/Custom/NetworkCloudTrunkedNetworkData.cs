// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetworkCloud
{
    // Backward compat: The old Swagger/AutoRest API used a constructor with the local
    // ExtendedLocation type. The new TypeSpec-generated code uses the ARM common
    // ExtendedLocation type. This file suppresses the generated constructor and provides
    // one accepting the local ExtendedLocation type to avoid breaking existing consumers.
    [CodeGenSuppress("NetworkCloudTrunkedNetworkData", typeof(AzureLocation), typeof(IEnumerable<ResourceIdentifier>), typeof(IEnumerable<long>), typeof(ExtendedLocation))]
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
