// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetworkCloud
{
    // Customization: Suppresses the generated constructor (which uses ARM common ExtendedLocation)
    // and provides a custom constructor accepting the local ExtendedLocation type.
    // Also exposes a local ExtendedLocation property for backward compatibility.
    [CodeGenSuppress("NetworkCloudBareMetalMachineKeySetData", typeof(AzureLocation), typeof(string), typeof(DateTimeOffset), typeof(IEnumerable<IPAddress>), typeof(BareMetalMachineKeySetPrivilegeLevel), typeof(IEnumerable<KeySetUser>), typeof(ExtendedLocation))]
    public partial class NetworkCloudBareMetalMachineKeySetData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkCloudBareMetalMachineKeySetData"/>. </summary>
        public NetworkCloudBareMetalMachineKeySetData(AzureLocation location, ExtendedLocation extendedLocation, string azureGroupId, DateTimeOffset expireOn, IEnumerable<IPAddress> jumpHostsAllowed, BareMetalMachineKeySetPrivilegeLevel privilegeLevel, IEnumerable<KeySetUser> userList)
            : base(location)
        {
            Argument.AssertNotNull(extendedLocation, nameof(extendedLocation));
            Argument.AssertNotNull(azureGroupId, nameof(azureGroupId));
            Argument.AssertNotNull(jumpHostsAllowed, nameof(jumpHostsAllowed));
            Argument.AssertNotNull(userList, nameof(userList));
            Properties = new BareMetalMachineKeySetProperties(azureGroupId, expireOn, jumpHostsAllowed, privilegeLevel, userList);
            ExtendedLocation = extendedLocation;
        }

        /// <summary> The extended location of the cluster associated with the resource. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get; set; }
    }
}
