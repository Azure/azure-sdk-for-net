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
    /// <summary> Compatibility declaration for the ApplicationGatewayWafDynamicManifestData type. </summary>
    [CodeGenSuppress("AvailableRuleSets")]
    public partial class ApplicationGatewayWafDynamicManifestData
    {
        /// <summary> Gets or sets the AvailableRuleSets compatibility property. </summary>
        public IReadOnlyList<Models.ApplicationGatewayFirewallManifestRuleSet> AvailableRuleSets => Properties?.AvailableRuleSets as IReadOnlyList<Models.ApplicationGatewayFirewallManifestRuleSet>;
    }
}
