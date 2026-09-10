// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the IPGroupData type. </summary>
    [CodeGenSuppress("FirewallPolicies")]
    [CodeGenSuppress("Firewalls")]
    public partial class IPGroupData
    {
        /// <summary> Gets or sets the FirewallPolicies compatibility property. </summary>
        [WirePath("properties.firewallPolicies")]
        public IReadOnlyList<WritableSubResource> FirewallPolicies => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.FirewallPolicies);
        /// <summary> Gets or sets the Firewalls compatibility property. </summary>
        [WirePath("properties.firewalls")]
        public IReadOnlyList<WritableSubResource> Firewalls => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.Firewalls);
    }
}
