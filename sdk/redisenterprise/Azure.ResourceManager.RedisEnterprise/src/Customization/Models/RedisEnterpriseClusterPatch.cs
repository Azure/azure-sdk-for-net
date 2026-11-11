// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.RedisEnterprise.Models
{
    public partial class RedisEnterpriseClusterPatch
    {
        /// <summary>
        /// The complete set of firewall rules for an Azure Managed Redis cluster.
        /// On PATCH, omitting this property preserves existing rules unless public network access is disabled.
        /// Assigning null or an empty collection clears all rules; a non-empty collection replaces all rules.
        /// With public network access enabled, an empty rule set allows all public source IPs.
        /// At most 250 rules are supported. Non-empty rules require public network access to be enabled.
        /// Firewall rule changes cannot be combined with scaling or encryption changes in the same request.
        /// </summary>
        public IList<FirewallRule> FirewallRules
        {
            get => (Properties ??= new ClusterUpdateProperties()).FirewallRules;
            set => (Properties ??= new ClusterUpdateProperties()).SetFirewallRules(value);
        }
    }
}
