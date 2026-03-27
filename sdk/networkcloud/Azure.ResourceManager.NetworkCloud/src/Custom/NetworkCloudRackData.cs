// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetworkCloud
{
    // Backward compat: The old Swagger/AutoRest API used a constructor with the local
    // ExtendedLocation type. The new TypeSpec-generated code uses the ARM common
    // ExtendedLocation type. This file suppresses the generated constructor and provides
    // one accepting the local ExtendedLocation type to avoid breaking existing consumers.
    [CodeGenSuppress("NetworkCloudRackData", typeof(AzureLocation), typeof(string), typeof(string), typeof(string), typeof(ResourceIdentifier), typeof(ExtendedLocation))]
    public partial class NetworkCloudRackData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkCloudRackData"/>. </summary>
        public NetworkCloudRackData(AzureLocation location, ExtendedLocation extendedLocation, string availabilityZone, string rackLocation, string rackSerialNumber, ResourceIdentifier rackSkuId)
            : base(location)
        {
            Argument.AssertNotNull(extendedLocation, nameof(extendedLocation));
            Argument.AssertNotNull(availabilityZone, nameof(availabilityZone));
            Argument.AssertNotNull(rackLocation, nameof(rackLocation));
            Argument.AssertNotNull(rackSerialNumber, nameof(rackSerialNumber));
            Argument.AssertNotNull(rackSkuId, nameof(rackSkuId));
            Properties = new RackProperties(availabilityZone, rackLocation, rackSerialNumber, rackSkuId);
            ExtendedLocation = extendedLocation;
        }

        /// <summary> The extended location of the cluster associated with the resource. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get; set; }
    }
}
