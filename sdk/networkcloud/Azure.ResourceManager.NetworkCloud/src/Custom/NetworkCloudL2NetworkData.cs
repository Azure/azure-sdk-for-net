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
    [CodeGenSuppress("NetworkCloudL2NetworkData", typeof(AzureLocation), typeof(ResourceIdentifier), typeof(ExtendedLocation))]
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
