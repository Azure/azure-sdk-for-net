// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds hidden aliases (IPRules, IPv6Rules) for renamed properties.
// Could use @@clientName in spec but would lose improved names.

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageAccountNetworkRuleSet
    {
        /// <summary> Backward-compatible alias for IpRules. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("ipRules")]
        public IList<StorageAccountIPRule> IPRules => IpRules;

        /// <summary> Backward-compatible alias for Ipv6Rules. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("ipv6Rules")]
        public IList<StorageAccountIPRule> IPv6Rules => Ipv6Rules;
    }
}
