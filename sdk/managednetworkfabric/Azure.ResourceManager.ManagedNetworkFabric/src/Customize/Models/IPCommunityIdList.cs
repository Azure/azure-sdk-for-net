// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // TypeSpec generates IpCommunityIdList, but the shipped SDK exposed IPCommunityIdList and
    // IPCommunityIds. Removing this customization would rename the public type/member and break callers.
    [CodeGenType("IpCommunityIdList")]
    public partial class IPCommunityIdList
    {
        /// <summary> Initializes a new instance of <see cref="IPCommunityIdList"/>. </summary>
        public IPCommunityIdList()
        {
            IpCommunityIds = new ChangeTrackingList<ResourceIdentifier>();
        }

        internal IPCommunityIdList(IList<ResourceIdentifier> ipCommunityIds)
        {
            IpCommunityIds = ipCommunityIds;
        }

        /// <summary> List of IP Community resource IDs. </summary>
        public IList<ResourceIdentifier> IPCommunityIds => IpCommunityIds;
    }
}
