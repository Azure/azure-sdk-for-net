// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable CS0612, CS0618, CS1591

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    [CodeGenSuppress("HttpListeners")]
    [CodeGenSuppress("PathBasedRules")]
    public partial class WebApplicationFirewallPolicyData
    {
        [WirePath("properties.httpListeners")] public IReadOnlyList<WritableSubResource> HttpListeners => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.HttpListeners);
        [WirePath("properties.pathBasedRules")] public IReadOnlyList<WritableSubResource> PathBasedRules => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.PathBasedRules);
    }
}

#pragma warning restore CS0612, CS0618, CS1591
