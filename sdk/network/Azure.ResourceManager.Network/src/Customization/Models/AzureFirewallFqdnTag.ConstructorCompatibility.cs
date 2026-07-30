// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the AzureFirewallFqdnTag type. </summary>
    [CodeGenSuppress("AzureFirewallFqdnTag")]
    public partial class AzureFirewallFqdnTag
    {
        /// <summary> Initializes a new instance of the AzureFirewallFqdnTag class. </summary>
        public AzureFirewallFqdnTag()
        {
        }
    }
}
