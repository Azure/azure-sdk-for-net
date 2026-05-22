// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    [CodeGenType("IpCommunityIdList")]
    public partial class IPCommunityIdList
    {
        /// <summary> Initializes a new instance of <see cref="IPCommunityIdList"/>. </summary>
        public IPCommunityIdList()
        {
            IPCommunityIds = new ChangeTrackingList<ResourceIdentifier>();
        }

        internal IPCommunityIdList(IList<ResourceIdentifier> ipCommunityIds)
        {
            IPCommunityIds = ipCommunityIds;
        }

        /// <summary> List of IP Community resource IDs. </summary>
        public IList<ResourceIdentifier> IPCommunityIds { get; internal set; }
    }
}
