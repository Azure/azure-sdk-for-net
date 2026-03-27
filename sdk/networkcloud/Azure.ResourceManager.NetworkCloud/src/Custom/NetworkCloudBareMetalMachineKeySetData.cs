// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetworkCloud
{
    // Backward compat: The old Swagger/AutoRest API used a constructor with the local
    // ExtendedLocation type and exposed OSGroupName as a flat property. The new TypeSpec-
    // generated code uses the ARM common ExtendedLocation type and nests OSGroupName under
    // Properties. This file suppresses the generated constructor and preserves the old API
    // surface to avoid breaking existing consumers.
    [CodeGenSuppress("NetworkCloudBareMetalMachineKeySetData", typeof(AzureLocation), typeof(string), typeof(DateTimeOffset), typeof(IEnumerable<IPAddress>), typeof(BareMetalMachineKeySetPrivilegeLevel), typeof(IEnumerable<KeySetUser>), typeof(ExtendedLocation))]
    public partial class NetworkCloudBareMetalMachineKeySetData
    {
        /// <summary> The name of the group that users will be assigned to on the operating system of the machines. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string OSGroupName
        {
            get => Properties?.OSGroupName;
            set
            {
                if (Properties is null)
                    Properties = new Models.BareMetalMachineKeySetProperties();
                Properties.OSGroupName = value;
            }
        }

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
