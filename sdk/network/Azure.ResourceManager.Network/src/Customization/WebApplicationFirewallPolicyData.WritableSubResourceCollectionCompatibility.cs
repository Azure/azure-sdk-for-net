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
    /// <summary> Compatibility declaration for the WebApplicationFirewallPolicyData type. </summary>
    [CodeGenSuppress("HttpListeners")]
    [CodeGenSuppress("PathBasedRules")]
    public partial class WebApplicationFirewallPolicyData
    {
        /// <summary> Gets or sets the HttpListeners compatibility property. </summary>
        [WirePath("properties.httpListeners")]
        public IReadOnlyList<WritableSubResource> HttpListeners => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.HttpListeners);
        /// <summary> Gets or sets the PathBasedRules compatibility property. </summary>
        [WirePath("properties.pathBasedRules")]
        public IReadOnlyList<WritableSubResource> PathBasedRules => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.PathBasedRules);
    }
}
