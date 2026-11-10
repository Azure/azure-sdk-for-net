// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Collections.Generic;
using Azure.ResourceManager.RedisEnterprise.Models;

namespace Azure.ResourceManager.RedisEnterprise
{
    public partial class RedisEnterpriseClusterData
    {
        /// <summary>
        /// The complete set of firewall rules for an Azure Managed Redis cluster.
        /// On PUT, omitting this property, assigning null, or supplying an empty collection clears existing rules.
        /// With public network access enabled, an empty rule set allows all public source IPs.
        /// At most 250 rules are supported. Non-empty rules require public network access to be enabled.
        /// Disabling public network access also clears existing rules.
        /// Firewall rule changes cannot be combined with scaling or encryption changes in the same request.
        /// </summary>
        public IList<FirewallRule>? FirewallRules
        {
            get => (Properties ??= new ClusterCreateProperties(default)).FirewallRules;
            set => (Properties ??= new ClusterCreateProperties(default)).SetFirewallRules(value);
        }
    }
}
