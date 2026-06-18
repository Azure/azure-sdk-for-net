// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the WebApplicationFirewallPolicyData type. </summary>
    [CodeGenSuppress("ApplicationGatewayForContainers")]
    public partial class WebApplicationFirewallPolicyData
    {
        /// <summary> Gets or sets the ApplicationGatewayForContainers compatibility property. </summary>
        public IReadOnlyList<SubResource> ApplicationGatewayForContainers => default;
    }
}
