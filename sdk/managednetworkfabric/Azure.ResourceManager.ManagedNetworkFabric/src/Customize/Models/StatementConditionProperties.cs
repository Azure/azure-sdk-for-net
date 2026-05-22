// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> Route policy statement condition properties. </summary>
    public partial class StatementConditionProperties
    {
        /// <summary> List of IP Extended Community resource IDs. </summary>
        public IList<ResourceIdentifier> IPExtendedCommunityIds => IpExtendedCommunityIds;

        /// <summary> ARM Resource Id of IpPrefix. </summary>
        public ResourceIdentifier IPPrefixId
        {
            get => IpPrefixId;
            set => IpPrefixId = value;
        }
    }
}
