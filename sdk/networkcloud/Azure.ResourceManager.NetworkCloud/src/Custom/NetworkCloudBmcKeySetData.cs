// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudBmcKeySetData
    {
        // Backward compat: old API had ExtendedLocation as 2nd parameter; new API has it last.
        /// <summary> Initializes a new instance of <see cref="NetworkCloudBmcKeySetData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkCloudBmcKeySetData(AzureLocation location, ExtendedLocation extendedLocation, string azureGroupId, DateTimeOffset expireOn, BmcKeySetPrivilegeLevel privilegeLevel, IEnumerable<KeySetUser> userList)
            : this(location, azureGroupId, expireOn, privilegeLevel, userList, extendedLocation) { }
    }
}
