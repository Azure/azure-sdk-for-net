// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.RedisEnterprise.Models
{
    internal partial class ClusterProperties
    {
        private IList<FirewallRule> _firewallRules = new ChangeTrackingList<FirewallRule>();

        // Generated compatibility factories pass null for rules absent from the released API.
        // Keep those rules undefined rather than serializing an empty array that clears them.
        public IList<FirewallRule> FirewallRules
        {
            get => _firewallRules;
            private set => _firewallRules = value ?? new ChangeTrackingList<FirewallRule>();
        }
    }
}
