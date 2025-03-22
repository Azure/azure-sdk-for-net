// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class RoutingConfigurationValidationData
    {
        public string Description { get; set; }

        public string Name { get; set; }

        public List<RoutingRuleValidationData> RoutingRules { get; set; } = new List<RoutingRuleValidationData>();

        public List<RoutingRuleCollectionValidationData> RoutingRuleCollections { get; set; } = new List<RoutingRuleCollectionValidationData>();
    }

#pragma warning disable SA1402 // File may only contain a single type
    public class RoutingRuleValidationData
#pragma warning restore SA1402 // File may only contain a single type
    {
        public string Name { get; set; }

        public string DestinationAddress { get; set; }

        public RoutingRuleDestinationType DestinationType { get; set; }

        public string NextHopAddress { get; set; }

        public RoutingRuleNextHopType NextHopType { get; set; }
    }

#pragma warning disable SA1402 // File may only contain a single type
    public class RoutingRuleCollectionValidationData
#pragma warning restore SA1402 // File may only contain a single type
    {
        public string Description { get; set; }

        public string Name { get; set; }

        public DisableBgpRoutePropagation DisableBgpRoutePropagation { get; set; }

        public List<NetworkManagerRoutingGroupItem> AppliesTo { get; set; } = new List<NetworkManagerRoutingGroupItem>();
    }
}
