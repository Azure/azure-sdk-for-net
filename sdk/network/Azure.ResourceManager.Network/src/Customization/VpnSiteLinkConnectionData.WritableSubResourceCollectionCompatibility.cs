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
    /// <summary> Compatibility declaration for the VpnSiteLinkConnectionData type. </summary>
    [CodeGenSuppress("EgressNatRules")]
    [CodeGenSuppress("IngressNatRules")]
    public partial class VpnSiteLinkConnectionData
    {
        /// <summary> Gets or sets the EgressNatRules compatibility property. </summary>
        [WirePath("properties.egressNatRules")]
        public IList<WritableSubResource> EgressNatRules => WritableSubResourceCollectionCompatibility.AsList(Properties?.EgressNatRules);
        /// <summary> Gets or sets the IngressNatRules compatibility property. </summary>
        [WirePath("properties.ingressNatRules")]
        public IList<WritableSubResource> IngressNatRules => WritableSubResourceCollectionCompatibility.AsList(Properties?.IngressNatRules);
    }
}
