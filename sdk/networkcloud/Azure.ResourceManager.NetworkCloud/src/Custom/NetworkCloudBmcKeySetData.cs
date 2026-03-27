// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
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
    [CodeGenSuppress("NetworkCloudBmcKeySetData", typeof(AzureLocation), typeof(string), typeof(DateTimeOffset), typeof(BmcKeySetPrivilegeLevel), typeof(IEnumerable<KeySetUser>), typeof(ExtendedLocation))]
    public partial class NetworkCloudBmcKeySetData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkCloudBmcKeySetData"/>. </summary>
        public NetworkCloudBmcKeySetData(AzureLocation location, ExtendedLocation extendedLocation, string azureGroupId, DateTimeOffset expireOn, BmcKeySetPrivilegeLevel privilegeLevel, IEnumerable<KeySetUser> userList)
            : base(location)
        {
            Argument.AssertNotNull(extendedLocation, nameof(extendedLocation));
            Argument.AssertNotNull(azureGroupId, nameof(azureGroupId));
            Argument.AssertNotNull(userList, nameof(userList));
            Properties = new BmcKeySetProperties(azureGroupId, expireOn, privilegeLevel, userList);
            ExtendedLocation = extendedLocation;
        }

        /// <summary> The extended location of the cluster associated with the resource. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get; set; }
    }
}
