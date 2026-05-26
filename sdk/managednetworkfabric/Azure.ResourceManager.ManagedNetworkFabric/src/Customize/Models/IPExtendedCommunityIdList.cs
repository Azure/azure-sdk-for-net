// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // TypeSpec generates IpExtendedCommunityIdList, but the shipped SDK exposed IPExtendedCommunityIdList
    // and IPExtendedCommunityIds. Removing this customization would rename the public type/member and break callers.
    [CodeGenType("IpExtendedCommunityIdList")]
    public partial class IPExtendedCommunityIdList
    {
        /// <summary> Initializes a new instance of <see cref="IPExtendedCommunityIdList"/>. </summary>
        public IPExtendedCommunityIdList()
        {
            IpExtendedCommunityIds = new ChangeTrackingList<ResourceIdentifier>();
        }

        internal IPExtendedCommunityIdList(IList<ResourceIdentifier> ipExtendedCommunityIds)
        {
            IpExtendedCommunityIds = ipExtendedCommunityIds;
        }

        /// <summary> List of IP Extended Community resource IDs. </summary>
        public IList<ResourceIdentifier> IPExtendedCommunityIds => IpExtendedCommunityIds;
    }
}
