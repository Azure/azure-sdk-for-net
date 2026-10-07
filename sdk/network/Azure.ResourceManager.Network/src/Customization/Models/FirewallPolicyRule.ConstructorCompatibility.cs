// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the FirewallPolicyRule type. </summary>
    [CodeGenSuppress("FirewallPolicyRule")]
    public abstract partial class FirewallPolicyRule
    {
        /// <summary> Initializes a new instance of the FirewallPolicyRule class. </summary>
        protected FirewallPolicyRule()
        {
        }
    }
}
