// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the P2SConnectionConfiguration type. </summary>
    public partial class P2SConnectionConfiguration : NetworkResourceData
    {
        /// <summary> Compatibility member. </summary>
        public IList<string> VpnClientAddressPrefixes { get; } = new List<string>();

        /// <summary> Gets or sets the RoutingConfiguration compatibility property. </summary>
        public RoutingConfiguration RoutingConfiguration { get; set; }

        /// <summary> Gets a read-only view of the configuration policy groups. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use ConfigurationPolicyGroups instead.")]
        public IReadOnlyList<WritableSubResource> ConfigurationPolicyGroupAssociations => new ReadOnlyCollection<WritableSubResource>(ConfigurationPolicyGroups);
    }
}
