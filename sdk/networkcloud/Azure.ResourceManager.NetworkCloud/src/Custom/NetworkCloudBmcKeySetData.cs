// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    /// <summary>
    /// A class representing the NetworkCloudBmcKeySet data model.
    /// BmcKeySet represents the baseboard management controller key set.
    /// </summary>
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
        public NetworkCloudBmcKeySetData(AzureLocation location, ExtendedLocation extendedLocation, string azureGroupId, DateTimeOffset expireOn, BmcKeySetPrivilegeLevel privilegeLevel, IEnumerable<KeySetUser> userList)
            : this(location, azureGroupId, expireOn, privilegeLevel, userList, extendedLocation)
        {
        }
    }
}
