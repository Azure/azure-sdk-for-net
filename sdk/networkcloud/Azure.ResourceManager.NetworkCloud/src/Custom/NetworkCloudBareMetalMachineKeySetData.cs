// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudBareMetalMachineKeySetData
    {
        /// <summary> The name of the group that users will be assigned to on the operating system of the machines. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string OSGroupName
        {
            get => OsGroupName;
            set => OsGroupName = value;
        }

        // Backward compat: old API had ExtendedLocation as 2nd parameter; new API has it last.
        /// <summary> Initializes a new instance of <see cref="NetworkCloudBareMetalMachineKeySetData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkCloudBareMetalMachineKeySetData(AzureLocation location, ExtendedLocation extendedLocation, string azureGroupId, DateTimeOffset expireOn, IEnumerable<IPAddress> jumpHostsAllowed, BareMetalMachineKeySetPrivilegeLevel privilegeLevel, IEnumerable<KeySetUser> userList)
            : this(location, azureGroupId, expireOn, jumpHostsAllowed, privilegeLevel, userList, extendedLocation) { }
    }
}
