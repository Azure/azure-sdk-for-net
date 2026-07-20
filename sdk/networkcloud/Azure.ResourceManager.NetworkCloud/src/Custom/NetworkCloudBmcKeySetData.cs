// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetworkCloud.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudBmcKeySetData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkCloudBmcKeySetData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="azureGroupId"> The object ID of Azure Active Directory group that all users in the list must be in for access to be granted. Users that are not in the group will not have access. </param>
        /// <param name="expireOn"> The date and time after which the users in this key set will be removed from the baseboard management controllers. </param>
        /// <param name="privilegeLevel"> The access level allowed for the users in this key set. </param>
        /// <param name="userList"> The unique list of permitted users. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="extendedLocation"/>, <paramref name="azureGroupId"/> or <paramref name="userList"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkCloudBmcKeySetData(AzureLocation location, ExtendedLocation extendedLocation, string azureGroupId, DateTimeOffset expireOn, BmcKeySetPrivilegeLevel privilegeLevel, IEnumerable<KeySetUser> userList) : base(location)
        {
            Argument.AssertNotNull(azureGroupId, nameof(azureGroupId));
            Argument.AssertNotNull(userList, nameof(userList));
            Argument.AssertNotNull(extendedLocation, nameof(extendedLocation));

            Properties = new BmcKeySetProperties(azureGroupId, expireOn, privilegeLevel, userList);
            ExtendedLocation = extendedLocation;
        }

        /// <summary> The extended location of the cluster associated with the resource. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get; set; }
    }
}
