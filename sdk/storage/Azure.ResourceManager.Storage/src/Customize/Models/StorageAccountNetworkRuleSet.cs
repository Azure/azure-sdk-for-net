// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds hidden aliases (IPRules, IPv6Rules) for renamed properties.

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageAccountNetworkRuleSet
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("ipRules")]
        public IList<StorageAccountIPRule> IPRules { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("ipv6Rules")]
        public IList<StorageAccountIPRule> IPv6Rules { get; }
    }
}
